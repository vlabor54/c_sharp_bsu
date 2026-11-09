//File
//FileInfo


var path = @"E:\Downloads\test.txt";
FileInfo fi = new FileInfo(path);

//if (fi.Exists)
//{
//    Console.WriteLine(fi.FullName);
//    Console.WriteLine(fi.CreationTime);
//    Console.WriteLine(fi.Length);

//    fi.Delete();
//    Console.WriteLine("Файл удален");
//}

//MoveTo(where, override)
//CopyTo

//Создание
var str = "\n\tAnotherText";
await File.WriteAllTextAsync(path, str);

//Чтение
var content = await File.ReadAllTextAsync(path);
Console.WriteLine(content);

