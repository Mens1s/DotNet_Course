namespace Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(10);
            CustomerManager customerManager2 = new CustomerManager(10);
            CustomerManager customerManager3 = new CustomerManager();
            customerManager.List();

            Product product = new Product(1, "Good falls");
            Product product2 = new Product();

            EmployeeManager employeeManager = new EmployeeManager(new FileLogger());
            employeeManager.Add();

            PersonManager personManager = new PersonManager("test");
            personManager.Add();

            Teacher.Number = 10;

            Teacher.Number++;
            
            Utilities.Validate();
            
            Manager.DoSomething();
            Manager manager = new Manager();
            manager.DoSomething2();
            // not valid manager.DoSomething();
        }
    }

    class CustomerManager
    {
        private int _count;
        private static int _customerCount = 0;
        public CustomerManager(int count)
        {
            _count = count;
            _customerCount++;
        }
        
        public CustomerManager()
        {
            _count = 15;
            _customerCount++;
        }
        public void List()
        {
            Console.WriteLine("Listed! {0}. Total count {1}", _count, _customerCount);
        }

        public void Add()
        {
            Console.WriteLine("Added.");
        }
    }

    class Product
    {
        public Product()
        {
            
        }

        public Product(int id, string name)
        {
            _id = id;
            _name = name;
        }

        private int _id;
        private string _name;

        public int Id
        {
            get { return _id; }
            set
            {
                if (value < 0) throw new ArgumentException("Id must be greater than 0");
                _id = value;
            }
        }
        public string Name { 
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Name cannot be null or white space");
                _name = value;
            } 
        }
    }

    interface ILogger
    {
        void Log();
    }
    
    class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("DB logged.");
        }
    }
    
    class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("File logged.");
        }
    }

    class EmployeeManager
    {
        private ILogger _logger;
        public EmployeeManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Add()
        {
            _logger.Log();
            Console.WriteLine("Added.");
        }
    }

    class BaseClass
    {
        private string _entity;

        public BaseClass(string entity)
        {
            _entity = entity;
        }
        public void Message()
        {
            Console.WriteLine("{0} message.",_entity);
        }
    }

    class PersonManager : BaseClass
    {
        public PersonManager(string entity) : base(entity)
        {
        }

        public void Add()
        {
            Message();
        }
    }

    static class Teacher
    {
        public static int Number { get; set; }
    }

    static class Utilities
    {
        static Utilities()
        {
            Console.WriteLine("First Code To RUN when it first occurs!");
        }
        public static void Validate()
        {
            Console.WriteLine("Validate is done.");
        }
    }

    class Manager
    {
        public static void DoSomething()
        {
            Console.WriteLine("Doing something1.");
        }

        public void DoSomething2()
        {
            Console.WriteLine("Doing something2.");
        }
    }
}