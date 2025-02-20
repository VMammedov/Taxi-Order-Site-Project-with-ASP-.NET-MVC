﻿using System;
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
            else if ((string)Session["Class"] == "Driver")
            {
                return RedirectToAction("EditDriver", "Driver");
            }
            else
            {
                return RedirectToAction("RestrictionError", "Error");
            }
        }

        public ActionResult UserOrders()
        {
            if ((string)Session["Class"] == "Client")
            {
                return RedirectToAction("OrdersByClient", "Order");
            }
            else if ((string)Session["Class"] == "Driver")
            {
                return RedirectToAction("OrdersByDriver", "Order");
            }
            else
            {
                return RedirectToAction("RestrictionError", "Error");
            }
        }
    }
}