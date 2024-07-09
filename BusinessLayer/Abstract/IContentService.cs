using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();
        public List<Content> GetListBySearch(string p);
        public List<Content> GetListByWriter(int id);
        List<Content> GetListById(int id);
        void ContentAdd(Content p);
        public Content GetByID(int id);
        void ContentDelete(Content p);
        void ContentUpdate(Content p);
    }
}
