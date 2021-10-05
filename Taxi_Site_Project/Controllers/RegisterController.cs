using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Dto;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Taxi_Site_Project.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {

        IAuthService authService = new AuthManager(new ClientManager(new EfClientDal()), new DriverManager(new EfDriverDal()), new AdminManager(new EfAdminDal()));

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ClientRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ClientRegister(ClientLoginDto clientLoginDto)
        {
            ClientDtoValidator clientDtoValidator = new ClientDtoValidator();
            ValidationResult result = clientDtoValidator.Validate(clientLoginDto);
            if (authService.ChechkMail(clientLoginDto.Email) && result.IsValid)
            {
                authService.ClientRegister(clientLoginDto.Name, clientLoginDto.SurName, clientLoginDto.Email, clientLoginDto.Password1, clientLoginDto.Phone ,clientLoginDto.Profession, clientLoginDto.Sex);
                TempData["Successfull"] = "You are Regsitered Successfully";
                return RedirectToAction("ClientLogin", "Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                if (!authService.ChechkMail(clientLoginDto.Email))
                    ModelState.AddModelError("Email","There is account with that email in the Server!");
                return View();
            }
        }

        [HttpGet]
        public ActionResult DriverRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DriverRegister(DriverLoginDto driverLoginDto)
        {
            DriverDtoValidator driverDtoValidator = new DriverDtoValidator();
            ValidationResult result = driverDtoValidator.Validate(driverLoginDto);

            if (authService.ChechkMail(driverLoginDto.Email) && result.IsValid)
            {
                authService.DriverRegister(driverLoginDto.Name, driverLoginDto.SurName, driverLoginDto.Email, driverLoginDto.Password1, driverLoginDto.Phone, driverLoginDto.Profession, driverLoginDto.Sex);
                TempData["Successfull"] = "You are Regsitered Successfully";
                return RedirectToAction("DriverLogin", "Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                if (!authService.ChechkMail(driverLoginDto.Email))
                    ModelState.AddModelError("Email", "There is account with that email in the Server!");
                return View();
            }
        }

        [HttpGet]
        public ActionResult AdminRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminRegister(AdminLoginDto adminLoginDto)
        {
            if (adminLoginDto.AdminPassword1==adminLoginDto.AdminPassword2)
            {
                authService.AdminRegister(adminLoginDto.AdminUserName, adminLoginDto.AdminMail, adminLoginDto.AdminPassword1, adminLoginDto.Role);
                return RedirectToAction("AdminLogin", "Login");
            }
            else
            {
                TempData["ErrorMessageAdmin"] = "Please make sure the passwords are the same!";
            }
            return RedirectToAction("AdminRegister");
        }
    }
}