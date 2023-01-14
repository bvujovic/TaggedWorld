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
            this.components = new System.ComponentModel.Container();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.picIco = new System.Windows.Forms.PictureBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblTags = new System.Windows.Forms.Label();
            this.ctxStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIco)).BeginInit();
            this.ctxStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlMain.Controls.Add(this.picIco);
            this.pnlMain.Controls.Add(this.lblAddress);
            this.pnlMain.Controls.Add(this.lblTags);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pnlMain.Location = new System.Drawing.Point(1, 2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(484, 44);
            this.pnlMain.TabIndex = 2;
            this.pnlMain.DoubleClick += new System.EventHandler(this.PnlMain_DoubleClick);
            // 
            // picIco
            // 
            this.picIco.Location = new System.Drawing.Point(4, 7);
            this.picIco.Name = "picIco";
            this.picIco.Size = new System.Drawing.Size(42, 32);
            this.picIco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIco.TabIndex = 1;
            this.picIco.TabStop = false;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAddress.Location = new System.Drawing.Point(50, 4);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(108, 17);
            this.lblAddress.TabIndex = 0;
            this.lblAddress.Text = "target address...";
            this.lblAddress.Click += new System.EventHandler(this.LblAddress_Click);
            // 
            // lblTags
            // 
            this.lblTags.AutoSize = true;
            this.lblTags.Location = new System.Drawing.Point(50, 24);
            this.lblTags.Name = "lblTags";
            this.lblTags.Size = new System.Drawing.Size(80, 17);
            this.lblTags.TabIndex = 0;
            this.lblTags.Text = "tag1, tag2 ...";
            // 
            // ctxStrip
            // 
            this.ctxStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEdit,
            this.tsmiRemove});
            this.ctxStrip.Name = "ctxStrip";
            this.ctxStrip.Size = new System.Drawing.Size(181, 70);
            this.ctxStrip.Opening += new System.ComponentModel.CancelEventHandler(this.CtxStrip_Opening);
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(180, 22);
            this.tsmiEdit.Text = "Edit";
            this.tsmiEdit.Click += new System.EventHandler(this.TsmiEdit_Click);
            // 
            // tsmiRemove
            // 
            this.tsmiRemove.Name = "tsmiRemove";
            this.tsmiRemove.Size = new System.Drawing.Size(180, 22);
            this.tsmiRemove.Text = "Remove";
            this.tsmiRemove.Click += new System.EventHandler(this.TsmiRemove_Click);
            // 
            // TargetCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.pnlMain);
            this.Name = "TargetCtrl";
            this.Padding = new System.Windows.Forms.Padding(1, 2, 1, 0);
            this.Size = new System.Drawing.Size(486, 46);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIco)).EndInit();
            this.ctxStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlMain;
        private PictureBox picIco;
        private Label lblAddress;
        private Label lblTags;
        private ContextMenuStrip ctxStrip;
        private ToolStripMenuItem tsmiEdit;
        private ToolStripMenuItem tsmiRemove;
    }
}
