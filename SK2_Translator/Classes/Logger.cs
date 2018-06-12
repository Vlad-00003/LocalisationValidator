using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Share;
using static Share.Utilities;

namespace SK2_Translator.Classes
{
    internal class Logger : ILogger
    {
        public static Logger Inst = new Logger();
        public void PrintWarning(string format, params object[] args) => PrintLine("[WARNING] " + FormatString(format, args), Color.Orange);

        public void PrintInfo(string format, params object[] args) => PrintLine("[INFO] " + FormatString(format, args), Color.Cyan);

        public void PrintError(string format, params object[] args) => PrintLine("[ERROR] " + FormatString(format, args), Color.Crimson);

        public void Print(string format, params object[] args)
        {
            PrintLine(FormatString(format, args), SystemColors.WindowText);
        }
        private void PrintLine(string text, Color color)
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

        public void ShowWarinig(string text, string capation = "Warning", params object[] args)
        {
            MessageBox.Show(FormatString(text, args), capation, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void ShowError(string text, string capation ="Error", params object[] args)
        {
            MessageBox.Show(FormatString(text,args), capation, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void ShowInfo(string text, string capation = "Info", params object[] args)
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
