

/*//Последовательно
//await PrintAsync("one");
//await PrintAsync("two");
//await PrintAsync("three");

//Параллельно
var t1 = PrintAsync("one");
var t2 = PrintAsync("two");
var t3 = PrintAsync("three");

//await t1;
//await t2;
//await t3;

//await Task.WhenAll(t1, t2, t3); //Завершение всех
await Task.WhenAny(t1, t2, t3); //Завершение одного*/


var tSquare1 = SquareAsync(1);
var tSquare2 = SquareAsync(2);

//int[] result = await Task.WhenAll(tSquare1, tSquare2);

//foreach (var item in result)
//{
//    Console.WriteLine(item);
//}

await Task.WhenAll(tSquare1, tSquare2);

Console.WriteLine(tSquare2.Result);

Console.WriteLine("The end");

async Task PrintAsync(string msg)
{
    await Task.Delay(new Random().Next(1000, 3000));
    Console.WriteLine(msg);
}

async Task<int> SquareAsync(int n)
{
    await Task.Delay(1000);
    return n * n;
}



