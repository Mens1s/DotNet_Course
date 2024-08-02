namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonManager personManager = new PersonManager();
            Customer customer = new Customer
                { Id = 1, Address = "tatil köyü", FirstName = "ahmet", LastName = "mens1s" };
            Student student = new Student
                { Department = "CENG", FirstName = "Ahmet", LastName = "Mens1s", Id = 1 };
            Worker worker = new Worker
                { Company = "VKBank", FirstName = "Ahmet", LastName = "Mens1s", Id = 1 };    
            personManager.Add(customer);
            personManager.Add(student);
            
            CustomerManager customerManager = new CustomerManager();
            customerManager.Add(new SqlServerCustomerDal());

            ICustomerDal[] customerDals = new ICustomerDal[2]
            {
                new OracleServerCustomerDal(),
                new SqlServerCustomerDal()
            };

            foreach (var customerDal in customerDals)
            {
                customerDal.Add();
            }
        } 
    }

    interface IPerson
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }

    class Customer : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public String Address { get; set; }
    }

    class Student : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
    }
    
    class Worker : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
    }
    

    class PersonManager
    {
        public void Add(IPerson person)
        {
            Console.WriteLine(person.FirstName);
        }
    }
}