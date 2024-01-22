using AlertSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AlertSystem.Controllers
{
    public class HomeController : Controller
    {
        private PCContext pc;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, PCContext pcdb)
        {
            _logger = logger;
            pc = pcdb;
        }

        public IActionResult Index()
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