using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taxi_Site_Project.Utilities;

namespace Taxi_Site_Project.Controllers.AdminControllers
{
    public class AdmNewsController : Controller
    {

        NewsManager nm = new NewsManager(new EfNewsDal());

        public ActionResult News(string p, int page = 1)
        {
            IPagedList<News> news = nm.GetListBySearch(p).ToPagedList(page, 10); 
            return View(news);
        }

        public ActionResult AddNews()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNews(News news)
        {
            NewsValidator validationRules = new NewsValidator();
            ValidationResult result = validationRules.Validate(news);
            if (result.IsValid)
            {
                news.NewsImage = FunctionHelper.UpdateImage(Request, news.NewsImage);
                nm.NewsAdd(news);
                return RedirectToAction("News");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        public ActionResult EditNews(int id)
        {
            News value = nm.GetByID(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult EditNews(News news)
        {
            NewsValidator validationRules = new NewsValidator();
            ValidationResult result = validationRules.Validate(news);
            if (result.IsValid)
            {
                news.NewsImage = FunctionHelper.UpdateImage(Request, news.NewsImage);
                nm.NewsUpdate(news);
                return RedirectToAction("News");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        public ActionResult DeleteNews(int id)
        {
            News news = nm.GetByID(id);
            nm.NewsDelete(news);
            return RedirectToAction("News");
        }

        public ActionResult ActivateNews(int id)
        {
            News news = nm.GetByID(id);
            news.NewsStatus = true;
            nm.NewsUpdate(news);
            return RedirectToAction("News");
        }
    }
}