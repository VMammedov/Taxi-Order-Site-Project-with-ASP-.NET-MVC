using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
    public class AdminLoginDto
    {
        public string AdminUserName { get; set; }

        public string AdminMail { get; set; }

        public string AdminPassword1 { get; set; }

        public string AdminPassword2 { get; set; }

        public string Role { get; set; }
    }
}
