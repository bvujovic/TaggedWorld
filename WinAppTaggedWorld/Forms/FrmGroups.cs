using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using WinAppTaggedWorld.Classes;
using WinAppTaggedWorld.Data;

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
                bsGroups.DataSource = groups;
            }
            catch (Exception ex) { Utils.Mbox(ex); }
        }
    }
}
