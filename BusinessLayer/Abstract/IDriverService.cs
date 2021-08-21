﻿using EntityLayer.Concrete;
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
        Driver GetByID(int id);
    }
}
