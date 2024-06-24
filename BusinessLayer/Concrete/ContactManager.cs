using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
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
        IContactDal _iContactDal;

        public ContactManager(IContactDal iContactDal)
        {
            _iContactDal = iContactDal;
        }

        public void ContactAdd(Contact p)
        {
            _iContactDal.Insert(p);
        }

        public void ContactDelete(Contact p)
        {
            _iContactDal.Delete(p);
        }

        public void ContactUpdate(Contact p)
        {
            _iContactDal.Update(p);
        }

        public Contact GetByID(int id)
        {
            return _iContactDal.Get(x => x.ContactID ==  id);
        }

        public List<Contact> GetList()
        {
           return _iContactDal.List();
        }
    }
}
