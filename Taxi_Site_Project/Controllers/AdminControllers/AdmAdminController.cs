using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taxi_Site_Project.Utilities;

namespace Taxi_Site_Project.Controllers.AdminControllers
{
    public class AdmAdminController : Controller
    {
        AdminManager am = new AdminManager(new EfAdminDal());

        public ActionResult Admins()
        {
            List<Admin> admins = am.GetList();
            return View(admins);
        }

        [HttpGet]
        public ActionResult AdmEditAdmin(int id)
        {
            Admin admin = am.GetByID(id);
            return View(admin);
        }

        [HttpPost]
        public ActionResult AdmEditAdmin(Admin admin)
        {
            admin.AdminImage = FunctionHelper.UpdateImage(Request, admin.AdminImage);
            am.AdminUpdate(admin);
            return RedirectToAction("Admins");
        }

        public ActionResult DeleteAdmin(int id)
        {
            Admin admin = am.GetByID(id);
            am.AdminUpdate(admin);
            return RedirectToAction("Admins");
        }

        public ActionResult ActivateAdmin(int id)
        {
            Admin admin = am.GetByID(id);
            admin.AdminStatus = true;
            am.AdminUpdate(admin);
            return RedirectToAction("Admins");
        }
    }
}