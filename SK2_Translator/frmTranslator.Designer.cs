namespace SK2_Translator
{
    partial class FrmTranslator
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
            this.components = new System.ComponentModel.Container();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msOpenOriginal = new System.Windows.Forms.ToolStripMenuItem();
            this.translatedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadFIlesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msSave = new System.Windows.Forms.ToolStripMenuItem();
            this.msSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.msSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.msAutoClick = new System.Windows.Forms.ToolStripMenuItem();
            this.msAutoFile = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msInfoHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.msInfoAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnCls = new System.Windows.Forms.Button();
            this.txtConsole = new System.Windows.Forms.RichTextBox();
            this.txtNew = new System.Windows.Forms.RichTextBox();
            this.txtOrig = new System.Windows.Forms.RichTextBox();
            this.lstKeys = new System.Windows.Forms.ListBox();
            this.msFiles = new System.Windows.Forms.ListBox();
            this.msFilesCOntext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.msFilesName = new System.Windows.Forms.ToolStripMenuItem();
            this.msFilesRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.msFilesCOntext.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(3, 210);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(66, 53);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "Save key\r\n (Alt+W)";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.msSettings,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(951, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.reloadFIlesToolStripMenuItem,
            this.msSave,
            this.msSaveAs,
            this.saveAllToolStripMenuItem,
            this.msQuit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msOpenOriginal,
            this.translatedToolStripMenuItem,
            this.msOpenFolder});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveToolStripMenuItem.Text = "Open";
            // 
            // msOpenOriginal
            // 
            this.msOpenOriginal.Name = "msOpenOriginal";
            this.msOpenOriginal.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.O)));
            this.msOpenOriginal.Size = new System.Drawing.Size(246, 22);
            this.msOpenOriginal.Text = "Original";
            this.msOpenOriginal.ToolTipText = "Open file with the original text";
            this.msOpenOriginal.Click += new System.EventHandler(this.MsOpenOriginal_Click);
            // 
            // translatedToolStripMenuItem
            // 
            this.translatedToolStripMenuItem.Name = "translatedToolStripMenuItem";
            this.translatedToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.translatedToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.translatedToolStripMenuItem.Text = "Translated";
            this.translatedToolStripMenuItem.ToolTipText = "Open your desired language file";
            this.translatedToolStripMenuItem.Click += new System.EventHandler(this.TranslatedToolStripMenuItem_Click);
            // 
            // msOpenFolder
            // 
            this.msOpenFolder.Enabled = false;
            this.msOpenFolder.Name = "msOpenFolder";
            this.msOpenFolder.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.msOpenFolder.Size = new System.Drawing.Size(246, 22);
            this.msOpenFolder.Text = "Localization folder";
            this.msOpenFolder.ToolTipText = "This folder should contain at least 2 files:\r\nLanguage_English.txt\r\nand at least " +
    "one another";
            // 
            // reloadFIlesToolStripMenuItem
            // 
            this.reloadFIlesToolStripMenuItem.Name = "reloadFIlesToolStripMenuItem";
            this.reloadFIlesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.reloadFIlesToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.reloadFIlesToolStripMenuItem.Text = "Reload FIles";
            this.reloadFIlesToolStripMenuItem.Click += new System.EventHandler(this.ReloadFIlesToolStripMenuItem_Click);
            // 
            // msSave
            // 
            this.msSave.Name = "msSave";
            this.msSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.msSave.Size = new System.Drawing.Size(186, 22);
            this.msSave.Text = "Save";
            this.msSave.ToolTipText = "Save the current translating file";
            this.msSave.Click += new System.EventHandler(this.MsSave_Click);
            // 
            // msSaveAs
            // 
            this.msSaveAs.Name = "msSaveAs";
            this.msSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.msSaveAs.Size = new System.Drawing.Size(186, 22);
            this.msSaveAs.Text = "Save As";
            this.msSaveAs.ToolTipText = "Save translated files into the specified location";
            this.msSaveAs.Click += new System.EventHandler(this.MsSaveAs_Click);
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveAllToolStripMenuItem.Text = "Save All";
            this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.SaveAllToolStripMenuItem_Click);
            // 
            // msQuit
            // 
            this.msQuit.Name = "msQuit";
            this.msQuit.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.msQuit.Size = new System.Drawing.Size(186, 22);
            this.msQuit.Text = "Exit";
            this.msQuit.ToolTipText = "Quit the application";
            this.msQuit.Click += new System.EventHandler(this.MsQuit_Click);
            // 
            // msSettings
            // 
            this.msSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msAutoClick,
            this.msAutoFile});
            this.msSettings.Name = "msSettings";
            this.msSettings.Size = new System.Drawing.Size(61, 20);
            this.msSettings.Text = "Settings";
            // 
            // msAutoClick
            // 
            this.msAutoClick.CheckOnClick = true;
            this.msAutoClick.Name = "msAutoClick";
            this.msAutoClick.Size = new System.Drawing.Size(250, 22);
            this.msAutoClick.Text = "Automaticly read the key on click";
            this.msAutoClick.ToolTipText = "Be carefull! You might loose your data!";
            // 
            // msAutoFile
            // 
            this.msAutoFile.CheckOnClick = true;
            this.msAutoFile.Name = "msAutoFile";
            this.msAutoFile.Size = new System.Drawing.Size(250, 22);
            this.msAutoFile.Text = "Automaticly open file on click";
            this.msAutoFile.ToolTipText = "Be carefull! You might loose your data!";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msInfoHelp,
            this.msInfoAbout});
            this.infoToolStripMenuItem.Enabled = false;
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // msInfoHelp
            // 
            this.msInfoHelp.Name = "msInfoHelp";
            this.msInfoHelp.Size = new System.Drawing.Size(107, 22);
            this.msInfoHelp.Text = "Help";
            // 
            // msInfoAbout
            // 
            this.msInfoAbout.Name = "msInfoAbout";
            this.msInfoAbout.Size = new System.Drawing.Size(107, 22);
            this.msInfoAbout.Text = "About";
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(3, 53);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(66, 52);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Read key\r (Alt+R)";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // btnCls
            // 
            this.btnCls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCls.Location = new System.Drawing.Point(846, 43);
            this.btnCls.Name = "btnCls";
            this.btnCls.Size = new System.Drawing.Size(75, 63);
            this.btnCls.TabIndex = 7;
            this.btnCls.Text = "Clear console (Alt+C)";
            this.btnCls.UseVisualStyleBackColor = true;
            this.btnCls.Click += new System.EventHandler(this.BtnCls_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsole.BackColor = System.Drawing.Color.Black;
            this.txtConsole.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtConsole.ForeColor = System.Drawing.SystemColors.Window;
            this.txtConsole.Location = new System.Drawing.Point(6, 19);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.Size = new System.Drawing.Size(834, 111);
            this.txtConsole.TabIndex = 8;
            this.txtConsole.Text = "";
            this.txtConsole.VisibleChanged += new System.EventHandler(this.TxtConsole_VisibleChanged);
            // 
            // txtNew
            // 
            this.txtNew.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNew.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtNew.Location = new System.Drawing.Point(75, 161);
            this.txtNew.Name = "txtNew";
            this.txtNew.Size = new System.Drawing.Size(544, 152);
            this.txtNew.TabIndex = 9;
            this.txtNew.Text = "Your translated text goes here";
            // 
            // txtOrig
            // 
            this.txtOrig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrig.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtOrig.Location = new System.Drawing.Point(75, 3);
            this.txtOrig.Name = "txtOrig";
            this.txtOrig.ReadOnly = true;
            this.txtOrig.Size = new System.Drawing.Size(544, 152);
            this.txtOrig.TabIndex = 10;
            this.txtOrig.Text = "Here goes the original text";
            // 
            // lstKeys
            // 
            this.lstKeys.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstKeys.FormattingEnabled = true;
            this.lstKeys.Items.AddRange(new object[] {
            "Kek",
            "Крф"});
            this.lstKeys.Location = new System.Drawing.Point(12, 49);
            this.lstKeys.Name = "lstKeys";
            this.lstKeys.Size = new System.Drawing.Size(124, 316);
            this.lstKeys.TabIndex = 3;
            this.lstKeys.SelectedIndexChanged += new System.EventHandler(this.LstKeys_SelectedIndexChanged);
            // 
            // msFiles
            // 
            this.msFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.msFiles.ContextMenuStrip = this.msFilesCOntext;
            this.msFiles.FormattingEnabled = true;
            this.msFiles.Location = new System.Drawing.Point(770, 49);
            this.msFiles.Name = "msFiles";
            this.msFiles.Size = new System.Drawing.Size(169, 316);
            this.msFiles.TabIndex = 11;
            this.msFiles.SelectedIndexChanged += new System.EventHandler(this.MsFiles_SelectedIndexChanged);
            // 
            // msFilesCOntext
            // 
            this.msFilesCOntext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msFilesName,
            this.msFilesRemove});
            this.msFilesCOntext.Name = "msFilesCOntext";
            this.msFilesCOntext.Size = new System.Drawing.Size(175, 48);
            this.msFilesCOntext.Opening += new System.ComponentModel.CancelEventHandler(this.MsFilesCOntext_Opening);
            // 
            // msFilesName
            // 
            this.msFilesName.Enabled = false;
            this.msFilesName.Name = "msFilesName";
            this.msFilesName.Size = new System.Drawing.Size(174, 22);
            // 
            // msFilesRemove
            // 
            this.msFilesRemove.Name = "msFilesRemove";
            this.msFilesRemove.Size = new System.Drawing.Size(174, 22);
            this.msFilesRemove.Text = "Удалить из списка";
            this.msFilesRemove.Click += new System.EventHandler(this.MsFilesRemove_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtOrig, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtNew, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnConfirm, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnLoad, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(142, 49);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(622, 316);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(812, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Available files";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Translation keys";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnCls);
            this.groupBox1.Controls.Add(this.txtConsole);
            this.groupBox1.Location = new System.Drawing.Point(12, 388);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(927, 142);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Console";
            // 
            // frmTranslator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 559);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.msFiles);
            this.Controls.Add(this.lstKeys);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(638, 387);
            this.Name = "FrmTranslator";
            this.Text = "Shoope Keep 2 Translator";
            this.Load += new System.EventHandler(this.FrmTranslator_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.msFilesCOntext.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem msSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ToolStripMenuItem msOpenFolder;
        private System.Windows.Forms.ToolStripMenuItem msOpenOriginal;
        private System.Windows.Forms.ToolStripMenuItem translatedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem msQuit;
        private System.Windows.Forms.ToolStripMenuItem msSaveAs;
        private System.Windows.Forms.Button btnCls;
        internal System.Windows.Forms.RichTextBox txtConsole;
        private System.Windows.Forms.ToolStripMenuItem msSettings;
        private System.Windows.Forms.ToolStripMenuItem msAutoFile;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem msInfoHelp;
        private System.Windows.Forms.ToolStripMenuItem msInfoAbout;
        private System.Windows.Forms.RichTextBox txtNew;
        private System.Windows.Forms.RichTextBox txtOrig;
        private System.Windows.Forms.ListBox lstKeys;
        private System.Windows.Forms.ListBox msFiles;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem reloadFIlesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem msAutoClick;
        private System.Windows.Forms.ContextMenuStrip msFilesCOntext;
        private System.Windows.Forms.ToolStripMenuItem msFilesRemove;
        private System.Windows.Forms.ToolStripMenuItem msFilesName;
    }
}

