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

namespace Taxi_Site_Project.Controllers.AdminControllers
{
    public class AdmClientController : Controller
    {

        ClientManager cm = new ClientManager(new EfClientDal());

        [HttpGet]
        public ActionResult AdmEditClient(int id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
                return RedirectToAction("Error.cshtml");
            Client value = cm.GetByID(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult AdmEditClient(Client client)
        {
            ClientValidator validationRules = new ClientValidator();
            ValidationResult result = validationRules.Validate(client);
            if (result.IsValid)
            {
                client.ClientImage = FunctionHelper.UpdateImage(Request, client.ClientImage);
                cm.ClientUpdate(client);
                return RedirectToAction("Clients", "AdmDashboard");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return AdmEditClient(client.ClientID);
            }
        }

        public ActionResult AdmChangePasswordClient(int id)
        {
            TempData["id"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult AdmChangePasswordClient(string id, AdmChangePasswordViewModel passwordViewModel)
        {
            Client clientvalue = cm.GetByID(Convert.ToInt32(id));
            AdmChangePasswordValidator validationRules = new AdmChangePasswordValidator();
            ValidationResult result = validationRules.Validate(passwordViewModel);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return AdmChangePasswordClient(Convert.ToInt32(id));
            }
            cm.AdmChangePassword(clientvalue, passwordViewModel);
            return RedirectToAction("Clients", "AdmDashboard");
        }

        public ActionResult DeleteClient(int id)
        {
            var value = cm.GetByID(id);
            cm.ClientDelete(value);
            return RedirectToAction("Clients", "AdmDashboard");
        }

        public ActionResult ActivateClient(int id)
        {
            var value = cm.GetByID(id);
            value.ClientStatus = true;
            cm.ClientUpdate(value);
            return RedirectToAction("Clients", "AdmDashboard");
        }

    }
}