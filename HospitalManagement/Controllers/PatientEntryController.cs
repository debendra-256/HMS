using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMSMODEL;

namespace HospitalManagement.Controllers
{
    public class PatientEntryController : Controller
    {
        HospitalBLL.HospitalComponents obj = new HospitalBLL.HospitalComponents();
        // GET: PatientEntry
        public ActionResult PatientsEntry()
        {



            return View();
        }
        [HttpPost]
        public ActionResult PatientsEntry(PatientEntry patient)
        {

            bool details = obj.PatientEntry(patient);
            if(details==true)
            {
                ViewBag.SuccessMessage = "<p>Success!</p>";
                return View();
            }
            else
            {
                ViewBag.SuccessMessage = "<p>Please try once!!!!!!</p>";
                return View();
            }




           
        }
        [HttpPost]
        public ActionResult Index()
        {

            return View();
        }
    }
}