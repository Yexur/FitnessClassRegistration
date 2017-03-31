using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitnessApp.Logic;
using FitnessApp.Models.ApplicationViewModels;
using Microsoft.AspNetCore.Authorization;

namespace FitnessApp.Controllers
{
    [Authorize]
    public class InstructorsController : Controller
    {
        private readonly IInstructorLogic _instructorLogic;

        public InstructorsController(IInstructorLogic instructorLogic)
        {
            _instructorLogic = instructorLogic;
        }

        // GET: Instructors
        [Authorize(Roles = "FitnessAppAdmin")]
        public async Task<IActionResult> Index()
        {
            return View(await _instructorLogic.GetList());
        }

        // GET: Instructors/Create
        [Authorize(Roles = "FitnessAppAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instructors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "FitnessAppAdmin")]
        public async Task<IActionResult> Create([Bind("Id, Name, Status")] InstructorView instructor)
        {
            if (ModelState.IsValid)
            {
                await _instructorLogic.Save(instructor);
                return RedirectToAction("Index");
            }
            return View(instructor);
        }

        // GET: Instructors/Edit/5
        [Authorize(Roles = "FitnessAppAdmin")]
        public IActionResult Edit(int id)
        {
            var instructor = _instructorLogic.FindById(id);
            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);
        }

        // POST: Instructors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "FitnessAppAdmin")]
        public async Task<IActionResult> Edit(
            int id, 
            [Bind("Id, Name, Status")] InstructorView instructor
        )
        {
            if (id != instructor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _instructorLogic.Save(instructor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_instructorLogic.InstructorExists(instructor.Id))
                    {
                        return NotFound();
                    } else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(instructor);
        }

        // GET: Instructors/Delete/5
        [Authorize(Roles = "FitnessAppAdmin")]
        public IActionResult Delete(int id)
        {
            var instructor = _instructorLogic.FindById(id);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        // POST: Instructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "FitnessAppAdmin")]
        public IActionResult DeleteConfirmed(int id)
        {
            _instructorLogic.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
