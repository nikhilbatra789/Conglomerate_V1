namespace Conglomerate
{
    partial class CleansingDisplay
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Tablename = new System.Windows.Forms.Label();
            this.Extract = new System.Windows.Forms.Label();
            this.Transform = new System.Windows.Forms.Label();
            this.ld = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(225, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cleansing is in Progress";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Conglomerate.Properties.Resources.Cleansing;
            this.pictureBox1.Location = new System.Drawing.Point(274, 109);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 175);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Tablename
            // 
            this.Tablename.Location = new System.Drawing.Point(123, 68);
            this.Tablename.Name = "Tablename";
            this.Tablename.Size = new System.Drawing.Size(479, 23);
            this.Tablename.TabIndex = 2;
            this.Tablename.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Extract
            // 
            this.Extract.AutoSize = true;
            this.Extract.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Extract.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Extract.Location = new System.Drawing.Point(142, 307);
            this.Extract.Name = "Extract";
            this.Extract.Size = new System.Drawing.Size(66, 20);
            this.Extract.TabIndex = 3;
            this.Extract.Text = "Extract";
            // 
            // Transform
            // 
            this.Transform.AutoSize = true;
            this.Transform.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Transform.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Transform.Location = new System.Drawing.Point(317, 307);
            this.Transform.Name = "Transform";
            this.Transform.Size = new System.Drawing.Size(90, 20);
            this.Transform.TabIndex = 4;
            this.Transform.Text = "Transform";
            // 
            // ld
            // 
            this.ld.AutoSize = true;
            this.ld.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ld.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ld.Location = new System.Drawing.Point(512, 307);
            this.ld.Name = "ld";
            this.ld.Size = new System.Drawing.Size(49, 20);
            this.ld.TabIndex = 5;
            this.ld.Text = "Load";
            // 
            // CleansingDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(725, 351);
            this.Controls.Add(this.ld);
            this.Controls.Add(this.Transform);
            this.Controls.Add(this.Extract);
            this.Controls.Add(this.Tablename);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CleansingDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CleansingDisplay";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Tablename;
        private System.Windows.Forms.Label Extract;
        private System.Windows.Forms.Label Transform;
        private System.Windows.Forms.Label ld;
    }
}