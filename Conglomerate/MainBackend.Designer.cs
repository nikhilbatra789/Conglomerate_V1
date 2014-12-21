namespace Conglomerate
{
    partial class MainBackend
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LoginAs = new System.Windows.Forms.Button();
            this.ViewTables = new System.Windows.Forms.Button();
            this.OLTPSettings = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.AddUser = new System.Windows.Forms.Button();
            this.DefineOLTP = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oLTPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defineOLTPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delOLTPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executeQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginAsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewLogstoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.93617F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.06383F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1252, 568);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(240, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1009, 488);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(240, 497);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1009, 68);
            this.panel2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(989, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 68);
            this.button1.TabIndex = 0;
            this.button1.Text = "R e f r e sh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 497);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(231, 68);
            this.panel3.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.LoginAs);
            this.panel4.Controls.Add(this.ViewTables);
            this.panel4.Controls.Add(this.OLTPSettings);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Controls.Add(this.AddUser);
            this.panel4.Controls.Add(this.DefineOLTP);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(231, 485);
            this.panel4.TabIndex = 4;
            // 
            // LoginAs
            // 
            this.LoginAs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginAs.Location = new System.Drawing.Point(10, 197);
            this.LoginAs.Name = "LoginAs";
            this.LoginAs.Size = new System.Drawing.Size(211, 88);
            this.LoginAs.TabIndex = 5;
            this.LoginAs.Text = "Login As";
            this.LoginAs.UseVisualStyleBackColor = true;
            this.LoginAs.Click += new System.EventHandler(this.LoginAs_Click);
            // 
            // ViewTables
            // 
            this.ViewTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewTables.Location = new System.Drawing.Point(10, 291);
            this.ViewTables.Name = "ViewTables";
            this.ViewTables.Size = new System.Drawing.Size(211, 88);
            this.ViewTables.TabIndex = 4;
            this.ViewTables.Text = "View Tables";
            this.ViewTables.UseVisualStyleBackColor = true;
            this.ViewTables.Click += new System.EventHandler(this.button5_Click);
            // 
            // OLTPSettings
            // 
            this.OLTPSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OLTPSettings.Location = new System.Drawing.Point(10, 197);
            this.OLTPSettings.Name = "OLTPSettings";
            this.OLTPSettings.Size = new System.Drawing.Size(211, 88);
            this.OLTPSettings.TabIndex = 3;
            this.OLTPSettings.Text = "OLTP Settings";
            this.OLTPSettings.UseVisualStyleBackColor = true;
            this.OLTPSettings.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(10, 385);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(211, 88);
            this.button3.TabIndex = 2;
            this.button3.Text = "View Logs";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // AddUser
            // 
            this.AddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddUser.Location = new System.Drawing.Point(9, 103);
            this.AddUser.Name = "AddUser";
            this.AddUser.Size = new System.Drawing.Size(211, 88);
            this.AddUser.TabIndex = 1;
            this.AddUser.Text = "Add User";
            this.AddUser.UseVisualStyleBackColor = true;
            this.AddUser.Click += new System.EventHandler(this.button2_Click);
            // 
            // DefineOLTP
            // 
            this.DefineOLTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefineOLTP.Location = new System.Drawing.Point(9, 9);
            this.DefineOLTP.Name = "DefineOLTP";
            this.DefineOLTP.Size = new System.Drawing.Size(211, 88);
            this.DefineOLTP.TabIndex = 0;
            this.DefineOLTP.Text = "Define OLTP";
            this.DefineOLTP.UseVisualStyleBackColor = true;
            this.DefineOLTP.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.userToolStripMenuItem,
            this.oLTPToolStripMenuItem,
            this.loginAsStripMenuItem,
            this.profileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1252, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loToolStripMenuItem
            // 
            this.loToolStripMenuItem.Name = "loToolStripMenuItem";
            this.loToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.loToolStripMenuItem.Text = "Logout";
            this.loToolStripMenuItem.Click += new System.EventHandler(this.loToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(109, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUserToolStripMenuItem,
            this.deleteUserToolStripMenuItem});
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.userToolStripMenuItem.Text = "User";
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.addUserToolStripMenuItem.Text = "Add User";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // deleteUserToolStripMenuItem
            // 
            this.deleteUserToolStripMenuItem.Name = "deleteUserToolStripMenuItem";
            this.deleteUserToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.deleteUserToolStripMenuItem.Text = "Delete User";
            this.deleteUserToolStripMenuItem.Click += new System.EventHandler(this.deleteUserToolStripMenuItem_Click);
            // 
            // oLTPToolStripMenuItem
            // 
            this.oLTPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defineOLTPToolStripMenuItem,
            this.delOLTPToolStripMenuItem,
            this.toolStripMenuItem2,
            this.settingsToolStripMenuItem,
            this.viewTablesToolStripMenuItem,
            this.executeQueryToolStripMenuItem});
            this.oLTPToolStripMenuItem.Name = "oLTPToolStripMenuItem";
            this.oLTPToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.oLTPToolStripMenuItem.Text = "OLTP";
            // 
            // defineOLTPToolStripMenuItem
            // 
            this.defineOLTPToolStripMenuItem.Name = "defineOLTPToolStripMenuItem";
            this.defineOLTPToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.defineOLTPToolStripMenuItem.Text = "Define OLTP";
            this.defineOLTPToolStripMenuItem.Click += new System.EventHandler(this.defineOLTPToolStripMenuItem_Click);
            // 
            // delOLTPToolStripMenuItem
            // 
            this.delOLTPToolStripMenuItem.Name = "delOLTPToolStripMenuItem";
            this.delOLTPToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.delOLTPToolStripMenuItem.Text = "Delete OLTP";
            this.delOLTPToolStripMenuItem.Click += new System.EventHandler(this.delOLTPToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(146, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // viewTablesToolStripMenuItem
            // 
            this.viewTablesToolStripMenuItem.Name = "viewTablesToolStripMenuItem";
            this.viewTablesToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.viewTablesToolStripMenuItem.Text = "View Tables";
            this.viewTablesToolStripMenuItem.Click += new System.EventHandler(this.viewTablesToolStripMenuItem_Click);
            // 
            // executeQueryToolStripMenuItem
            // 
            this.executeQueryToolStripMenuItem.Name = "executeQueryToolStripMenuItem";
            this.executeQueryToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.executeQueryToolStripMenuItem.Text = "Execute Query";
            this.executeQueryToolStripMenuItem.Click += new System.EventHandler(this.executeQueryToolStripMenuItem_Click);
            // 
            // loginAsStripMenuItem
            // 
            this.loginAsStripMenuItem.Name = "loginAsStripMenuItem";
            this.loginAsStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.loginAsStripMenuItem.Text = "Login As";
            this.loginAsStripMenuItem.Click += new System.EventHandler(this.loginAsStripMenuItem_Click);
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordtoolStripMenuItem,
            this.viewLogstoolStripMenuItem});
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.profileToolStripMenuItem.Text = "Profile";
            // 
            // changePasswordtoolStripMenuItem
            // 
            this.changePasswordtoolStripMenuItem.Name = "changePasswordtoolStripMenuItem";
            this.changePasswordtoolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.changePasswordtoolStripMenuItem.Text = "Change Password";
            this.changePasswordtoolStripMenuItem.Click += new System.EventHandler(this.changePasswordtoolStripMenuItem_Click);
            // 
            // viewLogstoolStripMenuItem
            // 
            this.viewLogstoolStripMenuItem.Name = "viewLogstoolStripMenuItem";
            this.viewLogstoolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.viewLogstoolStripMenuItem.Text = "View Logs";
            this.viewLogstoolStripMenuItem.Click += new System.EventHandler(this.viewLogstoolStripMenuItem_Click);
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tableLayoutPanel1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1252, 568);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(1252, 592);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // MainBackend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 592);
            this.Controls.Add(this.toolStripContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainBackend";
            this.Text = "Conglomerate";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button AddUser;
        private System.Windows.Forms.Button DefineOLTP;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OLTPSettings;
        private System.Windows.Forms.Button ViewTables;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripMenuItem loToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button LoginAs;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oLTPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defineOLTPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delOLTPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewTablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executeQueryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginAsStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordtoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewLogstoolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.Button button1;
    }
}