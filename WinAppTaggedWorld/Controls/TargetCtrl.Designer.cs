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
            this.lblTargetAddress = new System.Windows.Forms.Label();
            this.lblTags = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTargetAddress
            // 
            this.lblTargetAddress.AutoSize = true;
            this.lblTargetAddress.Location = new System.Drawing.Point(4, 2);
            this.lblTargetAddress.Name = "lblTargetAddress";
            this.lblTargetAddress.Size = new System.Drawing.Size(103, 17);
            this.lblTargetAddress.TabIndex = 0;
            this.lblTargetAddress.Text = "target address...";
            this.lblTargetAddress.DoubleClick += new System.EventHandler(this.PnlMain_DoubleClick);
            // 
            // lblTags
            // 
            this.lblTags.AutoSize = true;
            this.lblTags.Location = new System.Drawing.Point(4, 20);
            this.lblTags.Name = "lblTags";
            this.lblTags.Size = new System.Drawing.Size(80, 17);
            this.lblTags.TabIndex = 0;
            this.lblTags.Text = "tag1, tag2 ...";
            this.lblTags.DoubleClick += new System.EventHandler(this.PnlMain_DoubleClick);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlMain.Controls.Add(this.lblTargetAddress);
            this.pnlMain.Controls.Add(this.lblTags);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pnlMain.Location = new System.Drawing.Point(1, 2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(484, 44);
            this.pnlMain.TabIndex = 1;
            this.pnlMain.DoubleClick += new System.EventHandler(this.PnlMain_DoubleClick);
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
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblTargetAddress;
        private Label lblTags;
        private Panel pnlMain;
    }
}
