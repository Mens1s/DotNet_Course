using Ninject.Modules;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete.EntityFramework;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;

namespace Northwind.Business.DependencyResolvers.Ninject;

public class BusinessModule:NinjectModule
{
    public override void Load()
    {
        Bind<IProductService>().To<ProductManager>().InSingletonScope(); // tek bir kez üretir ve isteyen herkese aynısını verir performans
        Bind<IProductDal>().To<EfProductDal>().InSingletonScope(); // It creates a single instance of EfProductDal and shares it across all requests for IProductDal.

        Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
        Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();
    }
}