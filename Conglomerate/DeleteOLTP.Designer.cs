namespace Conglomerate
{
    partial class DeleteOLTP
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
            this.Delete = new System.Windows.Forms.Button();
            this.OLTPName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(504, 72);
            this.label1.TabIndex = 0;
            this.label1.Text = "Do you really want to delete your OLTP. This may lead to loss of your data. If yo" +
                "u delete it you will have to redefine it in order to use it.";
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(483, 163);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 1;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // OLTPName
            // 
            this.OLTPName.AutoSize = true;
            this.OLTPName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OLTPName.Location = new System.Drawing.Point(54, 163);
            this.OLTPName.Name = "OLTPName";
            this.OLTPName.Size = new System.Drawing.Size(57, 20);
            this.OLTPName.TabIndex = 2;
            this.OLTPName.Text = "label2";
            // 
            // DeleteOLTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 261);
            this.Controls.Add(this.OLTPName);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.label1);
            this.Name = "DeleteOLTP";
            this.Text = "DeleteOLTP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Label OLTPName;
    }
}