using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.ViewModels
{
    public class ChangePasswordViewModel
    {
        public string oldpassword { get; set; }
        public string password1 { get; set; }
        public string password2 { get; set; }
    }
}
