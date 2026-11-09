using System;

namespace ClassObject
{
    class Person
    {
        public string Name {
            get;set;
            //set {
            //    this._name = value;
            //}
        } //property свойство

        /* Альтернатива */
        //private string _name;

        //public string Name_get()
        //{
        //    return _name;
        //} 

        //public void Name_set(string name)
        //{
        //    this._name = name;
        //}

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return (obj is Person person) ? Name == person.Name : false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //ToString
            int n = 10;
            Console.WriteLine(n.ToString());
            int k = 10;

            //GetHashCode
            var person1 = new Person { Name = "Tom"};
            var person2 = new Person { Name = "Tom" };

            person1.Name = "Bob";
            Console.WriteLine($"person1.Name = {person1.Name}");

            Console.WriteLine(person1.GetHashCode());
            Console.WriteLine(person2.GetHashCode());
            Console.WriteLine($"n={n.GetHashCode()}");
            Console.WriteLine($"k={k.GetHashCode()}");

            //GetType
            Console.WriteLine(person1.GetType());
            Console.WriteLine(person2.GetType());
            Console.WriteLine($"person1.GetType() == typeof(Person): {person1.GetType() == typeof(Person)}");
            Console.WriteLine($"person1 is Person: {person1 is Person}");

            //Equals
            Console.WriteLine($"person1.Equals(person2): {person1.Equals(person2)}");
            Console.WriteLine($"n.Equals(k): {n.Equals(k)}");
        }
    }
}
