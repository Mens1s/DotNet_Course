using Northwind.Entities.Concrete;

namespace Northwind.Business.Abstract;

public interface IProductService
{
    public List<Product> GetAll();
    public List<Product> GetProductsByCategory(int categoryId);
}