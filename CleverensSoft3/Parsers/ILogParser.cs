using CleverensSoft3.Models;

namespace CleverensSoft3.Parsers
{
    public interface ILogParser
    {
        LogEntry? TryParse(string line);
    }
}
