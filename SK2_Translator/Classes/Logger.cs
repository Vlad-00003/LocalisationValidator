using Share;
using System;
using System.Drawing;
using System.Windows.Forms;
using static Share.Utilities;

namespace SK2_Translator.Classes
{
    internal class Logger : ILogger
    {
        public static readonly Logger Inst = new Logger();
        public void PrintWarning(string format, params object[] args) => PrintLine("[WARNING] " + FormatString(format, args), Color.Orange);

        public void PrintInfo(string format, params object[] args) => PrintLine("[INFO] " + FormatString(format, args), Color.Cyan);

        public void PrintError(string format, params object[] args) => PrintLine("[ERROR] " + FormatString(format, args), Color.Crimson);

        public void Print(string format, params object[] args)
        {
            PrintLine(FormatString(format, args), SystemColors.WindowText);
        }
        private static void PrintLine(string text, Color color)
        {
            var scolor = Program.Console.SelectionColor;
            Program.Console.SelectionColor = color;
            string msg = FormatString("{0}{1}: {2}",Environment.NewLine, DateTime.Now.ToShortTimeString(), text);
            Program.Console.AppendText(msg);
            LogToFile(msg);
            Program.Console.SelectionColor = scolor;
        }

        public void MakeError(string text, params object[] args)
        {
            ShowError(text, "Error", args);
            PrintError(text,args);
        }

        public void MakeWarning(string text, params object[] args)
        {
            ShowWarinig(text, "Warning",args);
            PrintWarning(text,args);
        }
        public void MakeInfo(string text, params object[] args)
        {
            ShowInfo(text, "Info", args);
            PrintInfo(text, args);
        }

        public static void ShowWarinig(string text, string capation = "Warning", params object[] args)
        {
            MessageBox.Show(FormatString(text, args), capation, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowError(string text, string capation ="Error", params object[] args)
        {
            MessageBox.Show(FormatString(text,args), capation, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void ShowInfo(string text, string capation = "Info", params object[] args)
        {
            MessageBox.Show(FormatString(text, args), capation, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ClearConsole()
        {
            Program.Console.Clear();
        }

        public bool CheckResponse(string text)
        {
            return MessageBox.Show(text,"",MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
        }
    }
}
