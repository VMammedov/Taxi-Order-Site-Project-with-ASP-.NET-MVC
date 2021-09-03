using BusinessLayer.Abstract;
using BusinessLayer.Utilities;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
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

        public bool ChangePassword(Driver driver, string op, string p1, string p2)
        {
            byte[] PasswordHash, PasswordSalt;
            if (string.IsNullOrEmpty(op) || string.IsNullOrEmpty(p1) || string.IsNullOrEmpty(p2) 
                || !HashingHelper.VerifyPasswordHash(op, driver.DriverPasswordHash, driver.DriverPasswordSalt) 
                || p1 != p2)
            {
                return false;
            }
            else
            {
                HashingHelper.CreatePasswordHash(p1, out PasswordHash, out PasswordSalt);
                driver.DriverPasswordHash = PasswordHash;
                driver.DriverPasswordSalt = PasswordSalt;
                DriverUpdate(driver);
                return true;
            }
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
