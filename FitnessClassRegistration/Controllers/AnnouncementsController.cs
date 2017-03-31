using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitnessApp.Logic;
using Microsoft.AspNetCore.Authorization;
using FitnessApp.Models.ApplicationViewModels;

namespace FitnessApp.Controllers
{
    [Authorize]
    public class AnnouncementsController : Controller
    {
        private readonly IAnnouncementLogic _announcementLogic;

        public AnnouncementsController(IAnnouncementLogic announcementLogic)
        {
            _announcementLogic = announcementLogic;    
        }

        // GET: Announcements
        public async Task<IActionResult> Index()
        {
            return View(await _announcementLogic.GetList());
        }

        // GET: Announcements/Create
        [Authorize(Roles = "FitnessAppAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Announcements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "FitnessAppAdmin")]
        public async Task<IActionResult> Create(
            [Bind("Id, Comment, Title")] AnnouncementView announcement
        )
        {
            if (ModelState.IsValid)
            {
                await _announcementLogic.Save(announcement);                
                return RedirectToAction("Index");
            }
            return View(announcement);
        }

        // GET: Announcements/Edit/5
        [Authorize(Roles = "FitnessAppAdmin")]
        public IActionResult Edit(int id)
        {
            var announcement = _announcementLogic.FindById(id);
            if (announcement == null)
            {
                return NotFound();
            }
            return View(announcement);
        }

        // POST: Announcements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "FitnessAppAdmin")]
        public async Task<IActionResult> Edit(
            int id, 
            [Bind("Id, Comment, Title")] AnnouncementView announcement
        )
        {
            if (id != announcement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _announcementLogic.Save(announcement);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_announcementLogic.AnnouncementExists(announcement.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(announcement);
        }

        // GET: Announcements/Delete/5
        [Authorize(Roles = "FitnessAppAdmin")]
        public IActionResult Delete(int id)
        {
            var announcement = _announcementLogic.FindById(id);
            if (announcement == null)
            {
                return NotFound();
            }

            return View(announcement);
        }

        // POST: Announcements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "FitnessAppAdmin")]
        public IActionResult DeleteConfirmed(int id)
        {
            _announcementLogic.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
