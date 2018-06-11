using System;
using System.IO;
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
                ConsoleUtilities.Inst.PrintError(
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
                foreach (var file in _loc.Available)
                {
                    ConsoleUtilities.Inst.PrintWarning("Filling file \"{0}\"", file.Filename);
                    if (file.Entries.FillKeys(_loc.Original.Entries, ConsoleUtilities.Inst))
                        ConsoleUtilities.Inst.PrintInfo("File has all the lines!");
                    file.Entries.SortDict(_loc.Original.Entries);
                    ConsoleUtilities.Inst.PrintWarning("File \"{0}\" sorted!", file.Filename);
                    file.Save();
                }
            }
            Quit();
        }

        private static bool GetPath()
        {
            ConsoleKey response;
            do
            {
                ConsoleUtilities.Inst.PrintWarning("Do you want to specify the path to the files? [y/n] ");
                response = Console.ReadKey(false).Key;
                if (response != ConsoleKey.Enter)
                    Console.WriteLine();

            } while (response != ConsoleKey.Y && response != ConsoleKey.N);
            switch (response)
            {
                case ConsoleKey.N:
                    return false;
                case ConsoleKey.Y:
                    ConsoleUtilities.Inst.Print("Enter path:");
                    return InitInput(Console.ReadLine()); ;
            }
            return false;
        }

        private static bool InitInput(string path)
        {
            try
            {
                _loc = new Localization(path, ConsoleUtilities.Inst);
                _loc.Init();
                return true;
            }
            catch (Exception Ex)
            {
                ConsoleUtilities.Inst.PrintWarning(Ex.Message);
                ConsoleUtilities.Inst.PrintError(Ex.FriendlyException());
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
