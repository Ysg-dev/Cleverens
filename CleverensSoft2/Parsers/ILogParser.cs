using CleverensSoft2.Models;

namespace CleverensSoft2.Parsers
{
    public interface ILogParser
    {
        LogEntry? TryParse(string line);
    }
}
