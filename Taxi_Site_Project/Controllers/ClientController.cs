using BusinessLayer.Concrete;
using BusinessLayer.Utilities;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using EntityLayer.ViewModels;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Taxi_Site_Project.Utilities;

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
            ClientValidator validationRules = new ClientValidator();
            ValidationResult result = validationRules.Validate(client);
            if (result.IsValid)
            {
                client.ClientImage = FunctionHelper.UpdateImage(Request, client.ClientImage);
                cm.ClientUpdate(client);
                TempData["Successfull"] = "Your changes saved successfully!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                Client clientvalue = cm.GetByID(cm.GetSessionID((string)Session["ClientMail"]));
                return View(clientvalue);
            }
        }

        public ActionResult ChangePasswordClient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePasswordClient(ChangePasswordViewModel passwordViewModel)
        {
            Client clientvalue = cm.GetByID(cm.GetSessionID((string)Session["ClientMail"]));
            ChangePasswordValidator validationRules = new ChangePasswordValidator();
            ValidationResult result = validationRules.Validate(passwordViewModel);
            if (!HashingHelper.VerifyPasswordHash(passwordViewModel.oldpassword, clientvalue.ClientPasswordHash, clientvalue.ClientPasswordSalt))
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
            cm.ChangePassword(clientvalue, passwordViewModel);
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

        public ActionResult GetClientDetails(int id)
        {
            if (id.ToString() == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Client value = cm.GetByID(id);
            return View(value);
        }
    }
}