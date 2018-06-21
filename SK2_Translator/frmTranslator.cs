using SK2_Translator.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Share;

namespace SK2_Translator
{
    public partial class FrmTranslator : Form
    {
        private bool _unsavedText;
        private readonly List<string> _unsavedFiles = new List<string>();
        private string _currentFile;
        private string _currentKey;
        private bool _fromCode;
        public FrmTranslator()
        {
            InitializeComponent();
            Application.ApplicationExit += (a,b) => SaveChanged();
        }


        private void BtnCls_Click(object sender = null, EventArgs e = null)
        {
            Logger.Inst.PrintInfo("Clearing console...");
            Logger.Inst.ClearConsole();
            Logger.Inst.PrintInfo("Console cleared.");
        }

        private void FrmTranslator_Load(object sender, EventArgs e)
        {
            Logger.Inst.PrintInfo("Main form loaded.");
            ResetLists(true);
        }
        private void MsFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            Logger.Inst.PrintInfo($"Selected file \"{LstFiles.SelectedItem}\"");
            if (!MsAutoFile.Checked || _fromCode)
            {
                _fromCode = false;
                return;
            }
            BtnLoad_Click();
        }
        private void LstKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            Logger.Inst.PrintInfo($"Selected key \"{LstKeys.SelectedItem}\"");
            if (!MsAutoClick.Checked || _fromCode)
            {
                _fromCode = false;
                return;
            }
            BtnLoad_Click();
            _fromCode = false;
        }

        private void BtnLoad_Click(object sender = null, EventArgs e = null)
        {

            Logger.Inst.PrintInfo($"Trying to load key \"{LstKeys.SelectedItem}\" from the file \"{LstFiles.SelectedItem}\"");
            if (_unsavedText)
                if (MsAutoSave.Checked || Logger.Inst.CheckResponse("Do you want to save current line?"))
                    SetLine(_currentFile, _currentKey, TxtNew.Text);

            if (_currentFile != LstFiles.SelectedItem?.ToString())
            {
                Logger.Inst.PrintInfo("File changed.");
                ResetLists();
            }
            if (_currentKey != LstKeys.SelectedItem.ToString())
            {
                Logger.Inst.PrintInfo("Key changed.");
                ResetKeys();
            }
            if (LstKeys.SelectedItem == null)
            {
                Logger.Inst.MakeWarning("You must select the key!");
                return;
            }
            TxtOrig.Text = FileController.Inst.GetOriginalLine(LstKeys.SelectedItem);
            TxtNew.Text = FileController.Inst.GetFileLine(_currentFile, LstKeys.SelectedItem);
            _unsavedText = false;
            Logger.Inst.PrintInfo("Text fields updated.");
        }

        private void SetLine(object file, object key, string text)
        {
            Logger.Inst.PrintInfo($"Setting line \"{key}\" to \"{text}\" in the file \"{file}\"");
            FileController.Inst.SetFileLine(file, key, text);
            _unsavedText = false;
        }

        private void AddToUnsaved(object filename)
        {
            if (!_unsavedFiles.Contains(filename.ToString()))
            {
                _unsavedFiles.Add(filename.ToString());
                Logger.Inst.PrintInfo($"Adding file \"{filename}\" to unsaved list.");
            }
        }

        private void RemoveUnsaved(object filename)
        {
            if (_unsavedFiles.Contains(filename.ToString()))
            {
                _unsavedFiles.Remove(filename.ToString());
                Logger.Inst.PrintInfo($"Removing file \"{filename}\" from unsaved list.");
            }
        }

        private void BtnConfirm_Click(object sender = null, EventArgs e = null)
        {
            Logger.Inst.PrintInfo("Confirm button clicked.");
            if (LstKeys.SelectedItem == null)
            {
                Logger.Inst.MakeWarning("You must select the key!");
                return;
            }
            SetLine(LstFiles.SelectedItem, LstKeys.SelectedItem, TxtNew.Text);
        }


        private void MsSave_Click(object sender = null, EventArgs e = null)
        {
            FileController.Inst.Save(LstFiles.SelectedItem);
            Logger.Inst.PrintInfo($"Saving file \"{LstFiles.SelectedItem}\".");
            RemoveUnsaved(LstFiles.SelectedItem);
        }

        private void ResetLists(bool init = false)
        {
            Logger.Inst.PrintInfo("Resetting lists...");
            _fromCode = true;
            if (_unsavedText)
                if (MsAutoSave.Checked || Logger.Inst.CheckResponse("Do you want to save current line?"))
                    BtnConfirm_Click();
            SaveChanged();

            _currentFile = LstFiles.SelectedItem?.ToString();
            LstFiles.Items.Clear();
            LstFiles.Items.AddRange(FileController.Localization.Available.Select(p => p.Filename as object).ToArray());
            if (init && LstFiles.Items.Count > 0 && LstFiles.SelectedIndex == -1)
                LstFiles.SelectedIndex = 0;
            if (!string.IsNullOrEmpty(_currentFile))
            {
                Logger.Inst.PrintInfo("Restoring previously selected file.");
                _fromCode = true;
                var index = LstFiles.FindStringExact(_currentFile);
                if (index != ListBox.NoMatches)
                {
                    LstFiles.SelectedIndex = index;
                    Logger.Inst.PrintInfo($"Restored selection to \"{LstFiles.SelectedItem}\".");
                }
                else
                {
                    Logger.Inst.PrintError($"Unable to restore selection. File \"{_currentFile}\" not found in the list!.");
                }
            }
            _currentFile = LstFiles.SelectedItem?.ToString();
            Logger.Inst.PrintInfo($"Current file set to \"{_currentFile}\".");
            ResetKeys(init);
        }
        private void ResetKeys(bool init = false)
        {
            Logger.Inst.PrintInfo("Resetting keys.");
            _fromCode = true;
            if (LstFiles.Items.Count <= 0)
            {
                LstKeys.Items.Clear();
                return;
            }
            var file = FileController.GetLFile(LstFiles.SelectedItem) ?? FileController.Localization.Original;
            _currentKey = LstKeys.SelectedItem?.ToString();
            LstKeys.Items.Clear();
            LstKeys.Items.AddRange(file.Entries.Keys.Select(p => p as object).ToArray());
            if (init && LstKeys.Items.Count > 0 && LstKeys.SelectedIndex == -1)
                LstKeys.SelectedIndex = 0;
            if (_currentKey!=null)
            {
                Logger.Inst.PrintInfo("Trying to restore selected key...");
                _fromCode = true;
                var index = LstKeys.FindStringExact(_currentKey);
                if (index != ListBox.NoMatches)
                {
                    LstKeys.SelectedIndex = index;
                    Logger.Inst.PrintInfo($"Selection restored to \"{_currentKey}\".");
                }
                else
                {
                    Logger.Inst.PrintError($"Unable to restore selection. Key \"{_currentKey}\" not found in the list!.");
                }
            }
            _currentKey = LstKeys.SelectedItem?.ToString();
            Logger.Inst.PrintInfo($"Selection set to \"{_currentKey}\".");
        }

        private void MsSaveAs_Click(object sender, EventArgs e)
        {
            Logger.Inst.PrintInfo($"Saving file \"{LstFiles.SelectedItem}\" as ...");
            FileController.Inst.SaveAs(LstFiles.SelectedItem);
            ResetLists();
        }

        private void SaveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.Inst.PrintInfo("Saving all files...");
            FileController.SaveAll();
        }

        private void ReloadFIlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.Inst.PrintInfo("Reloading files");
            FileController.ReloadFiles();
            SaveChanged();
            ResetLists();
        }
        private void SaveChanged()
        {
            Logger.Inst.PrintInfo("Saving changed files");
            for (int i = 0; i < _unsavedFiles.Count; i++)
            {
                if(MsAutoSave.Checked |
                   Logger.Inst.CheckResponse($"Do you want to save changes to \"{_unsavedFiles[i]}\"?"))
                {
                    FileController.Inst.Save(_unsavedFiles[i]);
                    _unsavedFiles.Remove(LstFiles.SelectedItem.ToString());
                }
            }
        }
        private void MsQuit_Click(object sender, EventArgs e)
        {
            Logger.Inst.PrintInfo("Quitting...");
            if (!Logger.Inst.CheckResponse("Do you want to quit?")) return;
            SaveChanged();
            Application.Exit();
        }

        private void MsOpenOriginal_Click(object sender, EventArgs e)
        {
            Logger.Inst.PrintInfo("Trying to open new original file...");
            FileController.Inst.OpenOriginal();
            ResetLists(true);
            BtnLoad_Click();
        }

        private void TranslatedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.Inst.PrintInfo("Trying to open new translated file...");
            FileController.Inst.OpenFiles();
            ResetLists(true);
            BtnLoad_Click();
        }

        private void LstFilesContext_Opening(object sender, CancelEventArgs e)
        {
            Logger.Inst.PrintInfo("File list context opened.");
            MsFilesName.Text = FileController.Localization.Available[LstFiles.SelectedIndex].Fullpath;
        }

        private void MsFilesRemove_Click(object sender, EventArgs e)
        {
            Logger.Inst.PrintInfo($"Trying to remove file \"{LstFiles.SelectedItem}\" from the list.");
            FileController.RemoveFile(LstFiles.SelectedItem);
            if (_unsavedFiles.Contains(LstFiles.SelectedItem.ToString()))
            {
                if (MsAutoSave.Checked || Logger.Inst.CheckResponse($"Do you want to save \"{LstFiles.SelectedItem.ToString()}\"?"))
                {
                    MsSave_Click();
                }
            }
            ResetLists(true);
            if(LstFiles.Items.Count > 0)
                BtnLoad_Click();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Alt | Keys.W:
                    BtnConfirm_Click();
                    return true;
                case Keys.Alt | Keys.R:
                    BtnLoad_Click();
                    return true;
                case Keys.Alt | Keys.C:
                    BtnCls_Click();
                    return true;
                case Keys.Alt | Keys.Up:
                    LstKeys.Focus();
                    LstKeys.Select();
                    LstKeys.SelectedIndex--;
                    return true;
                case Keys.Alt | Keys.Down:
                    LstKeys.Focus();
                    LstKeys.Select();
                    LstKeys.SelectedIndex++;
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void TxtNew_TextChanged(object sender, EventArgs e)
        {
            _unsavedText = true;
        }

        private void TxtKeysSearch_TextChanged(object sender, EventArgs e)
        {
            _fromCode = true;
            var ind = LstKeys.FindString(TxtKeysSearch.Text);
            LstKeys.SelectedIndex = ind;
            TxtKeysSearch.BackColor = ind == ListBox.NoMatches ? Color.Crimson : SystemColors.Window;
        }

        private void MsKeysRemove_Click(object sender, EventArgs e)
        {
            Logger.Inst.PrintInfo($"Trying to remove key \"{LstKeys.SelectedItem}\" from the file \"{LstFiles.SelectedItem}\".");
            LocalizationFile file = FileController.GetLFile(LstFiles.SelectedItem);
            if (!file?.Entries.ContainsKey(LstKeys.SelectedItem.ToString()) == true)
            {
                Logger.Inst.MakeError("Can't delete key \"{0}\" - the key doesn't exists!.", _currentFile, _currentKey);
                return;
            }
            file?.Entries.Remove(LstKeys.SelectedItem.ToString());
            Logger.Inst.PrintInfo("Key removed.");
            ResetKeys();
        }

        private void AddKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.Inst.PrintInfo("Adding the key to the file");
            LocalizationFile file = FileController.GetLFile(LstFiles.SelectedItem);
            if (file == null) return;
            var newKey = Prompt.ShowTextDialog("Enter key:", $"Adding new key to the file \"{file.Filename}\"");
            if (string.IsNullOrEmpty(newKey))
            {
                Logger.Inst.MakeError("Key can't be empty!.", _currentFile, _currentKey);
                return;
            }
            if (file.Entries.ContainsKey(newKey))
            {
                Logger.Inst.MakeError("Can't add key \"{0}\" - the key already exists!.", _currentFile, _currentKey);
                return;
            }
            file.Entries.Add(newKey,null);
            Logger.Inst.PrintInfo("Key addded.");
            ResetKeys();
            _fromCode = true;
            LstKeys.SelectedItem = newKey;
            AddToUnsaved(LstFiles.SelectedItem);
        }

        private void OrderItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.Inst.PrintInfo("Sorting files keys.");
            FileController.SortFilesKeys();
            ResetKeys();
        }

        private void SortKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.Inst.PrintInfo($"Sorting file \"{LstFiles.SelectedItem}\" keys.");
            FileController.SortFileKeys(LstFiles.SelectedItem);
            ResetKeys();
        }

    }
}
