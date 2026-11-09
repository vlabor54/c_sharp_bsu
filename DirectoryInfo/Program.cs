string dirName = "C:\\";

if (Directory.Exists(dirName))
{
    var dirs = Directory.GetDirectories(dirName);
    //foreach (var dir in dirs)
    //{
    //    Console.WriteLine(dir);
    //}

    var files = Directory.GetFiles(dirName);
    //foreach(var file in files)
    //{
    //    Console.WriteLine(file);
    //}

    //Фильтрация
    var dirsFiltered = Directory.GetDirectories(dirName, "Progr*");
    //foreach (var dir in dirsFiltered)
    //{
    //    Console.WriteLine(dir);
    //}

    //Файлы
    var filesFiltered = Directory.GetFiles(dirName, "page*");
    //foreach (var f in filesFiltered)
    //{
    //    Console.WriteLine(f);
    //}

    var filesFiltered2 = (new DirectoryInfo(dirName)).GetFiles("*.tmp");
    //foreach (var f in filesFiltered2)
    //{
    //    Console.WriteLine(f);
    //}

    //Создание каталога
    var dirNameLocal = "Test";
    Directory.CreateDirectory(dirNameLocal);
    Console.WriteLine("Создана директория");

    //Удаление
    //Directory.Delete(dirNameLocal);
    //Console.WriteLine("Удалена директория");

    //Перемещение
    var dirNameLocalNew = "Test2";
    DirectoryInfo dirInfo = new DirectoryInfo(dirNameLocal);
    dirInfo.MoveTo(dirNameLocalNew);

    


}
