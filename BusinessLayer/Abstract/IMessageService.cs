using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox(string p);
        List<Message> GetListSendbox();

        void MessageAdd(Message p);
        Message GetByID(int id);
        void MessageDelete(Message p);
        void MessageUpdate(Message p);
        void MarkAsRead(Message p);
    }
}
