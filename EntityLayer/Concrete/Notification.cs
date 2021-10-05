using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }

        [StringLength(50)]
        public string NotificationTitle { get; set; }

        [StringLength(300)]
        public string NotificationContent { get; set; }
        public DateTime NotificationTime { get; set; }
        public bool NotificationStatus { get; set; }
        public bool IsRead { get; set; }

        public int OrderID { get; set; }

        public virtual Order Order { get; set; }
    }
}
