var task1 = PrintAsync("Te");
var task2 = PrintAsync("Be");
var taskAll = Task.WhenAll(task1, task2);

try
{
    //await PrintAsync("Te");
    //var task = PrintAsync("Te");

    await taskAll;
}
catch //(Exception e)
{
    //Console.WriteLine(e.Message);
    Console.WriteLine(taskAll.Exception.InnerException.Message);
    Console.WriteLine(taskAll.Status);

    foreach(var e in taskAll.Exception.InnerExceptions)
    {
        Console.WriteLine(e.Message);
    }
}

async Task PrintAsync(string msg)
{
    //try
    //{


    if (msg.Length < 3)
    {
        throw new ArgumentException($"Argument error {msg}: {msg.Length} ");
    }
    await Task.Delay(new Random().Next(1000, 3000));
    Console.WriteLine(msg);
    //} 
    //catch (Exception e)
    //{
    //    Console.WriteLine(e.Message);
    //}
}

async void PrintVoidAsync(string msg)
{
    try
    {


        if (msg.Length < 3)
        {
            throw new ArgumentException($"Argument error {msg}: {msg.Length} ");
        }
        await Task.Delay(new Random().Next(1000, 3000));
        Console.WriteLine(msg);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}