using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
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
        }

        private async void FrmGroups_Load(object sender, EventArgs e)
        {
            try
            {
                var groups = await DataGetter.GetGroupsAsync();
                if (groups == null)
                    return;
                foreach (var mg in LocalData.GetInstance().MyGroups!)
                {
                    var g = groups.FirstOrDefault(it => it.GroupId == mg.GroupId);
                    if (g != null)
                        g.AmIaMember = true;
                }
                bsGroups.DataSource = groups.OrderByDescending(it => it.AmIaMember).ThenBy(it => it.Name);
            }
            catch (Exception ex) { Utils.Mbox(ex); }
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
                        await DataGetter.MemberLeave(g.GroupId, LocalData.GetInstance().User.UserId);
                    else
                        await DataGetter.MemberJoin(g.GroupId, LocalData.GetInstance().User.UserId);
                }
            }
            catch { }
        }
    }
}
