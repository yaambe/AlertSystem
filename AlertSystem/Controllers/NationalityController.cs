using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlertSystem.Models;
using Microsoft.Data.SqlClient;

namespace AlertSystem.Controllers
{
    public class NationalityController : Controller
    {

        private PCContext pc;

        public NationalityController(PCContext pcdb)
        {
            pc = pcdb;
        }


        public IActionResult Index()
        {
            return View();
        }

    }
}
