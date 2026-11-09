using System;
using System.Threading;
using System.Threading.Tasks;

namespace TPLIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(()=> {
                Console.WriteLine("Task Started");
                Thread.Sleep(1000);
                Console.WriteLine("Task Ended");
            });
            task.Start();

            Console.WriteLine($"Task.Id {task.Id}");
            Console.WriteLine($"Task Completed {task.IsCompleted}");
            Console.WriteLine($"Task Status {task.Status}");
            //task.RunSynchronously();

            //task.Wait();

            //Task task1 = Task.Factory.StartNew(() => Console.WriteLine("Task Factory!"));
            //Task task2 = Task.Run(() => Console.WriteLine("Task Run!"));

            //task.Wait();
            //task1.Wait();
            //task2.Wait();
            Console.WriteLine("Main end");
        }

    }
}
