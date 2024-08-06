
namespace Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer
            {
                Id=1,
                FirstName = "ahmet",
                LastName = "mens1s",
                Age = 22
            };

            CustomerDal customerDal = new CustomerDal();
            customerDal.Add(customer);
        }
    }

    [ToTable("Customers")]
    class Customer
    {
        public int Id { get; set; }
        [RequiredProperty]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    class CustomerDal
    {
        [Obsolete("Don't use Add, instead use AddNew method!")]
        public void Add(Customer customer)
        {
            Console.WriteLine(customer.Id + customer.FirstName + customer.LastName + customer.Age);
        }
        
        public void AddNew(Customer customer)
        {
            Console.WriteLine(customer.Id + customer.FirstName + customer.LastName + customer.Age);
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    class RequiredPropertyAttribute : Attribute
    {
         
    }
    
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    class ToTableAttribute : Attribute
    {
        private string _tableName;

        public ToTableAttribute(string tableName)
        {
            _tableName = tableName;
        }
        
    }
}