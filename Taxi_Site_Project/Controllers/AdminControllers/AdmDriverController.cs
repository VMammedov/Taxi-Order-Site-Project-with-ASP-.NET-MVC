using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Taxi_Site_Project.Controllers.AdminControllers
{
    public class AdmDriverController : Controller
    {

        DriverManager dm = new DriverManager(new EfDriverDal());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AcceptDriver(int id)
        {
            var value = dm.GetByID(id);
            value.DriverStatus = true;
            dm.DriverUpdate(value);
            return RedirectToAction("Index", "AdmDashboard");
        }

        [HttpGet]
        public ActionResult AdmEditDriver(int id)
        {
            var value = dm.GetByID(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult AdmEditDriver(Driver client)
        {
            dm.DriverUpdate(client);
            return RedirectToAction("Clients", "AdmDashboard");
        }

        public ActionResult DeleteDriver(int id)
        {
            var value = dm.GetByID(id);
            dm.DriverDelete(value);
            return RedirectToAction("Drivers", "AdmDashboard");
        }

    }
}