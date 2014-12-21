namespace Conglomerate
{
    partial class Basic_Details
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
            this.label2 = new System.Windows.Forms.Label();
            this.p_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.c_name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dw_name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.no_of_table = new System.Windows.Forms.TextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project Details";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Project Name";
            // 
            // p_name
            // 
            this.p_name.Location = new System.Drawing.Point(205, 55);
            this.p_name.Name = "p_name";
            this.p_name.Size = new System.Drawing.Size(100, 20);
            this.p_name.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Company Name";
            // 
            // c_name
            // 
            this.c_name.Enabled = false;
            this.c_name.Location = new System.Drawing.Point(205, 110);
            this.c_name.Name = "c_name";
            this.c_name.Size = new System.Drawing.Size(100, 20);
            this.c_name.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Data Warehouse Name";
            // 
            // dw_name
            // 
            this.dw_name.Location = new System.Drawing.Point(205, 175);
            this.dw_name.Name = "dw_name";
            this.dw_name.Size = new System.Drawing.Size(100, 20);
            this.dw_name.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "No of Tables";
            // 
            // no_of_table
            // 
            this.no_of_table.Location = new System.Drawing.Point(205, 229);
            this.no_of_table.Name = "no_of_table";
            this.no_of_table.Size = new System.Drawing.Size(100, 20);
            this.no_of_table.TabIndex = 8;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(205, 301);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 9;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // Basic_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 381);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.no_of_table);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dw_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.c_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.p_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Basic_Details";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Basic Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox p_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox c_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox dw_name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox no_of_table;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}