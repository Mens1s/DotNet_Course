namespace AbstractClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Oracle();
            Database database2 = new SqlServer();
            
            database.Delete();
            database2.Delete();
        }
    }

    abstract class Database
    {
        public void Add()
        {
            Console.WriteLine("Added by default.");
        }

        public abstract void Delete();
    }
    
    class SqlServer : Database
    {
        public override void Delete()
        {
            Console.WriteLine("Deleted by override. SqlServer");
        }
    }

    class Oracle : Database
    {
        public override void Delete()
        {
            Console.WriteLine("Deleted by override. Oracle.");
        }
    }
}