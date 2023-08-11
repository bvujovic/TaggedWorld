using System;
using WinAppTaggedWorld.Classes;

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
            Text = Utils.AppName + " - Login";
#if DEBUG
            txtUsername.Text = "bojan";
            txtPassword.Text = "string";
#endif
            btnLogin.PerformClick();
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                txtUsername.Text = txtUsername.Text.Trim();
                txtPassword.Text = txtPassword.Text.Trim();
                if (txtUsername.Text == "" || txtPassword.Text == "")
                    throw new Exception("Username and password are required.");

                btnLogin.Enabled = false;
                await Data.DataGetter.UserLoginAsync(new TaggedWorldLibrary.DTOs.UserLoginReq
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text
                });
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex) { Utils.Mbox(ex.Message); }
            btnLogin.Enabled = true;
        }

        private void LnkRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new FrmRegistration();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtUsername.Text = frm.Username;
                txtPassword.Text = frm.Password;
            }
        }
    }
}
