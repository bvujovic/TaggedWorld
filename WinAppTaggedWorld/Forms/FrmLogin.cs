using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace WinAppTaggedWorld.Forms
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            Text = Classes.Utils.AppName + " - Login";
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void LnkRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new FrmRegistration().ShowDialog();
        }
    }
}
