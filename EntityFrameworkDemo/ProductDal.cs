using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo
{
    public class ProductDal
    {
        public List<Product> GetAll()
        {
            using (AdonetContext context = new AdonetContext())
            {
                return context.Products.ToList();;
            }
        }
        

        public void Add(Product product)
        {
            using (AdonetContext context = new AdonetContext())
            {
                //context.Products.Add(product);
                var entity = context.Entry(product);
                entity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            using (AdonetContext context = new AdonetContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Product product)
        {
            using (AdonetContext context = new AdonetContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
