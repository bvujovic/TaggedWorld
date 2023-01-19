using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using WinAppTaggedWorld.Classes;

namespace WinAppTaggedWorld.Forms
{
    public partial class FrmRegistration : Form
    {
        public FrmRegistration()
        {
            InitializeComponent();
        }

        private void FrmRegistration_Load(object sender, EventArgs e)
        {
            Text = Utils.AppName + " - Registration";
        }

        private async void BtnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var txt in Controls.OfType<TextBox>())
                {
                    txt.Text = txt.Text.Trim();
                    if (txt.Text == "")
                        throw new Exception("All fields on this form are required.");
                }
                if (txtPassword.Text != txtPasswordConfirm.Text)
                    throw new Exception("Confirmed password is different than the password.");

                btnRegister.Enabled = false;
                await Data.DataGetter.UserRegisterAsync(new TaggedWorldLibrary.DTOs.UserRegistrationReq
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    FullName = txtFullName.Text,
                    Email = txtEmail.Text
                });
                Utils.Mbox("Successful Registration!");
                Username = txtUsername.Text;
                Password = txtPassword.Text;
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex) { Utils.Mbox(ex.Message); }
            btnRegister.Enabled = true;
        }

        public string Username { get; private set; }
        public string Password { get; private set; }
    }
}
