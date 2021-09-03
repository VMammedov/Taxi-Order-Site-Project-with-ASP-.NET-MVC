using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
                return RedirectToAction("RestrictionError", "Error");
            }
        }

        public ActionResult GetTaxiService()
        {
            if (Convert.ToString(Session["Class"]) != "Driver")
            {
                CarTypeManager ctm = new CarTypeManager(new EfCarTypeDal());
                List<SelectListItem> valuecartype = (from x in ctm.GetList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.carType,
                                                         Value = x.CarTypeID.ToString()
                                                     }
                                                   ).ToList();
                ViewBag.vlct = valuecartype;
                return View();
            }
            else
            {
                return RedirectToAction("RestrictionError", "Error");
            }
        }
    }
}