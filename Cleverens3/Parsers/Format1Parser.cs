using System.Text.RegularExpressions;
using CleverensSoft.Models;

namespace CleverensSoft.Parsers
{
    public class Format1Parser : ILogParser
    {
        private readonly Regex regex = new(@"^(?<date>\d{2}\.\d{2}\.\d{4}) (?<time>\d{2}:\d{2}:\d{2}\.\d{3}) (?<level>\w+)\s+(?<message>.+)$");

        public LogEntry? TryParse(string line)
        {
            var match = regex.Match(line);
            if (!match.Success) return null;

            return new LogEntry
            {
                Date = ConvertDate(match.Groups["date"].Value),
                Time = match.Groups["time"].Value,
                LogLevel = NormalizeLevel(match.Groups["level"].Value),
                Method = "DEFAULT",
                Message = match.Groups["message"].Value
            };
        }

        private string ConvertDate(string input)
        {
            var p = input.Split('.');
            return $"{p[0]}-{p[1]}-{p[2]}";
        }

        private string NormalizeLevel(string level) => level.ToUpper() switch
        {
            "INFORMATION" => "INFO",
            "WARNING" => "WARN",
            _ => level.ToUpper()
        };
    }
}
