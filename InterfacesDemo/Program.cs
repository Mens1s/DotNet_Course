namespace InterfacesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IWorker[] workers = new IWorker[3]
            {
                new Manager(),
                new Worker(),
                new Robot()
            };

            foreach (var worker in workers)
            {
                worker.Work();
                
                if (worker is IEat eat)
                    eat.Eat();
                
                if(worker is IGetSalary getSalary)
                    getSalary.GetSalary();
                
            }
            
        }

        interface IWorker
        {
            void Work();
        }

        interface IEat
        {
            void Eat();
        }

        interface IGetSalary
        {
            void GetSalary();
        }
        
        class Manager:IWorker, IEat, IGetSalary
        {
            public void Work()
            {
                Console.WriteLine("Manager Work.");
            }

            public void Eat()
            {
                Console.WriteLine("Manager Eat.");
            }

            public void GetSalary()
            {
                Console.WriteLine("Manager GetSalary.");
            }
        }

        class Worker : IWorker, IEat, IGetSalary
        {
            public void Work()
            {
                Console.WriteLine("Worker Work.");
            }

            public void Eat()
            {
                Console.WriteLine("Worker Eat.");
            }

            public void GetSalary()
            {
                Console.WriteLine("Worker GetSalary.");
            }
        }

        class Robot : IWorker
        {
            public void Work()
            {
                Console.WriteLine("Robot Work.");
            }
            
        }
    }
}