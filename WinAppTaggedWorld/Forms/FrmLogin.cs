using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            //T btnLogin.PerformClick();
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
                await Data.DataGetter.LoginAsync(new TaggedWorldLibrary.DTOs.UserLoginReq
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text
                });
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex) { Utils.Mbox(ex.Message); }
            btnLogin.Enabled = true;
            //await Data.DataGetter.LogoutAsync();
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
