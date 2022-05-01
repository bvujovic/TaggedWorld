using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using TaggedWorld;

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

        public void Display(IEnumerable<Target> targets)
        {
            try
            {
                Controls.Clear();
                foreach (var target in targets) 
                    Controls.Add(new TargetCtrl(target));
            }
            catch (Exception ex) { Classes.Utils.Mbox(ex); }
        }
    }
}
