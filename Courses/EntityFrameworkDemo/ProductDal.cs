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
        
        public List<Product> GetByName(string name)
        {
            using (AdonetContext context = new AdonetContext())
            {
                // linq - it is working as sql query where like %key
                return context.Products.Where(p=>p.Name.Contains(name)).ToList();;
            }
        }
        
        // min to higher
        public List<Product> GetByUnitPrice(decimal price)
        {
            using (AdonetContext context = new AdonetContext())
            {
                // linq - it is working as sql query where like %key
                return context.Products.Where(p=>p.UnitPrice >= price).ToList();;
            }
        }
        
        public List<Product> GetByBetweenUnitPrice(decimal minPrice, decimal maxPrice)
        {
            using (AdonetContext context = new AdonetContext())
            {
                // linq - it is working as sql query where like %key
                return context.Products.Where(p=>p.UnitPrice >= minPrice && p.UnitPrice <= maxPrice).ToList();;
            }
        }

        public Product GetById(int id)
        {
            using (AdonetContext context = new AdonetContext())
            {
                // linq - it is working as sql query where like %key
                return context.Products.FirstOrDefault(p=>p.Id == id);;
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
