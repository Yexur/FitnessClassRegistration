using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FitnessApp.Logic;
using Microsoft.EntityFrameworkCore;
using FitnessApp.Models.ApplicationViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace FitnessApp.Controllers
{
    [Authorize]
    public class FitnessClassesController : Controller
    {
        private readonly IFitnessClassLogic _fitnessClassLogic;
        private readonly IRegistrationRecordLogic _registrationRecordLogic;

        public FitnessClassesController(
            IFitnessClassLogic fitnessClassLogic,
            IRegistrationRecordLogic registrationRecordLogic)
        {
            _fitnessClassLogic = fitnessClassLogic;
            _registrationRecordLogic = registrationRecordLogic;
        }

        // GET: FitnessClasses
        [Authorize(Roles = "FitnessAppAdmin")]
        public async Task<IActionResult> Index()
        {
            return View(await _fitnessClassLogic.GetList());
        }

        // GET: Available FitnessClasses
        public async Task<IActionResult> SignUp()
        {
            return View(await _fitnessClassLogic.GetAvailableClasses(User.Identity.Name));
        }

        //POST: FitnessClasses/SignUp
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(string[] attendingSelected)
        {
            try
            {
                var fitnessClassIds = attendingSelected.Select(int.Parse).ToArray();
                await _registrationRecordLogic.SaveRange(fitnessClassIds, User.Identity.Name);
            }
            catch (DbUpdateConcurrencyException) // need to change this to be less specific
            {
                throw;
            }

            return View(await _fitnessClassLogic.GetAvailableClasses(User.Identity.Name));
        }

        // GET: FitnessClasses/Create
        [Authorize(Roles = "FitnessAppAdmin")]
        public async Task<IActionResult> Create()
        {
            return View(await _fitnessClassLogic.Create());
        }

        // POST: FitnessClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "FitnessAppAdmin")]
        public async Task<IActionResult> Create(
            [Bind("Id, StartTime, EndTime, DateOfClass, Status, Capacity, FitnessClassType_Id, Instructor_Id, Location_Id")]
            FitnessClassEditView fitnessClass
        )
        {
            if (ModelState.IsValid)
            {
                await _fitnessClassLogic.Save(fitnessClass);
                return RedirectToAction("Index");
            } else
            {
                fitnessClass.FitnessClassTypes = await _fitnessClassLogic.GetFitnessClassTypes();
                fitnessClass.Locations = await _fitnessClassLogic.GetLocations();
                fitnessClass.Instructors = await _fitnessClassLogic.GetInstructors();
            }
            return View(fitnessClass);
        }

        // GET: FitnessClasses/Edit/5
        [Authorize(Roles = "FitnessAppAdmin")]
        public async Task<IActionResult> Edit(int id)
        {
            var fitnessClass = await _fitnessClassLogic.FindById(id);

            if (fitnessClass == null)
            {
                return NotFound();
            }
            return View(fitnessClass);
        }

        // POST: FitnessClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "FitnessAppAdmin")]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id, StartTime, EndTime, DateOfClass, Status, Capacity, FitnessClassType_Id, Instructor_Id, Location_Id")]
            FitnessClassEditView fitnessClass
        )
        {
            if (id != fitnessClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _fitnessClassLogic.Save(fitnessClass);
                }
                catch (DbUpdateConcurrencyException) // need to change this to be less specific
                {
                    if (!_fitnessClassLogic.FitnessClassExists(fitnessClass.Id))
                    {
                        return NotFound();
                    } else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            } else
            {
                fitnessClass.FitnessClassTypes = await _fitnessClassLogic.GetFitnessClassTypes();
                fitnessClass.Locations = await _fitnessClassLogic.GetLocations();
                fitnessClass.Instructors = await _fitnessClassLogic.GetInstructors();
            }
            return View(fitnessClass);
        }

        // GET: FitnessClasses/Delete/5
        [Authorize(Roles = "FitnessAppAdmin")]
        public IActionResult Delete(int id)
        {
            var fitnessClass = _fitnessClassLogic.FindByIdForDelete(id);

            if (fitnessClass == null)
            {
                return NotFound();
            }
            return View(fitnessClass);
        }

        // POST: FitnessClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "FitnessAppAdmin")]
        public IActionResult DeleteConfirmed(int id)
        {
            _fitnessClassLogic.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
