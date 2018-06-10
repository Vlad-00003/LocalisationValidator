using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static LocalisationValidator.Utilities;

namespace LocalisationValidator
{
    class Localization
    {
        public LocalizationFile Original;
        public List<LocalizationFile> Available;
        private readonly string _path;
        public Localization(string path)
        {
            _path = path;
        }

        public bool Init()
        {
            PrintInfo("Localizatin Initialization started...");
            if (string.IsNullOrEmpty(_path))
            {
                PrintError(3,"Attempt to initilize Localization class without path.");
                return false;
            }
            List<string> files;
            try
            {
                files = Directory.GetFiles(_path, "*.txt", SearchOption.TopDirectoryOnly).ToList();
            }
            catch (Exception ex)
            {
                PrintError(4,"Can't get the files in the folder {0}.\n{1}", _path, ex.FriendlyException());
                return false;
            }
            if (files.Count == 0)
            {
                PrintError(5,"No files found in the folder \"{0}\",", _path);
                return false;
            }
            var original = files.FirstOrDefault(p => p.EndsWith("Language_English.txt"));
            if (string.IsNullOrEmpty(original))
            {
                PrintError(6,"English localization file not found in the folder \"{0}\"!", _path);
                return false;
            }
            files.Remove(original);
            Original = new LocalizationFile(original);
            if (!Original.Ready)
            {
                PrintError(8,"Original file isn't ready. Can't procced");
                return false;
            }
            PrintInfo("English localisation file found, looking for over languages...");
            Available = new List<LocalizationFile>();
            foreach (var file in files)
            {
                var lfile = new LocalizationFile(file);
                if (!lfile.Ready)
                {
                    PrintError(9,"Localization file \"{0}\" isn't ready and won't be used.",file);
                    continue;
                }
                Available.Add(lfile);
            }
            PrintInfo("Initialization complete! Got {0} files to work with!",Available.Count);
            return true;
        }
    }

    class LocalizationFile
    {
        public readonly string Filename;
        private readonly string _fullpath;
        private JSONObject _text;
        public Dictionary<string, string> Entries;
        public bool Ready;

        public LocalizationFile(string fullpath)
        {
            Filename = Path.GetFileName(fullpath);
            _fullpath = fullpath;
            Entries = new Dictionary<string, string>();
            Ready = false;
            ReadFile();
        }

        private void ReadFile()
        {
            if (string.IsNullOrEmpty(Filename))
            {
                PrintError(0,"Attempt to read file without path. Filename: \"{0}\"", Filename);
                return;
            }
            var file = File.ReadAllText(_fullpath);
            try
            {
                //Entries = JsonConvert.DeserializeObject<Dictionary<string, string>>(file);
                _text = new JSONObject(file);
                Ready = AddLanguage();
            }
            catch (Exception ex)
            {
                PrintError(7,"Attempt to parse the file {0}.\n{1}", Filename, ex.FriendlyException());
                ConsoleKey response;
                do
                {
                    PrintInfo("Do you want to override this file with english lines? [y/n] ");
                    response = Console.ReadKey(false).Key;
                    if (response != ConsoleKey.Enter)
                        Console.WriteLine();

                } while (response != ConsoleKey.Y && response != ConsoleKey.N);
                if (response == ConsoleKey.Y)
                {
                    Ready = true;
                    Entries = new Dictionary<string, string>();
                }
            }
        }

        private bool AddLanguage()
        {
            try
            {
                Entries = new Dictionary<string, string>(_text.ToDictionary());
            }
            catch (Exception e)
            {
                
                PrintError(10,"Can't load language \"{0}\"\n{1}", Filename,e.FriendlyException());
                return false;
            }
            return true;
        }

        private bool Write()
        {
            PrintInfo("Writing file \"{0}\" to the disk.",Filename);
            if (string.IsNullOrEmpty(_fullpath))
            {
                PrintError(1,"Attempt to write file without path. Filename: \"{0}\"", Filename);
                return false;
            }
            File.WriteAllText(_fullpath, _text.ToString(true).Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "\r\n"));
            PrintInfo("File \"{0}\" successfully written!",Filename);
            return true;
        }

        public void Save()
        {
            PrintInfo("Saving file \"{0}\".",Filename);
            _text = new JSONObject(Entries);
            if(Write())
                PrintInfo("File \"{0}\" saved.", Filename);
        }
    }
}
