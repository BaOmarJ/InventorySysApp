using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySysApp
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void rbtShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            
            txtUserName.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUserName.Text == "Admin" && txtPassword.Text == "Password")
            {
                lblUserName.ForeColor = Color.Black;
                lblPassword.ForeColor = Color.Black;
                MessageBox.Show("You're Welcome!");
            }
            else if (txtUserName.Text != "Admin")
            {
                lblUserName.ForeColor= Color.Red;
                lblClear_Click(sender, e);
            }
            else
            {
                lblPassword.ForeColor= Color.Red;
                lblClear_Click(sender, e);
            }
        }
    }
}
