﻿using System;
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
       

        public ActionResult ViewTemplate()
        {
            return View();
           


        }
        public ActionResult getData()
        {

            dt = new DataTable();

            dt = obj.getTemplateData();


            List<Template> list = new List<Template>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Template temp1 = new Template();
                temp1.id = Convert.ToInt32(dt.Rows[i]["id"]);
                temp1.Header = dt.Rows[i]["Header"].ToString();
                temp1.Description = dt.Rows[i]["Description"].ToString();
                list.Add(temp1);
            }
            var data = list;
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }


       

    }

       
}
