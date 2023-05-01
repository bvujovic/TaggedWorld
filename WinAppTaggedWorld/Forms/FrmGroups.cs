using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using TaggedWorldLibrary.DTOs;
using TaggedWorldLibrary.Utils;
using WinAppTaggedWorld.Classes;
using WinAppTaggedWorld.Data;
using WinAppTaggedWorld.Data.VM;

namespace WinAppTaggedWorld.Forms
{
    public partial class FrmGroups : Form
    {
        public FrmGroups()
        {
            InitializeComponent();
            data = LocalData.GetInstance();
        }

        private readonly LocalData data;
        private IEnumerable<GroupVM> groups = default!;

        private async void FrmGroups_Load(object sender, EventArgs e)
        {
            try
            {
                groups = await DataGetter.GetGroupsAsync() ?? throw new Exception("Groups info is missing.");
                foreach (var mg in data.MyGroups!)
                {
                    var g = groups.FirstOrDefault(it => it.GroupId == mg.GroupId);
                    if (g != null)
                        g.AmIaMember = true;
                }
                bsGroups.DataSource = SortedGroups();

                tagList.ListChanged += TagList_ListChanged;
                tagList.TagLabelClicked += (o, ea) => { tagList.RemoveTag(o as Controls.TagLabel); };
            }
            catch (Exception ex) { Utils.Mbox(ex); }
        }

        private IEnumerable<GroupVM> SortedGroups()
            => groups.OrderByDescending(it => it.AmIaMember).ThenBy(it => it.Name);

        private void TagList_ListChanged(object? sender, EventArgs e)
        {
            try
            {
                var ds = SortedGroups();
                if (tagList.Tags.Any())
                    ds = ds.Where(it => Utils.StrContains(it.Name, tagList.Tags)
                        || Utils.StrFind(Tags.ParseTags(it.StrTags), tagList.Tags));
                bsGroups.DataSource = ds.Any() ? ds : null;
            }
            catch { }
        }

        private async void DgvGroups_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0 || e.RowIndex == -1)
                return;
            try
            {
                var g = (GroupVM)dgvGroups.CurrentRow.DataBoundItem;
                if (Utils.MboxYesNo($"Are you sure that you want to {(g.AmIaMember ? "LEAVE" : "JOIN")} group {g.Name}?")
                    == DialogResult.Yes)
                {
                    if (g.AmIaMember)
                        await DataGetter.MemberLeave(g.GroupId, data.User.UserId);
                    else
                        await DataGetter.MemberJoin(new MemberDto
                        {
                            UserId = data.User.UserId,
                            GroupId = g.GroupId
                        });
                    g.AmIaMember = !g.AmIaMember;
                    data.MyGroups = await WebApi.GetList<GroupDto>(WebApi.ReqEnum.Groups_My);
                }
            }
            catch (Exception ex) { Utils.Mbox(ex); }
        }

        //! Kopija koda iz FrmMain !!!

        private void TxtTag_KeyDown(object sender, KeyEventArgs e)
        {
            // Enter -> dodavanje unetog teksta u tagove
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                if (txtTag.Text != string.Empty)
                    AddTagFromTxt();
            }
            // Escape -> brisanje liste tagova
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = e.SuppressKeyPress = true;
                tagList.Clear();
            }
        }

        /// <summary>Na osnovu taga dodaje se TagLabel kontrola u listu tagova za pretragu.</summary>
        /// <returns>true: uspesno dodata kontrola</returns>
        private bool AddToTags(string tag)
        {
            // ponovljeni tag se odbija
            if (tagList.Exists(tag))
            {
                Utils.Mbox($"Tag '{tag}' is already listed.");
                return false;
            }
            // prihvatanje tj. dodavanje taga u listu za pretragu
            tagList.AddTag(tag);
            txtTag.Focus();
            return true;
        }

        /// <summary>Dodavanje taga iz textBox-a u listu tagova.</summary>
        private void AddTagFromTxt()
        {
            var tags = Tags.ParseTags(txtTag.Text);
            //targetList.SuspendDisplay();
            foreach (var tag in tags)
                AddToTags(tag);
            //targetList.ResumeDisplay(targetSelector.Targets);
            txtTag.Clear();
        }

        private void BtnSearchAddTag_Click(object sender, EventArgs e)
        {
            AddTagFromTxt();
        }

        private void BtnTagListClear_Click(object sender, EventArgs e)
        {
            tagList.Clear();
            txtTag.Focus();
        }

        private void BtnTagListCopy_Click(object sender, EventArgs e)
        {
            try
            {
                tagList.CopyToClipboard();
            }
            catch (Exception ex) { Utils.Mbox(ex); }
        }
    }
}
