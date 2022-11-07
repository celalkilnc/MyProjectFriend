﻿using System;
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
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }
        private void MainScreen_Load(object sender, EventArgs e)
        {
            Database.cbxDefination(cbxSchool, "tblSchools", "SchoolName");
            Database.cbxDefination(cbxBranch, "tblBranchs", "BranchName");
            User user = User.users[0];
            textBox2.Text = user.ID.ToString();
            textBox1.Text = user.Name;
            textBox3.Text = user.Surname;
        }
        private void MainScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
