using DataAccesLayer.Concrete;
using DataAccesLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {

        GenericRepository<Category> repo = new GenericRepository<Category>(new Context());
       
        public List<Category> GetAllBl()
        {
            return repo.List();
        }
        public void CategoryAddBl(Category p)
        {
            if(p.CategoryName == "" || p.CategoryName.Length <= 3 ||
                
                p.CategoryDescription == "" || p.CategoryName.Length >= 51)
            {
                // hata mesajı
            }
            else
            {
                repo.Insert(p);
            }
        }
    }
}
