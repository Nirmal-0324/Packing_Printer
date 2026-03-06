using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using Microsoft.VisualBasic;

namespace SampleAppWithWrapper
{
    public partial class UserControlPage : Form
    {
        string config = "config.txt";


        public UserControlPage()
        {
            InitializeComponent();
            LoadPorts();
            LoadData();
            label2 = new printers_form();
            label2.Show();
        }
        printers_form label2;
        private void LoadData()
        {
            try
            {
                string[] data = File.ReadAllLines(config);
               
                    comboBox2.SelectedItem = data[0];
                targetQTY.Text = data[1];
                Compare_string.Text = data[2];
                    textBox2.Text = data[3];
              

            }
            catch (Exception ex)
            {
                if (cmbPorts.Items.Contains("COM2"))
                {
                    cmbPorts.SelectedItem = "COM2";
                }
                targetQTY.Text = 45.ToString();
                Compare_string.Text = "C";
            }
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
            var_update();
            printerSetting.print();
        }
        string pub_fp = "";
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
                    Invoke(new Action(() =>
                    {
                        textBox2.Text = filePath;
                    }));
                    pub_fp = ofd.FileName;
                    vars = printerSetting.change_active_doc(filePath);
                    foreach (string i in vars)
                    {
                        comboBox2.Items.Add(i);
                    }
                    save_file();
                }
            }
            pbLabelPreview.Image = printerSetting.UpdateLabelPreview2().Image;
            printerSetting.UpdatePrinterList();
        }
        private void save_file()
        {
            try
            {
                string[] data = { cmbPorts.SelectedItem.ToString(), targetQTY.Text, Compare_string.Text, pub_fp };
                File.WriteAllLines("config.txt", data);
            }
            catch(Exception ex) {
                throw ex;
            }
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


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to exit?",
                    "Confirm Exit",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);  

                if (result == DialogResult.No)
                    e.Cancel = true;
            }
        }




        #region getData
        int count = 0;
        SerialPort _serialPort;
        public void open_serial()
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                Invoke(new Action(() =>
                {
                    AddLog("Serial Port Already in OPEN");
                }));
                return;
            }
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
                if (data.Contains(Compare_string.Text))
                {
                    count++;
                    try
                    {
                        label2.qty_increment();
                    }
                    catch { }
                    Invoke(new Action(() =>
                    {
                        textBox3.Text = count.ToString();
                    }));
                    if (count == int.Parse(targetQTY.Text))
                    {
                        var_update();
                        printerSetting.print();

                        count = 0;
                    }
                }
                // Because this event runs on another thread
                Invoke(new Action(() =>
                {
                    AddLog(data);
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




        private const int MAX_LINES = 100;
        public void AddLog(string text)
        {
            richTextBox1.AppendText(text + Environment.NewLine);
            int totalLines = richTextBox1.Lines.Length;
            if (totalLines > MAX_LINES)
            {
                int removeUpto = richTextBox1.GetFirstCharIndexFromLine(totalLines - MAX_LINES);
                richTextBox1.Select(0, removeUpto);
                richTextBox1.SelectedText = "";
            }
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            open_serial();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (groupBox1.Enabled == true)
            {
                groupBox1.Enabled = false;
            }
            else
            {

                string text = Interaction.InputBox("Enter password ", "Authentication", "");
                DateTime now = DateTime.Now;
                string pass = ((int)now.DayOfWeek).ToString() + now.Month.ToString();
                if (text == pass || text == "7")
                {
                    groupBox1.Enabled = true;
                    cmbPorts.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Incorrect Password");
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label2.qty_increment();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            save_file();
        }
    }
}
