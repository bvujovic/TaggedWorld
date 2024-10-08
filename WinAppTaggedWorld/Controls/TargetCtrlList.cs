﻿using System;
using System.Windows.Forms;
using TaggedWorldLibrary.Model;

namespace WinAppTaggedWorld.Controls
{
    public partial class TargetCtrlList : UserControl
    {
        public TargetCtrlList()
        {
            InitializeComponent();
        }

        /// <summary>Da li u listi targeta vec postoji jedan sa datom adresom.</summary>
        public bool Exists(string content)
            => TargetControls.FirstOrDefault(it => it.Target.Content == content) != null;

        public void AddTargetCtrl(TargetCtrl targetCtrl)
            => Controls.Add(targetCtrl);

        public void RemoveTargetCtrl(TargetCtrl targetCtrl)
            => Controls.Remove(targetCtrl);

        private bool isDisplaySuspended = false;

        public void SuspendDisplay() => isDisplaySuspended = true;
        public void ResumeDisplay(IEnumerable<Target>? targets)
        {
            isDisplaySuspended = false;
            Display(targets);
        }

        public void Display(IEnumerable<Target>? targets)
        {
            try
            {
                if (isDisplaySuspended || targets == null)
                    return;
                //T System.Diagnostics.Debug.WriteLine("Display " + targets.Count());
                Controls.Clear();
                foreach (var target in targets)
                {
                    var t = new TargetCtrl(target);
                    t.RemoveTarget += (o, ea) => RemoveTarget?.Invoke(o, ea);
                    t.EditTarget += (o, ea) => EditTarget?.Invoke(o, ea);
                    t.Selected += TargetCtrl_Selected;
                    Controls.Add(t);
                }
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
                foreach (var ctrl in TargetControls)
                    if (ctrl.Target.Equals(selectedTarget))
                    {
                        ctrl.IsSelected = true;
                        ScrollControlIntoView(ctrl);
                    }
                if (selectedTarget == null && Controls.Count > 0)
                    ScrollControlIntoView(Controls[Controls.Count - 1]);
            }
        }

        public TargetCtrl? GetSelectedCtrl()
            => TargetControls.FirstOrDefault(it => it.IsSelected);

        private IEnumerable<TargetCtrl> TargetControls
            => Controls.OfType<TargetCtrl>();

        private void TargetCtrl_Selected(object? sender, EventArgs e)
        {
            foreach (var ctrl in TargetControls)
                if (!ctrl.Equals(sender))
                    ctrl.IsSelected = false;
                else
                    SelectedTarget ??= ctrl.Target;
        }

        public event EventHandler RemoveTarget = default!;
        public event EventHandler EditTarget = default!;

        public int ControlsCount => Controls.Count;

        public override string ToString()
            => Controls.Count + " targets shown.";

        /// <summary>Klik na praznu povrsinu liste targeta deselektuje selektovani target (ako takav postoji).</summary>
        private void TargetCtrlList_Click(object sender, EventArgs e)
        {
            var ctrl = GetSelectedCtrl();
            if (ctrl != null)
                ctrl.IsSelected = false;
        }
    }
}
