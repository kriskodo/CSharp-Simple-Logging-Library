using SOLID.Contracts;
using SOLID.Enums;

namespace SOLID.Layouts
{
    public abstract class Layout : ILayout
    {
        public string Type() => this.GetType().Name;

        public abstract string Format(string dateTime, ReportLevel reportLevel, string message);
    }
}