using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface INewsService
    {
        List<News> GetList();
        List<News> GetActiveList();
        List<News> GetListBySearch(string p);
        void NewsAdd(News news);
        void NewsDelete(News news);
        void NewsUpdate(News news);
        News GetByID(int id);
    }
}
