string path = "binary.dat";
string text = "txt";
int num = 10;

using (var bw = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
{
    bw.Write(text);
    bw.Write(num);
    Console.WriteLine("Записано");
}


using (var br = new BinaryReader(File.Open(path, FileMode.Open)))
{
    text = br.ReadString();
    num = br.ReadInt32();
    Console.WriteLine($"{text} {num}");
}