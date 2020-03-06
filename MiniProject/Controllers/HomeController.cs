
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniProject;
namespace MiniProject
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string uname, string pass)
        {
            Mini t = new Mini();
            var rid = (from i in t.logindatas where i.uname == uname && i.password == pass select i).FirstOrDefault();
            Session["uid"] = rid.uid;
            Session["role"] = rid.roleid;
            return RedirectToAction("dashboard", "TRM");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}