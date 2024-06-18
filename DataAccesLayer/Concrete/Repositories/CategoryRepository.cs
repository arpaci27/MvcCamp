using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete.Repositories
{
    public class CategoryRepository : ICategoryDal
    {
        public void Delete(Category p)
        {
            throw new NotImplementedException();
        }

        public void Insert(Category p)
        {
            throw new NotImplementedException();
        }

        public List<Category> List()
        {
            throw new NotImplementedException();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Category p)
        {
            throw new NotImplementedException();
        }
    }
}
