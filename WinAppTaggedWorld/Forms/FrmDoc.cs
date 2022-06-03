using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinAppTaggedWorld.Classes;

namespace WinAppTaggedWorld.Forms
{
    public partial class FrmDoc : Form
    {
        public FrmDoc()
        {
            InitializeComponent();
        }

        private void FrmDoc_Load(object sender, EventArgs e)
        {
            try
            {
                //var rtb = new RichTextBox
                //{
                //    Dock = DockStyle.Fill
                //};
                //this.Controls.Add(rtb);

//                var wb = new WebBrowser
//                {
//                    Dock = DockStyle.Fill,
//                    DocumentText =
//@"
//<!DOCTYPE html>
//<html lang='en'>
//<head>
//    <meta charset='UTF-8'>
//    <title>Doc</title>
//</head>
//<body>
//    <h1>slov</h1>
//    kst.
//</body>
//</html>
//"
//                };
//                this.Controls.Add(wb);
            }
            catch (Exception ex) { Utils.Mbox(ex); }
        }
    }
}
