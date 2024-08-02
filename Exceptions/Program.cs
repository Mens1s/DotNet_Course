using System.Collections;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] students = new string[3] { "Ahmet1", "OfUs", "Last"};

            HandleException(()=>Find(students));
        }

        private static void HandleException(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (RecordNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void Find(String[] students)
        {
            if (!students.Contains("Ahmet"))
            {
                throw new RecordNotFoundException("Record not found!");
            }
            else
            {
                Console.WriteLine("Founded!");
            }
        }
    }
}