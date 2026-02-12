namespace SampleAppWithWrapper
{
    partial class SampleAppMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bnShowCS = new System.Windows.Forms.Button();
            this.tbLabelFolder = new System.Windows.Forms.TextBox();
            this.lblLabelFolder = new System.Windows.Forms.Label();
            this.bnLabelFolder = new System.Windows.Forms.Button();
            this.listboxLabels = new System.Windows.Forms.ListBox();
            this.pbLabelPreview = new System.Windows.Forms.PictureBox();
            this.listboxVars = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUpdateVar = new System.Windows.Forms.Button();
            this.lblVarValue = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPageSetup = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bnPrinterSettings = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxPrinter = new System.Windows.Forms.ComboBox();
            this.txtQtyValue = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbLabelPreview)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnShowCS
            // 
            this.bnShowCS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bnShowCS.Location = new System.Drawing.Point(17, 406);
            this.bnShowCS.Name = "bnShowCS";
            this.bnShowCS.Size = new System.Drawing.Size(161, 23);
            this.bnShowCS.TabIndex = 0;
            this.bnShowCS.Text = "Show/Hide Designer";
            this.bnShowCS.UseVisualStyleBackColor = true;
            this.bnShowCS.Click += new System.EventHandler(this.bnShowCS_Click);
            // 
            // tbLabelFolder
            // 
            this.tbLabelFolder.Enabled = false;
            this.tbLabelFolder.Location = new System.Drawing.Point(17, 42);
            this.tbLabelFolder.Name = "tbLabelFolder";
            this.tbLabelFolder.Size = new System.Drawing.Size(242, 20);
            this.tbLabelFolder.TabIndex = 1;
            this.tbLabelFolder.TextChanged += new System.EventHandler(this.tbLabelFolder_TextChanged);
            // 
            // lblLabelFolder
            // 
            this.lblLabelFolder.AutoSize = true;
            this.lblLabelFolder.Location = new System.Drawing.Point(14, 17);
            this.lblLabelFolder.Name = "lblLabelFolder";
            this.lblLabelFolder.Size = new System.Drawing.Size(62, 13);
            this.lblLabelFolder.TabIndex = 2;
            this.lblLabelFolder.Text = "Label folder";
            // 
            // bnLabelFolder
            // 
            this.bnLabelFolder.Location = new System.Drawing.Point(265, 39);
            this.bnLabelFolder.Name = "bnLabelFolder";
            this.bnLabelFolder.Size = new System.Drawing.Size(26, 23);
            this.bnLabelFolder.TabIndex = 3;
            this.bnLabelFolder.Text = "...";
            this.bnLabelFolder.UseVisualStyleBackColor = true;
            this.bnLabelFolder.Click += new System.EventHandler(this.bnLabelFolder_Click);
            // 
            // listboxLabels
            // 
            this.listboxLabels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listboxLabels.ForeColor = System.Drawing.SystemColors.ControlText;
            this.listboxLabels.Location = new System.Drawing.Point(17, 77);
            this.listboxLabels.Name = "listboxLabels";
            this.listboxLabels.Size = new System.Drawing.Size(242, 160);
            this.listboxLabels.Sorted = true;
            this.listboxLabels.TabIndex = 4;
            this.listboxLabels.SelectedIndexChanged += new System.EventHandler(this.listboxLabels_SelectedIndexChanged);
            // 
            // pbLabelPreview
            // 
            this.pbLabelPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLabelPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLabelPreview.Location = new System.Drawing.Point(310, 17);
            this.pbLabelPreview.Name = "pbLabelPreview";
            this.pbLabelPreview.Size = new System.Drawing.Size(273, 208);
            this.pbLabelPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLabelPreview.TabIndex = 5;
            this.pbLabelPreview.TabStop = false;
            // 
            // listboxVars
            // 
            this.listboxVars.ForeColor = System.Drawing.SystemColors.ControlText;
            this.listboxVars.Location = new System.Drawing.Point(11, 19);
            this.listboxVars.Name = "listboxVars";
            this.listboxVars.Size = new System.Drawing.Size(225, 95);
            this.listboxVars.TabIndex = 9;
            this.listboxVars.SelectedIndexChanged += new System.EventHandler(this.listboxVars_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.listboxVars);
            this.groupBox2.Controls.Add(this.btnUpdateVar);
            this.groupBox2.Controls.Add(this.lblVarValue);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(17, 242);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(242, 159);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Variables settings";
            // 
            // btnUpdateVar
            // 
            this.btnUpdateVar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnUpdateVar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpdateVar.Location = new System.Drawing.Point(167, 126);
            this.btnUpdateVar.Name = "btnUpdateVar";
            this.btnUpdateVar.Size = new System.Drawing.Size(60, 24);
            this.btnUpdateVar.TabIndex = 13;
            this.btnUpdateVar.Text = "Update";
            this.btnUpdateVar.UseVisualStyleBackColor = true;
            this.btnUpdateVar.Click += new System.EventHandler(this.btnUpdateVar_Click);
            // 
            // lblVarValue
            // 
            this.lblVarValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblVarValue.Location = new System.Drawing.Point(11, 127);
            this.lblVarValue.Name = "lblVarValue";
            this.lblVarValue.Size = new System.Drawing.Size(150, 20);
            this.lblVarValue.TabIndex = 12;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPrint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPrint.Location = new System.Drawing.Point(111, 26);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(94, 24);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPageSetup
            // 
            this.btnPageSetup.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPageSetup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPageSetup.Location = new System.Drawing.Point(111, 56);
            this.btnPageSetup.Name = "btnPageSetup";
            this.btnPageSetup.Size = new System.Drawing.Size(94, 24);
            this.btnPageSetup.TabIndex = 9;
            this.btnPageSetup.Text = "Page setup";
            this.btnPageSetup.UseVisualStyleBackColor = true;
            this.btnPageSetup.Click += new System.EventHandler(this.btnPageSetup_Click);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(8, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Label qty :";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.bnPrinterSettings);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.comboBoxPrinter);
            this.groupBox3.Controls.Add(this.btnPrint);
            this.groupBox3.Controls.Add(this.btnPageSetup);
            this.groupBox3.Controls.Add(this.txtQtyValue);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox3.Location = new System.Drawing.Point(310, 242);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(273, 159);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Printing settings";
            // 
            // bnPrinterSettings
            // 
            this.bnPrinterSettings.BackColor = System.Drawing.Color.LightSteelBlue;
            this.bnPrinterSettings.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bnPrinterSettings.Location = new System.Drawing.Point(206, 123);
            this.bnPrinterSettings.Name = "bnPrinterSettings";
            this.bnPrinterSettings.Size = new System.Drawing.Size(58, 24);
            this.bnPrinterSettings.TabIndex = 13;
            this.bnPrinterSettings.Text = "Settings";
            this.bnPrinterSettings.UseVisualStyleBackColor = true;
            this.bnPrinterSettings.Click += new System.EventHandler(this.bnPrinterSettings_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Printer";
            // 
            // comboBoxPrinter
            // 
            this.comboBoxPrinter.FormattingEnabled = true;
            this.comboBoxPrinter.Location = new System.Drawing.Point(11, 126);
            this.comboBoxPrinter.Name = "comboBoxPrinter";
            this.comboBoxPrinter.Size = new System.Drawing.Size(189, 21);
            this.comboBoxPrinter.Sorted = true;
            this.comboBoxPrinter.TabIndex = 11;
            this.comboBoxPrinter.SelectedIndexChanged += new System.EventHandler(this.comboBoxPrinter_SelectedIndexChanged);
            // 
            // txtQtyValue
            // 
            this.txtQtyValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtQtyValue.Location = new System.Drawing.Point(73, 26);
            this.txtQtyValue.Name = "txtQtyValue";
            this.txtQtyValue.Size = new System.Drawing.Size(32, 20);
            this.txtQtyValue.TabIndex = 8;
            this.txtQtyValue.Text = "1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(204, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 20);
            this.button1.TabIndex = 18;
            this.button1.Text = "Hide";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SampleAppMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 441);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pbLabelPreview);
            this.Controls.Add(this.listboxLabels);
            this.Controls.Add(this.bnLabelFolder);
            this.Controls.Add(this.lblLabelFolder);
            this.Controls.Add(this.tbLabelFolder);
            this.Controls.Add(this.bnShowCS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "SampleAppMainForm";
            this.Text = ".NET Wrapper Demo Application";
            this.Load += new System.EventHandler(this.SampleAppMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLabelPreview)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnShowCS;
        private System.Windows.Forms.TextBox tbLabelFolder;
        private System.Windows.Forms.Label lblLabelFolder;
        private System.Windows.Forms.Button bnLabelFolder;
        private System.Windows.Forms.ListBox listboxLabels;
        private System.Windows.Forms.PictureBox pbLabelPreview;
        private System.Windows.Forms.ListBox listboxVars;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox lblVarValue;
        private System.Windows.Forms.Button btnUpdateVar;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPageSetup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtQtyValue;
        private System.Windows.Forms.Button bnPrinterSettings;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comboBoxPrinter;
        private System.Windows.Forms.Button button1;
    }
}

