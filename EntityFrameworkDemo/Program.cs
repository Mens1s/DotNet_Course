using System.Data;

namespace EntityFrameworkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDal productDal = new ProductDal();
            
            // get All
            List<Product> products = productDal.GetAll();
            products.ForEach(product =>
            {
                Console.Write($"{TruncateOrPad(product.Id.ToString(), 11)}\t");
                Console.Write($"{TruncateOrPad(product.Name, 11)}\t");
                Console.Write($"{TruncateOrPad(product.UnitPrice.ToString(), 11)}\t");
                Console.Write($"{TruncateOrPad(product.StockAmount.ToString(), 11)}\t");
                Console.WriteLine();
            });
            
            // insert
            Product newProduct = new Product
            {
                Name = "Toplama Bilgisayar",
                StockAmount = 23,
                UnitPrice = 5999
            };
            //productDal.Add(newProduct);
            newProduct.Id = 7;

            newProduct.UnitPrice = 5555;
            
            productDal.Update(newProduct);
            //productDal.Delete(newProduct);
        }
        private static string TruncateOrPad(string value, int maxLength)
        {
            if (value.Length > maxLength)
            {
                return value.Substring(0, maxLength); // Truncate if too long
            }
            else
            {
                return value.PadRight(maxLength); // Pad if too short
            }
        }
    }
}