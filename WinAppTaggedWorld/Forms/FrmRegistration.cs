using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;

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
            Text = Classes.Utils.AppName + " - Registration";
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {

        }
    }
}
