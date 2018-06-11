using System;
using System.IO;
using System.Linq;

namespace Share
{
    internal static class Utilities
    {
        public static string Logpath = Environment.CurrentDirectory;

        #region Exceptions
        public static string FriendlyException(this Exception e)
        {
            if (e == null)
                return string.Empty;
            return $"\"Exception: {e.GetType()}\"\n\tMessage: {e.Message}\n\tStacktrace: {e.StackTrace}\nInner Exception:\n" +
                   FriendlyException(e.InnerException);
        }
        /// <summary>
        /// Generates the AppException and formates the input. If the first arg IS exception - it would be set as Inner
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static ApplicationException GenerateException(string format, params object[] args)
        {
            Exception ex = null;
            if (args != null && args.Length > 0)
            {
                if (args[0] is Exception)
                {
                    ex = (Exception) args[0];
                    args = args.Skip(1).ToArray();
                }
                if(args[0] == null)
                    args = args.Skip(1).ToArray();
            }
            return new ApplicationException(FormatString(format, args), ex);
        }
        #endregion

        public static string FormatString(string format, params object[] args)
        {
            string msg = format;
            if (args != null && args.Length > 0)
                msg = string.Format(msg, args);
            return msg;
        }

        #region File Log
        public static void LogToFile(string msg)
        {
            using (StreamWriter writer = File.AppendText(Logpath))
            {
                writer.WriteLine(msg);
            }
        }

        public static void ClearLog()
        {
            if (File.Exists(Logpath))
                File.Delete(Logpath);
        }
        #endregion
    }
}
