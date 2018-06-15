using System.Diagnostics.CodeAnalysis;

namespace Share
{
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    internal interface ILogger
    {
        void PrintWarning(string format, params object[] args);
        void PrintInfo(string format, params object[] args);
        void PrintError(string format, params object[] args);
        void Print(string format, params object[] args);
        bool CheckResponse(string text);
    }
}
