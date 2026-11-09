using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Collections.Specialized;

namespace FirstAsync
{
    class Program
    {


        public async void GetWebPageAsync(string url)
        {
            var wc = new HttpClient();
            Task<string> getStringTask = wc.GetStringAsync(url);

            string page = await getStringTask;
            Console.WriteLine(page);
        }

        //метод для получения размера страницы
        public async Task<int> GetPageSizeAsync(string url)
        {
            var wc = new HttpClient();
            string page = await wc.GetStringAsync(url);
            return page.Length;
        }

        //для того чтобы воспльзоваться асинхронным методом следует написать еще аснхронный метод
        //async является заразным 
        public async Task<string> FindLargestPage(string[] urls)
        {
            string largest = null;
            int largestSize = 0;
            foreach (var url in urls)
            {
                int size = await GetPageSizeAsync(url);
                if (size > largestSize)
                {
                    size = largestSize;
                    largest = url;
                }
            }
            Console.WriteLine("largest: " + largest);
            return largest;
        }

        async Task PrintAsync(String str)
        {
            await Task.Delay(2000);
            Console.WriteLine(str);
        }

        async void PrintVoidAsync(String str)
        {
            await Task.Delay(2000);
            Console.WriteLine(str);
        }

        //ValueTask<int> SumAsync(int a, int b)
        ValueTask<int> SumAsync(int a, int b)
        {
            return new ValueTask<int>(a + b);
        }

        async static Task Main(string[] args)
        {

            var p = new Program();
            //p.GetWebPageAsync("http://yandex.ru");



            //await p.FindLargestPage(new[] { "http://yandex.ru", "http://google.ru" });


            //var task1 = p.PrintAsync("task1");

            //await task1;
            //p.PrintVoidAsync("void");
            //await task2;

            var result = await p.SumAsync(1, 2);
            Console.WriteLine(result);

            //while (true)
            //{
            Console.WriteLine("working");
            //}

            Console.ReadKey();



        }
    }
}