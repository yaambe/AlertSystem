using Microsoft.AspNetCore.Mvc;
using AlertSystem.Models;
namespace AlertSystem.Controllers
{
    public class AssignController : Controller
    {
        private PCContext pc;

        public AssignController(PCContext pcdb)
        {
            pc = pcdb;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
