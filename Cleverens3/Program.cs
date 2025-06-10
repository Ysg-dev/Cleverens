using CleverensSoft.Services;

namespace CleverensSoft
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new LogProcessor();

            string projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));

            string input = Path.Combine(projectRoot, "input.txt");
            string output = Path.Combine(projectRoot, "standardized.txt");
            string problems = Path.Combine(projectRoot, "problems.txt");


            processor.ProcessFile(input, output, problems);

            Console.WriteLine("Готово! Логи обработаны.");
        }
    }
}
