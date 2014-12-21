namespace Conglomerate
{
    partial class FormChoice
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
            this.drpformChoice = new System.Windows.Forms.ComboBox();
            this.Load = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // drpformChoice
            // 
            this.drpformChoice.FormattingEnabled = true;
            this.drpformChoice.Location = new System.Drawing.Point(94, 101);
            this.drpformChoice.Name = "drpformChoice";
            this.drpformChoice.Size = new System.Drawing.Size(121, 21);
            this.drpformChoice.TabIndex = 0;
            // 
            // Load
            // 
            this.Load.Location = new System.Drawing.Point(233, 101);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(75, 23);
            this.Load.TabIndex = 1;
            this.Load.Text = "Load";
            this.Load.UseVisualStyleBackColor = true;
            this.Load.Click += new System.EventHandler(this.Load_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please choose a form that you would like to open.";
            // 
            // FormChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 242);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Load);
            this.Controls.Add(this.drpformChoice);
            this.Name = "FormChoice";
            this.Text = "FormChoice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox drpformChoice;
        private System.Windows.Forms.Button Load;
        private System.Windows.Forms.Label label1;
    }
}