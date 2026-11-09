using System;

namespace TestDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Message message1 = Welcome.Print; //статический метод
            Message message2 = new Hello().Display; //метод из эземпляра класса
            message1(); // Welcome
            message2(); // Привет
        }
    }

    delegate void Message(); //Определение вне класса

    class Welcome
    {
        public static void Print() => Console.WriteLine("Welcome");
        //public static void Print() { Console.WriteLine("Welcome"); }
    }
    class Hello
    {
        public void Display() => Console.WriteLine("Привет");
    }

}
