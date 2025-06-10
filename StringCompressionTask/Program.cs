using StringCompressionTask;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите исходную строку (напр. aaabbcccdde):");
        string input = Console.ReadLine();

        
        string compressed = StringCompressor.Compress(input);
        Console.WriteLine("Сжатая строка: " + compressed);

        
        string decompressed = StringCompressor.Decompress(compressed);
        Console.WriteLine("Декомпрессированная строка: " + decompressed);

        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}