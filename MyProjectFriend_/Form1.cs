using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProjectFriend_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtEmail.Focus();
        }
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUpForm frm = new SignUpForm();
            frm.ShowDialog();
        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            //Bilgilerin kontrolü ve ana ekranı açma
            string email = txtEmail.Text, password = txtPassword.Text;
            if (Database.enteranceControl(email, password))
            {
                MainScreen mainScreen = new MainScreen();
                mainScreen.Show(); this.Hide();
            }
            else
                MessageBox.Show("Başarısız");
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
