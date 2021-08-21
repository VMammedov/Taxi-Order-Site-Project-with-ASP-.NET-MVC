using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class LuggageTransfer
    {
        public int OrderID { get; set; }
        public int? DriverID { get; set; }
        public int ClientID { get; set; }

        [StringLength(100)]
        public string NameSurName { get; set; }

        [StringLength(50)]
        public string LuggageType { get; set; }

        [StringLength(150)]
        public string PickUpLocation { get; set; }

        [StringLength(150)]
        public string DropLocation { get; set; }

        public double LuggageAmount { get; set; }

        [Phone, StringLength(20)]
        public string Number { get; set; }

        [StringLength(1)]
        public string OrderStatus { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime PickUpTime { get; set; }
    }
}
