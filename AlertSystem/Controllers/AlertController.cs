using Microsoft.AspNetCore.Mvc;
using AlertSystem.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace AlertSystem.Controllers

{
    public class AlertController : Controller
    {

        private PCContext pc;

        public AlertController(PCContext pcdb)
        {
            pc = pcdb;
        }


        public IActionResult Index()
        {
            // will fetch the latest list of Alerts in the system
            string test = "1";
            string sqlQuery = $"select TOP 10 a.*, b.Nationality from pc.Alert a LEFT join pc.Nationality b ON a.NationalityId = b.Id WHERE {test} = 1 AND a.RecordStatus = 1 ORDER BY Id DESC;";
            // var param = new SqlParameter("@p1", 1);
            var myList = pc.Alert.FromSqlRaw(sqlQuery).ToList();
            ViewBag.viewList = myList;
            return View();
        }

        public IActionResult SaveAlert(Alert Alert)
        {
            if (Alert.Id != 0)
            {
                var _Alert = pc.Alert.Where(x => x.Id == Alert.Id).FirstOrDefault();
                _Alert.PassengerName = Alert.PassengerName;
                _Alert.PassportNo = Alert.PassportNo;
                _Alert.Nid = Alert.Nid;
                _Alert.DateOfBirth = Alert.DateOfBirth;
                _Alert.Gender = Alert.Gender;
                _Alert.NationalityId = Alert.NationalityId;
                _Alert.FlightId = Alert.FlightId;
                _Alert.FlightScheduledDate = Alert.FlightScheduledDate;
                _Alert.IsLuggageHit = Alert.IsLuggageHit;
                _Alert.LuggagetagNumber = Alert.LuggagetagNumber;
                _Alert.IsTroute = Alert.IsTroute;
                _Alert.TravellingAlone = Alert.TravellingAlone;
                _Alert.Eta = Alert.Eta;
                pc.Update(_Alert);
                pc.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                Alert.AlertStatusId = 1;
                Alert.RecordStatus = true;
                Alert.CreatedDate = DateTime.Now;
                Alert.AlertLevelId = 2;
                pc.Alert.Add(Alert);
                pc.SaveChanges();
                return RedirectToAction("Index", new { Id = Alert.Id });
            }

        }

        public IActionResult AlertEdit(int AlertId)
        {
            var _alert = pc.Alert.Include(x => x.Nationality).Where(x => x.Id == AlertId).FirstOrDefault();
            ViewBag.viewlist = pc.Alert.OrderByDescending(x => x.Id).Where(x => x.RecordStatus == true).ToList();
            return View("Index", _alert);
        }

        public IActionResult ModalView(int alertId)
        {
            var _Alert = pc.Alert.Where(x => x.Id == alertId).FirstOrDefault();
            return PartialView("ModalView", _Alert);
        }

        public IActionResult AlertDelete(int AlertId)
        {
            var _alert = pc.Alert.Where(x => x.Id == AlertId).FirstOrDefault();
            _alert.RecordStatus = false;
            pc.Alert.Update(_alert);
            pc.SaveChanges();
            ViewBag.viewlist = pc.Alert.OrderByDescending(x => x.Id).Where(x => x.RecordStatus == true).ToList();
            return View("Index", _alert);
        }

    }
}
