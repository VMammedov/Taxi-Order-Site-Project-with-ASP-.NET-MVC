using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Taxi_Site_Project.Controllers
{
    public class UserController : Controller
    {
        public ActionResult EditUser()
        {
            if ((string)Session["Class"] == "Client")
            {
                return RedirectToAction("EditClient", "Client");
            }
            else if ((string)Session["Class"] == "Client")
            {
                return RedirectToAction("");
            }
            else
            {
                return RedirectToAction("RestrictionError", "Error");
            }
        }
    }
}