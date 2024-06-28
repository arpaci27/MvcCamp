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
    public class EfImageFileDal : GenericRepository<ImageFile>, IIMageFileDal
    {
        public EfImageFileDal(Context context) : base(context)
        {
        }
    }
}
