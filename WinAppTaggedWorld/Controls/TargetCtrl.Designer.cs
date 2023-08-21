namespace WinAppTaggedWorld.Controls
{
    partial class TargetCtrl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblGroup = new Label();
            ctxTarget = new ContextMenuStrip(components);
            tsmiEdit = new ToolStripMenuItem();
            tsmiRemove = new ToolStripMenuItem();
            tsmiSendTo = new ToolStripMenuItem();
            lblDateTime = new Label();
            lblSentBy = new Label();
            pnlMain = new Panel();
            tlpShareInfo = new TableLayoutPanel();
            picIco = new PictureBox();
            lblAddress = new Label();
            lblTags = new Label();
            ctxSharedTarget = new ContextMenuStrip(components);
            tsmiSharedAccept = new ToolStripMenuItem();
            tsmiSharedReject = new ToolStripMenuItem();
            ctxTarget.SuspendLayout();
            pnlMain.SuspendLayout();
            tlpShareInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIco).BeginInit();
            ctxSharedTarget.SuspendLayout();
            SuspendLayout();
            // 
            // lblGroup
            // 
            lblGroup.AutoSize = true;
            lblGroup.ContextMenuStrip = ctxTarget;
            lblGroup.Location = new Point(71, 0);
            lblGroup.Margin = new Padding(0);
            lblGroup.Name = "lblGroup";
            lblGroup.Size = new Size(45, 17);
            lblGroup.TabIndex = 2;
            lblGroup.Text = "Group";
            // 
            // ctxTarget
            // 
            ctxTarget.Items.AddRange(new ToolStripItem[] { tsmiEdit, tsmiRemove, tsmiSendTo });
            ctxTarget.Name = "ctxStrip";
            ctxTarget.Size = new Size(118, 70);
            ctxTarget.Opening += CtxStrip_Opening;
            // 
            // tsmiEdit
            // 
            tsmiEdit.Name = "tsmiEdit";
            tsmiEdit.Size = new Size(117, 22);
            tsmiEdit.Text = "Edit";
            tsmiEdit.Click += TsmiEdit_Click;
            // 
            // tsmiRemove
            // 
            tsmiRemove.Name = "tsmiRemove";
            tsmiRemove.Size = new Size(117, 22);
            tsmiRemove.Text = "Remove";
            tsmiRemove.Click += TsmiRemove_Click;
            // 
            // tsmiSendTo
            // 
            tsmiSendTo.Name = "tsmiSendTo";
            tsmiSendTo.Size = new Size(117, 22);
            tsmiSendTo.Text = "Send to";
            // 
            // lblDateTime
            // 
            lblDateTime.AutoSize = true;
            lblDateTime.Location = new Point(167, 0);
            lblDateTime.Margin = new Padding(0);
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Size = new Size(67, 17);
            lblDateTime.TabIndex = 2;
            lblDateTime.Text = "Date, time";
            // 
            // lblSentBy
            // 
            lblSentBy.AutoSize = true;
            lblSentBy.ContextMenuStrip = ctxTarget;
            lblSentBy.Location = new Point(0, 0);
            lblSentBy.Margin = new Padding(0);
            lblSentBy.Name = "lblSentBy";
            lblSentBy.Size = new Size(51, 17);
            lblSentBy.TabIndex = 1;
            lblSentBy.Text = "Sent by";
            // 
            // pnlMain
            // 
            pnlMain.BackColor = SystemColors.ControlLightLight;
            pnlMain.ContextMenuStrip = ctxTarget;
            pnlMain.Controls.Add(tlpShareInfo);
            pnlMain.Controls.Add(picIco);
            pnlMain.Controls.Add(lblAddress);
            pnlMain.Controls.Add(lblTags);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            pnlMain.Location = new Point(1, 2);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(484, 44);
            pnlMain.TabIndex = 2;
            pnlMain.BackColorChanged += PnlMain_BackColorChanged;
            pnlMain.DoubleClick += PnlMain_DoubleClick;
            // 
            // tlpShareInfo
            // 
            tlpShareInfo.AutoSize = true;
            tlpShareInfo.BackColor = SystemColors.ControlLightLight;
            tlpShareInfo.ColumnCount = 5;
            tlpShareInfo.ColumnStyles.Add(new ColumnStyle());
            tlpShareInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpShareInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpShareInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpShareInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpShareInfo.Controls.Add(lblSentBy, 0, 0);
            tlpShareInfo.Controls.Add(lblGroup, 2, 0);
            tlpShareInfo.Controls.Add(lblDateTime, 4, 0);
            tlpShareInfo.Location = new Point(180, 8);
            tlpShareInfo.Name = "tlpShareInfo";
            tlpShareInfo.RowCount = 1;
            tlpShareInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpShareInfo.Size = new Size(243, 19);
            tlpShareInfo.TabIndex = 3;
            tlpShareInfo.Visible = false;
            // 
            // picIco
            // 
            picIco.Location = new Point(4, 7);
            picIco.Name = "picIco";
            picIco.Size = new Size(42, 32);
            picIco.SizeMode = PictureBoxSizeMode.Zoom;
            picIco.TabIndex = 1;
            picIco.TabStop = false;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.ContextMenuStrip = ctxTarget;
            lblAddress.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point);
            lblAddress.Location = new Point(50, 4);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(96, 17);
            lblAddress.TabIndex = 0;
            lblAddress.Text = "target address...";
            lblAddress.Click += Lbl_Click;
            // 
            // lblTags
            // 
            lblTags.AutoSize = true;
            lblTags.ContextMenuStrip = ctxTarget;
            lblTags.Location = new Point(50, 24);
            lblTags.Name = "lblTags";
            lblTags.Size = new Size(80, 17);
            lblTags.TabIndex = 0;
            lblTags.Text = "tag1, tag2 ...";
            lblTags.Click += Lbl_Click;
            // 
            // ctxSharedTarget
            // 
            ctxSharedTarget.Items.AddRange(new ToolStripItem[] { tsmiSharedAccept, tsmiSharedReject });
            ctxSharedTarget.Name = "ctxStrip";
            ctxSharedTarget.RenderMode = ToolStripRenderMode.Professional;
            ctxSharedTarget.Size = new Size(181, 70);
            ctxSharedTarget.Opening += CtxSharedTarget_Opening;
            // 
            // tsmiSharedAccept
            // 
            tsmiSharedAccept.Name = "tsmiSharedAccept";
            tsmiSharedAccept.Size = new Size(180, 22);
            tsmiSharedAccept.Text = "&Accept";
            tsmiSharedAccept.Click += TsmiSharedAccept_Click;
            // 
            // tsmiSharedReject
            // 
            tsmiSharedReject.Name = "tsmiSharedReject";
            tsmiSharedReject.Size = new Size(180, 22);
            tsmiSharedReject.Text = "&Reject";
            tsmiSharedReject.Click += TsmiSharedReject_Click;
            // 
            // TargetCtrl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(pnlMain);
            Name = "TargetCtrl";
            Padding = new Padding(1, 2, 1, 0);
            Size = new Size(486, 46);
            ctxTarget.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            tlpShareInfo.ResumeLayout(false);
            tlpShareInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picIco).EndInit();
            ctxSharedTarget.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private PictureBox picIco;
        private Label lblAddress;
        private Label lblTags;
        private ContextMenuStrip ctxTarget;
        private ToolStripMenuItem tsmiEdit;
        private ToolStripMenuItem tsmiRemove;
        private ToolStripMenuItem tsmiSendTo;
        private TableLayoutPanel tlpShareInfo;
        private Label lblSentBy;
        private Label lblGroup;
        private Label lblDateTime;
        private ContextMenuStrip ctxSharedTarget;
        private ToolStripMenuItem tsmiSharedAccept;
        private ToolStripMenuItem tsmiSharedReject;
    }
}
