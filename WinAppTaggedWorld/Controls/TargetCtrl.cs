using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TaggedWorldLibrary.Model;

namespace WinAppTaggedWorld.Controls
{
    public partial class TargetCtrl : UserControl
    {
        public TargetCtrl(Target target)
        {
            InitializeComponent();
            Dock = DockStyle.Top;
            var typeTag = target.GetTypeTag();
            if (typeTag != null)
            {
                if (typeTag == TaggedWorldLibrary.Utils.Tags.TypeFolder)
                    picIco.Image = Properties.Resources.ico_folder;
                if (typeTag == TaggedWorldLibrary.Utils.Tags.TypeFile)
                    picIco.Image = Properties.Resources.ico_file;
                if (typeTag == TaggedWorldLibrary.Utils.Tags.TypeLink)
                    picIco.Image = Properties.Resources.ico_link;
            }
            Target = target;
            RefreshDisplay();
            pnlMain.Click += Control_Click;
            lblAddress.Click += Control_Click;
            lblTags.Click += Control_Click;
        }

        private void Control_Click(object? sender, EventArgs e)
            => IsSelected = true;

        public Target Target { get; private set; }

        private void PnlMain_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                IsSelected = true;
                Classes.Utils.OpenTarget(Target);
            }
            catch (Exception ex) { Classes.Utils.Mbox(ex); }
        }

        private void LblAddress_Click(object sender, EventArgs e)
        {
            IsSelected = true;
            Clipboard.SetText(lblAddress.Text);
        }

        private void TsmiRemove_Click(object sender, EventArgs e)
            => RemoveTarget?.Invoke(this, e);

        public event EventHandler RemoveTarget = default!;

        public event EventHandler EditTarget = default!;

        private void TsmiEdit_Click(object sender, EventArgs e)
            => EditTarget?.Invoke(this, e);

        public event EventHandler Selected = default!;

        private bool isSelected;
        /// <summary>Da li je ova kontrola selektovana u listi.</summary>
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    pnlMain.BackColor = isSelected
                        ? SystemColors.ControlLight : SystemColors.ControlLightLight;
                    if (IsSelected)
                        Selected?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private void CtxStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
            => IsSelected = true;

        public void RefreshDisplay()
        {
            lblAddress.Text = Target.Content;
            lblTags.Text = string.Join(", ", Target.Tags);
        }

        public override string ToString()
            => lblAddress.Text;
    }
}
