using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SampleAppWithWrapper
{
    public partial class PortNumbers : Form
    {
        public PortNumbers()
        {
            InitializeComponent();
            Load_file();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Load_file()
        {
            DataTable dt = new DataTable();

            string[] lines = File.ReadAllLines("part_numbers.csv");

            if (lines.Length > 0)
            {
                // First row = column headers
                string[] headers = lines[0].Split(',');

                foreach (string header in headers)
                    dt.Columns.Add(header);

                // Add rows
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] data = lines[i].Split(',');
                    dt.Rows.Add(data);
                }
            }

            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.");
                return;
            }

          
                StringBuilder sb = new StringBuilder();

                // Write column headers
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    sb.Append(dataGridView1.Columns[i].HeaderText);
                    if (i < dataGridView1.Columns.Count - 1)
                        sb.Append(",");
                }
                sb.AppendLine();

                // Write rows
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            var value = row.Cells[i].Value?.ToString() ?? "";

                            // Escape quotes
                            value = value.Replace("\"", "\"\"");

                            // Wrap in quotes if needed
                            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
                                value = $"\"{value}\"";

                            sb.Append(value);

                            if (i < dataGridView1.Columns.Count - 1)
                                sb.Append(",");
                        }
                        sb.AppendLine();
                    }
                }

                File.WriteAllText("part_numbers.csv", sb.ToString(), Encoding.UTF8);

                MessageBox.Show("Export completed successfully!");
            
        }
    }
}
