using Northwind.Business.Abstract;
using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;

namespace Northwind.Business.Concrete.EntityFramework;

public class CategoryManager: ICategoryService
{
    private ICategoryDal _categoryDal;

    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }


    public List<Category> GetAll()
    {
        return _categoryDal.GetAll();
    }
}