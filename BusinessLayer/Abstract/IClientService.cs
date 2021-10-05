using EntityLayer.Concrete;
using EntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IClientService
    {
        List<Client> GetList();
        List<Client> GetListBySearch(string p);
        List<Client> GetListByClient(int id);
        int GetSessionID(string p);
        void ClientAdd(Client client);
        void ClientDelete(Client client);
        void ClientUpdate(Client client);
        void ChangePassword(Client client, ChangePasswordViewModel passwordViewModel);
        void AdmChangePassword(Client client, AdmChangePasswordViewModel passwordViewModel);
        Client GetByID(int id);
    }
}
