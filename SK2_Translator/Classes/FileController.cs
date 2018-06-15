using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Share;

namespace SK2_Translator.Classes
{
    class FileController
    {
        public static FileController Inst = new FileController();
        public static Localization Localization;
        private FolderBrowserDialog folderBrowser;
        private FileDialog fileDialog;
        private SaveFileDialog saveFileDialog;

        FileController()
        {
            folderBrowser = new FolderBrowserDialog();
            fileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog
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
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                Logger.Inst.PrintInfo("User selected path \"{0}\", trying to initilize localisation...", folderBrowser.SelectedPath);
                return InitInput(folderBrowser.SelectedPath);
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
                Logger.Inst.ShowError($"Error trying to init the localisation: {ex.Message}");
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
            for (int i = 0; i < files.Length; i++)
            {
                LocalizationFile lfile;
                try
                {
                    lfile = new LocalizationFile(files[i], Logger.Inst);
                }
                catch (Exception ex)
                {
                    Logger.Inst.MakeError("Can't initilize file \"{0}\". It won't be used. Exception: {1}", files[i], ex.FriendlyException());
                    continue;
                }
                lfiles.Add(lfile);
            }
            return lfiles;
        }
        private string[] GetPathFiles(string mask = "Original localisation file|Language_English.txt|Text Files|*.txt|All Files (*.*)|*.*")
        {
            fileDialog.Filter = mask;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                return fileDialog.FileNames;
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
                Logger.Inst.MakeError("The given key \"{0}\" is not present in the original file!");
                return "Null";
            }
            Logger.Inst.PrintInfo("Read line \"{0}\" from original (\"{1}\") file.", id, Localization.Original._fullpath);
            return Localization.Original.Entries[id];
        }

        public LocalizationFile GetLFile(object filename)
        {
            if (filename == null)
            {
                Logger.Inst.MakeWarning("Please select the file in the \"Files\" menu!");
                return null;
            }
            var file = Localization.Available.FirstOrDefault(p => p.Filename == filename.ToString());
            if (file == null)
            {
                Logger.Inst.MakeError("Listed file not found. Contact the developer and give him the log file!", filename);
                Logger.Inst.PrintError("File: \"{0}\"\nLocalization.Available:\n{1}",
                    filename,
                    string.Join("\n", Localization.Available.Select(p => p._fullpath).ToArray()));
                return null;
            }
            return file;
        }

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
                Logger.Inst.MakeError("File \"{0}\" doesn't have line \"{1}\".", filename);
                if (Logger.Inst.CheckResponse("Do you want to validate the file?"))
                    CheckFile(file);
                else
                    return "Null";
            }
            Logger.Inst.PrintInfo("Read line \"{0}\" from the file \"{1}\".", id, file._fullpath);
            return file.Entries[id];
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
            Logger.Inst.PrintInfo("Write line \"{0}\" to \"{1}\" in the file \"{1}\"", id, text, file._fullpath);
            file.Entries[id] = text;
        }

        public void Save(object filename) =>
            Save(GetLFile(filename));

        public void Save(LocalizationFile file)
        {
            var saved = file?.Save();
            if (saved.HasValue && saved.Value)
                Logger.Inst.MakeInfo("File \"{0}\" saved as \"{1}\"", file.Filename, file._fullpath);
            else
                Logger.Inst.MakeError("File \"{0}\" wasn't saved! See the console for error.", file?.Filename);
        }

        public void RemoveFile(object filename) =>
            RemoveFile(GetLFile(filename));
        public void RemoveFile(LocalizationFile file)
        {
            if (file == null)
            {
                return;
            }
            Localization.Available.Remove(file);
            Logger.Inst.MakeInfo("File \"{0}\" was removed from the list!", "Success",file._fullpath);

        }
        public void SaveAs(object filename) =>
            SaveAs(GetLFile(filename));
        public void SaveAs(LocalizationFile file)
        {
            if (file == null)
            {
                return;
            }
            saveFileDialog.InitialDirectory = Path.GetDirectoryName(Localization.Original._fullpath);
            saveFileDialog.FileName = file.Filename;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (file.SaveAs(saveFileDialog.FileName))
                {
                    Logger.Inst.MakeInfo("File \"{0}\" saved as \"{1}\"", file.Filename, file._fullpath);
                    AddFiles(new[]{ saveFileDialog.FileName });
                }
                else
                    Logger.Inst.MakeError("File \"{0}\" wasn't saved! See the console for error.", file?.Filename);
            }

        }

        public void SaveAll()
        {
            if (Logger.Inst.CheckResponse("Do you want to save all files?"))
            {
                Localization.Available.ForEach(Save);
            }
        }

        public void ReloadFiles()
        {
            if (Logger.Inst.CheckResponse("Do you want to save all files?"))
            {
                SaveAll();
            }
            HashSet<string> deleted = new HashSet<string>();
            for (int i = 0; i < Localization.Available.Count; ++i)
            {
                try
                {
                    Localization.Available[i].ReadFile();
                }
                catch (Exception ex)
                {
                    Logger.Inst.ShowWarinig("File \"{0}\" can not be found. Was it removed?","Warning",
                        Localization.Available[i]._fullpath);
                    Logger.Inst.PrintError(ex.FriendlyException());

                    deleted.Add(Localization.Available[i]._fullpath);
                }
            }
            Localization.Available.RemoveAll(p => deleted.Contains(p._fullpath));
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
                Logger.Inst.ShowWarinig("The original language file isn't changed");
                return;
            }
            Localization.Original = original;
            Logger.Inst.PrintInfo("Original changed to \"{0}\"", original._fullpath);
        }

        public void OpenFiles()
        {
            var files = GetFiles();
            foreach (var file in files)
            {
                if (Localization.Available.Any(x => x._fullpath == file._fullpath))
                {
                    Logger.Inst.MakeWarning("The file \"{0}\" is in the list already! You can update it by going to File-Reload Files",file._fullpath);
                    continue;
                }
                Localization.Available.Add(file);
                Logger.Inst.PrintInfo("File \"{0}\" added to the available list",file._fullpath);
            }
        }

    }
}
