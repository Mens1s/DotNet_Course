using System.ComponentModel.DataAnnotations;
using Northwind.Business.Abstract;
using Northwind.Business.Utilities;
using Northwind.Business.ValidationRules.FluentValidation;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.Entities.Concrete;

namespace Northwind.Business.Concrete.EntityFramework;

public class ProductManager : IProductService
{
    private IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }
    
    public List<Product> GetAll()
    {
        // Business rules.
        return _productDal.GetAll();
    }

    public List<Product> GetProductsByCategory(int categoryId)
    {
        return _productDal.GetAll(p => p.category_id == categoryId);
    }

    public List<Product> GetProductsByName(string productName)
    {
        return _productDal.GetAll(p => p.product_name.ToLower().Contains(productName.ToLower()));
    }

    public void AddProduct(Product product)
    {
        ValidationTool.Validate(new ProductValidator(), product);
        _productDal.Add(product);
    }

    public void UpdateProduct(Product product)
    {
        ValidationTool.Validate(new ProductValidator(), product);
        _productDal.Update(product);
    }

    public void DeleteProduct(Product product)
    {
        ValidationTool.Validate(new ProductValidator(), product);
        _productDal.Delete(product);
    }
}