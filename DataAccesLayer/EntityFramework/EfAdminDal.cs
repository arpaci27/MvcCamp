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
    public class EfAdminDal: GenericRepository<Admin>, IAdminDal
    {
        public EfAdminDal(Context context) : base(context)
        { 
        }
    }
}
