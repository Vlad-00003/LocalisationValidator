using Share;
using System;
using static Share.Utilities;
namespace LocalisationValidator
{
    internal class ConsoleUtilities : ILogger
    {
        public static readonly ConsoleUtilities Inst = new ConsoleUtilities();

        public bool CheckResponse(string text)
        {
            ConsoleKey response;
            do
            {
                PrintInfo(text + " [y/n] ");
                response = Console.ReadKey(false).Key;
                if (response != ConsoleKey.Enter)
                    Console.WriteLine();

            } while (response != ConsoleKey.Y && response != ConsoleKey.N);
            return response == ConsoleKey.Y;
        }

        public void PrintWarning(string format, params object[] args) => PrintLine("[WARNING] "+FormatString(format, args), ConsoleColor.Yellow);

        public void PrintInfo(string format, params object[] args) => PrintLine("[INFO] "+FormatString(format, args), ConsoleColor.Cyan);

        public void PrintError(string format, params object[] args) => PrintLine("[ERROR] "+FormatString(format, args), ConsoleColor.Red);

        public void Print(string format, params object[] args) => PrintLine(FormatString(format, args));

        private void PrintLine(string text, ConsoleColor foregroundColor = ConsoleColor.White)
        {
            Console.ForegroundColor = foregroundColor;
            string msg = FormatString("{0}: {1}", DateTime.Now.ToShortTimeString(), text);
            Console.WriteLine(msg);
            LogToFile(msg);
            Console.ResetColor();
        }
    }
}
