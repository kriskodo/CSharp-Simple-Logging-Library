using System.IO;
using System.Text;
using SOLID.Contracts;

namespace SOLID.Loggers
{
    public class LogFile : ILogFile
    {
        public double Size { get; protected set; }
        public StringBuilder Value { get; } = new();
        
        public void Write(string message)
        {
            this.Value.AppendLine(message);
            using (var writer = File.AppendText("log.txt"))
            {
                writer.WriteLine(message);
            }
            
            foreach (var c in message)
            {
                this.Size += c;
            }
        }
    }
}