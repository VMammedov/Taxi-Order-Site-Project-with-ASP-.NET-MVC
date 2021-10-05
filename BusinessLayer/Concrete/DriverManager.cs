using BusinessLayer.Abstract;
using BusinessLayer.Utilities;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DriverManager : IDriverService
    {

        IDriverDal _driverDal;

        public DriverManager(IDriverDal driverDal)
        {
            _driverDal = driverDal;
        }

        public void ChangePassword(Driver driver, ChangePasswordViewModel passwordViewModel)
        {
            byte[] PasswordHash, PasswordSalt;
            HashingHelper.CreatePasswordHash(passwordViewModel.password1, out PasswordHash, out PasswordSalt);
            driver.DriverPasswordHash = PasswordHash;
            driver.DriverPasswordSalt = PasswordSalt;
            DriverUpdate(driver);
        }

        public void AdmChangePassword(Driver driver, AdmChangePasswordViewModel passwordViewModel)
        {
            byte[] PasswordHash, PasswordSalt;
            HashingHelper.CreatePasswordHash(passwordViewModel.password1, out PasswordHash, out PasswordSalt);
            driver.DriverPasswordHash = PasswordHash;
            driver.DriverPasswordSalt = PasswordSalt;
            DriverUpdate(driver);
        }

        public void DriverAdd(Driver driver)
        {
            _driverDal.Insert(driver);
        }

        public void DriverDelete(Driver driver)
        {
            driver.DriverStatus = false;
            _driverDal.Update(driver);
        }

        public void DriverUpdate(Driver driver)
        {
            _driverDal.Update(driver);
        }

        public Driver GetByID(int id)
        {
            return _driverDal.Get(x => x.DriverID == id);
        }

        public List<Driver> GetList()
        {
            return _driverDal.List();
        }

        public List<Driver> GetListBySearch(string p)
        {
            if (string.IsNullOrEmpty(p))
                return _driverDal.List();
            else
                return _driverDal.List(x => x.DriverName.Contains(p));
        }

        public List<Driver> GetNonAcceptedList()
        {
            return _driverDal.List(x => x.DriverStatus == false);
        }

        public int GetSessionID(string p)
        {
            int value = _driverDal.List(x => x.DriverMail == p).Select(y => y.DriverID).FirstOrDefault();
            return value;
        }
    }
}
