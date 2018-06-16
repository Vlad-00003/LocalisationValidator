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
        }

        private void BtnCls_Click(object sender = null, EventArgs e = null)
        {
            Logger.Inst.ClearConsole();
        }

        private void TxtConsole_VisibleChanged(object sender, EventArgs e)
        {
            txtConsole.SelectionStart = txtConsole.TextLength;
            txtConsole.ScrollToCaret();
        }

        private void FrmTranslator_Load(object sender, EventArgs e)
        {
            ResetLists(true);
        }
        private void MsFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!msAutoFile.Checked || _fromCode)
            {
                _fromCode = false;
                return;
            }
            BtnLoad_Click();
        }
        private void LstKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!msAutoClick.Checked || _fromCode)
            {
                _fromCode = false;
                return;
            }
            BtnLoad_Click();
            _fromCode = false;
        }

        private void BtnLoad_Click(object sender = null, EventArgs e = null)
        {
            if (_currentFile != msFiles.SelectedItem?.ToString())
            {
                ResetKeys();
            }
            if (lstKeys.SelectedItem == null)
            {
                Logger.Inst.MakeWarning("You must select the key!");
                return;
            }
            if (_unsavedText)
                if (MsAutoSave.Checked || Logger.Inst.CheckResponse("Do you want to save current line?"))
                    SetLine(_currentFile, _currentKey, txtNew.Text);



            txtOrig.Text = FileController.Inst.GetOriginalLine(lstKeys.SelectedItem);
            txtNew.Text = FileController.Inst.GetFileLine(_currentFile, lstKeys.SelectedItem);
            _unsavedText = false;
        }

        private void SetLine(object file, object key, string text)
        {
            FileController.Inst.SetFileLine(file, key, text);
            _unsavedText = false;
            if(!_unsavedFiles.Contains(file.ToString()))
                _unsavedFiles.Add(file.ToString());
        }

        private void BtnConfirm_Click(object sender = null, EventArgs e = null)
        {
            if (lstKeys.SelectedItem == null)
            {
                Logger.Inst.MakeWarning("You must select the key!");
                return;
            }
            SetLine(msFiles.SelectedItem, lstKeys.SelectedItem, txtNew.Text);
        }


        private void MsSave_Click(object sender = null, EventArgs e = null)
        {
            FileController.Inst.Save(msFiles.SelectedItem);
            if (_unsavedFiles.Contains(msFiles.SelectedItem.ToString()))
                _unsavedFiles.Remove(msFiles.SelectedItem.ToString());
        }

        private void ResetLists(bool init = false)
        {
            _fromCode = true;
            if (_unsavedText)
                if (MsAutoSave.Checked || Logger.Inst.CheckResponse("Do you want to save current line?"))
                    BtnConfirm_Click();
            SaveChanged();

            msFiles.Items.Clear();
            msFiles.Items.AddRange(FileController.Localization.Available.Select(p => p.Filename as object).ToArray());
            if (init && msFiles.Items.Count > 0 && msFiles.SelectedIndex == -1)
                msFiles.SelectedIndex = 0;
            ResetKeys(init);
        }
        private void ResetKeys(bool init = false)
        {
            _fromCode = true;
            var file = FileController.GetLFile(msFiles.SelectedItem) ?? FileController.Localization.Original;
            _currentKey = lstKeys.SelectedItem?.ToString();
            lstKeys.Items.Clear();
            lstKeys.Items.AddRange(file.Entries.Keys.Select(p => p as object).ToArray());
            if (init && lstKeys.Items.Count > 0 && lstKeys.SelectedIndex == -1)
                lstKeys.SelectedIndex = 0;
            if (_currentKey!=null)
            {
                _fromCode = true;
                var index = lstKeys.FindStringExact(_currentKey);
                if (index != ListBox.NoMatches)
                    lstKeys.SelectedIndex = index;
            }
            _currentKey = lstKeys.SelectedItem?.ToString();
            _currentFile = msFiles.SelectedItem?.ToString();
        }

        private void MsSaveAs_Click(object sender, EventArgs e)
        {
            FileController.Inst.SaveAs(msFiles.SelectedItem);
            ResetLists();
        }

        private void SaveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileController.SaveAll();
        }

        private void ReloadFIlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileController.ReloadFiles();
            SaveChanged();
            ResetLists();
        }
        private void SaveChanged()
        {
            foreach (var file in _unsavedFiles.Where(file => MsAutoSave.Checked |
                Logger.Inst.CheckResponse($"Do you want to save changes to \"{file}\"?")))
            {
                FileController.Inst.Save(file);
                _unsavedFiles.Remove(msFiles.SelectedItem.ToString());
            }
        }
        private void MsQuit_Click(object sender, EventArgs e)
        {
            if (!Logger.Inst.CheckResponse("Do you want to quit?")) return;
            SaveChanged();
            Application.Exit();
        }

        private void MsOpenOriginal_Click(object sender, EventArgs e)
        {
            FileController.Inst.OpenOriginal();
            ResetLists();
            BtnLoad_Click();
        }

        private void TranslatedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileController.Inst.OpenFiles();
            ResetLists();
            BtnLoad_Click();
        }

        private void MsFilesCOntext_Opening(object sender, CancelEventArgs e)
        {
            msFilesName.Text = FileController.Localization.Available[msFiles.SelectedIndex].Fullpath;
        }

        private void MsFilesRemove_Click(object sender, EventArgs e)
        {
            FileController.RemoveFile(msFiles.SelectedItem);
            if (_unsavedFiles.Contains(msFiles.SelectedItem.ToString()))
            {
                if (MsAutoSave.Checked || Logger.Inst.CheckResponse($"Do you want to save \"{msFiles.SelectedItem.ToString()}\"?"))
                {
                    MsSave_Click();
                }
            }
            ResetLists();
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
            var ind = lstKeys.FindString(TxtKeysSearch.Text);
            lstKeys.SelectedIndex = ind;
            TxtKeysSearch.BackColor = ind == ListBox.NoMatches ? Color.Crimson : SystemColors.Window;
        }

        private void MsKeysRemove_Click(object sender, EventArgs e)
        {
            LocalizationFile file = FileController.GetLFile(msFiles.SelectedItem);
            if (!file?.Entries.ContainsKey(lstKeys.SelectedItem.ToString()) == true)
            {
                Logger.Inst.MakeError("Can't delete key \"{0}\" - the key doesn't exists!.", _currentFile, _currentKey);
                return;
            }
            file?.Entries.Remove(lstKeys.SelectedItem.ToString());
            ResetKeys();
        }
    }
}
