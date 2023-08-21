namespace WinAppTaggedWorld.Forms
{
    partial class FrmSharedTargets
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            targetList = new Controls.TargetCtrlList();
            lblTargetResults = new Label();
            SuspendLayout();
            // 
            // targetList
            // 
            targetList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            targetList.AutoScroll = true;
            targetList.BorderStyle = BorderStyle.FixedSingle;
            targetList.Location = new Point(12, 12);
            targetList.Name = "targetList";
            targetList.SelectedTarget = null;
            targetList.Size = new Size(776, 250);
            targetList.TabIndex = 0;
            targetList.RemoveTarget += TargetList_RemoveTarget;
            // 
            // lblTargetResults
            // 
            lblTargetResults.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTargetResults.AutoSize = true;
            lblTargetResults.Location = new Point(12, 265);
            lblTargetResults.Name = "lblTargetResults";
            lblTargetResults.Size = new Size(44, 15);
            lblTargetResults.TabIndex = 3;
            lblTargetResults.Text = "Results";
            // 
            // FrmSharedTargets
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 289);
            Controls.Add(lblTargetResults);
            Controls.Add(targetList);
            Name = "FrmSharedTargets";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "New Shared Targets";
            Load += FrmSharedTargets_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Controls.TargetCtrlList targetList;
        private Label lblTargetResults;
    }
}