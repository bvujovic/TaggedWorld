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
            => Controls.Add(targetCtrl);

        public void RemoveTargetCtrl(TargetCtrl targetCtrl)
            => Controls.Remove(targetCtrl);

        public void Display(IEnumerable<Target> targets)
        {
            try
            {
                Controls.Clear();
                foreach (var target in targets)
                {
                    var t = new TargetCtrl(target);
                    t.RemoveTarget += (o, ea) => RemoveTarget?.Invoke(o, ea);
                    t.EditTarget += (o, ea) => EditTarget?.Invoke(o, ea);
                    t.Selected += TargetCtrl_Selected;
                    Controls.Add(t);
                }
                //?
                //if (Controls.Count > 0)
                //    ScrollControlIntoView(Controls[Controls.Count - 1]);

                // ponovno obelezavanje prethodno selektovanog targeta
                SelectedTarget = selectedTarget;
            }
            catch (Exception ex) { Classes.Utils.Mbox(ex); }
        }

        private Target? selectedTarget = null;
        /// <summary>Selektovani/oznaceni target.</summary>
        public Target? SelectedTarget
        {
            get => selectedTarget;
            set
            {
                selectedTarget = value;
                foreach (var ctrl in Controls.Cast<TargetCtrl>())
                    if (ctrl.Target.Equals(selectedTarget))
                    {
                        ctrl.IsSelected = true;
                        ScrollControlIntoView(ctrl);
                    }
                if (selectedTarget == null && Controls.Count > 0)
                    ScrollControlIntoView(Controls[0]);
            }
        }

        public TargetCtrl? GetSelectedCtrl()
        {
            return Controls.OfType<TargetCtrl>().FirstOrDefault(it => it.IsSelected);
        }

        private void TargetCtrl_Selected(object? sender, EventArgs e)
        {
            foreach (var ctrl in Controls.Cast<TargetCtrl>())
                if (!ctrl.Equals(sender))
                    ctrl.IsSelected = false;
        }

        public event EventHandler RemoveTarget = default!;
        public event EventHandler EditTarget = default!;
    }
}
