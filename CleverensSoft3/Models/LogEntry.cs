namespace CleverensSoft3.Models
{
    public class LogEntry
    {
        public string Date { get; set; }      
        public string Time { get; set; }
        public string LogLevel { get; set; }    
        public string Method { get; set; }         
        public string Message { get; set; }

        public override string ToString()
        {
            return $"{Date}\n{Time}\t{LogLevel}\t{Method}\n{Message}";
        }
    }
}
