using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Taxi_Site_Project.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}