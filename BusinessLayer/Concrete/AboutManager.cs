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
    public class AboutManager : IAboutService    
    {
        IAboutDal _iaboutDal;

        public AboutManager(IAboutDal iaboutDal)
        {
            _iaboutDal = iaboutDal;
        }

        public void AboutAdd(About p)
        {
            _iaboutDal.Insert(p);
        }

        public void AboutDelete(About p)
        {
            _iaboutDal.Delete(p);
        }

        public void AboutUpdate(About p)
        {
            _iaboutDal.Update(p);
        }

        public About GetByID(int id)
        {
           return _iaboutDal.Get(x => x.AboutID == id);
        }

        public List<About> GetList()
        {
            return _iaboutDal.List();
        }
    }
}
