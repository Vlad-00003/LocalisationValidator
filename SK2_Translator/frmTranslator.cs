using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Share;
using SK2_Translator.Classes;

namespace SK2_Translator
{
    public partial class frmTranslator : Form
    {
        public frmTranslator()
        {
            InitializeComponent();
        }

        private void btnCls_Click(object sender, EventArgs e)
        {
            Logger.Inst.ClearConsole();
        }

        private void txtConsole_VisibleChanged(object sender, EventArgs e)
        {
            txtConsole.SelectionStart = txtConsole.TextLength;
            txtConsole.ScrollToCaret();
        }

        private void frmTranslator_Load(object sender, EventArgs e)
        {
            ResetLists();
        }
        private void msFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(msAutoFile.Checked)
                btnLoad_Click();
        }
        private void lstKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(msAutoClick.Checked)
                btnLoad_Click();
        }

        private void btnLoad_Click(object sender = null, EventArgs e = null)
        {
            if (lstKeys.SelectedItem == null)
            {
                Logger.Inst.MakeWarning("You must select the key!");
                return;
            }
            txtOrig.Text = FileController.Inst.GetOriginalLine(lstKeys.SelectedItem);
            txtNew.Text = FileController.Inst.GetFileLine(msFiles.SelectedItem, lstKeys.SelectedItem);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (lstKeys.SelectedItem == null)
            {
                Logger.Inst.MakeWarning("You must select the key!");
                return;
            }
            FileController.Inst.SetFileLine(msFiles.SelectedItem,lstKeys.SelectedItem,txtNew.Text);
        }


        private void msSave_Click(object sender, EventArgs e)
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

        private void msSaveAs_Click(object sender, EventArgs e)
        {
            FileController.Inst.SaveAs(msFiles.SelectedItem);
            ResetLists();
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileController.Inst.SaveAll();
        }

        private void reloadFIlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileController.Inst.ReloadFiles();
            ResetLists();
        }

        private void msQuit_Click(object sender, EventArgs e)
        {
            if (Logger.Inst.CheckResponse("Do you want to quit?"))
            {
                FileController.Inst.SaveAll();
                Application.Exit();
            }
        }

        private void msOpenOriginal_Click(object sender, EventArgs e)
        {
            FileController.Inst.OpenOriginal();
            ResetLists();
            btnLoad_Click();
        }

        private void translatedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileController.Inst.OpenFiles();
            ResetLists();
            btnLoad_Click();
        }

        private void msFilesCOntext_Opening(object sender, CancelEventArgs e)
        {
            msFilesName.Text = FileController.Localization.Available[msFiles.SelectedIndex]._fullpath;
        }

        private void msFilesRemove_Click(object sender, EventArgs e)
        {
            FileController.Inst.RemoveFile(msFiles.SelectedItem);
            ResetLists();
            btnLoad_Click();
        }
    }
}
