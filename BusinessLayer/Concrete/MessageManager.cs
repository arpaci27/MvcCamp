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
            return _messageDal.Get(x => x.MessageID == id);
        }

        public List<Message> GetListInbox(string p)
        {
            return _messageDal.List(x=>x.ReceiverMail == p);  
        }
        public List<Message> GetListSendbox()
        {
            return _messageDal.List(x => x.SenderMail == "arpaci.omer2@gmail.coö");
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
            _messageDal.Update(p);
        }

        public void MarkAsRead(int messageId)
        {
            var message = _messageDal.Get(x => x.MessageID == messageId);
            if (message != null && message.Unread)
            {
                message.Unread = false;
                _messageDal.Update(message);
            }
        }

        void IMessageService.MarkAsRead(Message p)
        {
            throw new NotImplementedException();
        }
    }
}
