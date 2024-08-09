namespace FunctionAndActions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Action void functions
            // Func is a function can be returnable
            Func<int, int, int> func = Topla;
            Console.WriteLine(func(3,5));

            Func<int> rand = delegate()
            {
                Random random = new Random();
                return random.Next(1, 100);
            };

            Func<int> rand2 = () => new Random().Next(1, 100);
            
            Console.WriteLine(rand());
            Console.WriteLine(rand2());
        }

        static int Topla(int x, int y)
        {
            return x + y;
        }

      
    }
}