using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceApp.commons
{
    public partial class LoginPage : Form
    {
        Authentication authentication;
        public LoginPage()
        {
            InitializeComponent();
            authentication = new Authentication();
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            Boolean validLogin = this.authentication.userAuthentication(this.iduser.Text, this.password.Text);
            if (validLogin)
            {
                //this.Parent.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login inválido");
            }
        }
    }
}
