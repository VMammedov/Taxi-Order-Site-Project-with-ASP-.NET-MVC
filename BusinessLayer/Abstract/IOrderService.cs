using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IOrderService
    {
        List<Order> GetListFinishedOrders();
        List<Order> GetListOngoingOrders();
        List<Order> GetListWaitingOrders();
        List<Order> GetListBySearch(string p);
        List<Order> OrdersByClient(string ClientMail);
        List<Order> OrdersByDriver(string DriverMail);
        void SetOrderDetails(ref Order order, Client client);
        void OrderAdd(Order order);
        void OrderDelete(Order order);
        void OrderUpdate(Order order);
        Order GetByID(int id);
    }
}
