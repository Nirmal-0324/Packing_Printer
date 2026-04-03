using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tkx.Lppa;


namespace SampleAppWithWrapper
{
    public partial class printers_form : Form
    {
        private SampleAppMainForm printerSetting;

        public printers_form()
        {
            InitializeComponent();
            Lock();
            load_last_values();
            ForDateCode();


        }
        private void ForDateCode()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 minute
            timer.Tick += Timer_Tick;
            timer.Start();
          //  MessageBox.Show("1");
        }
        private void load_last_values()
        {

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            
                update_datecode();
            
        }
        public void update_datecode()
        {
            if (groupBox3.Enabled == false)
            {
                char[] dateArray =
                 {
                '1','2','3','4','5','6','7','8','9',
                'A','B','C','D','E','F','G','H','I','J',
                'K','L','M','N','O','P','Q','R','S','T',
                'U','V','W','X','Y','Z'
                   };
                System.DateTime now = System.DateTime.Now;
                string temp1 = now.Month.ToString();
                string temp2 = now.Year.ToString();

                string dateCode = temp2[temp2.Length - 1].ToString() + temp1[temp1.Length - 1].ToString() + dateArray[now.Day - 1].ToString();
                Date_code.Text = dateCode;

                if (now.Date.ToString() != temp5)
                {
                    temp5 = now.Date.ToString();
                    RunningSerialNumber.Text = 1.ToString("D6");
                    SaveData();

                }
            }
        }
        DataTable dt;
        private System.Windows.Forms.Timer timer;

        private void printers_form_Load(object sender, EventArgs e)
        {
         
            dt = new DataTable();
            string[] lines = File.ReadAllLines("part_numbers.csv");

            if (lines.Length > 0)
            {
                // Create columns
                string[] headers = lines[0].Split(',');
                foreach (string header in headers)
                    dt.Columns.Add(header.Trim());

                // Add rows
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] data = lines[i].Split(',');
                    dt.Rows.Add(data);
                }
            }

            LoadModels();
            LoadData();
            printerSetting = new SampleAppMainForm();
            printerSetting.Show();
            printerSetting.Visible = false;
            load_label();

           // groupBox2.Enabled = false;
        }
        public void LoadModels()
        {
            comboBox1.Items.Clear();

            foreach (DataRow row in dt.Rows)
            {
                string model = row["Delta P/N"].ToString();

                if (!comboBox1.Items.Contains(model))
                {
                    comboBox1.Items.Add(model);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            printerSetting.change_variable(comboBox4.SelectedItem.ToString(), textBox2.Text);
            pbLabelPreview.Image = printerSetting.UpdateLabelPreview2().Image;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void EditInfo_Click(object sender, EventArgs e)
        {
            PortNumbers temp4 = new PortNumbers();
            temp4.Show();
            temp4.FormClosed += temp_closed;

        }
        private void temp_closed(object sender, FormClosedEventArgs e)
        {
            LoadModels();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            //txtResult.Clear();

            string selectedModel = comboBox1.SelectedItem.ToString();

            foreach (DataRow row in dt.Rows)
            {
                if (row["Delta P/N"].ToString() == selectedModel)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        string value = row[col.ColumnName].ToString();

                        if (!string.IsNullOrWhiteSpace(value) && value != "NA")
                        {
                            comboBox2.Items.Add(col.ColumnName);
                        }
                    }
                    break;
                }
            }
        }
        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
                return;

            string selectedModel = comboBox1.SelectedItem.ToString();
            string selectedColumn = comboBox2.SelectedItem.ToString();

            foreach (DataRow row in dt.Rows)
            {
                if (row["Delta P/N"].ToString() == selectedModel)
                {
                    Customer_pn_2.Text = row[selectedColumn].ToString();
                    Customer_pn.Text = row[selectedColumn].ToString();
                    break;
                }
            }
        }
        string temp5 = string.Empty;
        private async void LoadData()
        {
            if (!File.Exists("appstate.json"))
                return;

            string json = File.ReadAllText("appstate.json");

            AppState state = JsonConvert.DeserializeObject<AppState>(json);
            if (state == null)
                return;

            // ComboBoxes
            comboBox1.SelectedIndex = state.ModelSelectedIndex;
            //    await Task.Delay(20); // Ensure comboBox1 updates before setting comboBox2
            comboBox2.SelectedIndex = state.CustSelectedIndex;

            // TextBoxes (string)
            Customer_pn.Text = state.PartNumber;
            Customer_pn_2.Text = state.PartNumber;
            Dell_carton_constant.Text = state.Constant1;

            // Integers -> convert to string for Text
            RunningSerialNumber.Text = state.RunningSN.ToString("D6");
            runningSN = state.RunningSN;
            Qty.Text = state.RunningQty.ToString();
            Qty_2.Text = state.Qty.ToString();
            Currrent_Qty.Text = state.RunningQty.ToString();
            textBox1.Text = state.label_location;
            temp5 = state.UpdatedDate;
            printerSetting.select_printer(state.SelectedPrinter);
            // Restore label contents
            //if (state.LabelContents != null)
            //{
            //    for (int i = 0; i < state.LabelContents.Count; i++)
            //    {
            //        // Example if you stored label texts
            //        // Adjust depending on your actual labels
            //        if (i < this.Controls.OfType<Label>().Count())
            //        {
            //            this.Controls.OfType<Label>().ElementAt(i).Text = state.LabelContents[i];
            //        }
            //    }
            //}
        }
        int runningSN = 0;
        private void SaveData()
        {
            AppState state = new AppState();

            // ComboBoxes
            state.ModelSelectedIndex = comboBox1.SelectedIndex;
            state.CustSelectedIndex = comboBox2.SelectedIndex;

            // TextBoxes (string)
            state.PartNumber = Customer_pn.Text;
            state.Constant1 = Dell_carton_constant.Text;

            // Integers (convert safely)
            int.TryParse(RunningSerialNumber.Text, out runningSN);
            int.TryParse(Qty_2.Text, out int qty);
            int.TryParse(Currrent_Qty.Text, out int runningQty);

            state.RunningSN = runningSN;
            state.Qty = qty;
            state.RunningQty = runningQty;
            state.label_location = textBox1.Text;
            // Save label contents (if needed)
            state.LabelContents = this.Controls
                .OfType<Label>()
                .Select(lbl => lbl.Text)
                .ToList();

            // Serialize
            state.UpdatedDate = temp5;
            state.SelectedPrinter = printerSetting.selectedPrinterName;
            string json = JsonConvert.SerializeObject(state, Formatting.Indented);

            File.WriteAllText("appstate.json", json);
        }
        public void load_label()
        {
            try
            {
                List<string> vars = new List<string>();
                vars = printerSetting.change_active_doc(textBox1.Text);
                foreach (string i in vars)
                {
                    comboBox4.Items.Add(i);
                }
                pbLabelPreview.Image = printerSetting.UpdateLabelPreview2().Image;
                  printerSetting.UpdatePrinterList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveData();
            update_label();
        }
        public void update_label()
        {
            string carton_number = Dell_carton_constant.Text.Trim() + Date_code.Text.Trim() + RunningSerialNumber.Text.Trim() + Customer_pn.Text.Trim() + Currrent_Qty.Text.Trim();
            printerSetting.change_variable("PN", carton_number);
            printerSetting.change_variable("CN", Customer_pn.Text);
            printerSetting.change_variable("QTY", Qty.Text);
            pbLabelPreview.Image = printerSetting.UpdateLabelPreview2().Image;
        }

        private void button1_Click(object sender, EventArgs e)
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
                        textBox1.Text = filePath;
                    }));
                    pub_fp = ofd.FileName;
                    vars = printerSetting.change_active_doc(filePath);
                    foreach (string i in vars)
                    {    
                        comboBox4.Items.Add(i);
                    }
                    SaveData();
                }
            }
            pbLabelPreview.Image = printerSetting.UpdateLabelPreview2().Image;
            printerSetting.UpdatePrinterList();
        }
        string pub_fp = "";

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
        public void qty_increment()
        {
            Qty.Text = (int.Parse(Qty.Text)+1).ToString();
            Currrent_Qty.Text = Qty.Text;
            if (int.Parse(Qty_2.Text) <= int.Parse(Currrent_Qty.Text))
            {
                print_label();
                RunningSerialNumber.Text = (runningSN + 1).ToString("D6");
                Currrent_Qty.Text = "0";
                Qty.Text = "0";

            }
            SaveData();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            print_label();
        }
        public void print_label()
        {
            update_label();
            printerSetting.print();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            printerSetting.Visible = true;
        }
        public string password { get; private set; }
        bool isenabled = true;
        private void Lock()
        {
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
            //  groupBox2.Enabled = false;
            button1.Enabled = false;
            button8.Enabled = false;
            button9.Text = "Unlock";
            isenabled = false;
        }
        private void unlock()
        {

            Enter temp7 = new Enter();
            temp7.ShowDialog();
            string text = temp7.password;
            System.DateTime now = System.DateTime.Now;
            string pass = ((int)now.DayOfWeek).ToString() + now.Day + now.Month.ToString();
            if (text == pass)
            {
                groupBox3.Enabled = true;
                groupBox4.Enabled = true;
                groupBox5.Enabled = true;
                button4.Enabled = true;
                button6.Enabled = true;
                groupBox2.Enabled = true;
                button1.Enabled = true;
                button8.Enabled = true;
                button9.Text = "Lock";

                button9.Text = "Lock";
                isenabled = true;

            }
            else if (text == "NBBUQA@789")
            {
                groupBox3.Enabled = true;
                groupBox4.Enabled = true;
                groupBox5.Enabled = true;
                button4.Enabled = true;
                button6.Enabled = true;
                isenabled = true;

            }
            else if (text == "NBBUIE@432")
            {
                button1.Enabled = true;
                button8.Enabled = true;
                button9.Text = "Lock";
                isenabled = true;
            }
            else
            {
                MessageBox.Show("Incorrect Password");
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (isenabled == true)
            {
                Lock();
            }
            else
            {
                unlock();
            }
        }
    }


    public class AppState
    {
        public string label_location { get; set; }
        public int ModelSelectedIndex { get; set; }
        public int CustSelectedIndex { get; set; }
        public string PartNumber { get; set; }
        public string Constant1 { get; set; }
        public int RunningSN { get; set; }
        public int Qty { get; set; }
        public int RunningQty { get; set; }
        public int lastSerialNumber { get; set; }
        public List<string> LabelContents { get; set; }
        public string UpdatedDate { get; set; }
        public string SelectedPrinter {  get; set; } 
    }
}
