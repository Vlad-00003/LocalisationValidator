﻿using System;
using System.IO;
using System.Linq;
using Share;
using static Share.Utilities;

namespace LocalisationValidator
{
    static class Program
    {
        private static Localization _loc;
        static void Main(string[] args)
        {
            #region Vars
            Logpath += @"\LocalisationValidator.log.txt";

            if (!File.Exists(Environment.CurrentDirectory+ @"\Assembly-CSharp.dll"))
            {
                Logger.Inst.PrintError(
                    @"Assembly-CSharp.dll is not present! Move the program to ...\Shoppe Keep 2\Shoppe Keep 2_Data\Managed\");
                Quit();
            }

            ClearLog();

            var path = args.Length > 0
                ? string.Join(string.Empty, args)
                : Environment.ExpandEnvironmentVariables(
                    @"%HOMEDRIVE%%HOMEPATH%\AppData\LocalLow\Strange Fire\Shoppe Keep 2\Languages");

            #endregion

            if (InitInput(path))
            {
                foreach (var file in _loc.Available.Where(p => p != null))
                {
                    Logger.Inst.PrintWarning("Filling file \"{0}\"", file.Filename);
                    if (file.Entries.FillKeys(_loc.Original.Entries, Logger.Inst))
                        Logger.Inst.PrintInfo("File has all the lines!");
                    file.Entries.SortDict(_loc.Original.Entries,Logger.Inst);
                    Logger.Inst.PrintWarning("File \"{0}\" sorted!", file.Filename);
                    file.Save();
                }
            }
            Quit();
        }

        private static bool GetPath()
        {
            if(!Logger.Inst.CheckResponse("Do you want to specify the path to the files?"))
                return false;
            Logger.Inst.Print("Enter path:");
            return InitInput(Console.ReadLine()); 
        }

        private static bool InitInput(string path)
        {
            try
            {
                _loc = new Localization(path, Logger.Inst);
                _loc.Init();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Inst.PrintWarning(ex.Message);
                Logger.Inst.PrintError(ex.FriendlyException());
                return GetPath();
            }
        }

        private static void Quit()
        {
            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
        }
    }
}
