namespace CSharpBeginner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mens1s ONE DAY Course");
            
            // variables
            const int num1 = 11;
            const long num2 = 12;
            const short num3 = 13;
            const byte num4 = 14;
            const bool isT = false;
            const char c = 'c';
            const double num5 = 15.5;
            const decimal num6 = 16.41561m;

            var num7 = 10;
            num7 = 'a'; // it is not problem ascii
            // ERROR: num7 = 12;
            
            Console.WriteLine("Enum : {0}:{1}", Days.Cm, (int) Days.Cm + 1);
            Console.WriteLine("num1 : {0}", num1);
            
            // Conditions
            Console.WriteLine(num1 == 10 ? "Number is 10" : "Number is not 10");

            if (num2 == 11)
            {
                Console.WriteLine("Number is 11");
            }
            else if (num2 == 12)
            {
                Console.WriteLine("Number is 12");
            }
            else
            {
                Console.WriteLine("Number is not 11 or 12");
            }

            switch (num2)
            {
                case 11:
                    Console.WriteLine("Number is 12");
                    break;
                case 12:
                    Console.WriteLine("Number is 12");
                    break;
                default:
                    Console.WriteLine("Number is not 11 or 12");
            }
            
            // methods & functions
            Console.WriteLine("Function Result: " + Add(2,3));
            Console.WriteLine("Function Result: " + Add(b:3));

            int referenceA = 10;
            int referenceBNot = 20;
            
            Console.WriteLine("a:"+referenceA+"b"+referenceBNot);
            RefChanger(ref referenceA, referenceBNot);            
            Console.WriteLine("a:"+referenceA+"b"+referenceBNot);
            OutChanger(out referenceA, referenceBNot);            
            Console.WriteLine("a:"+referenceA+"b"+referenceBNot);
            
            Console.WriteLine(Multiply(2,5));
            Console.WriteLine(Multiply(2,5, 3));

            Console.WriteLine(AddRandomNumbers(1,2,3,4,5,6,312,7,8,9));
            
            // arrays collections
            string[] students = new string[3];
            string[] students1 = new []{"TEST", "TEST1", "TEST2"};
            string[] students2 = {"TEST", "TEST1", "TEST2"};
            
            students[0] = "ahmet";
            students[1] = "ahmet1";
            students[2] = "ahmet2";

            foreach (var VARIABLE in students)
            {
                Console.WriteLine(VARIABLE);
            }

            string[,] regions = new string[5, 3]
            {
                {"t1","t3","t6" },
                {"t4","t5","t4" },
                {"t5","t6","t2" },
                {"t5","t4","t3" },
                {"t6","t7","t9" }
            };
            int i = 1;

            for (i = 0; i <= regions.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= regions.GetUpperBound(1); j++)
                {
                    Console.WriteLine(regions[i,j]);
                }
            }
            
            // loops
            for (i = 1; i < 10; i = i * 2)
            {
                Console.WriteLine(i);
            }

            i = 1;
            while (i < 10)
            {
                Console.WriteLine(i);
                i *= 2;
            }

            i = 1;
            do
            {
                Console.WriteLine(i);
                i *= 2;
            } while (i < 10);

            int upper = 47;

            bool isPrime = true;
            for (i = 2; i < upper; i++)
            {
                if (upper % i == 0)
                {
                    isPrime = false;
                    i = upper;
                }
            }

            if (!isPrime || upper < 2)
            {
                Console.WriteLine("Not prime!");
            }
            else
            {
                Console.WriteLine("Prime.");
            }
            
            // strings
            string words = "Words are realy bad things, are you okay?";

            int len = words.Length;
            var clone = words.Clone();
            
            bool end = words.EndsWith("k");
            bool start = words.StartsWith("Words");

            int index = words.IndexOf("are");
            int indexLast = words.LastIndexOf("are");

            var added = words.Insert(0, "Hello");
            var subString = words.Substring(5);
            
            
        }

        static int Add(int a=10, int b=30)
        {
            Console.WriteLine("Result = " + (a + b));
            return a + b;
        }

        static void RefChanger(ref int a, int b)
        {
            a = 100;
            b = 200;
        }
         
        static void OutChanger(out int a, int b)
        {
            a = 10; // a must be initialized or assigned
            b = 20;
        }

        static int Multiply(int a, int b)
        {
            return a * b;
        }
            
        static int Multiply(int a, int b, int c)
        {
            return a * b * c;
        }

        static int AddRandomNumbers(params int[] arr)
        {
            return arr.Sum();
        }
    }

    enum Days
    {
        Pzt,Sal,Crs,Prs,Cm,Cmt,Pzr
    }
}
