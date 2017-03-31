using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using FitnessApp.Logic;

namespace FitnessApp.Controllers
{
    [Authorize]
    public class RegistrationRecordsController : Controller
    {
        private readonly IRegistrationRecordLogic _registrationRecordLogic;
        private readonly IFitnessClassLogic _fitnessClassLogic;

        public RegistrationRecordsController(
            IRegistrationRecordLogic registrationRecordLogic,
            IFitnessClassLogic fitnessClassLogic
        )
        {
            _registrationRecordLogic = registrationRecordLogic;
            _fitnessClassLogic = fitnessClassLogic;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _fitnessClassLogic.GetFitnessClassWithRegistrations());
        }

        public async Task<IActionResult> RegistrationsByFitnessClass(int id)
        {
            var regs = await _registrationRecordLogic.FindByFitnessClassId(id);
            return View(regs);
        }

        // GET: RegistrationRecords
        public async Task<IActionResult> RegistrationIndex()
        {
            return View(await _registrationRecordLogic.FindByUserName(User.Identity.Name));
        }

        //POST: RegistrationRecords/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrationIndex(string[] deleteSelected)
        {
            try
            {
                var registrationRecordIds = deleteSelected.Select(int.Parse).ToArray();
                _registrationRecordLogic.DeleteRange(registrationRecordIds, User.Identity.Name);
            }
            catch (DbUpdateConcurrencyException) // need to change this to be less specific
            {
                throw;
            }

            return View(await _registrationRecordLogic.FindByUserName(User.Identity.Name));
        }
    }

}
