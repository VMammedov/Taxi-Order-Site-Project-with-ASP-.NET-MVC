using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Order
    {
        public int OrderID { get; set; }
        public int? DriverID { get; set; }
        public int ClientID { get; set; }

        [StringLength(150)]
        public string PickUpLocation { get; set; }

        [StringLength(150)]
        public string DropLocation { get; set; }

        [StringLength(1)]
        public string OrderStatus { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime PickUpTime { get; set; }

        public virtual Client Client { get; set; }
        public virtual Driver Driver { get; set; }

        public int? CarTypeID { get; set; }
        public virtual CarType CarTypes { get; set; }
    }
}
