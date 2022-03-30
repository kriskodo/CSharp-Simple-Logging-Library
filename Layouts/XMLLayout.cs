using SOLID.Enums;

namespace SOLID.Layouts
{
    public class XMLLayout : Layout
    {
        public override string Format(string dateTime, ReportLevel reportLevel, string message)
        {
            return $"XML FORMAT {dateTime} - {reportLevel} - {message}";
        }
    }
}