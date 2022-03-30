using SOLID.Enums;

namespace SOLID.Contracts
{
    public interface ILayout
    {
        string Type();
        string Format(string dateTime, ReportLevel reportLevel, string message);
    }
}