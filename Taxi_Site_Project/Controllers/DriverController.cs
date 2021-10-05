using BusinessLayer.Concrete;
using BusinessLayer.Utilities;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.ViewModels;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taxi_Site_Project.Utilities;

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
            DriverValidator validationRules = new DriverValidator();
            ValidationResult result = validationRules.Validate(driver);
            if (result.IsValid)
            {
                driver.DriverImage = FunctionHelper.UpdateImage(Request, driver.DriverImage);
                dm.DriverUpdate(driver);
                TempData["Successfull"] = "Your changes saved successfully!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                Driver drivervalue = dm.GetByID(dm.GetSessionID((string)Session["DriverMail"]));
                return View(drivervalue);
            }
        }

        public ActionResult ChangePasswordDriver()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePasswordDriver(ChangePasswordViewModel passwordViewModel)
        {
            Driver drivervalue = dm.GetByID(dm.GetSessionID((string)Session["DriverMail"]));
            ChangePasswordValidator validationRules = new ChangePasswordValidator();
            ValidationResult result = validationRules.Validate(passwordViewModel);
            if (!HashingHelper.VerifyPasswordHash(passwordViewModel.oldpassword, drivervalue.DriverPasswordHash, drivervalue.DriverPasswordSalt))
            {
                TempData["ErrorMessage"] = "Old password is incorrect!";
                return View();
            }
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            dm.ChangePassword(drivervalue, passwordViewModel);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult DriverDelete()
        {
            string p = (string)Session["DriverMail"];
            int id = dm.GetSessionID(p);
            var clientvalue = dm.GetByID(id);
            dm.DriverDelete(clientvalue);
            return RedirectToAction("SignOut", "Login");
        }

        public ActionResult GetDriverDetails(int id)
        {
            if (id.ToString() == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Driver value = dm.GetByID(id);
            return View(value);
        }
    }
}