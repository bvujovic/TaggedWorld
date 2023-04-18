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
            pnlMain = new Panel();
            ctxStrip = new ContextMenuStrip(components);
            tsmiEdit = new ToolStripMenuItem();
            tsmiRemove = new ToolStripMenuItem();
            lblShareInfo = new Label();
            picIco = new PictureBox();
            lblAddress = new Label();
            lblTags = new Label();
            tsmiSendTo = new ToolStripMenuItem();
            pnlMain.SuspendLayout();
            ctxStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIco).BeginInit();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = SystemColors.ControlLightLight;
            pnlMain.ContextMenuStrip = ctxStrip;
            pnlMain.Controls.Add(lblShareInfo);
            pnlMain.Controls.Add(picIco);
            pnlMain.Controls.Add(lblAddress);
            pnlMain.Controls.Add(lblTags);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            pnlMain.Location = new Point(1, 2);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(484, 44);
            pnlMain.TabIndex = 2;
            pnlMain.DoubleClick += PnlMain_DoubleClick;
            // 
            // ctxStrip
            // 
            ctxStrip.Items.AddRange(new ToolStripItem[] { tsmiEdit, tsmiRemove, tsmiSendTo });
            ctxStrip.Name = "ctxStrip";
            ctxStrip.Size = new Size(181, 92);
            ctxStrip.Opening += CtxStrip_Opening;
            // 
            // tsmiEdit
            // 
            tsmiEdit.Name = "tsmiEdit";
            tsmiEdit.Size = new Size(180, 22);
            tsmiEdit.Text = "Edit";
            tsmiEdit.Click += TsmiEdit_Click;
            // 
            // tsmiRemove
            // 
            tsmiRemove.Name = "tsmiRemove";
            tsmiRemove.Size = new Size(180, 22);
            tsmiRemove.Text = "Remove";
            tsmiRemove.Click += TsmiRemove_Click;
            // 
            // lblShareInfo
            // 
            lblShareInfo.Anchor = AnchorStyles.Right;
            lblShareInfo.AutoSize = true;
            lblShareInfo.BackColor = Color.LightSteelBlue;
            lblShareInfo.ContextMenuStrip = ctxStrip;
            lblShareInfo.Location = new Point(414, 3);
            lblShareInfo.Name = "lblShareInfo";
            lblShareInfo.Padding = new Padding(2);
            lblShareInfo.Size = new Size(69, 38);
            lblShareInfo.TabIndex = 2;
            lblShareInfo.Text = "Group\r\nusername";
            lblShareInfo.TextAlign = ContentAlignment.MiddleCenter;
            lblShareInfo.Visible = false;
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
            lblAddress.ContextMenuStrip = ctxStrip;
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
            lblTags.ContextMenuStrip = ctxStrip;
            lblTags.Location = new Point(50, 24);
            lblTags.Name = "lblTags";
            lblTags.Size = new Size(80, 17);
            lblTags.TabIndex = 0;
            lblTags.Text = "tag1, tag2 ...";
            lblTags.Click += Lbl_Click;
            // 
            // tsmiSendTo
            // 
            tsmiSendTo.Name = "tsmiSendTo";
            tsmiSendTo.Size = new Size(180, 22);
            tsmiSendTo.Text = "Send to";
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
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ctxStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picIco).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private PictureBox picIco;
        private Label lblAddress;
        private Label lblTags;
        private ContextMenuStrip ctxStrip;
        private ToolStripMenuItem tsmiEdit;
        private ToolStripMenuItem tsmiRemove;
        private Label lblShareInfo;
        private ToolStripMenuItem tsmiSendTo;
    }
}
