using System.Data;

namespace AdoNetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDal productDal = new ProductDal();

            List<Product> products = productDal.GetAll();
            
            products.ForEach(product =>
            {
                Console.Write($"{TruncateOrPad(product.Id.ToString(), 11)}\t");
                Console.Write($"{TruncateOrPad(product.Name, 11)}\t");
                Console.Write($"{TruncateOrPad(product.UnitPrice.ToString(), 11)}\t");
                Console.Write($"{TruncateOrPad(product.StockAmount.ToString(), 11)}\t");
                Console.WriteLine();
            });
            
            // early to early times
            DataTable table = productDal.GetAll2();
            
            foreach (DataColumn column in table.Columns)
            {
                Console.Write($"{TruncateOrPad(column.ColumnName, 11)}\t");
            }
            Console.WriteLine();

            foreach (DataRow row in table.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write($"{TruncateOrPad(item.ToString(), 11)}\t");
                }
                Console.WriteLine();
            }
            
            // add data
            Product newProduct = new Product
            {
                Name = "Toplama Bilgisayar",
                StockAmount = 23,
                UnitPrice = 5999
            };

            //productDal.Add(newProduct);
            
            // update
            newProduct.Id = 4;
            newProduct.UnitPrice = 4999;
            productDal.Update(newProduct);
            
            // delete
            productDal.Delete(newProduct.Id);
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