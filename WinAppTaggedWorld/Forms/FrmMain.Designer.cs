namespace WinAppTaggedWorld.Forms
{
    partial class FrmMain
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.txtTag = new System.Windows.Forms.TextBox();
            this.tagList = new WinAppTaggedWorld.Controls.TagLabelList();
            this.targetList = new Controls.TargetCtrlList();
            this.btnSearchAddTag = new System.Windows.Forms.Button();
            this.btnNewTarget = new System.Windows.Forms.Button();
            this.cmbNewTargetType = new System.Windows.Forms.ComboBox();
            this.btnTargetBrowse = new System.Windows.Forms.Button();
            this.txtTargetAddress = new System.Windows.Forms.TextBox();
            this.fileBrowse = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.btnAddTarget = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 47);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(71, 17);
            label1.TabIndex = 1;
            label1.Text = "Tag search";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 191);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(49, 17);
            label2.TabIndex = 1;
            label2.Text = "Results";
            // 
            // txtTag
            // 
            this.txtTag.Location = new System.Drawing.Point(12, 67);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(279, 25);
            this.txtTag.TabIndex = 0;
            this.txtTag.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtTag_KeyDown);
            // 
            // tagList
            // 
            this.tagList.AutoScroll = true;
            this.tagList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tagList.Location = new System.Drawing.Point(12, 98);
            this.tagList.Name = "tagList";
            this.tagList.Size = new System.Drawing.Size(322, 45);
            this.tagList.TabIndex = 2;
            // 
            // pnlSearchResults
            // 
            this.targetList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.targetList.Location = new System.Drawing.Point(12, 211);
            this.targetList.Name = "pnlSearchResults";
            this.targetList.Size = new System.Drawing.Size(776, 287);
            this.targetList.TabIndex = 3;
            // 
            // btnSearchAddTag
            // 
            this.btnSearchAddTag.Location = new System.Drawing.Point(291, 66);
            this.btnSearchAddTag.Name = "btnSearchAddTag";
            this.btnSearchAddTag.Size = new System.Drawing.Size(43, 27);
            this.btnSearchAddTag.TabIndex = 4;
            this.btnSearchAddTag.Text = "OK";
            this.btnSearchAddTag.UseVisualStyleBackColor = true;
            this.btnSearchAddTag.Click += new System.EventHandler(this.BtnSearchAddTag_Click);
            // 
            // btnNewTarget
            // 
            this.btnNewTarget.Location = new System.Drawing.Point(411, 65);
            this.btnNewTarget.Name = "btnNewTarget";
            this.btnNewTarget.Size = new System.Drawing.Size(85, 27);
            this.btnNewTarget.TabIndex = 5;
            this.btnNewTarget.Text = "New Target";
            this.btnNewTarget.UseVisualStyleBackColor = true;
            // 
            // cmbNewTargetType
            // 
            this.cmbNewTargetType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNewTargetType.FormattingEnabled = true;
            this.cmbNewTargetType.Location = new System.Drawing.Point(496, 66);
            this.cmbNewTargetType.Name = "cmbNewTargetType";
            this.cmbNewTargetType.Size = new System.Drawing.Size(83, 25);
            this.cmbNewTargetType.TabIndex = 6;
            this.cmbNewTargetType.SelectedIndexChanged += new System.EventHandler(this.CmbNewTargetType_SelectedIndexChanged);
            // 
            // btnTargetBrowse
            // 
            this.btnTargetBrowse.Location = new System.Drawing.Point(411, 97);
            this.btnTargetBrowse.Name = "btnTargetBrowse";
            this.btnTargetBrowse.Size = new System.Drawing.Size(85, 27);
            this.btnTargetBrowse.TabIndex = 7;
            this.btnTargetBrowse.Text = "Browse...";
            this.btnTargetBrowse.UseVisualStyleBackColor = true;
            // 
            // txtTargetAddress
            // 
            this.txtTargetAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetAddress.Location = new System.Drawing.Point(496, 98);
            this.txtTargetAddress.Name = "txtTargetAddress";
            this.txtTargetAddress.Size = new System.Drawing.Size(292, 25);
            this.txtTargetAddress.TabIndex = 8;
            // 
            // folderBrowse
            // 
            this.folderBrowse.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // btnAddTarget
            // 
            this.btnAddTarget.Location = new System.Drawing.Point(496, 155);
            this.btnAddTarget.Name = "btnAddTarget";
            this.btnAddTarget.Size = new System.Drawing.Size(85, 27);
            this.btnAddTarget.TabIndex = 9;
            this.btnAddTarget.Text = "Add Target";
            this.btnAddTarget.UseVisualStyleBackColor = true;
            this.btnAddTarget.Click += new System.EventHandler(this.BtnAddTarget_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 510);
            this.Controls.Add(this.btnAddTarget);
            this.Controls.Add(this.txtTargetAddress);
            this.Controls.Add(this.btnTargetBrowse);
            this.Controls.Add(this.cmbNewTargetType);
            this.Controls.Add(this.btnNewTarget);
            this.Controls.Add(this.btnSearchAddTag);
            this.Controls.Add(this.targetList);
            this.Controls.Add(this.tagList);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(this.txtTag);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtTag;
        private Controls.TagLabelList tagList;
        private Controls.TargetCtrlList targetList;
        private Button btnSearchAddTag;
        private Button btnNewTarget;
        private ComboBox cmbNewTargetType;
        private Button btnTargetBrowse;
        private TextBox txtTargetAddress;
        private OpenFileDialog fileBrowse;
        private FolderBrowserDialog folderBrowse;
        private Button btnAddTarget;
    }
}