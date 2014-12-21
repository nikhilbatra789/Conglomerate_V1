namespace Conglomerate
{
    partial class DBA
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panelRequest = new System.Windows.Forms.Panel();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPaymentID = new System.Windows.Forms.TextBox();
            this.txtCmpName = new System.Windows.Forms.TextBox();
            this.drpCmpny = new System.Windows.Forms.ComboBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelRequest.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Prefix";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 331);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Company";
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(141, 328);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(100, 20);
            this.txtPrefix.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(457, 326);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add Company";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelRequest
            // 
            this.panelRequest.Controls.Add(this.txtMobile);
            this.panelRequest.Controls.Add(this.txtEmail);
            this.panelRequest.Controls.Add(this.txtPaymentID);
            this.panelRequest.Controls.Add(this.txtCmpName);
            this.panelRequest.Location = new System.Drawing.Point(91, 42);
            this.panelRequest.Name = "panelRequest";
            this.panelRequest.Size = new System.Drawing.Size(461, 247);
            this.panelRequest.TabIndex = 5;
            // 
            // txtMobile
            // 
            this.txtMobile.Enabled = false;
            this.txtMobile.Location = new System.Drawing.Point(358, 3);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(100, 20);
            this.txtMobile.TabIndex = 3;
            this.txtMobile.Text = "Mobile No";
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(217, 3);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(135, 20);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.Text = "Email ID";
            // 
            // txtPaymentID
            // 
            this.txtPaymentID.Enabled = false;
            this.txtPaymentID.Location = new System.Drawing.Point(146, 3);
            this.txtPaymentID.Name = "txtPaymentID";
            this.txtPaymentID.Size = new System.Drawing.Size(65, 20);
            this.txtPaymentID.TabIndex = 1;
            this.txtPaymentID.Text = "Payment ID";
            // 
            // txtCmpName
            // 
            this.txtCmpName.Enabled = false;
            this.txtCmpName.Location = new System.Drawing.Point(3, 3);
            this.txtCmpName.Name = "txtCmpName";
            this.txtCmpName.Size = new System.Drawing.Size(137, 20);
            this.txtCmpName.TabIndex = 0;
            this.txtCmpName.Text = "Company Name";
            // 
            // drpCmpny
            // 
            this.drpCmpny.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpCmpny.FormattingEnabled = true;
            this.drpCmpny.Location = new System.Drawing.Point(327, 326);
            this.drpCmpny.Name = "drpCmpny";
            this.drpCmpny.Size = new System.Drawing.Size(100, 21);
            this.drpCmpny.TabIndex = 2;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(587, 42);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // DBA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 423);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.drpCmpny);
            this.Controls.Add(this.panelRequest);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPrefix);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DBA";
            this.Text = "DBA";
            this.Load += new System.EventHandler(this.DBA_Load);
            this.panelRequest.ResumeLayout(false);
            this.panelRequest.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mobileDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panelRequest;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPaymentID;
        private System.Windows.Forms.TextBox txtCmpName;
        private System.Windows.Forms.ComboBox drpCmpny;
        private System.Windows.Forms.Button btnLogout;
    }
}