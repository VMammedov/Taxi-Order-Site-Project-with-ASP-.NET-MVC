using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Taxi_Site_Project.Controllers
{
    public class LoginController : Controller
    {

        IAuthService authService = new AuthManager(new ClientManager(new EfClientDal()), new DriverManager(new EfDriverDal()), new AdminManager(new EfAdminDal()));

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ClientLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ClientLogin(ClientLoginDto clientLoginDto)
        {
            if (authService.ClientLogin(clientLoginDto))
            {
                FormsAuthentication.SetAuthCookie(clientLoginDto.Email, false);
                Session["ClientMail"] = clientLoginDto.Email;
                Session["Class"] = "Client"; 
                return RedirectToAction("Index", "Home");
            }
            else 
            {
                ViewData["ErrorMessage"] = "Email or Password is not valid!";
            }
            return RedirectToAction("ClientLogin");
        }

        [HttpGet]
        public ActionResult DriverLogin()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult DriverLogin(DriverLoginDto driverLoginDto)
        {
            if (authService.DriverLogin(driverLoginDto))
            {
                FormsAuthentication.SetAuthCookie(driverLoginDto.Email, false);
                Session["DriverMail"] = driverLoginDto.Email;
                Session["Class"] = "Driver";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["ErrorMessage"] = "Email or Password is not valid!";
            }
            return RedirectToAction("DriverLogin");
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(AdminLoginDto adminLoginDto)
        {
            if (authService.AdminLogin(adminLoginDto))
            {
                FormsAuthentication.SetAuthCookie(adminLoginDto.AdminMail, false);
                Session["AdminMail"] = adminLoginDto.AdminMail;
                return RedirectToAction("Index", "AdmDashboard");
            }
            else
            {
                ViewData["ErrorMessageAdmin"] = "Email or Password is not valid!";
            }
            return RedirectToAction("AdminLogin");
        }

        public ActionResult AdminSignOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AdminLogin");
        }

        public ActionResult UserSignOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}