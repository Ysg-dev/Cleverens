using CleverensSoft2.Models;
using CleverensSoft2.Parsers;

namespace CleverensSoft2.Services
{
    public class LogProcessor
    {
        private readonly List<ILogParser> parsers;

        public LogProcessor()
        {
            parsers = new List<ILogParser>
            {
                new Format1Parser(),
                new Format2Parser()
            };
        }

        public void ProcessFile(string inputPath, string outputPath, string problemPath)
        {
            var lines = File.ReadAllLines(inputPath);
            using StreamWriter goodWriter = new(outputPath);
            using StreamWriter badWriter = new(problemPath);

            foreach (var line in lines)
            {
                LogEntry? entry = null;
                foreach (var parser in parsers)
                {
                    entry = parser.TryParse(line);
                    if (entry != null)
                        break;
                }

                if (entry != null)
                    goodWriter.WriteLine(entry);
                else
                    badWriter.WriteLine(line);
            }
        }
    }
}
