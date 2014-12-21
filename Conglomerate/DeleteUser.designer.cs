namespace Conglomerate
{
    partial class DeleteUser
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
            this.label1 = new System.Windows.Forms.Label();
            this.userOltp = new System.Windows.Forms.ComboBox();
            this.userName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.adminOltp = new System.Windows.Forms.ComboBox();
            this.adminName = new System.Windows.Forms.ComboBox();
            this.deluser = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.deladmin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(101, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Delete User:";
            // 
            // userOltp
            // 
            this.userOltp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userOltp.FormattingEnabled = true;
            this.userOltp.Location = new System.Drawing.Point(104, 114);
            this.userOltp.Name = "userOltp";
            this.userOltp.Size = new System.Drawing.Size(121, 21);
            this.userOltp.TabIndex = 1;
            this.userOltp.SelectedIndexChanged += new System.EventHandler(this.userOltp_SelectedIndexChanged);
            // 
            // userName
            // 
            this.userName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userName.FormattingEnabled = true;
            this.userName.Location = new System.Drawing.Point(362, 113);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(121, 21);
            this.userName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(101, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Delete Admin:";
            // 
            // adminOltp
            // 
            this.adminOltp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.adminOltp.FormattingEnabled = true;
            this.adminOltp.Location = new System.Drawing.Point(104, 290);
            this.adminOltp.Name = "adminOltp";
            this.adminOltp.Size = new System.Drawing.Size(121, 21);
            this.adminOltp.TabIndex = 4;
            this.adminOltp.SelectedIndexChanged += new System.EventHandler(this.adminOltp_SelectedIndexChanged);
            // 
            // adminName
            // 
            this.adminName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.adminName.FormattingEnabled = true;
            this.adminName.Location = new System.Drawing.Point(362, 290);
            this.adminName.Name = "adminName";
            this.adminName.Size = new System.Drawing.Size(121, 21);
            this.adminName.TabIndex = 5;
            // 
            // deluser
            // 
            this.deluser.Location = new System.Drawing.Point(602, 174);
            this.deluser.Name = "deluser";
            this.deluser.Size = new System.Drawing.Size(75, 23);
            this.deluser.TabIndex = 6;
            this.deluser.Text = "Delete";
            this.deluser.UseVisualStyleBackColor = true;
            this.deluser.Click += new System.EventHandler(this.deluser_Click);
            // 
            // deladmin
            // 
            this.deladmin.Location = new System.Drawing.Point(602, 331);
            this.deladmin.Name = "deladmin";
            this.deladmin.Size = new System.Drawing.Size(75, 23);
            this.deladmin.TabIndex = 7;
            this.deladmin.Text = "Delete";
            this.deladmin.UseVisualStyleBackColor = true;
            this.deladmin.Click += new System.EventHandler(this.deladmin_Click_1);
            // 
            // DeleteUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 375);
            this.Controls.Add(this.deladmin);
            this.Controls.Add(this.deluser);
            this.Controls.Add(this.adminName);
            this.Controls.Add(this.adminOltp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.userOltp);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DeleteUser";
            this.Text = "Delete User";
            this.Load += new System.EventHandler(this.DeleteUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox userOltp;
        private System.Windows.Forms.ComboBox userName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox adminOltp;
        private System.Windows.Forms.ComboBox adminName;
        private System.Windows.Forms.Button deluser;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button deladmin;
    }
}