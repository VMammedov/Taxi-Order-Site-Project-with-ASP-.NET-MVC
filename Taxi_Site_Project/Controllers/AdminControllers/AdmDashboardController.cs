using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Taxi_Site_Project.Controllers.AdminControllers
{
    public class AdmDashboardController : Controller
    {

        DriverManager dm = new DriverManager(new EfDriverDal());
        ClientManager cm = new ClientManager(new EfClientDal());
        AdminManager am = new AdminManager(new EfAdminDal());

        public ActionResult Index()
        {
            TempData["NumberOfDrivers"] = dm.GetList().Count(x => x.DriverStatus == true);
            TempData["NumberOfClients"] = cm.GetList().Count(x => x.ClientStatus == true);
            var value = dm.GetNonAcceptedList();
            return View(value);
        }

        public PartialViewResult GetDriverDetails(int id)
        {
            var value = dm.GetByID(id);
            return PartialView(value);
        }

        public ActionResult GetClientDetails(int id)
        {
            var value = cm.GetByID(id);
            return View(value);
        }

        public ActionResult Clients(string p, int page=1)
        {
            var value = cm.GetListBySearch(p).ToPagedList(page, 5);
            return View(value);
        }

        public ActionResult Drivers(string p, int page = 1)
        {
            var value = dm.GetListBySearch(p).ToPagedList(page, 5);
            return View(value);
        }

        public PartialViewResult ProfileInfo()
        {
            var id = am.GetSessionID((string)Session["AdminMail"]);
            var value = am.GetByID(id);
            return PartialView(value);
        }

    }
}