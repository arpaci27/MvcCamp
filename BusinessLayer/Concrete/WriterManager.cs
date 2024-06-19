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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;
        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }
        public Writer GetByID(int id)
        {
            return _writerDal.Get(x => x.WriterID == id);
        }

        public List<Writer> GetList()
        {
            return _writerDal.List();
        }

        public void WriterAdd(Writer p)
        {
            _writerDal.Insert(p);
        }

        public void WriterDelete(Writer p)
        {
           _writerDal.Delete(p);
        }

        public void WriterUpdate(Writer p)
        {
            _writerDal.Update(p);
        }
    }
}
