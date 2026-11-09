//await foreach (var num in GetResultAsync())
//{
//    Console.WriteLine(num.ToString());
//}

await foreach (var str in GetResultArrayAsync())
{
    Console.WriteLine(str.ToString());
}


async IAsyncEnumerable<int> GetResultAsync()
{
    for (int i=0; i< 10; i++)
    {
        yield return i;
    }
}

async IAsyncEnumerable<string> GetResultArrayAsync()
{
    string[] data = { "t1", "t2", "t3"};

    for (int i = 0; i < data.Length; i++)
    {
        await Task.Delay(1000);
        yield return data[i];
    }
}


