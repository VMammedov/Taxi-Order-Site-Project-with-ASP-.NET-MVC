using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Taxi_Site_Project.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult Index()
        {
            if (Convert.ToString(Session["Class"])!="Driver")
            {
                return View();
            }
            else
            {
                return RedirectToAction("DriverRestrictionError", "Error");
            }
        }

        public ActionResult GetTaxiService()
        {
            if (Convert.ToString(Session["Class"]) != "Driver")
            {
                return View();
            }
            else
            {
                return RedirectToAction("DriverRestrictionError", "Error");
            }
        }
    }
}