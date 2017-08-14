using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using HMSMODEL;


namespace HospitalManagement.Controllers
{
    public class HomeController : Controller
    {
        HospitalBLL.HospitalComponents obj = new HospitalBLL.HospitalComponents();
        DataTable dt;

        public ActionResult Index()
        {
            dt = new DataTable();

            dt = obj.getTemplateData();


            List<Template> list = new List<Template>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Template temp = new Template();
                temp.id = Convert.ToInt32(dt.Rows[i]["id"]);
                temp.Header = dt.Rows[i]["Header"].ToString();
                temp.Description = dt.Rows[i]["Description"].ToString();
                list.Add(temp);
            }

            return View(list);


        }

       
        public ActionResult TemplateEntry()
        {

            return View();

        }
        [HttpPost]
        public ActionResult TemplateEntry(Template temp)
        {
            obj.tabEntery(temp);
            return View();
            

        }


       

    }

       
}
