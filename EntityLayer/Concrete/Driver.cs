using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Driver
    {
        [Key]
        public int DriverID { get; set; }

        [StringLength(40)]
        public string DriverName { get; set; }

        [StringLength(50)]
        public string DriverSurName { get; set; }

        [StringLength(25)]
        public string CarType { get; set; }

        [Phone, StringLength(20)]
        public string DriverNumber { get; set; }

        [StringLength(80)]
        public string DriverProfession { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(60)]
        public string DriverMail { get; set; }

        public byte[] DriverPasswordHash { get; set; }

        public byte[] DriverPasswordSalt { get; set; }

        [StringLength(350)]
        public string DriverAbout { get; set; }

        [StringLength(8)]
        public string Sex { get; set; }

        [StringLength(300)]
        public string DriverImage { get; set; }

        public bool DriverStatus { get; set; }

        public virtual ICollection<Order> Order { get; set; }

    }
}
