using CleverensSoft.Services;

namespace CleverensSoft
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new LogProcessor();

            string input = "input.txt";
            string output = "standardized.txt";
            string problems = "problems.txt";

            processor.ProcessFile(input, output, problems);

            Console.WriteLine("Готово! Логи обработаны.");
        }
    }
}
