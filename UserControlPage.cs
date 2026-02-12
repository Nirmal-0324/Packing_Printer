using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace SampleAppWithWrapper
{
    public partial class UserControlPage : Form
    {
        public UserControlPage()
        {
            InitializeComponent();
        }
        private void UserControlPage_Load(object sender, EventArgs e)
        {

            printerSetting = new SampleAppMainForm();
            printerSetting.Show();
            printerSetting.Visible = false;

        }
        private SampleAppMainForm printerSetting;
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Print_button_Click(object sender, EventArgs e)
        {
            printerSetting.print();
        }

        private void selectFile_Click(object sender, EventArgs e)
        {
            List<string> vars = new List<string>();
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select a file";
                ofd.Filter = "label files (*.lab)|*.lab|All files (*.*)|*.*";
                ofd.Multiselect = false;
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;
                    vars = printerSetting.change_active_doc(filePath);
                    foreach (string i in vars)
                    {
                        comboBox2.Items.Add(i);
                    }
                }
            }
            pbLabelPreview.Image = printerSetting.UpdateLabelPreview2().Image;
            printerSetting.UpdatePrinterList();
        }



        private void button2_Click(object sender, EventArgs e)
        {
           printerSetting.change_variable(comboBox2.SelectedItem.ToString(),textBox1.Text);
          pbLabelPreview.Image= printerSetting.UpdateLabelPreview2().Image;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            printerSetting.Visible = true;
        }
    }
}
