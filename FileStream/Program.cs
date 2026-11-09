using System.Text;
using System.IO;

var path = @"streamfile.txt";
var content = @"Text";

using (var fs = new FileStream(path, FileMode.OpenOrCreate))
{
    byte[] buffer = Encoding.Default.GetBytes(content);
    await fs.WriteAsync(buffer, 0, buffer.Length);
    Console.WriteLine($"Записано {content}");
}

//using (var fs = new FileStream(path, FileMode.Open))
//{
//    var buffer = new byte[fs.Length];
//    await fs.ReadAsync(buffer, 0, buffer.Length);
//    string text = Encoding.Default.GetString(buffer);
//    Console.WriteLine($"Text from file: {text}");
//}


//Использование курсора
using (var fs = new FileStream(path, FileMode.Open))
{
    fs.Seek(-2, SeekOrigin.End);
    
    var buffer = new byte[2];
    await fs.ReadAsync(buffer, 0, buffer.Length);
    string text = Encoding.Default.GetString(buffer);
    Console.WriteLine($"Text from file: {text}");
}