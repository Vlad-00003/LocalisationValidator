﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Share;
using SK2_Translator.Classes;
using static Share.Utilities;

namespace SK2_Translator
{
    static class Program
    {
        public static RichTextBox Console { get; private set; }
        public static frmTranslator frm { get; private set; }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logpath += @"\SK2_Translator.log.txt";
            ClearLog();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frm = new frmTranslator();
            Console = frm.txtConsole;
            Logger.Inst.ClearConsole();
            Logger.Inst.PrintInfo("Initialization started");
            
            if (!File.Exists(Environment.CurrentDirectory + @"\Assembly-CSharp.dll"))
            {
                string erMsg =
                    @"Assembly-CSharp.dll is not present! Move the program to ...\Shoppe Keep 2\Shoppe Keep 2_Data\Managed\ or move Assembly-CSharp.dll to the program folder.";
                Logger.Inst.ShowError(erMsg);
                LogToFile(DateTime.Now.ToShortTimeString() +": " + erMsg);
                return;
            }


            var path = Environment.ExpandEnvironmentVariables(
                @"%HOMEDRIVE%%HOMEPATH%\AppData\LocalLow\Strange Fire\Shoppe Keep 2\Languages");

            if (!FileController.Inst.InitInput(path))
            {
                if (Logger.Inst.CheckResponse(
                    "Localisation folder not found. Do you want to specify the \"Language_English.txt\" location manually?"))
                {
                    selection:
                    LocalizationFile original = FileController.Inst.GetFiles()?.FirstOrDefault();
                    if (original == null)
                    {
                        if (Logger.Inst.CheckResponse("Wrong file selected. Do you want to select another file?"))
                        {
                            goto selection;
                        }
                    }
                    if (original == null)
                    {
                        Logger.Inst.ShowError("The original language file isn't specified. Can not proceed...");
                        return;
                    }

                    FileController.Localization.Init(original);
                }
                else
                {
                    Logger.Inst.ShowError("The original language file isn't specified. Can not proceed...");
                    return;
                }
            }
            Logger.Inst.PrintInfo("Initialization complete.");
            FileController.Inst.CheckFiles();

            Application.Run(frm);
        }
    }
}
