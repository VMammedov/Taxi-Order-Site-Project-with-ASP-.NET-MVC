using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Taxi_Site_Project.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {

        ContactManager cm = new ContactManager(new EfContactDal());

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ContactUsForm()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult ContactUsForm(Contact p)
        {
            ContactValidator validationRules = new ContactValidator();
            ValidationResult result = validationRules.Validate(p);
            if (result.IsValid)
            {
                p.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.IsRead = false;
                cm.ContactAdd(p);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (ValidationFailure item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return RedirectToAction("Index","Home");
            }
        }

        public ActionResult ContactUs()
        {
            return View();
        }
    }
}