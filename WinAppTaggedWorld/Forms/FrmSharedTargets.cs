using System;
using TaggedWorldLibrary.DTOs;
using WinAppTaggedWorld.Classes;

namespace WinAppTaggedWorld.Forms
{
    public partial class FrmSharedTargets : Form
    {
        public FrmSharedTargets(IEnumerable<SharedTargetDto> sharedTargets)
        {
            this.sharedTargets = sharedTargets;
            InitializeComponent();
        }

        private readonly IEnumerable<SharedTargetDto> sharedTargets;

        private void FrmSharedTargets_Load(object sender, EventArgs e)
        {
            try
            {
                targetList.Display(sharedTargets.Select(it => it.ToTarget()));
                RefreshLblTargetResults();
            }
            catch (Exception ex) { Utils.Mbox(ex); }
        }

        private void RefreshLblTargetResults() => lblTargetResults.Text = $"Results ({targetList.ControlsCount})";

        private void TargetList_RemoveTarget(object sender, EventArgs e)
        {
            try
            {
                if (sender is Controls.TargetCtrl ctrl)
                {
                    targetList.RemoveTargetCtrl(ctrl);
                    RefreshLblTargetResults();
                    if (targetList.ControlsCount == 0)
                        Close();
                }
            }
            catch (Exception ex) { Utils.Mbox(ex); }
        }
    }
}
