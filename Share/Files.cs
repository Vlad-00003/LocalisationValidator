using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Share.Utilities;
namespace Share
{
    class Localization
    {
        public LocalizationFile Original;
        public List<LocalizationFile> Available = new List<LocalizationFile>();
        private readonly string _path;
        private readonly ILogger _logger;
        public bool Initilized { get; private set; }

        public Localization(string path, ILogger logger)
        {
            _path = path;
            _logger = logger;
        }

        public void Init(LocalizationFile original)
        {
            Original = original;
            Available = new List<LocalizationFile>();
            Initilized = true;
        }
        public void Init()
        {
            if (string.IsNullOrEmpty(_path))
            {
                throw GenerateException("Attempt to initilize Localization class without path.");
            }
            if (!Directory.Exists(_path))
            {
                throw GenerateException("Path \"{0}\" doesn't exist!.",_path);
            }
            List<string> files;
            try
            {
                files = Directory.GetFiles(_path, "*.txt", SearchOption.TopDirectoryOnly).ToList();
            }
            catch (Exception ex)
            {
                throw GenerateException("Can't get the files in the folder {0}.",ex, _path);
            }
            if (files.Count == 0)
            {
                throw GenerateException("No files found in the folder \"{0}\",", _path);
            }
            var original = files.FirstOrDefault(p => p.EndsWith("Language_English.txt"));
            if (string.IsNullOrEmpty(original))
            {
                throw GenerateException("English localization file not found in the folder \"{0}\"!", _path);
            }
            files.Remove(original);
            try
            {
                Original = new LocalizationFile(original, _logger);
            }
            catch(Exception ex)
            { 
                throw GenerateException("Original file isn't ready. Can't procced",ex);
            }
            foreach (var file in files)
            {
                LocalizationFile lfile;
                try
                {
                    lfile = new LocalizationFile(file, _logger);
                }
                catch (Exception ex)
                {
                    _logger.PrintError("Can't initilize file \"{0}\". It won't be used. Error: {1}",file,ex.FriendlyException());
                    continue;
                }
                Available.Add(lfile);
            }
            Initilized = true;
        }
    }

    class LocalizationFile
    {
        public readonly string Filename;
        public readonly string Fullpath;
        private JSONObject _text;
        public Dictionary<string, string> Entries;
        private readonly ILogger _logger;

        public override string ToString()
        {
            return $"{Fullpath} (lang:{Entries["LANG_NAME"]}";
        }

        public LocalizationFile(string fullpath,ILogger logger)
        {
            Filename = Path.GetFileName(fullpath);
            Fullpath = fullpath;
            Entries = new Dictionary<string, string>();
            _logger = logger;
            ReadFile();
        }

        public void ReadFile()
        {
            if (string.IsNullOrEmpty(Filename))
            {
                throw GenerateException("Attempt to read file without path.");
            }
            var file = File.ReadAllText(Fullpath);
            try
            {
                _text = new JSONObject(file);
                AddLanguage();
            }
            catch (Exception ex)
            {
                _logger.PrintError(ex.FriendlyException());
                if (!_logger.CheckResponse(
                    "File \"{0}\" seems broken (probably missing, unescaped or wrong placed comma or \")\nDo you want to override the file with english lines?",
                    Filename))
                {
                    Entries = null;
                }
            }
        }

        private void AddLanguage()
        {
            try
            {
                Entries = new Dictionary<string, string>(_text.ToDictionary());
            }
            catch (Exception e)
            {
                if (e is ArgumentException)
                {
                    var duplicates = _text.keys.GroupBy(x => x)
                        .Where(group => group.Count() > 1)
                        .Select(group => group.Key);
                    foreach (var duplicate in duplicates)
                    {
                        _logger.PrintError("Dubplcate key \"{0}\" in the file \"{1}!\"\nValue: {2}", duplicate, Filename, _text[duplicate]);
                    }
                }
                throw GenerateException("Can't load language \"{0}\"", e, Filename);
            }
        }

        private bool Write(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw GenerateException("Attempt to write file without path. Filename: \"{0}\"", Filename);
            }
            File.WriteAllText(path, _text.ToString(true).Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "\r\n"));
            return true;
        }

        public bool Save()
        {
            if (Entries == null)
                return false;
            _text = new JSONObject(Entries);
            return Write(Fullpath);
        }

        public bool SaveAs(string path)
        {
            _text = new JSONObject(Entries);
            return Write(path);
        }
    }
}
