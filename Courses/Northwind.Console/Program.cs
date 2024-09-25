 using Northwind.Business.Abstract;
 using Northwind.Business.Concrete.EntityFramework;
 using Northwind.Business.DependencyResolvers.Ninject;
 using Northwind.DataAccess.Concrete.EntityFramework;

 class Program
{
    // dependency injection
    private static IProductService _productService = InstanceFactory.GetInstance<IProductService>();
    private static ICategoryService _categoryService = InstanceFactory.GetInstance<ICategoryService>();
    static void Main(string[] args)
    {
        Console.WriteLine(_productService.GetAll().First().product_name);
        Console.Write(_categoryService.GetAll().First().category_name); 
    }
}