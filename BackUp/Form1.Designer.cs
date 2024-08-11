namespace BackUp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.مساعدةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.حـــولالتطبيقToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backUpLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.addlbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fbmlbl = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView11 = new System.Windows.Forms.ListView();
            this.columnHeader70 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader54 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader77 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.إضافةمسارنسخاحتياطيToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تعديلمسارنسخاحتياطيToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.حذفمسارالنسخالاحتياطيToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تحديدوقتالنسخالاحتياطيToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.بدءالنسالاحتياطيالآنToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.خروجToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Image = global::BackUp.Properties.Resources.beginbup;
            this.button5.Location = new System.Drawing.Point(286, 152);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(55, 55);
            this.button5.TabIndex = 119;
            this.toolTip1.SetToolTip(this.button5, "Start BackUp Now.");
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Image = global::BackUp.Properties.Resources.buptm;
            this.button4.Location = new System.Drawing.Point(381, 152);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(55, 55);
            this.button4.TabIndex = 121;
            this.toolTip1.SetToolTip(this.button4, "Set BackUp Time.");
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Image = global::BackUp.Properties.Resources.delbup;
            this.button3.Location = new System.Drawing.Point(476, 152);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(55, 55);
            this.button3.TabIndex = 120;
            this.toolTip1.SetToolTip(this.button3, "Delete BackUp Path");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Image = global::BackUp.Properties.Resources.edbup;
            this.button2.Location = new System.Drawing.Point(564, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(55, 55);
            this.button2.TabIndex = 118;
            this.toolTip1.SetToolTip(this.button2, "Edit Backup Path");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = global::BackUp.Properties.Resources.addbup;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(652, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 55);
            this.button1.TabIndex = 117;
            this.toolTip1.SetToolTip(this.button1, "Add Backup Path");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DodgerBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.مساعدةToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(994, 24);
            this.menuStrip1.TabIndex = 110;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // مساعدةToolStripMenuItem
            // 
            this.مساعدةToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.حـــولالتطبيقToolStripMenuItem,
            this.backUpLogToolStripMenuItem});
            this.مساعدةToolStripMenuItem.Name = "مساعدةToolStripMenuItem";
            this.مساعدةToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.مساعدةToolStripMenuItem.Text = "Help";
            // 
            // حـــولالتطبيقToolStripMenuItem
            // 
            this.حـــولالتطبيقToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("حـــولالتطبيقToolStripMenuItem.Image")));
            this.حـــولالتطبيقToolStripMenuItem.Name = "حـــولالتطبيقToolStripMenuItem";
            this.حـــولالتطبيقToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.حـــولالتطبيقToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.حـــولالتطبيقToolStripMenuItem.Text = "About";
            this.حـــولالتطبيقToolStripMenuItem.Click += new System.EventHandler(this.حـــولالتطبيقToolStripMenuItem_Click);
            // 
            // backUpLogToolStripMenuItem
            // 
            this.backUpLogToolStripMenuItem.Name = "backUpLogToolStripMenuItem";
            this.backUpLogToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.backUpLogToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.backUpLogToolStripMenuItem.Text = "BackUp Log.";
            this.backUpLogToolStripMenuItem.Click += new System.EventHandler(this.backUpLogToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.textBox27);
            this.groupBox1.Controls.Add(this.addlbl);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.fbmlbl);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(994, 548);
            this.groupBox1.TabIndex = 111;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BackUp Info";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.Color.GhostWhite;
            this.textBox2.ForeColor = System.Drawing.Color.Blue;
            this.textBox2.Location = new System.Drawing.Point(92, 97);
            this.textBox2.MaxLength = 255;
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(844, 48);
            this.textBox2.TabIndex = 113;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.GhostWhite;
            this.textBox1.ForeColor = System.Drawing.Color.Blue;
            this.textBox1.Location = new System.Drawing.Point(92, 59);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.Size = new System.Drawing.Size(844, 32);
            this.textBox1.TabIndex = 111;
            // 
            // textBox27
            // 
            this.textBox27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox27.BackColor = System.Drawing.Color.GhostWhite;
            this.textBox27.ForeColor = System.Drawing.Color.Blue;
            this.textBox27.Location = new System.Drawing.Point(92, 23);
            this.textBox27.Name = "textBox27";
            this.textBox27.ReadOnly = true;
            this.textBox27.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox27.Size = new System.Drawing.Size(844, 32);
            this.textBox27.TabIndex = 112;
            // 
            // addlbl
            // 
            this.addlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addlbl.AutoSize = true;
            this.addlbl.ForeColor = System.Drawing.Color.OrangeRed;
            this.addlbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.addlbl.Location = new System.Drawing.Point(20, 97);
            this.addlbl.Name = "addlbl";
            this.addlbl.Size = new System.Drawing.Size(56, 26);
            this.addlbl.TabIndex = 114;
            this.addlbl.Text = "Notes:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(20, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 26);
            this.label1.TabIndex = 116;
            this.label1.Text = "Target:";
            // 
            // fbmlbl
            // 
            this.fbmlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fbmlbl.AutoSize = true;
            this.fbmlbl.ForeColor = System.Drawing.Color.OrangeRed;
            this.fbmlbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.fbmlbl.Location = new System.Drawing.Point(20, 23);
            this.fbmlbl.Name = "fbmlbl";
            this.fbmlbl.Size = new System.Drawing.Size(63, 26);
            this.fbmlbl.TabIndex = 115;
            this.fbmlbl.Text = "Source:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView11);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.ForeColor = System.Drawing.Color.OrangeRed;
            this.groupBox2.Location = new System.Drawing.Point(3, 213);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(988, 332);
            this.groupBox2.TabIndex = 110;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BackUp Paths";
            // 
            // listView11
            // 
            this.listView11.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader70,
            this.columnHeader54,
            this.columnHeader77,
            this.columnHeader1});
            this.listView11.ContextMenuStrip = this.contextMenuStrip1;
            this.listView11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView11.ForeColor = System.Drawing.Color.Blue;
            this.listView11.FullRowSelect = true;
            this.listView11.GridLines = true;
            this.listView11.Location = new System.Drawing.Point(3, 31);
            this.listView11.MultiSelect = false;
            this.listView11.Name = "listView11";
            this.listView11.Size = new System.Drawing.Size(982, 298);
            this.listView11.TabIndex = 92;
            this.listView11.UseCompatibleStateImageBehavior = false;
            this.listView11.View = System.Windows.Forms.View.Details;
            this.listView11.SelectedIndexChanged += new System.EventHandler(this.listView11_SelectedIndexChanged);
            this.listView11.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView11_MouseDoubleClick);
            // 
            // columnHeader70
            // 
            this.columnHeader70.Text = "hid";
            this.columnHeader70.Width = 0;
            // 
            // columnHeader54
            // 
            this.columnHeader54.Text = "Source";
            this.columnHeader54.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader54.Width = 400;
            // 
            // columnHeader77
            // 
            this.columnHeader77.Text = "Target";
            this.columnHeader77.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader77.Width = 400;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Notes";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 250;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.إضافةمسارنسخاحتياطيToolStripMenuItem,
            this.تعديلمسارنسخاحتياطيToolStripMenuItem,
            this.حذفمسارالنسخالاحتياطيToolStripMenuItem,
            this.تحديدوقتالنسخالاحتياطيToolStripMenuItem,
            this.بدءالنسالاحتياطيالآنToolStripMenuItem,
            this.toolStripMenuItem1,
            this.خروجToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(217, 158);
            // 
            // إضافةمسارنسخاحتياطيToolStripMenuItem
            // 
            this.إضافةمسارنسخاحتياطيToolStripMenuItem.Name = "إضافةمسارنسخاحتياطيToolStripMenuItem";
            this.إضافةمسارنسخاحتياطيToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.إضافةمسارنسخاحتياطيToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.إضافةمسارنسخاحتياطيToolStripMenuItem.Text = "Add BackUp Path";
            this.إضافةمسارنسخاحتياطيToolStripMenuItem.Click += new System.EventHandler(this.إضافةمسارنسخاحتياطيToolStripMenuItem_Click);
            // 
            // تعديلمسارنسخاحتياطيToolStripMenuItem
            // 
            this.تعديلمسارنسخاحتياطيToolStripMenuItem.Name = "تعديلمسارنسخاحتياطيToolStripMenuItem";
            this.تعديلمسارنسخاحتياطيToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.تعديلمسارنسخاحتياطيToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.تعديلمسارنسخاحتياطيToolStripMenuItem.Text = "Edit BackUp Path";
            this.تعديلمسارنسخاحتياطيToolStripMenuItem.Click += new System.EventHandler(this.تعديلمسارنسخاحتياطيToolStripMenuItem_Click);
            // 
            // حذفمسارالنسخالاحتياطيToolStripMenuItem
            // 
            this.حذفمسارالنسخالاحتياطيToolStripMenuItem.Name = "حذفمسارالنسخالاحتياطيToolStripMenuItem";
            this.حذفمسارالنسخالاحتياطيToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.حذفمسارالنسخالاحتياطيToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.حذفمسارالنسخالاحتياطيToolStripMenuItem.Text = "Delete Backup Path";
            this.حذفمسارالنسخالاحتياطيToolStripMenuItem.Click += new System.EventHandler(this.حذفمسارالنسخالاحتياطيToolStripMenuItem_Click);
            // 
            // تحديدوقتالنسخالاحتياطيToolStripMenuItem
            // 
            this.تحديدوقتالنسخالاحتياطيToolStripMenuItem.Name = "تحديدوقتالنسخالاحتياطيToolStripMenuItem";
            this.تحديدوقتالنسخالاحتياطيToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.تحديدوقتالنسخالاحتياطيToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.تحديدوقتالنسخالاحتياطيToolStripMenuItem.Text = "Set BackUp Time.";
            this.تحديدوقتالنسخالاحتياطيToolStripMenuItem.Click += new System.EventHandler(this.تحديدوقتالنسخالاحتياطيToolStripMenuItem_Click);
            // 
            // بدءالنسالاحتياطيالآنToolStripMenuItem
            // 
            this.بدءالنسالاحتياطيالآنToolStripMenuItem.Name = "بدءالنسالاحتياطيالآنToolStripMenuItem";
            this.بدءالنسالاحتياطيالآنToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D5)));
            this.بدءالنسالاحتياطيالآنToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.بدءالنسالاحتياطيالآنToolStripMenuItem.Text = "Start BackUp Now.";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(216, 22);
            this.toolStripMenuItem1.Text = "BackUp Log.";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // خروجToolStripMenuItem
            // 
            this.خروجToolStripMenuItem.Name = "خروجToolStripMenuItem";
            this.خروجToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.خروجToolStripMenuItem.Text = "Exit.";
            this.خروجToolStripMenuItem.Click += new System.EventHandler(this.خروجToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "BackUp";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(994, 572);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Simplified Arabic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BackUp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem مساعدةToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem حـــولالتطبيقToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backUpLogToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox27;
        private System.Windows.Forms.Label addlbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label fbmlbl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView11;
        private System.Windows.Forms.ColumnHeader columnHeader70;
        private System.Windows.Forms.ColumnHeader columnHeader54;
        private System.Windows.Forms.ColumnHeader columnHeader77;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem إضافةمسارنسخاحتياطيToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem تعديلمسارنسخاحتياطيToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem حذفمسارالنسخالاحتياطيToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem تحديدوقتالنسخالاحتياطيToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem بدءالنسالاحتياطيالآنToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem خروجToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

