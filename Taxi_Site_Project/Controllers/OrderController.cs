using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Utilities;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace Taxi_Site_Project.Controllers
{
    public class OrderController : Controller
    {

        OrderManager om = new OrderManager(new EfOrderDal());
        ClientManager cm = new ClientManager(new EfClientDal());
        DriverManager dm = new DriverManager(new EfDriverDal());

        [AllowAnonymous]
        public ActionResult NewOrderNow()
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
                ViewData["vlct"] = valuecartype;
                return View();
            }
            else
            {
                return RedirectToAction("RestrictionError", "Error");
            }
        }

        [HttpPost]
        public ActionResult NewOrderNow(Order p)
        {
            if (User.Identity.IsAuthenticated && Convert.ToString(Session["Class"]) != "Driver")
            {
                OrderValidator validationRules = new OrderValidator();
                ValidationResult result = validationRules.Validate(p);
                if (result.IsValid)
                {
                    int id = cm.GetSessionID((string)Session["ClientMail"]);
                    Client clientvalue = cm.GetByID(id);
                    om.SetOrderDetails(ref p, clientvalue);
                    om.OrderAdd(p);
                    TempData["Successfull"] = "Your order has been successfully received!";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (ValidationFailure item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                    return NewOrderNow();
                }
            }
            else
                return RedirectToAction("ClientLogin", "Login");
        }

        [HttpGet]
        public ActionResult Orders()
        {
            if ((string)Session["Class"] != "Client")
            {
                var value = om.GetListWaitingOrders();
                return View(value);
            }
            else
            {
                return RedirectToAction("RestrictionError", "Error");
            }
        }

        public ActionResult TakeOrder(int id)
        {
            if ((string)Session["Class"] == "Driver")
            {
                var order = om.GetByID(id);
                order.DriverID = dm.GetSessionID((string)Session["DriverMail"]);
                order.OrderStatus = "C";
                om.OrderUpdate(order);
                order = om.GetByID(id);
                string message = "Hello dear customer " + order.Client.ClientName + ", I'm your driver "
            + order.Driver.DriverName + " " + order.Driver.DriverSurName + ". I accepted your order. I will contact you as soon as possible.";
                OrderNMessage orderNMessage = new OrderNMessage(order.OrderID, message);
                return RedirectToAction("SendNofitication","Notification",orderNMessage);
            }
            else
            {
                return RedirectToAction("RestrictionError", "Error");
            }
        }

        public ActionResult OrdersByClient()
        {
            List<Order> value = om.OrdersByClient((string)Session["ClientMail"]);
            return View(value);
        }

        public ActionResult OrdersByDriver()
        {
            List<Order> value = om.OrdersByDriver((string)Session["DriverMail"]);
            return View(value);
        }

    }
}