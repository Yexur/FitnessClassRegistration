using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using FitnessApp.Logic;
using FitnessApp.Models.ApplicationViewModels;

namespace FitnessApp.Controllers
{
    [Authorize]
    public class LocationsController : Controller
    {
        private readonly ILocationLogic _locationLogic;

        public LocationsController(ILocationLogic locationLogic)
        {
            _locationLogic = locationLogic;
        }

        // GET: Locations
        [Authorize(Roles = "FitnessAppAdmin")]
        public async Task<IActionResult> Index()
        {
            return View(await _locationLogic.GetList());
        }

        // GET: Locations/Create
        [Authorize(Roles = "FitnessAppAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "FitnessAppAdmin")]
        public async Task<IActionResult> Create([Bind("Id, Name")] LocationView location)
        {
            if (ModelState.IsValid)
            {
                await _locationLogic.Save(location);
                return RedirectToAction("Index");
            }
            return View(location);
        }

        // GET: Locations/Edit/5
        [Authorize(Roles = "FitnessAppAdmin")]
        public IActionResult Edit(int id)
        {
            var location = _locationLogic.FindById(id);
            if (location == null)
            {
                return NotFound();
            }
            return View(location);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "FitnessAppAdmin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name ")] LocationView location)
        {
            if (id != location.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _locationLogic.Save(location);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_locationLogic.LocationExists(location.Id))
                    {
                        return NotFound();
                    } else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(location);
        }

        // GET: Locations/Delete/5
        [Authorize(Roles = "FitnessAppAdmin")]
        public IActionResult Delete(int id)
        {
            var location = _locationLogic.FindById(id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "FitnessAppAdmin")]
        public IActionResult DeleteConfirmed(int id)
        {
            _locationLogic.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
