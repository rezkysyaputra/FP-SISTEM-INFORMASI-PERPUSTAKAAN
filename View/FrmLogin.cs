using Perpustakaan.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perpustakaan
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            txtUserName.Text = "admin";
            txtPassword.Text = "admin";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserController controller = new UserController();

            bool isValidUser = controller.IsValidUser(txtUserName.Text, txtPassword.Text);
            if (isValidUser)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
