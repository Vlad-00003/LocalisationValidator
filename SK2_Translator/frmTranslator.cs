using SK2_Translator.Classes;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace SK2_Translator
{
    public partial class FrmTranslator : Form
    {
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
            ResetLists();
        }
        private void MsFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(msAutoFile.Checked)
                BtnLoad_Click();
        }
        private void LstKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(msAutoClick.Checked)
                BtnLoad_Click();
        }

        private void BtnLoad_Click(object sender = null, EventArgs e = null)
        {
            if (lstKeys.SelectedItem == null)
            {
                Logger.Inst.MakeWarning("You must select the key!");
                return;
            }
            txtOrig.Text = FileController.Inst.GetOriginalLine(lstKeys.SelectedItem);
            txtNew.Text = FileController.Inst.GetFileLine(msFiles.SelectedItem, lstKeys.SelectedItem);
        }

        private void BtnConfirm_Click(object sender = null, EventArgs e = null)
        {
            if (lstKeys.SelectedItem == null)
            {
                Logger.Inst.MakeWarning("You must select the key!");
                return;
            }
            FileController.Inst.SetFileLine(msFiles.SelectedItem,lstKeys.SelectedItem,txtNew.Text);
        }


        private void MsSave_Click(object sender = null, EventArgs e = null)
        {
            FileController.Inst.Save(msFiles.SelectedItem);
        }

        private void ResetLists()
        {
            lstKeys.Items.Clear();
            lstKeys.Items.AddRange(FileController.Localization.Original.Entries.Keys.Select(p => p as object).ToArray());
            if (lstKeys.Items.Count > 0)
                lstKeys.SelectedIndex = 0;
            msFiles.Items.Clear();
            msFiles.Items.AddRange(FileController.Localization.Available.Select(p => p.Filename as object).ToArray());
            if (msFiles.Items.Count > 0)
                msFiles.SelectedIndex = 0;
        }

        private void MsSaveAs_Click(object sender, EventArgs e)
        {
            FileController.Inst.SaveAs(msFiles.SelectedItem);
            ResetLists();
        }

        private void SaveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileController.Inst.SaveAll();
        }

        private void ReloadFIlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileController.Inst.ReloadFiles();
            ResetLists();
        }

        private void MsQuit_Click(object sender, EventArgs e)
        {
            if (Logger.Inst.CheckResponse("Do you want to quit?"))
            {
                FileController.Inst.SaveAll();
                Application.Exit();
            }
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

    }
}
