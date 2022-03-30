using SOLID.Contracts;
using SOLID.Enums;
using SOLID.Loggers;

namespace SOLID.Appenders
{
    public class FileAppender : Appender
    {
        private readonly ILogFile logFile;
        
        public FileAppender(ILayout layout, ReportLevel reportLevel, ILogFile logFile = null) 
            : base(layout, reportLevel)
        {
            this.logFile = logFile ?? new LogFile();
        }

        protected override void SpecificAppendLineLogic(string message)
        {
            logFile.Write(message);
        }
    }
}