namespace SampleAppWithWrapper
{
    partial class UserControlPage
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
            this.Print_button = new System.Windows.Forms.Button();
            this.selectFile = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pbLabelPreview = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbLabelPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // Print_button
            // 
            this.Print_button.Location = new System.Drawing.Point(732, 178);
            this.Print_button.Name = "Print_button";
            this.Print_button.Size = new System.Drawing.Size(100, 35);
            this.Print_button.TabIndex = 1;
            this.Print_button.Text = "Print";
            this.Print_button.UseVisualStyleBackColor = false;
            this.Print_button.Click += new System.EventHandler(this.Print_button_Click);
            // 
            // selectFile
            // 
            this.selectFile.Location = new System.Drawing.Point(171, 13);
            this.selectFile.Name = "selectFile";
            this.selectFile.Size = new System.Drawing.Size(241, 23);
            this.selectFile.TabIndex = 2;
            this.selectFile.Text = "Select templete";
            this.selectFile.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.selectFile.UseVisualStyleBackColor = false;
            this.selectFile.Click += new System.EventHandler(this.selectFile_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(631, 76);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(153, 21);
            this.comboBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(801, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(732, 116);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 26);
            this.button2.TabIndex = 6;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pbLabelPreview
            // 
            this.pbLabelPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLabelPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLabelPreview.Location = new System.Drawing.Point(54, 64);
            this.pbLabelPreview.Name = "pbLabelPreview";
            this.pbLabelPreview.Size = new System.Drawing.Size(528, 310);
            this.pbLabelPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLabelPreview.TabIndex = 8;
            this.pbLabelPreview.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(633, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 32);
            this.button1.TabIndex = 9;
            this.button1.Text = "Printer Settings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // UserControlPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 400);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pbLabelPreview);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.selectFile);
            this.Controls.Add(this.Print_button);
            this.Name = "UserControlPage";
            this.Text = "UserControlPage";
            this.Load += new System.EventHandler(this.UserControlPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLabelPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Print_button;
        private System.Windows.Forms.Button selectFile;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pbLabelPreview;
        private System.Windows.Forms.Button button1;
    }
}