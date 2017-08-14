using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMSMODEL;
using System.Data;

namespace HospitalManagement.Controllers
{
    public class PatientEntryController : Controller
    {
        HospitalBLL.HospitalComponents obj = new HospitalBLL.HospitalComponents();
        DataTable dt;
        
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
        
        public ActionResult patientDetails()
        {

            dt = new DataTable();

            dt= obj.GetPatientEntry_onParticularDate();


            List<PatientEntry> list = new List<PatientEntry>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PatientEntry patient = new PatientEntry();
                patient.ID = dt.Rows[i]["ID"].ToString();
                patient.FirstName = dt.Rows[i]["FirstName"].ToString();
                patient.LastName = dt.Rows[i]["LastName"].ToString();
                patient.Date = Convert.ToDateTime(dt.Rows[i]["date"]);
                patient.Address = dt.Rows[i]["Address"].ToString();
                patient.Age = Convert.ToInt32(dt.Rows[i]["Age"]);
                patient.Description = dt.Rows[i]["Description"].ToString();
                list.Add(patient);
            }

            return View(list);

           
        }
    }
}