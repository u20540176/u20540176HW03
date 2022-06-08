using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO; //add additional directive to execute functionality

namespace u20540176_HW03.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost] 
        public ActionResult Index(HttpPostedFileBase files, FormCollection frm)
        {
            if (files != null && files.ContentLength > 0)
            {

                var fileName = Path.GetFileName(files.FileName);
                
                var path = Path.Combine(Server.MapPath("~/Media"), fileName);
                files.SaveAs(path);

                

                
            }
            return RedirectToAction("Index");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult File()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}