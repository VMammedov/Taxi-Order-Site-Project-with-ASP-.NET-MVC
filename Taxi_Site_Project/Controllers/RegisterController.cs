using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Taxi_Site_Project.Controllers
{
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
            if (clientLoginDto.Password1 == clientLoginDto.Password2)
            {
                authService.ClientRegister(clientLoginDto.Name, clientLoginDto.SurName, clientLoginDto.Email, clientLoginDto.Password1, clientLoginDto.Phone ,clientLoginDto.Profession, clientLoginDto.Sex);
                return RedirectToAction("ClientLogin", "Login");
            }
            else
            {
                TempData["ErrorMessage"] = "Please make sure the passwords are the same!";
            }
            return RedirectToAction("ClientRegister");
        }

        [HttpGet]
        public ActionResult DriverRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DriverRegister(DriverLoginDto driverLoginDto)
        {
            if (driverLoginDto.Password1==driverLoginDto.Password2)
            {
                authService.DriverRegister(driverLoginDto.Name, driverLoginDto.SurName, driverLoginDto.Email, driverLoginDto.Password1, driverLoginDto.Phone, driverLoginDto.Profession, driverLoginDto.Sex);
                return RedirectToAction("DriverLogin", "Login");
            }
            else
            {
                TempData["ErrorMessage"] = "Please make sure the passwords are the same!";
            }
            return RedirectToAction("DriverRegister");
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