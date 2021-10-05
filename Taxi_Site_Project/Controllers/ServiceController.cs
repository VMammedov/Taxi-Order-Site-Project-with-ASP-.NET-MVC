using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Taxi_Site_Project.Controllers
{
    [AllowAnonymous]
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
                return RedirectToAction("RestrictionError", "Error");
            }
        }

    }
}