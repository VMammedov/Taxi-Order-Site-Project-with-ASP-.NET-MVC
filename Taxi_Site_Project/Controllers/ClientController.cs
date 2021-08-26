using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
            string filename = Path.GetFileName(Request.Files[0].FileName);
            string extension = Path.GetExtension(Request.Files[0].FileName);
            string path = "~/Images/" + filename + extension;
            Request.Files[0].SaveAs(Server.MapPath(path));
            client.ClientImage = "/Images/" + filename + extension;
            cm.ClientUpdate(client);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ClientDelete()
        {
            string p = (string)Session["ClientMail"];
            int id = cm.GetSessionID(p);
            var clientvalue = cm.GetByID(id);
            cm.ClientDelete(clientvalue);
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}