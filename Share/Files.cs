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
        public List<LocalizationFile> Available;
        private readonly string _path;
        private readonly ILogger _logger;
        public Localization(string path, ILogger logger)
        {
            _path = path;
            _logger = logger;
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
            Available = new List<LocalizationFile>();
            foreach (var file in files)
            {
                LocalizationFile lfile;
                try
                {
                    lfile = new LocalizationFile(file, _logger);
                }
                catch (Exception)
                {
                    _logger.PrintError("Can't initilize file \"{0}\". It won't be used.",file);
                    continue;
                }
                Available.Add(lfile);
            }
            return;
        }
    }

    class LocalizationFile
    {
        public readonly string Filename;
        private readonly string _fullpath;
        private JSONObject _text;
        public Dictionary<string, string> Entries;
        private readonly ILogger _logger;

        public LocalizationFile(string fullpath,ILogger logger)
        {
            Filename = Path.GetFileName(fullpath);
            _fullpath = fullpath;
            Entries = new Dictionary<string, string>();
            _logger = logger;
            ReadFile();
        }

        private void ReadFile()
        {
            if (string.IsNullOrEmpty(Filename))
            {
                throw GenerateException("Attempt to read file without path.");
            }
            var file = File.ReadAllText(_fullpath);
            try
            {
                _text = new JSONObject(file);
                AddLanguage();
            }
            catch (Exception ex)
            {
                _logger.PrintError(ex.Message);
                if (_logger.CheckResponse("Do you want to override this file with english lines?"))
                {
                    Entries = new Dictionary<string, string>();
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
                throw GenerateException("Can't load language \"{0}\"", e, Filename);
            }
        }

        private bool Write()
        {
            if (string.IsNullOrEmpty(_fullpath))
            {
                throw GenerateException("Attempt to write file without path. Filename: \"{0}\"", Filename);
            }
            File.WriteAllText(_fullpath, _text.ToString(true).Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "\r\n"));
            return true;
        }

        public bool Save()
        {
            _text = new JSONObject(Entries);
            return Write();
        }
    }
}
