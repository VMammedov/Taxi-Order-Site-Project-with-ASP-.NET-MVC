using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }

        [StringLength(40)]
        public string ClientName { get; set; }

        [StringLength(50)]
        public string ClientSurName { get; set; }

        [Phone, StringLength(20)]
        public string ClientNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(60)]
        public string ClientMail { get; set; }

        public byte[] ClientPasswordHash { get; set; }

        public byte[] ClientPasswordSalt { get; set; }

        [StringLength(350)]
        public string ClientAbout { get; set; }

        [StringLength(8)]
        public string Sex { get; set; }

        [StringLength(300)]
        public string ClientImage { get; set; }

        [StringLength(80)]
        public string ClientProfession { get; set; }

        public bool ClientStatus { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
