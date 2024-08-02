using System.Collections;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            // ArrayList
            ArrayList cities = new ArrayList();
            cities.Add("Ankara");
            cities.Add(123);
            cities.Add(new string[4] { "a", "a", "a", "a" });
            // not type safe
            
            // type safe
            
            // List
            List<string> brands = new List<string>();
            brands.Add("nike");
            brands.Add("adidas");

            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer());

            var count = customers.Count;
            customers.AddRange(new []{new Customer(), new Customer()});
            customers.Clear();
            Customer customer = new Customer() { Id = 2, Name = "Mens1s" };
            customers.Add(customer);
            var b = customers.Contains(customer);
            var fi = customers.IndexOf(customer);
            var li = customers.LastIndexOf(customer);
            customers.Insert(1, customer);
            customers.Remove(customer);
            customers.RemoveAll(c => c.Name == "Ahmet");
            
            // Dictionary
            Dictionary<int, string> city = new Dictionary<int, string>();
            city.Add(6, "Ankara");
            city.Add(1, "Adana");

            Console.WriteLine(city[6]);
            Console.WriteLine(city[1]);
            Console.WriteLine(city.ContainsKey(6));
            Console.WriteLine(city.ContainsValue("Ankara"));
        }
    }

    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}