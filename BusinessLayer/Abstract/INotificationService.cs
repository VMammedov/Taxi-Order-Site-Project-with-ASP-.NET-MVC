using BusinessLayer.Utilities;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface INotificationService
    {
        List<Notification> GetListByClient(string Mail);
        List<Notification> GetListByDriver(string Mail);
        void NotificationAdd(Notification notification);
        void NotificationSend(OrderNMessage orderNMessage);
        void NotificationDelete(Notification notification);
        void NotificationUpdate(Notification notification);
        Notification GetByID(int id);
    }
}
