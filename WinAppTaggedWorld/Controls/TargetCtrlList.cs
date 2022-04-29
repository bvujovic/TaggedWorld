using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace WinAppTaggedWorld.Controls
{
    public partial class TargetCtrlList : UserControl
    {
        public TargetCtrlList()
        {
            InitializeComponent();
        }

        public void AddTargetCtrl(TargetCtrl targetCtrl)
        {
            Controls.Add(targetCtrl);
        }
    }
}
