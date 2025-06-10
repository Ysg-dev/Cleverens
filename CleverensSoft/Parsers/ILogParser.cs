using CleverensSoft.Models;

namespace CleverensSoft.Parsers
{
    public interface ILogParser
    {
        LogEntry? TryParse(string line);
    }
}
