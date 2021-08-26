using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Taxi_Site_Project.Controllers
{
    public class DriverController : Controller
    {

        DriverManager dm = new DriverManager(new EfDriverDal());

        
    }
}