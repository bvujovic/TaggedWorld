﻿using System;
using System.Windows.Forms;
using TaggedWorldLibrary.DTOs;
using TaggedWorldLibrary.Model;
using TaggedWorldLibrary.Utils;
using WinAppTaggedWorld.Classes;

namespace WinAppTaggedWorld.Controls
{
    public partial class TargetCtrl : UserControl
    {
        public TargetCtrl(Target target)
        {
            InitializeComponent();
            Target = target;
            try
            {
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
                }
                if (target is SharedTarget)
                    pnlMain.ContextMenuStrip = ctxSharedTarget;
                RefreshDisplay();
                pnlMain.Click += Control_Click;
                lblAddress.Click += Control_Click;
                lblTags.Click += Control_Click;
                tlpShareInfo.Click += Control_Click;
                lblSentBy.Click += Control_Click;
                lblGroup.Click += Control_Click;
                lblDateTime.Click += Control_Click;
            }
            catch (Exception ex) { Utils.Mbox(ex); }
        }

        private void Control_Click(object? sender, EventArgs e)
            => IsSelected = true;

        public Target Target { get; private set; }

        private void PnlMain_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                IsSelected = true;
                Utils.OpenTarget(Target);
            }
            catch (Exception ex) { Utils.Mbox(ex); }
        }

        private void Lbl_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(((Label)sender).Text);
        }

        private void TsmiRemove_Click(object sender, EventArgs e)
            => RemoveTarget?.Invoke(this, e);

        public event EventHandler RemoveTarget = default!;

        private void TsmiEdit_Click(object sender, EventArgs e)
            => EditTarget?.Invoke(this, e);

        public event EventHandler EditTarget = default!;

        private async void TsmiSharedAccept_Click(object sender, EventArgs e)
        {
            try
            {
                await Data.DataGetter.TargetAccept(Target.TargetId);
                RemoveTarget?.Invoke(this, e);
                var data = Data.LocalData.GetInstance();
                data.AddTarget(((SharedTarget)Target).ToTarget());
            }
            catch (Exception ex) { Utils.Mbox(ex); }
        }

        private async void TsmiSharedReject_Click(object sender, EventArgs e)
        {
            try
            {
                await Data.DataGetter.DeleteTarget(Target.TargetId);
                RemoveTarget?.Invoke(this, e);
            }
            catch (Exception ex) { Utils.Mbox(ex); }
        }

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

        private void CtxSharedTarget_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IsSelected = true;
        }

        private void CtxStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IsSelected = true;
            var data = Data.LocalData.GetInstance();
            tsmiSendTo.DropDownItems.Clear();
            if (data != null && data.MyGroups != null)
                foreach (var g in data.MyGroups)
                {
                    var tsmi = new ToolStripMenuItem
                    {
                        Text = g.Name,
                        Tag = g,
                    };
                    // "..." se dodaje kao Item za grupu da bi ova imala strelicu i da bi korisnik znao da se 
                    // clanovi te grupe ucitavaju u trenutku kad se ovaj item pokaze
                    tsmi.DropDownItems.Add(new ToolStripLabel("..."));
                    tsmi.Click += TsmiSendToGroup_Click;
                    tsmi.DropDownOpening += Tsmi_DropDownOpening;
                    tsmiSendTo.DropDownItems.Add(tsmi);
                }
        }

        private async void Tsmi_DropDownOpening(object? sender, EventArgs e)
        {
            if (sender is not ToolStripMenuItem tsmiGroup)
                return;
            if (tsmiGroup.Tag is not GroupDto g)
                return;
            var members = await Data.DataGetter.GetMembersAsync(g.GroupId);
            if (members == null)
                return;
            var me = Data.LocalData.GetInstance().User!;
            tsmiGroup.DropDownItems.Clear();
            foreach (var m in members.Where(it => it.Username != me.Username))
            {
                var tsmi = new ToolStripMenuItem
                {
                    Text = m.FullName,
                    Tag = m,
                };
                tsmi.Click += TsmiSendToUser_Click; ;
                tsmiGroup.DropDownItems.Add(tsmi);
            }
            //HACK Kada drugih korisnika u grupi ima samo 1, Item bi se bez ovog separatora
            // prikazivao u gornjem, levom uglu ekrana
            if (tsmiGroup.DropDownItems.Count == 1)
                tsmiGroup.DropDownItems.Add(new ToolStripSeparator());
        }

        private async void TsmiSendToUser_Click(object? sender, EventArgs e)
        {
            try
            {
                if (sender is not ToolStripMenuItem tsmi)
                    return;
                if (tsmi.Tag is not UserDto u)
                    return;
                ctxTarget.Close();
                await Data.DataGetter.SendTarget(new SharingDto
                {
                    TargetId = Target.TargetId,
                    ReceiveGroupId = null,
                    ReceiveUserId = u.UserId
                });
            }
            catch (Exception ex) { Utils.Mbox(ex); }
        }

        private async void TsmiSendToGroup_Click(object? sender, EventArgs e)
        {
            try
            {
                if (sender is not ToolStripMenuItem tsmi)
                    return;
                if (tsmi.Tag is not GroupDto g)
                    return;
                ctxTarget.Close();
                if (Utils.MboxYesNo($"Are you sure that you want to send selected target to ALL members of the group {g.Name}?")
                    == DialogResult.Yes)
                {
                    await Data.DataGetter.SendTarget(new SharingDto
                    {
                        TargetId = Target.TargetId,
                        ReceiveGroupId = g.GroupId,
                        ReceiveUserId = null
                    });
                }
            }
            catch (Exception ex) { Utils.Mbox(ex); }
        }

        public void RefreshDisplay()
        {
            lblAddress.Text = Target.Content;
            lblTags.Text = Tags.JoinTags(Target.Tags);
            if (Target is SharedTarget st)
            {
                Height = 70;
                tlpShareInfo.Left = lblAddress.Left;
                tlpShareInfo.Top = lblTags.Top + (lblTags.Top - lblAddress.Top);
                lblDateTime.Text = "Sent by: " + st.ShareUserName;
                lblGroup.Text = "Group: " + st.ShareGroupName;
                lblSentBy.Text = "Date, time: " + st.CreatedDate.ToString(Utils.DatumVremeFormat);
                tlpShareInfo.Visible = true;
            }
        }

        private void PnlMain_BackColorChanged(object sender, EventArgs e)
        {
            tlpShareInfo.BackColor = pnlMain.BackColor;
        }

        public override string ToString()
            => lblAddress.Text;
    }
}
