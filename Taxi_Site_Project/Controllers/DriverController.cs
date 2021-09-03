using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Taxi_Site_Project.Controllers
{
    public class DriverController : Controller
    {

        DriverManager dm = new DriverManager(new EfDriverDal());

        [HttpGet]
        public ActionResult EditDriver()
        {
            string p = (string)Session["DriverMail"];
            int id = dm.GetSessionID(p);
            var clientvalue = dm.GetByID(id);
            return View(clientvalue);
        }

        [HttpPost]
        public ActionResult EditDriver(Driver driver)
        {
            if (string.IsNullOrEmpty(Request.Files[0].FileName) == false)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Images/" + filename + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                driver.DriverImage = "/Images/" + filename + extension;
            }
            dm.DriverUpdate(driver);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ChangePasswordDriver()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePasswordDriver(string oldpassword, string password1, string password2)
        {
            string p = (string)Session["DriverMail"];
            var clientvalue = dm.GetByID(dm.GetSessionID(p));
            if (!dm.ChangePassword(clientvalue, oldpassword, password1, password2))
            {
                TempData["ErrorMessage"] = "Please check that you have filled in all fields correctly and check that the passwords are correct!";
                return RedirectToAction("ChangePasswordDriver");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ClientDelete()
        {
            string p = (string)Session["DriverMail"];
            int id = dm.GetSessionID(p);
            var clientvalue = dm.GetByID(id);
            dm.DriverDelete(clientvalue);
            return RedirectToAction("SignOut", "Login");
        }
    }
}