﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void ContactAdd(Contact contact)
        {
            _contactDal.Insert(contact);
        }

        public void ContactDelete(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void ContactUpdate(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Contact GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetList()
        {
            throw new NotImplementedException();
        }
    }
}