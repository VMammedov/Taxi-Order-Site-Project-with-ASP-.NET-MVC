using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using EntityLayer.Concrete;

namespace Taxi_Site_Project.Controllers
{
    [AllowAnonymous]
    public class NewsController : Controller
    {

        NewsManager nm = new NewsManager(new EfNewsDal());

        public ActionResult Index(int page=1)
        {
            IPagedList<News> newsvalue = nm.GetList().ToPagedList(page,3);
            return View(newsvalue);
        }
    }
}