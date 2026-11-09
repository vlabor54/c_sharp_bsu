using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegate
{
    public class CarEvetArgs : EventArgs
    {
        private string msg;
        public string Msg { get { return msg; } }
        public CarEvetArgs(string msg)
        {
            this.msg = msg;
        }
    }


    class Car
    {
        private int _currentSpeed;
        public int CurrentSpeed
        {
            get
            {
                return _currentSpeed;
            }
            set
            {
                _currentSpeed = value;
            }
        }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }
        private bool isDead;

        public Car() { MaxSpeed = 100; }
        public Car(string name, int maxSp, int currSp)
        {
            this.MaxSpeed = maxSp;
            this.PetName = name;
            this.CurrentSpeed = currSp;
        }

        //public delegate void CarEngineHadler(object sender, CarEvetArgs e);
        public delegate void CarEngineHadler(string msg);
        
        public event CarEngineHadler Exploded;
        public event CarEngineHadler AboutToBlow;

        //public event EventHandler<CarEvetArgs> Exploded;
        //public event EventHandler<CarEvetArgs> AboutToBlow;





        public void Accelerate(int delta)
        {
            if (isDead)
            {
                if (Exploded != null)
                    Exploded("Car is dead");
            }
            else
            {
                CurrentSpeed += delta;
                if ((MaxSpeed - CurrentSpeed) == 10 && AboutToBlow != null)
                {
                    AboutToBlow("Be Carefull");
                }
            }

            if (CurrentSpeed >= MaxSpeed)
                isDead = true;
            else
                Console.WriteLine("CurrentSpeed={0}", CurrentSpeed);
        }

    }

    class Program
    {

        static void Main(string[] args)
        {
            Car car = new Car("TestCar", maxSp: 100, currSp: 10);

            car.Exploded += delegate (string msg) //анонимный метод
            {
                Console.WriteLine($"Exploded Message from {car.PetName}:  {msg}");
            };

            car.AboutToBlow += delegate (string msg) //анонимный метод
            {
                Console.WriteLine($"AboutToBlow Message from {car.PetName}:  {msg}");
            };

            //car.AboutToBlow += (x, y) =>
            //{
            //    Console.WriteLine($"Message from {(x as Car).PetName}: {y.Msg}");
            //};

            for (int i = 0; i < 6; i++)
            {
                car.Accelerate(20);
            }

            Console.ReadKey();
        }

        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("Message from Car");
            Console.WriteLine("=>{0}", msg);
            Console.WriteLine("+++++++++++++++++++++\n");
        }

    }

}