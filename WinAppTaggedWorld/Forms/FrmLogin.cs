using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //T btnLogin.PerformClick();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //var json = await GetJson(ReqEnum.WeatherTest);
            //Classes.Utils.Mbox(json);

            DialogResult = DialogResult.OK;
        }

        private void LnkRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new FrmRegistration().ShowDialog();
        }
    }
}
