using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace SampleAppWithWrapper
{
    public partial class UserControlPage : Form
    {
        string config = "config.txt";


        public UserControlPage()
        {
            InitializeComponent();
            LoadPorts();
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
            printerSetting.change_variable(comboBox2.SelectedItem.ToString(), textBox1.Text);
            pbLabelPreview.Image = printerSetting.UpdateLabelPreview2().Image;

        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            printerSetting.Visible = true;
        }





        #region getData
        int count = 0;
        SerialPort _serialPort;
        public void open_serial()
        {
            _serialPort = new SerialPort(
                 "COM2",
                  9600,
                  Parity.Even,
                  7,
                  StopBits.One);
            _serialPort.DataReceived += SerialPort_DataReceived;
            _serialPort.Open();
            richTextBox1.AppendText("Serial Port Opened\r\n");
        }
        private void LoadPorts()
        {
            cmbPorts.Items.Clear();
            cmbPorts.Items.AddRange(SerialPort.GetPortNames());
            if (cmbPorts.Items.Count > 0)
                cmbPorts.SelectedIndex = 0;
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = _serialPort.ReadExisting();
                if (data.Contains(textBox4.Text))
                {
                    count++;
                    Invoke(new Action(() =>
                    {
                        textBox3.Text = count.ToString();
                    }));
                    if (count == int.Parse(textBox2.Text))
                    {
                        var_update();
                        printerSetting.print();

                        count = 0;
                    }
                }
                // Because this event runs on another thread
                Invoke(new Action(() =>
                {
                    richTextBox1.AppendText(data);
                }));
            }
            catch { }
        }


        public void var_update()
        {
            printerSetting.change_variable("Count", textBox3.Text);
            pbLabelPreview.Image = printerSetting.UpdateLabelPreview2().Image;
        }
        #endregion

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            open_serial();

        }
    }
}
