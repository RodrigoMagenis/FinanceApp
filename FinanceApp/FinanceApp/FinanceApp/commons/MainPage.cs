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
    public partial class MainPage : Form
    {

        public MainPage()
        {
            InitializeComponent();
            Load += new EventHandler(MainPage_Load);
        }

        private void MainPage_Load(object sender, System.EventArgs e)
        {
            this.Hide();
            LoginPage loginPage = new LoginPage();
            //loginPage.Show();
            loginPage.TopLevel = false;
            mainPageBody.Controls.Clear();
            mainPageBody.Controls.Add(loginPage);
            loginPage.Show();
        }

        private void btnanalytics_Click(object sender, EventArgs e)
        {
            StratificationPage stratificationPage = new StratificationPage();
            stratificationPage.TopLevel = false;
            mainPageBody.Controls.Clear();
            mainPageBody.Controls.Add(stratificationPage);
            stratificationPage.Show();
        }
    }
}
