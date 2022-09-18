using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using WorldUniversity.Services;
using WorldUniversity.Services.Messaging;
using WorldUniversity.ViewModels.Error;
using WorldUniversity.ViewModels.Home;

namespace WorldUniversity.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService homeService;
        private readonly IContactService contactService;
        private readonly IMailHelper mailHelper;

        public HomeController(IHomeService homeService
            , IContactService contactService
            , IMailHelper mailHelper)
        {
            this.homeService = homeService;
            this.contactService = contactService;
            this.mailHelper = mailHelper;
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
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Contact(ContactFormInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }
            await this.contactService.CreateAsync(input.Name, input.Email, input.Title, input.Content);

            await this.mailHelper.SendContactFormAsync(input.Email, input.Name, input.Title, input.Content);
            return this.RedirectToAction("Index");
        }
        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
