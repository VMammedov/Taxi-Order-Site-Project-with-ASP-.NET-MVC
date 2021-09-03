using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICarTypeService
    {
        List<CarType> GetList();
        void CarTypeAdd(CarType carType);
        void CarTypeDelete(CarType carType);
        void CarTypeUpdate(CarType carType);
        CarType GetByID(int id);
    }
}
