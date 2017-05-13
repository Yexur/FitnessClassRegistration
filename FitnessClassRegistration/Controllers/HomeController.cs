using System.Threading.Tasks;
using FitnessClassRegistration.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessClassRegistration.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IAnnouncementLogic _announcementLogic;

        public HomeController(IAnnouncementLogic announcementLogic)
        {
            _announcementLogic = announcementLogic;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _announcementLogic.GetList());
        }

        [AllowAnonymous]
        public IActionResult About()
        {
            ViewData["Message"] = "Fitness Registration.";

            return View();
        }

        [AllowAnonymous]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View();
        }
    }
}
