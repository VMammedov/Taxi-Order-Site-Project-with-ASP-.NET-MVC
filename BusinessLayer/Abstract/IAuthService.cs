using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAuthService
    {
        void ClientRegister(string userName, string userSurName, string userMail, string userPassword, string userPhone, string userProffesion, string Sex);
        void DriverRegister(string userName, string userSurName, string userMail, string userPassword, string userPhone, string userProffesion, string Sex);
        void AdminRegister(string AdminName, string AdminMail, string AdminPassword, string AdminRole);
        bool ClientLogin(ClientLoginDto clientLoginDto);
        bool DriverLogin(DriverLoginDto driverLoginDto);
        bool AdminLogin(AdminLoginDto adminLoginDto);
    }
}
