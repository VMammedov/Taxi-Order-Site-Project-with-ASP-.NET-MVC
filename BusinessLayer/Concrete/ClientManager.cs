using BusinessLayer.Abstract;
using BusinessLayer.Utilities;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ClientManager : IClientService
    {
        IClientDal _clientDal;

        public ClientManager(IClientDal clientDal)
        {
            _clientDal = clientDal;
        }

        public void ClientAdd(Client client)
        {
            _clientDal.Insert(client);
        }

        public void ClientDelete(Client client)
        {
            client.ClientStatus = false;
            _clientDal.Update(client);
        }

        public void ClientUpdate(Client client)
        {
            _clientDal.Update(client);
        }

        public Client GetByID(int id)
        {
            return _clientDal.Get(x => x.ClientID == id);
        }

        public List<Client> GetList()
        {
            return _clientDal.List();
        }

        public List<Client> GetListByClient(int id)
        {
            return _clientDal.List(x => x.ClientID == id);
        }

        public List<Client> GetListBySearch(string p)
        {
            if (string.IsNullOrEmpty(p))
                return _clientDal.List();
            else
                return _clientDal.List(x => x.ClientName.Contains(p));
        }

        public void ChangePassword(Client client, ChangePasswordViewModel passwordViewModel)
        {
            byte[] PasswordHash, PasswordSalt;
            HashingHelper.CreatePasswordHash(passwordViewModel.password1, out PasswordHash, out PasswordSalt);
            client.ClientPasswordHash = PasswordHash;
            client.ClientPasswordSalt = PasswordSalt;
            ClientUpdate(client);
        }

        public void AdmChangePassword(Client client, AdmChangePasswordViewModel passwordViewModel)
        {
            byte[] PasswordHash, PasswordSalt;
            HashingHelper.CreatePasswordHash(passwordViewModel.password1, out PasswordHash, out PasswordSalt);
            client.ClientPasswordHash = PasswordHash;
            client.ClientPasswordSalt = PasswordSalt;
            ClientUpdate(client);
        }

        public int GetSessionID(string p)
        {
            int value = _clientDal.List(x => x.ClientMail == p).Select(y => y.ClientID).FirstOrDefault();
            return value;
        }

    }
}
