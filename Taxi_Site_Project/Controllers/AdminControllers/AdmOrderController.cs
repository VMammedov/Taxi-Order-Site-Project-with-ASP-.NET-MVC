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

namespace Taxi_Site_Project.Controllers.AdminControllers
{
    public class AdmOrderController : Controller
    {

        OrderManager om = new OrderManager(new EfOrderDal());

        public ActionResult Orders(string p, int page = 1)
        {
            var value = om.GetListBySearch(p).ToPagedList(page, 8);
            return View(value);
        }

        [HttpGet]
        public ActionResult AdmEditOrder(int id)
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
            var value = om.GetByID(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult AdmEditOrder(Order order)
        {
            om.OrderUpdate(order);
            return RedirectToAction("Orders", "AdmOrder");
        }

        public ActionResult GetOrderDetails(int id)
        {
            Order order = om.GetByID(id);
            return View(order);
        }

        public ActionResult DeleteOrder(int id)
        {
            Order order = om.GetByID(id);
            om.OrderDelete(order);
            return RedirectToAction("Orders");
        }
    }
}