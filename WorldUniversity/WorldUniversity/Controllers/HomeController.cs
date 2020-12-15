using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorldUniversity.Data;
using WorldUniversity.Services;

namespace WorldUniversity.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IHomeService homeService;

        public HomeController(ApplicationDbContext context, IHomeService homeService)
        {
            this.homeService = homeService;
        }
        [AllowAnonymous]
        public ActionResult About()
        {
            var groups = homeService.GetGeneralInformation();
            return View(groups);
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }
        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
