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
    public class AdmContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());

        public ActionResult Index(string p, int page = 1)
        {
            IPagedList<Contact> contacts = cm.GetListBySearch(p).ToPagedList(page, 6);
            return View(contacts);
        }

        public ActionResult DeleteContact(int id)
        {
            Contact deletedcontact = cm.GetByID(id);
            cm.ContactDelete(deletedcontact);
            return RedirectToAction("Index");
        }

        public ActionResult GetContactDetails(int id)
        {
            Contact contact = cm.GetByID(id);
            contact.IsRead = true;
            cm.ContactUpdate(contact);
            return View(contact);
        }
    }
}