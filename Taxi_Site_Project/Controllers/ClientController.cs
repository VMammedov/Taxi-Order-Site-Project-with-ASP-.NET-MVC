using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Taxi_Site_Project.Controllers
{
    public class ClientController : Controller
    {

        ClientManager cm = new ClientManager(new EfClientDal());

        [HttpGet]
        public ActionResult EditClient()
        {
            string p = (string)Session["ClientMail"];
            int id = cm.GetSessionID(p);
            var clientvalue = cm.GetByID(id);
            return View(clientvalue);
        }

        [HttpPost]
        public ActionResult EditClient(Client client)
        {
            if (string.IsNullOrEmpty(Request.Files[0].FileName) == false)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Images/" + filename + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                client.ClientImage = "/Images/" + filename + extension;
            }
            cm.ClientUpdate(client);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ChangePasswordClient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePasswordClient(string oldpassword, string password1, string password2)
        {
            string p = (string)Session["ClientMail"];
            var clientvalue = cm.GetByID(cm.GetSessionID(p));
            if (!cm.ChangePassword(clientvalue, oldpassword, password1, password2))
            {
                TempData["ErrorMessage"] = "Please check that you have filled in all fields correctly and check that the passwords are correct!";
                return RedirectToAction("ChangePasswordClient");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ClientDelete()
        {
            string p = (string)Session["ClientMail"];
            int id = cm.GetSessionID(p);
            var clientvalue = cm.GetByID(id);
            cm.ClientDelete(clientvalue);
            return RedirectToAction("SignOut", "Login");
        }
    }
}