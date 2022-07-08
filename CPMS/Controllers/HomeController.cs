using CPMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CPMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult LoginSuccess()
        {
            return View();
        }

        public IActionResult LoginFailure()
        {
            return View();
        }

        public IActionResult TableManagement()
        {
            return View();
        }

        public IActionResult BridgeTable()
        {
            return View();
        }

        public IActionResult Reports()
        {
            return View();
        }

        public IActionResult AddAuthorToTable()
        {
            return View();
        }
        public IActionResult AddReviewerToTable()
        {
            return View();
        }



        public IActionResult ProcessLogin(UserModel userModel)
        {
            if (userModel.Username == "admin1" && userModel.Password == "cpmsadmin")
            {
                return View("LoginSuccess", userModel);
            }
            else
            {
                return View("LoginFailure", userModel);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}