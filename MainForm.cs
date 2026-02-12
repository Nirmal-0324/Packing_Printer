using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using Tkx.Lppa;

namespace SampleAppWithWrapper
{
    public partial class SampleAppMainForm : Form
    {
        Tkx.Lppa.Application NetApp = null;
        private Tkx.Lppa.Document ActiveDoc;
   //     UserControlPage userpage = new UserControlPage();
        public SampleAppMainForm()
        {
            InitializeComponent();
            //     userpage.Show();
        }

        private void SampleAppMainForm_Load(object sender, EventArgs e)
        {
            NetApp = new Tkx.Lppa.Application();
            NetApp.PreloadUI();

            //NetApp = Tkx.Lppa.Application.SelectApplication();

           // tbLabelFolder.Text = NetApp.DefaultFilePath;
            UpdatePrinterList();
          //  comboBoxPrinter.SelectedIndex = 2;

        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (ActiveDoc != null)
            {
                ActiveDoc.Close(false);
                ActiveDoc.Dispose();
            }

            if(NetApp != null)
                NetApp.Quit();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        
        public void UpdatePrinterList()
        {
            comboBoxPrinter.Items.Clear();

            string[] AllPrintersName;
            AllPrintersName = NetApp.PrinterSystem.PrintersNames(KindOfPrinters.AllPrinters);
            foreach (string PrinterName in AllPrintersName)
            {
                comboBoxPrinter.Items.Add(PrinterName);
            }
        }

        private void UpdateSelectedPrinter()
        {
            if (ActiveDoc != null)
            {
                string SelectedPrinter = ActiveDoc.Printer.Name;
                int Id = comboBoxPrinter.Items.IndexOf(SelectedPrinter);
                comboBoxPrinter.SelectedIndex = Id;
            }
        }

        private void UpdateFileList()
        {
            listboxLabels.Items.Clear();
            if ((tbLabelFolder.Text != ""))
            {
                string[] fileList = Directory.GetFiles(tbLabelFolder.Text, "*.lab");
                foreach (string currentFile in fileList)
                {
                    listboxLabels.Items.Add(currentFile.Substring(currentFile.LastIndexOf("\\") + 1));
                }
            }
            listboxLabels.SelectedIndex = -1;
            pbLabelPreview.Image = null;
        }

        private void UpdateLabelPreview()
        {
            if(ActiveDoc != null)
            {
                pbLabelPreview.Image = ActiveDoc != null ? ActiveDoc.GetPreview(true, true, 400) : null;
            }
        }
        public PictureBox UpdateLabelPreview2()
        {
            if (ActiveDoc != null)
            {
                pbLabelPreview.Image = ActiveDoc != null ? ActiveDoc.GetPreview(true, true, 400) : null;
            }
            return pbLabelPreview;

        }

        private void UpdateVarList()
        {
            listboxVars.Items.Clear();

            if (ActiveDoc != null)
            {
                foreach (Variable aVariable in ActiveDoc.Variables)
                {
                    listboxVars.Items.Add(aVariable.Name);
                }
            }

            if (listboxVars.Items.Count > 0)
                listboxVars.SelectedIndex = 0;
        }


        private void bnShowCS_Click(object sender, EventArgs e)
        {
            NetApp.Visible = !NetApp.Visible;
        }

        private void bnLabelFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.SelectedPath = tbLabelFolder.Text;

            if (FBD.ShowDialog() == DialogResult.OK)
            {
                string dirName = FBD.SelectedPath;
                tbLabelFolder.Text = dirName;
            }

        }

        private void tbLabelFolder_TextChanged(object sender, EventArgs e)
        {
            UpdateFileList();
        }

        private void listboxLabels_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveDoc != null)
            {
                ActiveDoc.Close(false);
                ActiveDoc.Dispose();
                ActiveDoc = null;
            }

            ActiveDoc = NetApp.Documents.Open(tbLabelFolder.Text + "\\" + listboxLabels.Text, false);

            UpdateLabelPreview();
            UpdateVarList();
            UpdateSelectedPrinter();
        }
        public List<string> change_active_doc(string docName)
        {
            if (ActiveDoc != null)
            {
                ActiveDoc.Close(false);
                ActiveDoc.Dispose();
                ActiveDoc = null;
            }

            ActiveDoc = NetApp.Documents.Open(docName, false);

            UpdateLabelPreview();
            UpdateVarList();
            UpdateSelectedPrinter();
            List<string> vars = new List<string>();
            foreach(string i in listboxVars.Items)
            {
                vars.Add(i);
            }
            return vars;
        }
        private void listboxVars_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveDoc != null)
            {
                Variable aVariable = ActiveDoc.Variables[listboxVars.Text];
            //    MessageBox.Show(listboxVars.Text);
                lblVarValue.Text = aVariable.Value;
            }
        }

        private void btnUpdateVar_Click(object sender, EventArgs e)
        {
            if (ActiveDoc != null)
            {
                Variable aVariable = ActiveDoc.Variables[listboxVars.Text];
                aVariable.Value = lblVarValue.Text;
            }

            UpdateLabelPreview();
        }
       
        public void change_variable(string variable, string value)
        {
            if (ActiveDoc != null)
            {
                Variable aVariable = ActiveDoc.Variables[variable];
                aVariable.Value = value;
            }

            UpdateLabelPreview();
        }
        private void btnPageSetup_Click(object sender, EventArgs e)
        {
            try
            {
                NetApp.Dialogs[DialogType.PageSetup].Show((int)this.Handle);
            }
            catch (COMException)
            {
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            print();
        }
        public void print()
        {
            if (ActiveDoc != null)
            {
                ActiveDoc.FullClippingMode = true;
                ActiveDoc.PrintDocument(int.Parse(txtQtyValue.Text));
            }
        }
        private void bnPrinterSettings_Click(object sender, EventArgs e)
        {
            try
            {
                NetApp.Dialogs[DialogType.PrinterSetup].Show((int)this.Handle);
            }
            catch (COMException)
            {
            }
        }

        private void comboBoxPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveDoc != null)
            {
                string PrinterName = comboBoxPrinter.Text;
                ActiveDoc.Printer.SwitchTo(PrinterName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}