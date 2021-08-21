using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Orders(string p, int page = 1)
        {
            var value = om.GetListBySearch(p).ToPagedList(page, 8);
            return View(value);
        }
    }
}