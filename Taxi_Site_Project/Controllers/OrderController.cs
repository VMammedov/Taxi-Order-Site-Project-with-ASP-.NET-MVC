using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Taxi_Site_Project.Controllers
{
    public class OrderController : Controller
    {

        OrderManager om = new OrderManager(new EfOrderDal());
        ClientManager cm = new ClientManager(new EfClientDal());
        DriverManager dm = new DriverManager(new EfDriverDal());

        [HttpPost]
        public ActionResult NewOrderNow(Order p)
        {
            if (User.Identity.IsAuthenticated && Convert.ToString(Session["Class"]) != "Driver")
            {
                int id = cm.GetSessionID((string)Session["ClientMail"]);
                var clientvalue = cm.GetByID(id);
                om.SetOrderDetails(ref p, clientvalue);
                om.OrderAdd(p);
                TempData["Successfull"] = "Your order has been successfully received!";
                return RedirectToAction("Index", "Home");
            }
            else
                return RedirectToAction("ClientLogin", "Login");
        }

        [HttpGet]
        public ActionResult Orders()
        {
            if (Convert.ToString(Session["Class"]) != "Client")
            {
                var value = om.GetListWaitingOrders();
                return View(value);
            }
            else
            {
                return RedirectToAction("DriverRestrictionError", "Error");
            }
        }

        public ActionResult TakeOrder(int id)
        {
            if (Convert.ToString(Session["Class"]) == "Driver")
            {
                var value = om.GetByID(id);
                value.DriverID = dm.GetSessionID(Convert.ToString(Session["DriverMail"]));
                value.OrderStatus = "C";
                om.OrderUpdate(value);
                return RedirectToAction("Orders");
            }
            else
            {
                return RedirectToAction("DriverRestrictionError", "Error");
            }
        }

    }
}