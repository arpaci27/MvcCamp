using DataAccesLayer.Concrete;

using EntityLayer.Concrete;

using DataAccesLayer.Abstract;
using System.Linq.Expressions;

namespace DataAccesLayer.EntityFramework
{
    public class EfAboutDal : GenericRepository<About>, IAboutDal
    {
        public EfAboutDal(Context context) : base(context)
        {
        }
    }
}
