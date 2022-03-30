using System.Collections.Generic;
using SOLID.Enums;

namespace SOLID.Contracts
{
    public interface IAppender
    {
        string GetType();
        ILayout Layout { get; }
        ReportLevel ReportLevel { get; }
        IList<string> Messages { get; }
        
        void AppendLine(ReportLevel reportLevel, string dateTime, string message);
    }
}