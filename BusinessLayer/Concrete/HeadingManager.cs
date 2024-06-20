using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        Context _context = new Context();
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public Heading GetByID(int id)
        {
            return _headingDal.Get(x => x.HeadingID == id); 
        }

        public List<Heading> GetList()
        {
            return _headingDal.List().Select(h => new Heading
            {
                HeadingID = h.HeadingID,
                HeadingName = h.HeadingName,
                HeadingDate = h.HeadingDate,
                CategoryID = h.CategoryID,
                Category = _context.Categories.FirstOrDefault(c => c.CategoryID == h.CategoryID)
            }).ToList();
        }

        public void HeadingAdd(Heading p)
        {
             _headingDal.Insert(p);
        }

        public void HeadingDelete(Heading p)
        {
            _headingDal.Delete(p);
        }

        public void HeadingUpdate(Heading p)
        {
            _headingDal.Update(p);
        }
    }
}
