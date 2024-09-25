namespace Delegates
{
    public delegate void MyDelegate();
    public delegate void MyDelegate2(String text);
    public delegate int MyDelegate3(int num1, int num2);
    
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.ShowAlert();
            customerManager.SendMessage();

            MyDelegate myDelegate = customerManager.SendMessage;
            myDelegate += customerManager.ShowAlert;
            myDelegate();
            myDelegate -= customerManager.ShowAlert;
            myDelegate();

            MyDelegate2 myDelegate2 = customerManager.SendMessage;
            myDelegate2 += customerManager.ShowAlert;
            myDelegate2("Message...");

            Mathematic mathematic = new Mathematic();
            MyDelegate3 myDelegate3 = mathematic.Sum;
            myDelegate3 += mathematic.Multiply;
            Console.WriteLine(myDelegate3(3, 4)); // last sum returned
        }
    }

    class CustomerManager
    {
        public void SendMessage()
        {
            Console.WriteLine("Hello!");
        }

        public void ShowAlert()
        {
            Console.WriteLine("Alert.");
        }
        
        public void SendMessage(String message)
        {
            Console.WriteLine(message);
        }

        public void ShowAlert(String message)
        {
            Console.WriteLine(message);
        }
    }

    class Mathematic
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }
}