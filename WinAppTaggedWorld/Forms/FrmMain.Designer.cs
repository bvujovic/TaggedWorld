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
            System.Windows.Forms.Label lblUserFullname;
            System.Windows.Forms.Label lblUserEmail;
            System.Windows.Forms.Label lblUserUsername;
            this.pnlTop = new System.Windows.Forms.Panel();
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
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.gbGroups = new System.Windows.Forms.GroupBox();
            this.groupList = new WinAppTaggedWorld.Controls.GroupList();
            this.gbUserData = new System.Windows.Forms.GroupBox();
            this.txtUserEmail = new System.Windows.Forms.TextBox();
            this.txtUserUsername = new System.Windows.Forms.TextBox();
            this.txtUserFullname = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            lblUserFullname = new System.Windows.Forms.Label();
            lblUserEmail = new System.Windows.Forms.Label();
            lblUserUsername = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.gbGroups.SuspendLayout();
            this.gbUserData.SuspendLayout();
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
            label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(12, 189);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(53, 17);
            label3.TabIndex = 26;
            label3.Text = "Targets";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(36, 17);
            label1.TabIndex = 17;
            label1.Text = "Tags";
            // 
            // lblUserFullname
            // 
            lblUserFullname.AutoSize = true;
            lblUserFullname.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblUserFullname.Location = new System.Drawing.Point(6, 26);
            lblUserFullname.Name = "lblUserFullname";
            lblUserFullname.Size = new System.Drawing.Size(66, 17);
            lblUserFullname.TabIndex = 0;
            lblUserFullname.Text = "Full Name";
            // 
            // lblUserEmail
            // 
            lblUserEmail.AutoSize = true;
            lblUserEmail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblUserEmail.Location = new System.Drawing.Point(6, 132);
            lblUserEmail.Name = "lblUserEmail";
            lblUserEmail.Size = new System.Drawing.Size(44, 17);
            lblUserEmail.TabIndex = 0;
            lblUserEmail.Text = "E-mail";
            // 
            // lblUserUsername
            // 
            lblUserUsername.AutoSize = true;
            lblUserUsername.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblUserUsername.Location = new System.Drawing.Point(6, 79);
            lblUserUsername.Name = "lblUserUsername";
            lblUserUsername.Size = new System.Drawing.Size(67, 17);
            lblUserUsername.TabIndex = 0;
            lblUserUsername.Text = "Username";
            // 
            // pnlTop
            // 
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
            this.pnlTop.Size = new System.Drawing.Size(887, 279);
            this.pnlTop.TabIndex = 0;
            // 
            // tagListSuggest
            // 
            this.tagListSuggest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagListSuggest.AutoScroll = true;
            this.tagListSuggest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tagListSuggest.Location = new System.Drawing.Point(12, 135);
            this.tagListSuggest.Name = "tagListSuggest";
            this.tagListSuggest.Size = new System.Drawing.Size(799, 51);
            this.tagListSuggest.TabIndex = 19;
            // 
            // btnTagListCopy
            // 
            this.btnTagListCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTagListCopy.Location = new System.Drawing.Point(811, 28);
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
            this.txtTargetAddress.Size = new System.Drawing.Size(798, 25);
            this.txtTargetAddress.TabIndex = 21;
            this.txtTargetAddress.TextChanged += new System.EventHandler(this.TxtTargetAddress_TextChanged);
            // 
            // btnTargetBrowse
            // 
            this.btnTargetBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTargetBrowse.Location = new System.Drawing.Point(811, 208);
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
            this.txtTag.Size = new System.Drawing.Size(799, 25);
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
            this.btnTagListClear.Location = new System.Drawing.Point(811, 54);
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
            this.tagListMain.Size = new System.Drawing.Size(799, 51);
            this.tagListMain.TabIndex = 18;
            // 
            // btnSearchAddTag
            // 
            this.btnSearchAddTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchAddTag.Location = new System.Drawing.Point(811, 80);
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
            this.pnlMain.Size = new System.Drawing.Size(887, 327);
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
            this.targetList.Size = new System.Drawing.Size(863, 292);
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
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.gbGroups);
            this.scMain.Panel1.Controls.Add(this.gbUserData);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.pnlMain);
            this.scMain.Panel2.Controls.Add(this.pnlTop);
            this.scMain.Size = new System.Drawing.Size(1094, 606);
            this.scMain.SplitterDistance = 203;
            this.scMain.TabIndex = 2;
            // 
            // gbGroups
            // 
            this.gbGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbGroups.Controls.Add(this.groupList);
            this.gbGroups.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbGroups.Location = new System.Drawing.Point(12, 224);
            this.gbGroups.Name = "gbGroups";
            this.gbGroups.Size = new System.Drawing.Size(188, 370);
            this.gbGroups.TabIndex = 2;
            this.gbGroups.TabStop = false;
            this.gbGroups.Text = "Group Sharings";
            // 
            // groupList
            // 
            this.groupList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupList.AutoScroll = true;
            this.groupList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.groupList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupList.Location = new System.Drawing.Point(6, 24);
            this.groupList.Name = "groupList";
            this.groupList.Padding = new System.Windows.Forms.Padding(2);
            this.groupList.Size = new System.Drawing.Size(176, 340);
            this.groupList.TabIndex = 0;
            this.groupList.SelectionChanged += new System.EventHandler(this.GroupList_SelectionChanged);
            // 
            // gbUserData
            // 
            this.gbUserData.Controls.Add(this.txtUserEmail);
            this.gbUserData.Controls.Add(this.txtUserUsername);
            this.gbUserData.Controls.Add(this.txtUserFullname);
            this.gbUserData.Controls.Add(lblUserFullname);
            this.gbUserData.Controls.Add(lblUserEmail);
            this.gbUserData.Controls.Add(lblUserUsername);
            this.gbUserData.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbUserData.Location = new System.Drawing.Point(12, 12);
            this.gbUserData.Name = "gbUserData";
            this.gbUserData.Size = new System.Drawing.Size(188, 194);
            this.gbUserData.TabIndex = 1;
            this.gbUserData.TabStop = false;
            this.gbUserData.Text = "User Data";
            // 
            // txtUserEmail
            // 
            this.txtUserEmail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUserEmail.Location = new System.Drawing.Point(6, 152);
            this.txtUserEmail.Name = "txtUserEmail";
            this.txtUserEmail.ReadOnly = true;
            this.txtUserEmail.Size = new System.Drawing.Size(176, 25);
            this.txtUserEmail.TabIndex = 4;
            // 
            // txtUserUsername
            // 
            this.txtUserUsername.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUserUsername.Location = new System.Drawing.Point(6, 99);
            this.txtUserUsername.Name = "txtUserUsername";
            this.txtUserUsername.ReadOnly = true;
            this.txtUserUsername.Size = new System.Drawing.Size(176, 25);
            this.txtUserUsername.TabIndex = 3;
            // 
            // txtUserFullname
            // 
            this.txtUserFullname.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUserFullname.Location = new System.Drawing.Point(6, 46);
            this.txtUserFullname.Name = "txtUserFullname";
            this.txtUserFullname.ReadOnly = true;
            this.txtUserFullname.Size = new System.Drawing.Size(176, 25);
            this.txtUserFullname.TabIndex = 2;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 606);
            this.Controls.Add(this.scMain);
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
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.gbGroups.ResumeLayout(false);
            this.gbUserData.ResumeLayout(false);
            this.gbUserData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlTop;
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
        private SplitContainer scMain;
        private Label lblUserFullname;
        private Label lblUserEmail;
        private Label lblUserUsername;
        private GroupBox gbUserData;
        private TextBox txtUserFullname;
        private TextBox txtUserEmail;
        private TextBox txtUserUsername;
        private GroupBox gbGroups;
        private Controls.GroupList groupList;
    }
}