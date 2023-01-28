using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TaggedWorldLibrary.Model;
using TaggedWorldLibrary.Utils;

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
                switch (typeTag)
                {
                    case Tags.TypeFolder: picIco.Image = Properties.Resources.ico_folder; break;
                    case Tags.TypeFile: picIco.Image = Properties.Resources.ico_file; break;
                    case Tags.TypeLink: picIco.Image = Properties.Resources.ico_link; break;
                }
                //B
                //if (typeTag == Tags.TypeFolder)
                //    picIco.Image = Properties.Resources.ico_folder;
                //if (typeTag == Tags.TypeFile)
                //    picIco.Image = Properties.Resources.ico_file;
                //if (typeTag == Tags.TypeLink)
                //    picIco.Image = Properties.Resources.ico_link;
            }
            Target = target;
            RefreshDisplay();
            pnlMain.Click += Control_Click;
            lblAddress.Click += Control_Click;
            lblTags.Click += Control_Click;
            //T lblShareInfo.Text = "Porodica\r\nbvujovic";
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

        private void Lbl_Click(object sender, EventArgs e)
        {
            IsSelected = true;
            Clipboard.SetText(((Label)sender).Text);
        }

        private void TsmiRemove_Click(object sender, EventArgs e)
            => RemoveTarget?.Invoke(this, e);

        public event EventHandler RemoveTarget = default!;

        private void TsmiEdit_Click(object sender, EventArgs e)
            => EditTarget?.Invoke(this, e);

        public event EventHandler EditTarget = default!;

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

        public event EventHandler Selected = default!;

        private void CtxStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
            => IsSelected = true;

        public void RefreshDisplay()
        {
            lblAddress.Text = Target.Content;
            lblTags.Text = Tags.JoinTags(Target.Tags);
            if (Target is TaggedWorldLibrary.DTOs.SharedTarget st)
            {
                lblShareInfo.Text = st.ShareGroupName + Environment.NewLine + st.ShareUserName;
                lblShareInfo.Visible = true;
            }
        }

        public override string ToString()
            => lblAddress.Text;

        //B
        //public void SetShareInfo()
        //{
        //    // grupa, ko je shareovao
        //}

        //{
        //  "targetId": 9,
        //  "createdDate": "2023-01-20T01:48:08.4792945",
        //  "ownerId": 1,
        //  "content": "C:\\Users\\bvnet\\OneDrive\\x\\RAF\\RAF Progres.xlsx",
        //  "strTags": "file, faks, progres, Excel"
        //},
    }
}
