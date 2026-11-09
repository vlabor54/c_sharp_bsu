using System.IO.Compression;

string file = @"e:\downloads\Заявка_на_сетевое_подключение.docx";
string compressed = "compressed.gz";
string decompressed = "decompressed.docx";

//await Compress(file, compressed);

//await Decompress(compressed, decompressed);

async Task Compress(string file, string compressed)
{
    using var fsFile = new FileStream(file, FileMode.Open);
    using var fsCompress = new FileStream(compressed, FileMode.OpenOrCreate);

    using GZipStream gzStream = new GZipStream(fsCompress, CompressionMode.Compress);

    await fsFile.CopyToAsync(gzStream);

    Console.WriteLine($"Файл {compressed}");
}

async Task Decompress(string compressed, string outFile)
{
    using var fsCompressed = new FileStream(compressed, FileMode.Open);
    using var fsOutFile = new FileStream(outFile, FileMode.CreateNew);

    using var gz = new GZipStream(fsCompressed, CompressionMode.Decompress);

    await gz.CopyToAsync(fsOutFile);

    Console.WriteLine("Decompress done");
}


var sourceDir = @"e:\downloads\1984163674_MEDDEV_144803";
var destDir = @"compressed.zip";
var destDecompressDir = @"decompressed";

File.Delete(destDir);

await ZipFile.CreateFromDirectoryAsync(sourceDir, destDir);
Console.WriteLine("Arch created");

await ZipFile.ExtractToDirectoryAsync(destDir, destDecompressDir);
Console.WriteLine("Arch decompressed");



