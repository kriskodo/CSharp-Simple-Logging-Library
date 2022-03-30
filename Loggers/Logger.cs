using System.Collections.Generic;
using SOLID.Contracts;
using SOLID.Enums;

namespace SOLID.Loggers
{
    public class Logger : ILogger
    {
        private readonly IList<IAppender> appenders;
        
        public Logger(IEnumerable<IAppender> appenders)
        {
            this.appenders = new List<IAppender>();
            
            foreach (var appender in appenders)
            {
                this.appenders.Add(appender);
            }
        }
        
        public void Info(string dateTime, string message)
        {
            UseAllAppenders(dateTime, ReportLevel.Info, message);
        }

        public void Warning(string dateTime, string message)
        {
            UseAllAppenders(dateTime, ReportLevel.Warning, message);
        }

        public void Error(string dateTime, string message)
        {
            UseAllAppenders(dateTime, ReportLevel.Error, message);
        }

        public void Critical(string dateTime, string message)
        {
            UseAllAppenders(dateTime, ReportLevel.Critical, message);
        }

        public void Fatal(string dateTime, string message)
        {
            UseAllAppenders(dateTime, ReportLevel.Fatal, message);
        }
        
        private void UseAllAppenders(string dateTime, ReportLevel reportLevel, string message)
        {
            foreach (var appender in this.appenders)
            {
                appender.AppendLine(reportLevel, dateTime, message);
            }
        }
    }
}