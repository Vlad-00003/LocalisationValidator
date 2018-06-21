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
            this.BtnConfirm = new System.Windows.Forms.Button();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MsOpenOriginal = new System.Windows.Forms.ToolStripMenuItem();
            this.TranslatedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MsOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.OrderItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReloadFIlesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MsSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MsSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MsQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.MsSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.MsAutoClick = new System.Windows.Forms.ToolStripMenuItem();
            this.MsAutoFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MsAutoSave = new System.Windows.Forms.ToolStripMenuItem();
            this.InfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MsInfoHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MsInfoAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnLoad = new System.Windows.Forms.Button();
            this.BtnCls = new System.Windows.Forms.Button();
            this.TxtConsole = new System.Windows.Forms.RichTextBox();
            this.TxtNew = new System.Windows.Forms.RichTextBox();
            this.TxtOrig = new System.Windows.Forms.RichTextBox();
            this.LstKeys = new System.Windows.Forms.ListBox();
            this.MsKeysContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MsKeysRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.AddKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LstFiles = new System.Windows.Forms.ListBox();
            this.MsFilesContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MsFilesName = new System.Windows.Forms.ToolStripMenuItem();
            this.MsFilesRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.SortKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtKeysSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MenuStrip.SuspendLayout();
            this.MsKeysContext.SuspendLayout();
            this.MsFilesContext.SuspendLayout();
            this.TableLayoutPanel1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConfirm.Location = new System.Drawing.Point(3, 210);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(66, 53);
            this.BtnConfirm.TabIndex = 2;
            this.BtnConfirm.Text = "Save key\r\n (Alt+W)";
            this.BtnConfirm.UseVisualStyleBackColor = true;
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.MsSettings,
            this.InfoToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(951, 24);
            this.MenuStrip.TabIndex = 4;
            this.MenuStrip.Text = "MenuStrip";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveToolStripMenuItem,
            this.OrderItemsToolStripMenuItem,
            this.ReloadFIlesToolStripMenuItem,
            this.MsSave,
            this.MsSaveAs,
            this.SaveAllToolStripMenuItem,
            this.MsQuit});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MsOpenOriginal,
            this.TranslatedToolStripMenuItem,
            this.MsOpenFolder});
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.SaveToolStripMenuItem.Text = "Open";
            // 
            // MsOpenOriginal
            // 
            this.MsOpenOriginal.Name = "MsOpenOriginal";
            this.MsOpenOriginal.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.O)));
            this.MsOpenOriginal.Size = new System.Drawing.Size(246, 22);
            this.MsOpenOriginal.Text = "Original";
            this.MsOpenOriginal.ToolTipText = "Open file with the original text";
            this.MsOpenOriginal.Click += new System.EventHandler(this.MsOpenOriginal_Click);
            // 
            // TranslatedToolStripMenuItem
            // 
            this.TranslatedToolStripMenuItem.Name = "TranslatedToolStripMenuItem";
            this.TranslatedToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.TranslatedToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.TranslatedToolStripMenuItem.Text = "Translated";
            this.TranslatedToolStripMenuItem.ToolTipText = "Open your desired language file";
            this.TranslatedToolStripMenuItem.Click += new System.EventHandler(this.TranslatedToolStripMenuItem_Click);
            // 
            // MsOpenFolder
            // 
            this.MsOpenFolder.Enabled = false;
            this.MsOpenFolder.Name = "MsOpenFolder";
            this.MsOpenFolder.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.MsOpenFolder.Size = new System.Drawing.Size(246, 22);
            this.MsOpenFolder.Text = "Localization folder";
            this.MsOpenFolder.ToolTipText = "This folder should contain at least 2 files:\r\nLanguage_English.txt\r\nand at least " +
    "one another";
            // 
            // OrderItemsToolStripMenuItem
            // 
            this.OrderItemsToolStripMenuItem.Name = "OrderItemsToolStripMenuItem";
            this.OrderItemsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.OrderItemsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.OrderItemsToolStripMenuItem.Text = "Order files keys";
            this.OrderItemsToolStripMenuItem.Click += new System.EventHandler(this.OrderItemsToolStripMenuItem_Click);
            // 
            // ReloadFIlesToolStripMenuItem
            // 
            this.ReloadFIlesToolStripMenuItem.Name = "ReloadFIlesToolStripMenuItem";
            this.ReloadFIlesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.ReloadFIlesToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.ReloadFIlesToolStripMenuItem.Text = "Reload FIles";
            this.ReloadFIlesToolStripMenuItem.Click += new System.EventHandler(this.ReloadFIlesToolStripMenuItem_Click);
            // 
            // MsSave
            // 
            this.MsSave.Name = "MsSave";
            this.MsSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MsSave.Size = new System.Drawing.Size(186, 22);
            this.MsSave.Text = "Save";
            this.MsSave.ToolTipText = "Save the current translating file";
            this.MsSave.Click += new System.EventHandler(this.MsSave_Click);
            // 
            // MsSaveAs
            // 
            this.MsSaveAs.Name = "MsSaveAs";
            this.MsSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.MsSaveAs.Size = new System.Drawing.Size(186, 22);
            this.MsSaveAs.Text = "Save As";
            this.MsSaveAs.ToolTipText = "Save translated files into the specified location";
            this.MsSaveAs.Click += new System.EventHandler(this.MsSaveAs_Click);
            // 
            // SaveAllToolStripMenuItem
            // 
            this.SaveAllToolStripMenuItem.Name = "SaveAllToolStripMenuItem";
            this.SaveAllToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.SaveAllToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.SaveAllToolStripMenuItem.Text = "Save All";
            this.SaveAllToolStripMenuItem.Click += new System.EventHandler(this.SaveAllToolStripMenuItem_Click);
            // 
            // MsQuit
            // 
            this.MsQuit.Name = "MsQuit";
            this.MsQuit.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.MsQuit.Size = new System.Drawing.Size(186, 22);
            this.MsQuit.Text = "Exit";
            this.MsQuit.ToolTipText = "Quit the application";
            this.MsQuit.Click += new System.EventHandler(this.MsQuit_Click);
            // 
            // MsSettings
            // 
            this.MsSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MsAutoClick,
            this.MsAutoFile,
            this.MsAutoSave});
            this.MsSettings.Name = "MsSettings";
            this.MsSettings.Size = new System.Drawing.Size(61, 20);
            this.MsSettings.Text = "Settings";
            // 
            // MsAutoClick
            // 
            this.MsAutoClick.CheckOnClick = true;
            this.MsAutoClick.Name = "MsAutoClick";
            this.MsAutoClick.Size = new System.Drawing.Size(250, 22);
            this.MsAutoClick.Text = "Automaticly read the key on click";
            this.MsAutoClick.ToolTipText = "Be carefull! You might loose your data!";
            // 
            // MsAutoFile
            // 
            this.MsAutoFile.CheckOnClick = true;
            this.MsAutoFile.Name = "MsAutoFile";
            this.MsAutoFile.Size = new System.Drawing.Size(250, 22);
            this.MsAutoFile.Text = "Automaticly open file on click";
            this.MsAutoFile.ToolTipText = "Be carefull! You might loose your data!";
            // 
            // MsAutoSave
            // 
            this.MsAutoSave.CheckOnClick = true;
            this.MsAutoSave.Name = "MsAutoSave";
            this.MsAutoSave.Size = new System.Drawing.Size(250, 22);
            this.MsAutoSave.Text = "Automaticly save key & file";
            this.MsAutoSave.ToolTipText = "Automaticly saves the changed key & file if you selecting another key or file";
            // 
            // InfoToolStripMenuItem
            // 
            this.InfoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MsInfoHelp,
            this.MsInfoAbout});
            this.InfoToolStripMenuItem.Enabled = false;
            this.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem";
            this.InfoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.InfoToolStripMenuItem.Text = "Info";
            // 
            // MsInfoHelp
            // 
            this.MsInfoHelp.Name = "MsInfoHelp";
            this.MsInfoHelp.Size = new System.Drawing.Size(107, 22);
            this.MsInfoHelp.Text = "Help";
            // 
            // MsInfoAbout
            // 
            this.MsInfoAbout.Name = "MsInfoAbout";
            this.MsInfoAbout.Size = new System.Drawing.Size(107, 22);
            this.MsInfoAbout.Text = "About";
            // 
            // BtnLoad
            // 
            this.BtnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnLoad.Location = new System.Drawing.Point(3, 53);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(66, 52);
            this.BtnLoad.TabIndex = 2;
            this.BtnLoad.Text = "Read key\r (Alt+R)";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // BtnCls
            // 
            this.BtnCls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCls.Location = new System.Drawing.Point(846, 43);
            this.BtnCls.Name = "BtnCls";
            this.BtnCls.Size = new System.Drawing.Size(75, 63);
            this.BtnCls.TabIndex = 7;
            this.BtnCls.Text = "Clear console (Alt+C)";
            this.BtnCls.UseVisualStyleBackColor = true;
            this.BtnCls.Click += new System.EventHandler(this.BtnCls_Click);
            // 
            // TxtConsole
            // 
            this.TxtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtConsole.BackColor = System.Drawing.Color.Black;
            this.TxtConsole.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TxtConsole.ForeColor = System.Drawing.SystemColors.Window;
            this.TxtConsole.HideSelection = false;
            this.TxtConsole.Location = new System.Drawing.Point(6, 19);
            this.TxtConsole.Name = "TxtConsole";
            this.TxtConsole.ReadOnly = true;
            this.TxtConsole.Size = new System.Drawing.Size(834, 111);
            this.TxtConsole.TabIndex = 8;
            this.TxtConsole.Text = "";
            // 
            // TxtNew
            // 
            this.TxtNew.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtNew.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TxtNew.Location = new System.Drawing.Point(75, 161);
            this.TxtNew.Name = "TxtNew";
            this.TxtNew.Size = new System.Drawing.Size(544, 152);
            this.TxtNew.TabIndex = 9;
            this.TxtNew.Text = "Your translated text goes here";
            this.TxtNew.TextChanged += new System.EventHandler(this.TxtNew_TextChanged);
            // 
            // TxtOrig
            // 
            this.TxtOrig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtOrig.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TxtOrig.Location = new System.Drawing.Point(75, 3);
            this.TxtOrig.Name = "TxtOrig";
            this.TxtOrig.ReadOnly = true;
            this.TxtOrig.Size = new System.Drawing.Size(544, 152);
            this.TxtOrig.TabIndex = 10;
            this.TxtOrig.Text = "Here goes the original text";
            // 
            // LstKeys
            // 
            this.LstKeys.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LstKeys.ContextMenuStrip = this.MsKeysContext;
            this.LstKeys.FormattingEnabled = true;
            this.LstKeys.Items.AddRange(new object[] {
            "Kek",
            "Крф"});
            this.LstKeys.Location = new System.Drawing.Point(192, 70);
            this.LstKeys.Name = "LstKeys";
            this.LstKeys.Size = new System.Drawing.Size(124, 290);
            this.LstKeys.TabIndex = 3;
            this.LstKeys.SelectedIndexChanged += new System.EventHandler(this.LstKeys_SelectedIndexChanged);
            // 
            // MsKeysContext
            // 
            this.MsKeysContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MsKeysRemove,
            this.AddKeyToolStripMenuItem});
            this.MsKeysContext.Name = "MsKeysContext";
            this.MsKeysContext.Size = new System.Drawing.Size(139, 48);
            // 
            // MsKeysRemove
            // 
            this.MsKeysRemove.Name = "MsKeysRemove";
            this.MsKeysRemove.Size = new System.Drawing.Size(138, 22);
            this.MsKeysRemove.Text = "Remove key";
            this.MsKeysRemove.Click += new System.EventHandler(this.MsKeysRemove_Click);
            // 
            // AddKeyToolStripMenuItem
            // 
            this.AddKeyToolStripMenuItem.Name = "AddKeyToolStripMenuItem";
            this.AddKeyToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.AddKeyToolStripMenuItem.Text = "AddKey";
            this.AddKeyToolStripMenuItem.Click += new System.EventHandler(this.AddKeyToolStripMenuItem_Click);
            // 
            // LstFiles
            // 
            this.LstFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LstFiles.ContextMenuStrip = this.MsFilesContext;
            this.LstFiles.FormattingEnabled = true;
            this.LstFiles.Location = new System.Drawing.Point(12, 44);
            this.LstFiles.Name = "LstFiles";
            this.LstFiles.Size = new System.Drawing.Size(174, 316);
            this.LstFiles.TabIndex = 11;
            this.LstFiles.SelectedIndexChanged += new System.EventHandler(this.MsFiles_SelectedIndexChanged);
            // 
            // MsFilesContext
            // 
            this.MsFilesContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MsFilesName,
            this.MsFilesRemove,
            this.SortKeysToolStripMenuItem});
            this.MsFilesContext.Name = "msFilesCOntext";
            this.MsFilesContext.Size = new System.Drawing.Size(165, 70);
            this.MsFilesContext.Opening += new System.ComponentModel.CancelEventHandler(this.LstFilesContext_Opening);
            // 
            // MsFilesName
            // 
            this.MsFilesName.Enabled = false;
            this.MsFilesName.Name = "MsFilesName";
            this.MsFilesName.Size = new System.Drawing.Size(164, 22);
            // 
            // MsFilesRemove
            // 
            this.MsFilesRemove.Name = "MsFilesRemove";
            this.MsFilesRemove.Size = new System.Drawing.Size(164, 22);
            this.MsFilesRemove.Text = "Remove from list";
            this.MsFilesRemove.Click += new System.EventHandler(this.MsFilesRemove_Click);
            // 
            // SortKeysToolStripMenuItem
            // 
            this.SortKeysToolStripMenuItem.Name = "SortKeysToolStripMenuItem";
            this.SortKeysToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.SortKeysToolStripMenuItem.Text = "Sort keys";
            this.SortKeysToolStripMenuItem.Click += new System.EventHandler(this.SortKeysToolStripMenuItem_Click);
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.Controls.Add(this.TxtOrig, 1, 0);
            this.TableLayoutPanel1.Controls.Add(this.BtnConfirm, 0, 1);
            this.TableLayoutPanel1.Controls.Add(this.BtnLoad, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.TxtNew, 1, 1);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(322, 41);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 2;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(622, 316);
            this.TableLayoutPanel1.TabIndex = 13;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(42, 25);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(71, 13);
            this.Label5.TabIndex = 12;
            this.Label5.Text = "Available files";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(206, 25);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(84, 13);
            this.Label4.TabIndex = 12;
            this.Label4.Text = "Translation keys";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.Controls.Add(this.BtnCls);
            this.GroupBox1.Controls.Add(this.TxtConsole);
            this.GroupBox1.Location = new System.Drawing.Point(12, 388);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(927, 142);
            this.GroupBox1.TabIndex = 14;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Output";
            // 
            // TxtKeysSearch
            // 
            this.TxtKeysSearch.Location = new System.Drawing.Point(193, 44);
            this.TxtKeysSearch.Name = "TxtKeysSearch";
            this.TxtKeysSearch.Size = new System.Drawing.Size(123, 20);
            this.TxtKeysSearch.TabIndex = 15;
            this.TxtKeysSearch.TextChanged += new System.EventHandler(this.TxtKeysSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 372);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Use \"Alt+Up (arrow)\"  or \"Alt+Down (arrow)\" to change keys";
            // 
            // FrmTranslator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 559);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtKeysSearch);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.LstFiles);
            this.Controls.Add(this.LstKeys);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.MinimumSize = new System.Drawing.Size(638, 387);
            this.Name = "FrmTranslator";
            this.Text = "Shoope Keep 2 Translator";
            this.Load += new System.EventHandler(this.FrmTranslator_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.MsKeysContext.ResumeLayout(false);
            this.MsFilesContext.ResumeLayout(false);
            this.TableLayoutPanel1.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnConfirm;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MsSave;
        private System.Windows.Forms.Button BtnLoad;
        private System.Windows.Forms.ToolStripMenuItem MsOpenFolder;
        private System.Windows.Forms.ToolStripMenuItem MsOpenOriginal;
        private System.Windows.Forms.ToolStripMenuItem TranslatedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MsQuit;
        private System.Windows.Forms.ToolStripMenuItem MsSaveAs;
        private System.Windows.Forms.Button BtnCls;
        internal System.Windows.Forms.RichTextBox TxtConsole;
        private System.Windows.Forms.ToolStripMenuItem MsSettings;
        private System.Windows.Forms.ToolStripMenuItem MsAutoFile;
        private System.Windows.Forms.ToolStripMenuItem InfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MsInfoHelp;
        private System.Windows.Forms.ToolStripMenuItem MsInfoAbout;
        private System.Windows.Forms.RichTextBox TxtNew;
        private System.Windows.Forms.RichTextBox TxtOrig;
        private System.Windows.Forms.ListBox LstKeys;
        private System.Windows.Forms.ListBox LstFiles;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.ToolStripMenuItem ReloadFIlesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MsAutoClick;
        private System.Windows.Forms.ContextMenuStrip MsFilesContext;
        private System.Windows.Forms.ToolStripMenuItem MsFilesRemove;
        private System.Windows.Forms.ToolStripMenuItem MsFilesName;
        private System.Windows.Forms.ToolStripMenuItem MsAutoSave;
        private System.Windows.Forms.TextBox TxtKeysSearch;
        private System.Windows.Forms.ContextMenuStrip MsKeysContext;
        private System.Windows.Forms.ToolStripMenuItem MsKeysRemove;
        private System.Windows.Forms.ToolStripMenuItem AddKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OrderItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SortKeysToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}

