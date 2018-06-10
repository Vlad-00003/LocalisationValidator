using System;
using System.IO;
using static LocalisationValidator.Utilities;

namespace LocalisationValidator
{
    static class Program
    {
        private static Localization _loc;
        static void Main(string[] args)
        {
            if (!File.Exists(Environment.CurrentDirectory+ @"\Assembly-CSharp.dll"))
            {
                PrintError(100,"Assembly-CSharp.dll is not present! Move the program to \"...\\Shoppe Keep 2\\Shoppe Keep 2_Data\\Managed\"");
                goto quit;
            }
            ClearLog();
            var path = args.Length > 0
                ? string.Join(string.Empty, args)
                : Environment.ExpandEnvironmentVariables(
                    "%HOMEDRIVE%%HOMEPATH%\\AppData\\LocalLow\\Strange Fire\\Shoppe Keep 2\\Languages");
            _loc = new Localization(path);
            while(!_loc.Init())
            {
                matrix:
                ConsoleKey response;
                do
                {
                    PrintWarning("Do you want to specify the path to the files? [y/n] ");
                    response = Console.ReadKey(false).Key;
                    if (response != ConsoleKey.Enter)
                        Console.WriteLine();

                } while (response != ConsoleKey.Y && response != ConsoleKey.N);
                switch (response)
                {
                    case ConsoleKey.N:
                        goto quit;
                    case ConsoleKey.Y:
                        Print("Enter path:");
                        path = Console.ReadLine();
                        if (string.IsNullOrEmpty(path))
                        {
                            PrintError(40,"Path is empty!");
                            goto matrix;
                        }
                        if (!Directory.Exists(path))
                        {
                            PrintError(41,"Path doesn't exist!");
                            goto matrix;
                        }
                        _loc = new Localization(path);
                        break;
                }
            }
            foreach (var file in _loc.Available)
            {
                PrintWarning("Filling file \"{0}\"", file.Filename);
                if (file.Entries.FillKeys(_loc.Original.Entries))
                    PrintInfo("File has all the lines!");
                file.Entries.SortDict(_loc.Original.Entries);
                PrintWarning("File \"{0}\" sorted!", file.Filename);
                file.Save();
            }
            quit:
            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
        }
    }


}
