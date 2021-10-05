using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [StringLength(30)]
        public string AdminName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(60)]
        public string AdminMail { get; set; }

        [StringLength(300)]
        public string AdminImage { get; set; }

        public byte[] AdminPasswordHash { get; set; }
        public byte[] AdminPasswordSalt { get; set; }

        [StringLength(1)]
        public string AdminRole { get; set; }

        public bool AdminStatus { get; set; }
    }
}
