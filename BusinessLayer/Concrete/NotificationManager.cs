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
    public class NotificationManager : INotificationService
    {
        INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public Notification GetByID(int id)
        {
            return _notificationDal.Get(x => x.NotificationID == id);
        }

        public List<Notification> GetListByClient(string Mail)
        {
            return _notificationDal.List(x => x.Order.Client.ClientMail == Mail);
        }

        public List<Notification> GetListByDriver(string Mail)
        {
            return _notificationDal.List(x => x.Order.Driver.DriverMail == Mail);
        }

        public void NotificationAdd(Notification notification)
        {
            _notificationDal.Insert(notification);
        }

        public void NotificationDelete(Notification notification)
        {
            _notificationDal.Update(notification);
        }

        public void NotificationSend(OrderNMessage orderNMessage)
        {
            Notification notification = new Notification();
            notification.NotificationTitle = "Order Received!";
            notification.NotificationTime = DateTime.Now;
            notification.NotificationContent = orderNMessage.message;
            notification.OrderID = orderNMessage.orderId;
            notification.NotificationStatus = true;
            _notificationDal.Insert(notification);
        }

        public void NotificationUpdate(Notification notification)
        {
            _notificationDal.Update(notification);
        }
    }
}
