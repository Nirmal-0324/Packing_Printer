using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleAppWithWrapper
{
    public partial class Enter : Form
    {
        public Enter()
        {
            InitializeComponent();
          
        }
        public string password = "";
       
        private void TextBox2_Enter1(object sender, EventArgs e)
        {
          
        }
        private void Enter_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                password = textBox2.Text;
                this.Close();
            }
        }
    }
}
