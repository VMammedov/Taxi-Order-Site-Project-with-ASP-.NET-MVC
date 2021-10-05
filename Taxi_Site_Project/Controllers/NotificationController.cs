using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Utilities;

namespace Taxi_Site_Project.Controllers
{
    public class NotificationController : Controller
    {
        NotificationManager nm = new NotificationManager(new EfNotificationDal());
        
        public PartialViewResult NotificationListByClient()
        {
            List<Notification> notifications = nm.GetListByClient((string)Session["ClientMail"]).Take(5).ToList();
            return PartialView(notifications);
        }

        public PartialViewResult NotificationListByDriver()
        {
            List<Notification> notifications = nm.GetListByDriver((string)Session["DriverMail"]).Take(5).ToList();
            return PartialView(notifications);
        }

        public ActionResult NotificationsByClient(int page = 1)
        {
            IPagedList<Notification> notifications = nm.GetListByClient((string)Session["ClientMail"]).ToPagedList(page, 6);
            return View(notifications);
        }

        public ActionResult NotificationsByDriver(int page = 1)
        {
            IPagedList<Notification> notifications = nm.GetListByClient((string)Session["ClientMail"]).ToPagedList(page, 6);
            return View(notifications);
        }

        public ActionResult SendNofitication(OrderNMessage orderNMessage)
        {
            nm.NotificationSend(orderNMessage);
            return RedirectToAction("Orders","Order");
        }
    }
}