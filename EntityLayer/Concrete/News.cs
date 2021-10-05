using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class News
    {
        [Key]
        public int NewsID { get; set; }

        [StringLength(50)]
        public string NewsHeading { get; set; }

        [StringLength(1000)]
        public string NewsValue { get; set; }

        [StringLength(300)]
        public string NewsImage { get; set; }

        public DateTime NewsDate { get; set; }

        public bool NewsStatus { get; set; }
    }
}
