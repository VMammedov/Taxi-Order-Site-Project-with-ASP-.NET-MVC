using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Taxi_Site_Project.Controllers.AdminControllers
{
    public class AdmClientController : Controller
    {

        ClientManager cm = new ClientManager(new EfClientDal());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DeleteClient(int id)
        {
            var value = cm.GetByID(id);
            cm.ClientDelete(value);
            return RedirectToAction("Clients", "AdmDashboard");
        }

        [HttpGet]
        public ActionResult AdmEditClient(int id)
        {
            var value = cm.GetByID(id);
            return PartialView(value);
        }

        [HttpPost]
        public ActionResult AdmEditClient(Client client)
        {
            cm.ClientUpdate(client);
            return RedirectToAction("Clients", "AdmDashboard");
        }

    }
}