using Agri_Enery_Connect.Areas.Identity.Data;
using Agri_Enery_Connect.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Agri_Enery_Connect.Controllers
{
 
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<Agri_EneryUser> _userManager;

        public HomeController(ILogger<HomeController> logger,UserManager<Agri_EneryUser> userManager)
        {
            _logger = logger;
            this._userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            ViewData["UserId"] = _userManager.GetUserId(this.User);
            var temp = TempData["rolecheck"];
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}