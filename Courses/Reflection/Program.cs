namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            DortIslem dortIslem = new DortIslem();
            dortIslem.Topla(1, 2);
            dortIslem.Topla();
            */
            // Çalışma anında dinamik instance üretilmesi
            var type = typeof(DortIslem);

            DortIslem dortIslem = (DortIslem) Activator.CreateInstance(type, 1, 3);

            // 1
            Console.WriteLine(dortIslem.Topla());// if functions is void, compile error
            
            // 2
            var instance = Activator.CreateInstance(type, 1, 4);
            Console.WriteLine(instance.GetType().GetMethod("Topla").Invoke(instance, null));// if functions is void it prints nothing
            // if there is two same name functions ambiguous error 
            
            var methods = type.GetMethods();

            foreach (var methodInfo in methods)
            {
                Console.WriteLine("Method Name : " + methodInfo.Name);
                if (methodInfo.Name.Equals("Topla"))
                {
                    Console.WriteLine(methodInfo.Invoke(instance, null));
                }
            }
        }
    }

    class DortIslem
    {
        private int _sayi1;
        private int _sayi2;
        
        public DortIslem()
        { }
        
        public DortIslem(int sayi1, int sayi2)
        {
            _sayi1 = sayi1;
            _sayi2 = sayi2;
        }
        
        public int Topla2(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        } 
        
        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        } 
        
        public int Topla()
        {
            return _sayi1 + _sayi2;
        } 
        
        public int Carp()
        {
            return _sayi1 * _sayi2;
        }
    }
}