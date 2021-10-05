using EntityLayer.Concrete;
using EntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IDriverService
    {
        List<Driver> GetList();
        List<Driver> GetListBySearch(string p);
        List<Driver> GetNonAcceptedList();
        int GetSessionID(string p);
        void DriverAdd(Driver driver);
        void DriverDelete(Driver driver);
        void DriverUpdate(Driver driver);
        void ChangePassword(Driver driver, ChangePasswordViewModel passwordViewModel);
        void AdmChangePassword(Driver driver, AdmChangePasswordViewModel passwordViewModel);
        Driver GetByID(int id);
    }
}
