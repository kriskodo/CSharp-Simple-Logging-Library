using System.Collections.Generic;
using SOLID.Contracts;
using SOLID.Enums;

namespace SOLID.Appenders
{
    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout, ReportLevel reportLevel)
        {
            this.Layout = layout;
            this.ReportLevel = reportLevel;
            this.Messages = new List<string>();
        }

        public new string GetType() => base.GetType().Name;
        public ILayout Layout { get; }
        public ReportLevel ReportLevel { get; set; }
        public IList<string> Messages { get; }
        protected abstract void SpecificAppendLineLogic(string message);

        public void AppendLine(ReportLevel reportLevel, string dateTime, string message)
        {
            if ((int)reportLevel < (int) this.ReportLevel) return;
            
            var formattedMessage = this.Layout.Format(dateTime,reportLevel, message);
            this.Messages.Add(formattedMessage);
            this.SpecificAppendLineLogic(formattedMessage);
        }
    }
}