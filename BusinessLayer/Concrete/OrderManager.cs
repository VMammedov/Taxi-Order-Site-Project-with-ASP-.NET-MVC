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
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public Order GetByID(int id)
        {
            return _orderDal.Get(x => x.OrderID == id);
        }

        public List<Order> GetListBySearch(string p)
        {
            if (string.IsNullOrEmpty(p))
                return _orderDal.List();
            else
                return _orderDal.List(x => x.Client.ClientName.Contains(p));
        }

        public List<Order> GetListWaitingOrders()
        {
            return _orderDal.List(x=>x.OrderStatus=="W");
        }

        public List<Order> GetListOngoingOrders()
        {
            return _orderDal.List(x => x.OrderStatus == "C");
        }

        public List<Order> GetListFinishedOrders()
        {
            return _orderDal.List(x => x.OrderStatus == "F");
        }

        public void OrderAdd(Order order)
        {
            _orderDal.Insert(order);
        }

        public void OrderDelete(Order order)
        {
            order.OrderStatus = "P";
            _orderDal.Update(order);
        }

        public void OrderUpdate(Order order)
        {
            _orderDal.Update(order);
        }

        public void SetOrderDetails(ref Order order, Client client)
        {
            order.OrderStatus = "W";
            order.ClientID = client.ClientID;
            order.Number = client.ClientNumber;
            order.OrderDate = DateTime.Parse(DateTime.Now.ToString());
        }
    }
}
