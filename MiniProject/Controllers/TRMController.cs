using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniProject;

namespace MiniProject
{
    public class TRMController : Controller
    {
        // GET: start
        public ActionResult dashboard()
        {

            Mini t = new Mini();
            int uid = int.Parse(Session["uid"].ToString());
            int rid = int.Parse(Session["role"].ToString());
            ViewBag.rid = rid;
            var rdata = from i in t.requests select i;
            List<request> reqs = new List<request>();
            foreach (var i in rdata)
            {
                request req = new request();
                req.reqid = i.reqid;
                req.skillname = i.skillname;
                req.sdate = i.sdate;
                req.edate = i.edate;
                req.status = i.status;
                req.trainerid = i.trainerid;
                req.execid = i.execid;
                reqs.Add(req);
            }
            return View(reqs);
        }
        public ActionResult addnewreq()
        {
            SelectListItem[] items = new SelectListItem[3];
            items[0] = new SelectListItem() { Text = "java", Value = "java" };
            items[1] = new SelectListItem() { Text = "c#", Value = "c#" };
            items[2] = new SelectListItem() { Text = "dot net", Value = " dot net" };
            ViewBag.lists = items;
            return View();
        }
        [HttpPost]
        public ActionResult addnewreq(string skill, DateTime sdate, DateTime edate)
        {
            Mini t = new Mini();
            request req = new request();
            req.skillname = skill;
            req.sdate = sdate;
            req.edate = edate;
            req.status = "requested";
            t.requests.Add(req);
            t.SaveChanges();
            return RedirectToAction("dashboard", "TRM");
        }
        public ActionResult spocsubmit(int rid)
        {
            Session["requestid"] = rid;
            Mini t = new Mini();
            var obj = t.logindatas.Where(i => i.roleid == 3);
            SelectListItem[] trainers = new SelectListItem[obj.Count()];
            int j = 0;

            foreach (var i in obj)
            {
                trainers[j] = new SelectListItem() { Text = i.uid.ToString(), Value = i.uid.ToString() };
                j++;

            }
            ViewBag.trainers = trainers;
            var obj1 = t.logindatas.Where(i => i.roleid == 4);
            SelectListItem[] executives = new SelectListItem[obj1.Count()];
            j = 0;

            foreach (var i in obj1)
            {
                executives[j] = new SelectListItem() { Text = i.uid.ToString(), Value = i.uid.ToString() };
                j++;

            }
            ViewBag.executives = executives;
            return View();
        }
        public ActionResult spocdb(int trainer, int executive)
        {
            int rid = int.Parse(Session["requestid"].ToString());
            Mini t = new Mini();
            var r = (from i in t.requests where i.reqid == rid select i).FirstOrDefault();

            r.execid = executive;
            r.trainerid = trainer;
            r.status = "assigned";
            t.SaveChanges();
            return RedirectToAction("dashboard", "TRM");
        }
        public ActionResult confirm(int rid)
        {
            Mini t = new Mini();
            var r = (from i in t.requests where i.reqid == rid select i).FirstOrDefault();
            r.status = "confirmed";
            t.SaveChanges();
            return RedirectToAction("dashboard", "TRM");
        }
    }
}
