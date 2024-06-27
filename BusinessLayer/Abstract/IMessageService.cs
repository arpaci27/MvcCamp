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
        List<Message> GetList();
        void MessageAdd(Message p); 
        Message GetByID(int id);
        void MessageDelete(Message p);
        void MessageUpdate(Message p);
    }
}
