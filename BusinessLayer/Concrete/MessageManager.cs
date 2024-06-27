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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetListInbox()
        {
            return _messageDal.List(x=>x.ReceiverMail =="admin@gmail.com");  
        }
        public List<Message> GetListSendbox()
        {
            return _messageDal.List(x => x.SenderMail == "admin@gmail.com");
        }
        public void MessageAdd(Message p)
        {
            _messageDal.Insert(p);
        }

        public void MessageDelete(Message p)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message p)
        {
            throw new NotImplementedException();
        }
    }
}
