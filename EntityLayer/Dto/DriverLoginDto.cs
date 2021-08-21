using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
    public class DriverLoginDto
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password1 { get; set; }
        public string Password2 { get; set; }
        public string Profession { get; set; }
        public string Sex { get; set; }
    }
}
