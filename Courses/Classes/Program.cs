namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            ProductManager productManager = new ProductManager();
            customerManager.Add();
            productManager.Update();

            Customer customer = new Customer
            {
                City = "Ankara",
                FirstName = "Ahmet",
                LastName = "Mens1s",
                Id = 1
            };

            Console.WriteLine(customer.FirstName);
            customer.FirstName = "Admin";
            Console.WriteLine(customer.FirstName);
        }
    }
}