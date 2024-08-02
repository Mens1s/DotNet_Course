namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] persons = new[]
            {
                new Customer{FirstName = "Ahmet"}, 
                new Student{FirstName = "Mens1s"}, 
                new Person {FirstName = "SEngineer"}
            };

            foreach (var person in persons)
            {
                Console.WriteLine(person.FirstName);
            }
        }
    }

    class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    class Customer : Person
    {
        public string City { get; set; }
    }

    class Student : Person
    {
        public string Department { get; set; }
    }
}