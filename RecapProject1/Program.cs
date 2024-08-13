namespace RecapProject1
{
    class Program
    {
        static void Main(string[] args)
        {
            Load();
        }

        static void Load()
        {
            //ListProductByCategoryId(6);
            //ListProductByName("F");
            ListProductByNameAndByCategoryId("f",5);
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

        private static void ListProducts()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                foreach (var product in context.Products)
                {
                    Console.Write($"{TruncateOrPad(product.product_id.ToString(), 5)}\t");
                    Console.Write($"{TruncateOrPad(product.product_name, 10)}\t");
                    Console.Write($"{TruncateOrPad(product.category_id.ToString(), 10)}\t");
                    Console.Write($"{TruncateOrPad(product.units_in_stock.ToString(), 10)}\t");
                    Console.Write($"{TruncateOrPad(product.quantity_per_unit, 10)}\t");
                    Console.Write($"{TruncateOrPad(product.unit_price.ToString(), 10)}\t");
                    Console.WriteLine();
                }
            }
        }

        private static void ListCategories()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                foreach (var category in context.Categories)
                {
                    Console.WriteLine($"{TruncateOrPad(category.category_name,25)}");
                }
            }
        }

        private static void ListProductByCategoryId(int categoryId)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                foreach (var product in context.Products.Where(p => p.category_id == categoryId))
                {
                    Console.Write($"{TruncateOrPad(product.product_id.ToString(), 5)}\t");
                    Console.Write($"{TruncateOrPad(product.product_name, 10)}\t");
                    Console.Write($"{TruncateOrPad(product.category_id.ToString(), 10)}\t");
                    Console.Write($"{TruncateOrPad(product.units_in_stock.ToString(), 10)}\t");
                    Console.Write($"{TruncateOrPad(product.quantity_per_unit, 10)}\t");
                    Console.Write($"{TruncateOrPad(product.unit_price.ToString(), 10)}\t");
                    Console.WriteLine();
                }
            }
        }

        private static void ListProductByName(string name)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                foreach (var product in context.Products.Where(p => p.product_name.ToLower().Contains(name.ToLower())))
                {
                    Console.Write($"{TruncateOrPad(product.product_id.ToString(), 5)}\t");
                    Console.Write($"{TruncateOrPad(product.product_name, 10)}\t");
                    Console.Write($"{TruncateOrPad(product.category_id.ToString(), 10)}\t");
                    Console.Write($"{TruncateOrPad(product.units_in_stock.ToString(), 10)}\t");
                    Console.Write($"{TruncateOrPad(product.quantity_per_unit, 10)}\t");
                    Console.Write($"{TruncateOrPad(product.unit_price.ToString(), 10)}\t");
                    Console.WriteLine();
                }
            }
        }

        private static void ListProductByNameAndByCategoryId(string name, int categoryId)
        {
            if (name.Length == 0)
            {
                ListProductByCategoryId(categoryId);
            }
            else
            {
                using (NorthwindContext context = new NorthwindContext())
                {
                    foreach (var product in context.Products.Where(p =>
                                 p.product_name.ToLower().Contains(name.ToLower()) && p.category_id== categoryId))
                    {
                        Console.Write($"{TruncateOrPad(product.product_id.ToString(), 5)}\t");
                        Console.Write($"{TruncateOrPad(product.product_name, 45)}\t");
                        Console.Write($"{TruncateOrPad(product.category_id.ToString(), 10)}\t");
                        Console.Write($"{TruncateOrPad(product.units_in_stock.ToString(), 10)}\t");
                        Console.Write($"{TruncateOrPad(product.quantity_per_unit, 10)}\t");
                        Console.Write($"{TruncateOrPad(product.unit_price.ToString(), 10)}\t");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}