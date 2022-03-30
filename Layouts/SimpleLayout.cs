using SOLID.Enums;

namespace SOLID.Layouts
{
    public class SimpleLayout : Layout
    {
        public override string Format(string dateTime,ReportLevel reportLevel, string message)
        {
            return $"{dateTime} - {reportLevel} - {message}";
        }
    }
}