using BusinessLayer.Abstract;
using BusinessLayer.Utilities;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthManager : IAuthService
    {
        IClientService _clientService;
        IDriverService _driverService;
        IAdminService _adminService;

        public AuthManager(IClientService clientService, IDriverService driverService, IAdminService adminService)
        {
            _clientService = clientService;
            _driverService = driverService;
            _adminService = adminService;
    }

        public bool AdminLogin(AdminLoginDto adminLoginDto)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                var adminvalue = _adminService.GetList();
                foreach (var item in adminvalue)
                {
                    if (HashingHelper.VerifyPasswordHash(adminLoginDto.AdminPassword1, item.AdminPasswordHash, item.AdminPasswordSalt))
                    {
                        return true;
                    }
                }
                return false;
            }    
        }

        public void AdminRegister(string AdminName, string AdminMail, string AdminPassword, string AdminRole)
        {
            byte[] PasswordHash, PasswordSalt;
            HashingHelper.CreatePasswordHash(AdminPassword, out PasswordHash, out PasswordSalt);
            Admin admin = new Admin
            {
                AdminMail = AdminMail,
                AdminName = AdminName,
                AdminPasswordHash = PasswordHash,
                AdminPasswordSalt = PasswordSalt,
                AdminRole = AdminRole,
                AdminStatus = true
            };
            _adminService.AdminAdd(admin);
        }

        public bool ClientLogin(ClientLoginDto clientLoginDto)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                var clientvalue = _clientService.GetList();
                foreach (var item in clientvalue)
                {
                    if (HashingHelper.VerifyPasswordHash(clientLoginDto.Password1, item.ClientPasswordHash, item.ClientPasswordSalt) && clientLoginDto.Email==item.ClientMail && item.ClientStatus==true)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public void ClientRegister(string userName, string userSurName, string userMail, string userPassword, string userPhone, string userProffesion, string Sex)
        {
            byte[] PasswordHash, PasswordSalt;
            HashingHelper.CreatePasswordHash(userPassword, out PasswordHash, out PasswordSalt);
            var client = new Client
            {
                ClientName = userName,
                ClientSurName = userSurName,
                ClientMail = userMail,
                ClientPasswordHash = PasswordHash,
                ClientPasswordSalt = PasswordSalt,
                ClientNumber = userPhone,
                ClientProfession = userProffesion,
                Sex = Sex,
                ClientStatus = true
            };
            _clientService.ClientAdd(client);
        }

        public bool DriverLogin(DriverLoginDto driverLoginDto)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                var drivervalue = _driverService.GetList();
                foreach (var item in drivervalue)
                {
                    if (HashingHelper.VerifyPasswordHash(driverLoginDto.Password1, item.DriverPasswordHash, item.DriverPasswordSalt) && driverLoginDto.Email==item.DriverMail && item.DriverStatus==true)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public void DriverRegister(string userName, string userSurName, string userMail, string userPassword, string userPhone, string userProffesion, string Sex)
        {
            byte[] PasswordHash, PasswordSalt;
            HashingHelper.CreatePasswordHash(userPassword, out PasswordHash, out PasswordSalt);
            var driver = new Driver
            {
                DriverName = userName,
                DriverSurName = userSurName,
                DriverMail = userMail,
                DriverPasswordHash = PasswordHash,
                DriverPasswordSalt = PasswordSalt,
                DriverNumber = userPhone,
                DriverProfession = userProffesion,
                Sex = Sex,
                DriverStatus = false
            };
            _driverService.DriverAdd(driver);
        }
    }
}
