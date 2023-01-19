namespace WinAppTaggedWorld.Forms
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label1;
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTargetExists = new System.Windows.Forms.Label();
            this.tagListSuggest = new WinAppTaggedWorld.Controls.TagLabelList();
            this.btnTagListCopy = new System.Windows.Forms.Button();
            this.txtTargetAddress = new System.Windows.Forms.TextBox();
            this.btnTargetBrowse = new System.Windows.Forms.Button();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.btnSaveTarget = new System.Windows.Forms.Button();
            this.btnTagListClear = new System.Windows.Forms.Button();
            this.tagListMain = new WinAppTaggedWorld.Controls.TagLabelList();
            this.btnSearchAddTag = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.targetList = new WinAppTaggedWorld.Controls.TargetCtrlList();
            this.lblTargetResults = new System.Windows.Forms.Label();
            this.fileBrowse = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowse = new System.Windows.Forms.FolderBrowserDialog();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 115);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(101, 17);
            label2.TabIndex = 28;
            label2.Text = "Suggested Tags";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(12, 189);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(51, 17);
            label3.TabIndex = 26;
            label3.Text = "Targets";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(35, 17);
            label1.TabIndex = 17;
            label1.Text = "Tags";
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblTargetExists);
            this.pnlTop.Controls.Add(label2);
            this.pnlTop.Controls.Add(this.tagListSuggest);
            this.pnlTop.Controls.Add(this.btnTagListCopy);
            this.pnlTop.Controls.Add(label3);
            this.pnlTop.Controls.Add(this.txtTargetAddress);
            this.pnlTop.Controls.Add(label1);
            this.pnlTop.Controls.Add(this.btnTargetBrowse);
            this.pnlTop.Controls.Add(this.txtTag);
            this.pnlTop.Controls.Add(this.btnSaveTarget);
            this.pnlTop.Controls.Add(this.btnTagListClear);
            this.pnlTop.Controls.Add(this.tagListMain);
            this.pnlTop.Controls.Add(this.btnSearchAddTag);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(860, 279);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTargetExists
            // 
            this.lblTargetExists.AutoSize = true;
            this.lblTargetExists.ForeColor = System.Drawing.Color.Red;
            this.lblTargetExists.Location = new System.Drawing.Point(124, 239);
            this.lblTargetExists.Name = "lblTargetExists";
            this.lblTargetExists.Size = new System.Drawing.Size(128, 17);
            this.lblTargetExists.TabIndex = 27;
            this.lblTargetExists.Text = "Target already exists";
            this.lblTargetExists.Visible = false;
            // 
            // tagListSuggest
            // 
            this.tagListSuggest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagListSuggest.AutoScroll = true;
            this.tagListSuggest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tagListSuggest.Location = new System.Drawing.Point(12, 135);
            this.tagListSuggest.Name = "tagListSuggest";
            this.tagListSuggest.Size = new System.Drawing.Size(772, 51);
            this.tagListSuggest.TabIndex = 19;
            // 
            // btnTagListCopy
            // 
            this.btnTagListCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTagListCopy.Location = new System.Drawing.Point(784, 28);
            this.btnTagListCopy.Name = "btnTagListCopy";
            this.btnTagListCopy.Size = new System.Drawing.Size(47, 27);
            this.btnTagListCopy.TabIndex = 25;
            this.btnTagListCopy.Text = "Copy";
            this.btnTagListCopy.UseVisualStyleBackColor = true;
            this.btnTagListCopy.Click += new System.EventHandler(this.BtnTagListCopy_Click);
            // 
            // txtTargetAddress
            // 
            this.txtTargetAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetAddress.Location = new System.Drawing.Point(13, 209);
            this.txtTargetAddress.Name = "txtTargetAddress";
            this.txtTargetAddress.Size = new System.Drawing.Size(771, 25);
            this.txtTargetAddress.TabIndex = 21;
            this.txtTargetAddress.TextChanged += new System.EventHandler(this.TxtTargetAddress_TextChanged);
            // 
            // btnTargetBrowse
            // 
            this.btnTargetBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTargetBrowse.Location = new System.Drawing.Point(784, 208);
            this.btnTargetBrowse.Name = "btnTargetBrowse";
            this.btnTargetBrowse.Size = new System.Drawing.Size(47, 27);
            this.btnTargetBrowse.TabIndex = 23;
            this.btnTargetBrowse.Text = "...";
            this.btnTargetBrowse.UseVisualStyleBackColor = true;
            this.btnTargetBrowse.Click += new System.EventHandler(this.BtnTargetBrowse_Click);
            // 
            // txtTag
            // 
            this.txtTag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTag.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtTag.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtTag.Location = new System.Drawing.Point(12, 81);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(772, 25);
            this.txtTag.TabIndex = 16;
            this.txtTag.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtTag_KeyDown);
            // 
            // btnSaveTarget
            // 
            this.btnSaveTarget.Location = new System.Drawing.Point(12, 234);
            this.btnSaveTarget.Name = "btnSaveTarget";
            this.btnSaveTarget.Size = new System.Drawing.Size(85, 27);
            this.btnSaveTarget.TabIndex = 22;
            this.btnSaveTarget.Text = "Save Target";
            this.btnSaveTarget.UseVisualStyleBackColor = true;
            this.btnSaveTarget.Click += new System.EventHandler(this.BtnSaveTarget_Click);
            // 
            // btnTagListClear
            // 
            this.btnTagListClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTagListClear.Location = new System.Drawing.Point(784, 54);
            this.btnTagListClear.Name = "btnTagListClear";
            this.btnTagListClear.Size = new System.Drawing.Size(47, 27);
            this.btnTagListClear.TabIndex = 24;
            this.btnTagListClear.Text = "Clear";
            this.btnTagListClear.UseVisualStyleBackColor = true;
            this.btnTagListClear.Click += new System.EventHandler(this.BtnTagListClear_Click);
            // 
            // tagListMain
            // 
            this.tagListMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagListMain.AutoScroll = true;
            this.tagListMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tagListMain.Location = new System.Drawing.Point(12, 29);
            this.tagListMain.Name = "tagListMain";
            this.tagListMain.Size = new System.Drawing.Size(772, 51);
            this.tagListMain.TabIndex = 18;
            // 
            // btnSearchAddTag
            // 
            this.btnSearchAddTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchAddTag.Location = new System.Drawing.Point(784, 80);
            this.btnSearchAddTag.Name = "btnSearchAddTag";
            this.btnSearchAddTag.Size = new System.Drawing.Size(47, 27);
            this.btnSearchAddTag.TabIndex = 20;
            this.btnSearchAddTag.Text = "OK";
            this.btnSearchAddTag.UseVisualStyleBackColor = true;
            this.btnSearchAddTag.Click += new System.EventHandler(this.BtnSearchAddTag_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.targetList);
            this.pnlMain.Controls.Add(this.lblTargetResults);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 279);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(860, 327);
            this.pnlMain.TabIndex = 1;
            // 
            // targetList
            // 
            this.targetList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetList.AutoScroll = true;
            this.targetList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.targetList.Location = new System.Drawing.Point(12, 23);
            this.targetList.Name = "targetList";
            this.targetList.SelectedTarget = null;
            this.targetList.Size = new System.Drawing.Size(836, 292);
            this.targetList.TabIndex = 3;
            // 
            // lblTargetResults
            // 
            this.lblTargetResults.AutoSize = true;
            this.lblTargetResults.Location = new System.Drawing.Point(13, 3);
            this.lblTargetResults.Name = "lblTargetResults";
            this.lblTargetResults.Size = new System.Drawing.Size(49, 17);
            this.lblTargetResults.TabIndex = 2;
            this.lblTargetResults.Text = "Results";
            // 
            // folderBrowse
            // 
            this.folderBrowse.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 606);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tagged World";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlTop;
        private Label lblTargetExists;
        private Controls.TagLabelList tagListSuggest;
        private Button btnTagListCopy;
        private TextBox txtTargetAddress;
        private Button btnTargetBrowse;
        private TextBox txtTag;
        private Button btnSaveTarget;
        private Button btnTagListClear;
        private Controls.TagLabelList tagListMain;
        private Button btnSearchAddTag;
        private Panel pnlMain;
        private Label lblTargetResults;
        private Controls.TargetCtrlList targetList;
        private OpenFileDialog fileBrowse;
        private FolderBrowserDialog folderBrowse;
    }
}