using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NewsManager : INewsService
    {
        INewsDal _newsDal;

        public NewsManager(INewsDal newsDal)
        {
            _newsDal = newsDal;
        }

        public News GetByID(int id)
        {
            return _newsDal.Get(x => x.NewsID == id);
        }

        public List<News> GetList()
        {
            return _newsDal.List();
        }

        public void NewsAdd(News news)
        {
            _newsDal.Insert(news);
        }

        public void NewsDelete(News news)
        {
            //news.NewsStatus = false;
            _newsDal.Update(news);
        }

        public void NewsUpdate(News news)
        {
            _newsDal.Update(news);
        }
    }
}
