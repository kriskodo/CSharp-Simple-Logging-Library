using System.Text;

namespace SOLID.Contracts
{
    public interface ILogFile
    {
        StringBuilder Value { get; }
        void Write(string message);
        double Size { get; }
    }
}