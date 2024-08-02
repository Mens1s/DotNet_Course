namespace VirtualMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlServer sqlServer = new SqlServer();
            MySql mySql = new MySql();
            
            sqlServer.Add();
            mySql.Add();
        }
    }

    class Database
    {
        public virtual void Add()
        {
            Console.WriteLine("Added By Default.");
        }

        public virtual void Delete()
        {
            Console.WriteLine("Deleted By Default.");
        }
    }

    class SqlServer:Database
    {
        public override void Add()
        {
            Console.WriteLine("SQL SERVER ADDED...");
            //base.Add();
        }
    }

    class MySql : Database
    {
        
    }
}