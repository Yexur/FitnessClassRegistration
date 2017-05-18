using System.Threading.Tasks;
using FitnessClassRegistration.Logic;
using FitnessClassRegistration.Models.ApplicationViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessClassRegistration.Controllers
{
    [Authorize]
    public class FitnessClassTypesController : Controller
    {
        private readonly IFitnessClassTypeLogic _fitnessClassTypeLogic;

        public FitnessClassTypesController(IFitnessClassTypeLogic fitnessClassTypeLogic)
        {
            _fitnessClassTypeLogic = fitnessClassTypeLogic;
        }

        // GET: FitnessClassTypes
        [Authorize(Roles = "FitnessAppAdmin")]
        public async Task<IActionResult> Index()
        {
            return View(await _fitnessClassTypeLogic.GetList());
        }

        // GET: FitnessClassTypes/Create
        [Authorize(Roles = "FitnessAppAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: FitnessClassTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "FitnessAppAdmin")]
        public async Task<IActionResult> Create(
            [Bind("Id, Name, Status")] FitnessClassTypeView fitnessClassType
        )
        {
            if (ModelState.IsValid)
            {
                await _fitnessClassTypeLogic.Save(fitnessClassType);
                return RedirectToAction("Index");
            }
            return View(fitnessClassType);
        }

        // GET: FitnessClassTypes/Edit/5
        [Authorize(Roles = "FitnessAppAdmin")]
        public IActionResult Edit(int id)
        {
            var fitnessClassType = _fitnessClassTypeLogic.FindById(id);
            if (fitnessClassType == null)
            {
                return NotFound();
            }
            return View(fitnessClassType);
        }

        // POST: FitnessClassTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "FitnessAppAdmin")]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id,Name,Status")] FitnessClassTypeView fitnessClassType
        )
        {
            if (id != fitnessClassType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _fitnessClassTypeLogic.Save(fitnessClassType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_fitnessClassTypeLogic.FitnessClassTypeExists(fitnessClassType.Id))
                    {
                        return NotFound();
                    } else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(fitnessClassType);
        }
    }
}
