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
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
            txtSchoolNo.Focus();
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {
            Database.cbxSchoolDefination(cbxSchool, "tblSchools", "SchoolName");
        }
        bool valuecontrol()
        {
            bool pswrd = txtPassword.Text == txtPasswordAgain.Text;
            if (String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtSurname.Text) || String.IsNullOrEmpty(txtEmail.Text) || String.IsNullOrEmpty(txtSchoolNo.Text) || String.IsNullOrEmpty(cbxSchool.Text) || !pswrd)
            {
                return false;
            }
            else
                return true;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string _email = txtEmail.Text;
            if (!Database.emailcontrol(_email))
            {
                Database.AddUserDB(Convert.ToInt32(txtSchoolNo.Text), txtName.Text, txtSurname.Text, cbxSchool.Text, _email, txtPassword.Text);
                MessageBox.Show($"{txtSchoolNo.Text} numaralı kullanıcı eklendi", "Kullanıcı eklendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                foreach (Control item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        (item as TextBox).Clear();
                    }
                }
                cbxSchool.Text = null;
            }
            else
            {
                txtEmail.Text = string.Empty;
                MessageBox.Show("Kayıt yapılamadı. Lütfen uygun e-posta girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtEmail, "Kullanılan E-Posta");
            }
        }
    }
}
