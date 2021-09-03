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
    public class CarTypeManager : ICarTypeService
    {
        ICarTypeDal _carTypeDal;

        public CarTypeManager(ICarTypeDal carTypeDal)
        {
            _carTypeDal = carTypeDal;
        }

        public void CarTypeAdd(CarType carType)
        {
            throw new NotImplementedException();
        }

        public void CarTypeDelete(CarType carType)
        {
            throw new NotImplementedException();
        }

        public void CarTypeUpdate(CarType carType)
        {
            throw new NotImplementedException();
        }

        public CarType GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<CarType> GetList()
        {
            return _carTypeDal.List();
        }
    }
}
