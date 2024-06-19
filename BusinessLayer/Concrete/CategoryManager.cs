using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryDal _categoryDal;

    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }

    public List<Category> GetList()
    {
        return _categoryDal.List();
    }

    public void CategoryAdd(Category p)
    {
        _categoryDal.Insert(p);
    }

    public Category GetById(int id)
    {
        return _categoryDal.Get(x => x.CategoryID == id);
    }

    public void CategoryDelete(Category p)
    {
        _categoryDal.Delete(p);
    }

    Category ICategoryService.GetByID(int id)
    {
        return _categoryDal.Get(x => x.CategoryID == id);

    }

    public void CategoryUpdate(Category p)
    {
        _categoryDal.Update(p);
    }

    void ICategoryService.CategoryUpdate(Category p)
    {
        throw new NotImplementedException();
    }
}
