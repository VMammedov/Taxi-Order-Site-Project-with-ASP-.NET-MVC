using BusinessLayer.Concrete;
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

namespace Taxi_Site_Project.Controllers.AdminControllers
{
    public class AdmDriverController : Controller
    {

        DriverManager dm = new DriverManager(new EfDriverDal());

        public ActionResult AcceptDriver(int id)
        {
            var value = dm.GetByID(id);
            value.DriverStatus = true;
            dm.DriverUpdate(value);
            return RedirectToAction("Index", "AdmDashboard");
        }

        [HttpGet]
        public ActionResult AdmEditDriver(int id)
        {
            var value = dm.GetByID(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult AdmEditDriver(Driver driver)
        {
            DriverValidator validationRules = new DriverValidator();
            ValidationResult result = validationRules.Validate(driver);
            if (result.IsValid)
            {
                driver.DriverImage = FunctionHelper.UpdateImage(Request, driver.DriverImage);
                dm.DriverUpdate(driver);
                return RedirectToAction("Drivers", "AdmDashboard");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return AdmEditDriver(driver.DriverID);
            }
        }

        public ActionResult AdmChangePasswordDriver(int id)
        {
            TempData["id"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult AdmChangePasswordDriver(string id, AdmChangePasswordViewModel passwordViewModel)
        {
            Driver drivervalue = dm.GetByID(Convert.ToInt32(id));
            AdmChangePasswordValidator validationRules = new AdmChangePasswordValidator();
            ValidationResult result = validationRules.Validate(passwordViewModel);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return AdmChangePasswordDriver(Convert.ToInt32(id));
            }
            dm.AdmChangePassword(drivervalue, passwordViewModel);
            return RedirectToAction("Drivers", "AdmDashboard");
        }


        public ActionResult DeleteDriver(int id)
        {
            var value = dm.GetByID(id);
            dm.DriverDelete(value);
            return RedirectToAction("Drivers", "AdmDashboard");
        }

        public ActionResult ActivateDriver(int id)
        {
            var value = dm.GetByID(id);
            value.DriverStatus = true;
            dm.DriverUpdate(value);
            return RedirectToAction("Drivers", "AdmDashboard");
        }
    }
}