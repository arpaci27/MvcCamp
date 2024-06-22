using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework
{
    public class EfContentDal : GenericRepository<Content>, IContentDal
    {
        public EfContentDal(Context context) : base(context)
        {

        }

    }
}
