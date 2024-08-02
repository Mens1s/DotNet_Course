namespace AccessModifiers
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }
    }

    class Customer
    {
        private int id; // only in class
        protected int id2; // only in inherited class
        internal int id3;
        public void Save()
        {
            id = 4;
            id2 = 4;
            id3 = 4;
        }
    }

    class Student // default internal class Course same as class Course it can accessible on all project
    {
        public void Save()
        {
            Customer customer = new Customer();
            //customer.id; not accessible
            //customer.id2 = 4; not accessible
            customer.id3 = 4;
        }
    }

    class Customer2 : Customer
    {
        public void Save2()
        {
            //id = 2; // not accessible
            id2 = 2;
        }
    }

    class Course
    {
        public string Name { get; set; }

        private class NestedClass // private class only occur in nested classes
        {
            
        }
        
        internal class PublicNestedClass
        {
            
        }

        public void save()
        {
            NestedClass nestedClass = new NestedClass();
            PublicNestedClass publicNestedClass = new PublicNestedClass();
        }
    }

    class Trainer
    {
        public void Save()
        {
            Course course = new Course();
            Course.PublicNestedClass publicNestedClass = new Course.PublicNestedClass();
        }
    }
}