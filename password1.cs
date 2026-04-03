using System;
using System.Windows.Forms;

namespace LoginFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;

        private void InitializeComponent()
        {
            this.lblUsername = new Label();
            this.lblPassword = new Label();
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();

            // Label Username
            this.lblUsername.Text = "Username:";
            this.lblUsername.Location = new System.Drawing.Point(30, 30);

            // TextBox Username
            this.txtUsername.Location = new System.Drawing.Point(120, 30);
            this.txtUsername.Width = 150;

            // Label Password
            this.lblPassword.Text = "Password:";
            this.lblPassword.Location = new System.Drawing.Point(30, 70);

            // TextBox Password
            this.txtPassword.Location = new System.Drawing.Point(120, 70);
            this.txtPassword.Width = 150;
            this.txtPassword.PasswordChar = '*';

            // Button Login
            this.btnLogin.Text = "Login";
            this.btnLogin.Location = new System.Drawing.Point(120, 110);
            this.btnLogin.Click += new EventHandler(this.BtnLogin_Click);

            // Form settings
            this.Text = "Login Form";
            this.ClientSize = new System.Drawing.Size(320, 180);

            // Add controls
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username == "admin" && password == "1234")
            {
                MessageBox.Show("Login Successful!");
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
        }
    }
}
