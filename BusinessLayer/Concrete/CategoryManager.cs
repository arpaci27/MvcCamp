using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }



        
        public List<Category> GetList()
        {
         return  _categoryDal.List();
        }


        public void CategoryAddBl(Category p)
        {
            if(p.CategoryName == "" || p.CategoryName.Length <= 3 || p.CategoryName.Length >= 51)
            {
                // hata mesajı
            }
            else
            {
                _categoryDal.Insert(p);
            }
        }

        public void CategoryAdd(Category p)
        {
            _categoryDal.Insert(p);
        }
    }
}
