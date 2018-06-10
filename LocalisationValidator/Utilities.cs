using System;
using System.IO;

namespace LocalisationValidator
{
    internal static class Utilities
    {
        private static readonly string Logpath = Environment.CurrentDirectory + @"\LocalisationValidator.log.txt";
        public static string FriendlyException(this Exception e)
        {
            if (e == null)
                return string.Empty;
            return $"\"Exception: {e.GetType()}\"\n\tMessage: {e.Message}\n\tStacktrace: {e.StackTrace}\n" +
                   FriendlyException(e.InnerException);
        }

        private static string FormatString(string format, params object[] args)
        {
            string msg = format;
            if (args != null && args.Length > 0)
                msg = string.Format(msg, args);
            return msg;
        }
        public static void PrintWarning(string format, params object[] args) =>
            PrintLine("[WARNING] "+FormatString(format, args), ConsoleColor.Yellow);

        public static void PrintInfo(string format, params object[] args) =>
            PrintLine("[INFO] "+FormatString(format, args), ConsoleColor.Cyan);

        public static void PrintError(int errn,string format, params object[] args) =>
            PrintLine(FormatString("[ERROR {0}] ",errn)+FormatString(format, args), ConsoleColor.Red);

        public static void Print(string format, params object[] args) => PrintLine(FormatString(format, args));

        private static void PrintLine(string text, ConsoleColor foregroundColor = ConsoleColor.White)
        {
            Console.ForegroundColor = foregroundColor;
            string msg = FormatString("{0}: {1}", DateTime.Now.ToShortTimeString(), text);
            Console.WriteLine(msg);
            LogToFile(msg);
            Console.ResetColor();
        }

        private static void LogToFile(string msg)
        {
            using (StreamWriter writer = File.AppendText(Logpath))
            {
                writer.WriteLine(msg);
            }
        }

        public static void ClearLog()
        {
            if(File.Exists(Logpath))
                File.Delete(Logpath);
        }
    }
}
