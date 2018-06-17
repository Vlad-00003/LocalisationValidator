using Share;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
// ReSharper disable LocalizableElement

namespace SK2_Translator.Classes
{
    class FileController
    {
        public static readonly FileController Inst = new FileController();
        public static Localization Localization;
        private readonly FolderBrowserDialog _folderBrowser;
        private readonly FileDialog _fileDialog;
        private readonly SaveFileDialog _saveFileDialog;

        FileController()
        {
            _folderBrowser = new FolderBrowserDialog();
            _fileDialog = new OpenFileDialog();
            _saveFileDialog = new SaveFileDialog
            {
                CreatePrompt = false,
                OverwritePrompt = true,
                AddExtension = true,
                RestoreDirectory = true,
                DefaultExt = "Original localisation file|Language_English.txt|Text Files|*.txt|All Files (*.*)|*.*",
                Filter = "Text Files|*.txt|All Files (*.*)|*.*"
            };
        }

        private bool GetPath()
        {
            Logger.Inst.PrintInfo("User selecting folder");
            if (!Logger.Inst.CheckResponse("Do you want to specify the path to the files?"))
            {
                Logger.Inst.PrintInfo("User didn't select the folder");
                return false;
            }
            if (_folderBrowser.ShowDialog() == DialogResult.OK)
            {
                Logger.Inst.PrintInfo("User selected path \"{0}\", trying to initilize localisation...", _folderBrowser.SelectedPath);
                return InitInput(_folderBrowser.SelectedPath);
            }
            Logger.Inst.PrintInfo("User didn't select the folder");
            return false;
        }
        public bool InitInput(string path)
        {
            try
            {
                Logger.Inst.PrintInfo("Initilizing localisation in the folder \"{0}\"", path);
                Localization = new Localization(path, Logger.Inst);
                Localization.Init();
                Logger.Inst.PrintInfo("Initilizing successfully initilized");
                return true;
            }
            catch (Exception ex)
            {
                Logger.ShowError($"Error trying to init the localisation: {ex.Message}");
                Logger.Inst.PrintWarning(ex.Message);
                Logger.Inst.PrintError(ex.FriendlyException());
                return GetPath();
            }
        }

        public void CheckFiles()
        {
            foreach (var file in Localization.Available)
            {
                CheckFile(file);
            }
        }

        private void CheckFile(LocalizationFile file)
        {
            Logger.Inst.PrintWarning("Filling file \"{0}\"", file.Filename);
            if (file.Entries.FillKeys(Localization.Original.Entries, Logger.Inst))
                Logger.Inst.PrintInfo("File has all the lines!");
            file.Entries.SortDict(Localization.Original.Entries, Logger.Inst);
            Logger.Inst.PrintWarning("File \"{0}\" sorted! Saving..", file.Filename);
            file.Save();
            Logger.Inst.PrintWarning("File \"{0}\" Saved!", file.Filename);
        }

        public List<LocalizationFile> GetFiles(string mask = "Original localisation file|Language_English.txt|Text Files|*.txt|All Files (*.*)|*.*")
        {
            List<LocalizationFile> lfiles = new List<LocalizationFile>();
            var files = GetPathFiles(mask);
            if (files == null || files.Length < 1)
            {
                Logger.Inst.MakeError("No file chosen!");
                return null;
            }
            foreach (string file in files)
            {
                LocalizationFile lfile;
                try
                {
                    lfile = new LocalizationFile(file, Logger.Inst);
                }
                catch (Exception ex)
                {
                    Logger.Inst.MakeError("Can't initilize file \"{0}\". It won't be used. Exception: {1}", file, ex.FriendlyException());
                    continue;
                }
                lfiles.Add(lfile);
            }
            return lfiles;
        }
        private string[] GetPathFiles(string mask = "Original localisation file|Language_English.txt|Text Files|*.txt|All Files (*.*)|*.*")
        {
            _fileDialog.Filter = mask;
            if (_fileDialog.ShowDialog() == DialogResult.OK)
            {
                return _fileDialog.FileNames;
            }
            return null;
        }

        private void AddFiles(string[] files)
        {
            foreach (var file in files)
            {
                LocalizationFile lfile;
                try
                {
                    lfile = new LocalizationFile(file, Logger.Inst);
                }
                catch (Exception ex)
                {
                    Logger.Inst.MakeError("Can't initilize file \"{0}\". It won't be used. Exception: {1}", file, ex.FriendlyException());
                    continue;
                }
                AddFile(lfile);
            }
        }
        private void AddFile(LocalizationFile file)
        {
            if (!Localization.Initilized)
            {
                Logger.Inst.MakeError("Attepmt to add file untill the Localization was initilized!");
                return;
            }
            if (Localization.Available.Contains(file))
            {
                Logger.Inst.MakeError("Attepmt to add already existing file to the filelist: {0}", file.ToString());
                return;
            }
            Localization.Available.Add(file);
        }

        public string GetOriginalLine(object key)
        {
            var id = key.ToString();
            if (!Localization.Original.Entries.ContainsKey(id))
            {
                Logger.Inst.MakeError("The given key \"{0}\" is not present in the original file!",key);
                return "<Null>";
            }
            Logger.Inst.PrintInfo("Read line \"{0}\" from original (\"{1}\") file.", id, Localization.Original.Fullpath);
            return Localization.Original.Entries[id];
        }

        public static LocalizationFile GetLFile(object filename)
        {
            if (filename == null)
            {
                Logger.Inst.MakeWarning("Please select the file in the \"Files\" menu!");
                return null;
            }
            var file = Localization.Available.FirstOrDefault(p => p.Filename == filename.ToString());
            if (file != null) return file;

            Logger.Inst.MakeError("Listed file not found. Contact the developer and give him the log file!", filename);
            Logger.Inst.PrintError("File: \"{0}\"\nLocalization.Available:\n{1}",
                filename,
                string.Join("\n", Localization.Available.Select(p => p.Fullpath).ToArray()));
            return null;
        }

        public static void SortFileKeys(object filename)
            => SortFileKeys(GetLFile(filename));

        private static void SortFileKeys(LocalizationFile file) =>
            file?.Entries.SortDict(Localization.Original.Entries, Logger.Inst);

        public static void SortFilesKeys()
            => Localization.Available.ForEach(SortFileKeys);

        public string GetFileLine(object filename, object key)
        {
            string id = key.ToString();
            var file = GetLFile(filename);
            if (file == null)
            {
                return "Null";
            }
            if (!file.Entries.ContainsKey(id))
            {
                Logger.Inst.MakeError("File \"{0}\" doesn't have line \"{1}\".", filename,id);
                if (Logger.Inst.CheckResponse("Do you want to validate the file?"))
                {
                    CheckFile(file);
                }
            }
            Logger.Inst.PrintInfo("Read line \"{0}\" from the file \"{1}\".", id, file.Fullpath);
            return file.Entries.ContainsKey(id) ? file.Entries[id] : "<NULL>";
        }

        public void SetFileLine(object filename, object key, string text)
        {
            string id = key.ToString();
            var file = GetLFile(filename);
            if (file == null)
            {
                return;
            }
            if (!file.Entries.ContainsKey(id))
            {
                Logger.Inst.MakeError("File \"{0}\" doesn't have line \"{1}\".", filename);
                if (Logger.Inst.CheckResponse("Do you want to validate the file?"))
                    CheckFile(file);
                else
                    return;
            }
            Logger.Inst.PrintInfo("Write line \"{0}\" to \"{1}\" in the file \"{1}\"", id, text, file.Fullpath);
            file.Entries[id] = text;
        }

        public void Save(object filename) =>
            Save(GetLFile(filename));

        private static void Save(LocalizationFile file)
        {
            var saved = file?.Save();
            if (saved.HasValue && saved.Value)
                Logger.Inst.MakeInfo("File \"{0}\" saved as \"{1}\"", file.Filename, file.Fullpath);
            else
                Logger.Inst.MakeError("File \"{0}\" wasn't saved! See the console for error.", file?.Filename);
        }

        public static void RemoveFile(object filename) =>
            RemoveFile(GetLFile(filename));

        private static void RemoveFile(LocalizationFile file)
        {
            if (file == null)
            {
                return;
            }
            Localization.Available.Remove(file);
            Logger.Inst.MakeInfo("File \"{0}\" was removed from the list!", "Success",file.Fullpath);

        }
        public void SaveAs(object filename) =>
            SaveAs(GetLFile(filename));

        private void SaveAs(LocalizationFile file)
        {
            if (file == null)
            {
                return;
            }
            _saveFileDialog.InitialDirectory = Path.GetDirectoryName(Localization.Original.Fullpath);
            _saveFileDialog.FileName = file.Filename;
            if (_saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (file.SaveAs(_saveFileDialog.FileName))
                {
                    Logger.Inst.MakeInfo("File \"{0}\" saved as \"{1}\"", file.Filename, file.Fullpath);
                    AddFiles(new[]{ _saveFileDialog.FileName });
                }
                else
                    Logger.Inst.MakeError("File \"{0}\" wasn't saved! See the console for error.", file.Filename);
            }

        }

        public static void SaveAll()
        {
            if (Logger.Inst.CheckResponse("Do you want to save all files?"))
            {
                Localization.Available.ForEach(Save);
            }
        }

        public static void ReloadFiles()
        {
            HashSet<string> deleted = new HashSet<string>();
            foreach (LocalizationFile file in Localization.Available)
            {
                try
                {
                    file.ReadFile();
                }
                catch (Exception ex)
                {
                    Logger.ShowWarinig("File \"{0}\" can not be found. Was it removed?","Warning",
                        file.Fullpath);
                    Logger.Inst.PrintError(ex.FriendlyException());

                    deleted.Add(file.Fullpath);
                }
            }
            Localization.Available.RemoveAll(p => deleted.Contains(p.Fullpath));
            Logger.Inst.PrintInfo("File list has been reloaded.");
        }

        public void OpenOriginal()
        {
            selection:
            LocalizationFile original = GetFiles()?.FirstOrDefault();
            if (original == null)
            {
                if (Logger.Inst.CheckResponse("Wrong file selected. Do you want to select another file?"))
                {
                    goto selection;
                }
            }
            if (original == null)
            {
                Logger.ShowWarinig("The original language file isn't changed");
                return;
            }
            Localization.Original = original;
            Logger.Inst.PrintInfo("Original changed to \"{0}\"", original.Fullpath);
        }

        public void OpenFiles()
        {
            var files = GetFiles();
            foreach (var file in files)
            {
                if (Localization.Available.Any(x => x.Fullpath == file.Fullpath))
                {
                    Logger.Inst.MakeWarning("The file \"{0}\" is in the list already! You can update it by going to File-Reload Files",file.Fullpath);
                    continue;
                }
                Localization.Available.Add(file);
                Logger.Inst.PrintInfo("File \"{0}\" added to the available list",file.Fullpath);
            }
        }

    }
}
