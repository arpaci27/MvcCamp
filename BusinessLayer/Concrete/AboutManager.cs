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
            throw new NotImplementedException();
        }

        public void AboutDelete(About p)
        {
            throw new NotImplementedException();
        }

        public void AboutUpdate(About p)
        {
            throw new NotImplementedException();
        }

        public About GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<About> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
