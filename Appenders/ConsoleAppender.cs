using System;
using SOLID.Contracts;
using SOLID.Enums;

namespace SOLID.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout, ReportLevel reportLevel) 
            : base(layout, reportLevel)
        {
        }

        protected override void SpecificAppendLineLogic(string message)
        {
            Console.WriteLine(message);
        }
    }
}