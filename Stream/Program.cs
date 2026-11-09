
var path = @"streamfile.txt";
var content = @"Text";

using (var writer = new StreamWriter(path, false))
{
    await writer.WriteLineAsync(content + "1");
}

using (var writer = new StreamWriter(path, true))
{
    await writer.WriteAsync(content + "2");
}

//Построчное чтение
using (var reader = new StreamReader(path))
{
    string? line;
    while((line = await reader.ReadLineAsync()) != null)
    {
        Console.WriteLine(line);
    }
}

