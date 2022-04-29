using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using TaggedWorld;

namespace WinAppTaggedWorld.Controls
{
    public partial class TargetCtrl : UserControl
    {
        public TargetCtrl(Target target)
        {
            InitializeComponent();
            Dock = DockStyle.Top;
            Target = target;
            lblTargetAddress.Text = target.Address;
            lblTags.Text = string.Join(", ", target.Tags);
        }

        public Target Target { get; private set; }

        private void PnlMain_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Classes.Utils.OpenTarget(Target);
            }
            catch (Exception ex) { Classes.Utils.Mbox(ex); }
        }
    }
}
