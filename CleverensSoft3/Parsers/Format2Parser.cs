using System.Text.RegularExpressions;
using CleverensSoft3.Models;

namespace CleverensSoft3.Parsers
{
    public class Format2Parser : ILogParser
    {
        private readonly Regex regex = new(@"^(?<date>\d{4}-\d{2}-\d{2}) (?<time>\d{2}:\d{2}:\d{2}\.\d+)\|\s*(?<level>\w+)\|\d+\|(?<method>[^|]+)\|\s*(?<message>.+)$");

        private string ConvertDate(string input)
        {
           var p = input.Split('-');
            return $"{p[2]}-{p[1]}-{p[0]}";    
        }

        public LogEntry? TryParse(string line)
        {
            var match = regex.Match(line);
            if (!match.Success) return null;

            return new LogEntry
            {
                Date = ConvertDate(match.Groups["date"].Value),
                Time = match.Groups["time"].Value,
                LogLevel = NormalizeLevel(match.Groups["level"].Value),
                Method = match.Groups["method"].Value,
                Message = match.Groups["message"].Value
            };
        }

        private string NormalizeLevel(string level) => level.ToUpper() switch
        {
            "INFORMATION" => "INFO",
            "WARNING" => "WARN",
            _ => level.ToUpper()
        };
    }
}
