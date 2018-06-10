namespace SK2_Translator
{
    partial class frmTranslator
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtOrig = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNew = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lstKeys = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msSave = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msInfoHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.msInfoAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoad = new System.Windows.Forms.Button();
            this.msOpenOriginal = new System.Windows.Forms.ToolStripMenuItem();
            this.translatedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.msOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.msSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOrig
            // 
            this.txtOrig.Location = new System.Drawing.Point(243, 29);
            this.txtOrig.Multiline = true;
            this.txtOrig.Name = "txtOrig";
            this.txtOrig.ReadOnly = true;
            this.txtOrig.Size = new System.Drawing.Size(433, 146);
            this.txtOrig.TabIndex = 0;
            this.txtOrig.Text = "Here goes the original text";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(428, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Original text";
            // 
            // txtNew
            // 
            this.txtNew.Location = new System.Drawing.Point(243, 194);
            this.txtNew.Multiline = true;
            this.txtNew.Name = "txtNew";
            this.txtNew.Size = new System.Drawing.Size(433, 151);
            this.txtNew.TabIndex = 0;
            this.txtNew.Text = "Your translated text goes here";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(430, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Translation";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(143, 237);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(94, 53);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "Save key\r\n<---";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // lstKeys
            // 
            this.lstKeys.FormattingEnabled = true;
            this.lstKeys.Items.AddRange(new object[] {
            "Kek",
            "Крф"});
            this.lstKeys.Location = new System.Drawing.Point(13, 29);
            this.lstKeys.Name = "lstKeys";
            this.lstKeys.Size = new System.Drawing.Size(124, 316);
            this.lstKeys.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(690, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.msSave,
            this.msSaveAs,
            this.msQuit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msOpenFolder,
            this.msOpenOriginal,
            this.translatedToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Open";
            // 
            // msSave
            // 
            this.msSave.Name = "msSave";
            this.msSave.Size = new System.Drawing.Size(180, 22);
            this.msSave.Text = "Save";
            this.msSave.ToolTipText = "Save the translated file";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msInfoHelp,
            this.msInfoAbout});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // msInfoHelp
            // 
            this.msInfoHelp.Name = "msInfoHelp";
            this.msInfoHelp.Size = new System.Drawing.Size(180, 22);
            this.msInfoHelp.Text = "Help";
            // 
            // msInfoAbout
            // 
            this.msInfoAbout.Name = "msInfoAbout";
            this.msInfoAbout.Size = new System.Drawing.Size(180, 22);
            this.msInfoAbout.Text = "About";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msLanguage});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // msLanguage
            // 
            this.msLanguage.Name = "msLanguage";
            this.msLanguage.Size = new System.Drawing.Size(180, 22);
            this.msLanguage.Text = "Language";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(143, 76);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(94, 53);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Read key\r--->";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // msOpenOriginal
            // 
            this.msOpenOriginal.Name = "msOpenOriginal";
            this.msOpenOriginal.Size = new System.Drawing.Size(180, 22);
            this.msOpenOriginal.Text = "Original";
            this.msOpenOriginal.ToolTipText = "Open file with the original text";
            // 
            // translatedToolStripMenuItem
            // 
            this.translatedToolStripMenuItem.Name = "translatedToolStripMenuItem";
            this.translatedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.translatedToolStripMenuItem.Text = "Translated";
            this.translatedToolStripMenuItem.ToolTipText = "Open your desired language file";
            // 
            // msQuit
            // 
            this.msQuit.Name = "msQuit";
            this.msQuit.Size = new System.Drawing.Size(180, 22);
            this.msQuit.Text = "Exit";
            this.msQuit.ToolTipText = "Quit the application";
            // 
            // msOpenFolder
            // 
            this.msOpenFolder.Name = "msOpenFolder";
            this.msOpenFolder.Size = new System.Drawing.Size(180, 22);
            this.msOpenFolder.Text = "Localization folder";
            this.msOpenFolder.ToolTipText = "This folder should contain at least 2 files:\r\nLanguage_English.txt\r\nand at least " +
    "one another";
            // 
            // msSaveAs
            // 
            this.msSaveAs.Name = "msSaveAs";
            this.msSaveAs.Size = new System.Drawing.Size(180, 22);
            this.msSaveAs.Text = "Save As";
            this.msSaveAs.ToolTipText = "Save translated files into the specified location";
            // 
            // frmTranslator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 363);
            this.Controls.Add(this.lstKeys);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNew);
            this.Controls.Add(this.txtOrig);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmTranslator";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOrig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.ListBox lstKeys;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem msSave;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem msLanguage;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem msInfoHelp;
        private System.Windows.Forms.ToolStripMenuItem msInfoAbout;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ToolStripMenuItem msOpenFolder;
        private System.Windows.Forms.ToolStripMenuItem msOpenOriginal;
        private System.Windows.Forms.ToolStripMenuItem translatedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem msQuit;
        private System.Windows.Forms.ToolStripMenuItem msSaveAs;
    }
}

