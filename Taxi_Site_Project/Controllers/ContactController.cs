using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Taxi_Site_Project.Controllers
{
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
            p.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.IsRead = false;
            cm.ContactAdd(p);
            return RedirectToAction("Index","Home");
        }

        public ActionResult ContactUs()
        {
            return View();
        }
    }
}