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
            Label label2;
            Label label3;
            Label label1;
            Label lblUserFullname;
            Label lblUserEmail;
            Label lblUserUsername;
            pnlTop = new Panel();
            tagListSuggest = new Controls.TagLabelList();
            btnTagListCopy = new Button();
            txtTargetAddress = new TextBox();
            btnTargetBrowse = new Button();
            txtTag = new TextBox();
            btnSaveTarget = new Button();
            btnTagListClear = new Button();
            tagListMain = new Controls.TagLabelList();
            btnSearchAddTag = new Button();
            pnlMain = new Panel();
            targetList = new Controls.TargetCtrlList();
            lblTargetResults = new Label();
            fileBrowse = new OpenFileDialog();
            folderBrowse = new FolderBrowserDialog();
            scMain = new SplitContainer();
            gbGroups = new GroupBox();
            groupList = new Controls.GroupList();
            gbUserData = new GroupBox();
            txtUserEmail = new TextBox();
            txtUserUsername = new TextBox();
            txtUserFullname = new TextBox();
            btnGroups = new Button();
            label2 = new Label();
            label3 = new Label();
            label1 = new Label();
            lblUserFullname = new Label();
            lblUserEmail = new Label();
            lblUserUsername = new Label();
            pnlTop.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)scMain).BeginInit();
            scMain.Panel1.SuspendLayout();
            scMain.Panel2.SuspendLayout();
            scMain.SuspendLayout();
            gbGroups.SuspendLayout();
            gbUserData.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 115);
            label2.Name = "label2";
            label2.Size = new Size(101, 17);
            label2.TabIndex = 28;
            label2.Text = "Suggested Tags";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(12, 189);
            label3.Name = "label3";
            label3.Size = new Size(53, 17);
            label3.TabIndex = 26;
            label3.Text = "Targets";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(36, 17);
            label1.TabIndex = 17;
            label1.Text = "Tags";
            // 
            // lblUserFullname
            // 
            lblUserFullname.AutoSize = true;
            lblUserFullname.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblUserFullname.Location = new Point(6, 26);
            lblUserFullname.Name = "lblUserFullname";
            lblUserFullname.Size = new Size(66, 17);
            lblUserFullname.TabIndex = 0;
            lblUserFullname.Text = "Full Name";
            // 
            // lblUserEmail
            // 
            lblUserEmail.AutoSize = true;
            lblUserEmail.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblUserEmail.Location = new Point(6, 132);
            lblUserEmail.Name = "lblUserEmail";
            lblUserEmail.Size = new Size(44, 17);
            lblUserEmail.TabIndex = 0;
            lblUserEmail.Text = "E-mail";
            // 
            // lblUserUsername
            // 
            lblUserUsername.AutoSize = true;
            lblUserUsername.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblUserUsername.Location = new Point(6, 79);
            lblUserUsername.Name = "lblUserUsername";
            lblUserUsername.Size = new Size(67, 17);
            lblUserUsername.TabIndex = 0;
            lblUserUsername.Text = "Username";
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(label2);
            pnlTop.Controls.Add(tagListSuggest);
            pnlTop.Controls.Add(btnTagListCopy);
            pnlTop.Controls.Add(label3);
            pnlTop.Controls.Add(txtTargetAddress);
            pnlTop.Controls.Add(label1);
            pnlTop.Controls.Add(btnTargetBrowse);
            pnlTop.Controls.Add(txtTag);
            pnlTop.Controls.Add(btnSaveTarget);
            pnlTop.Controls.Add(btnTagListClear);
            pnlTop.Controls.Add(tagListMain);
            pnlTop.Controls.Add(btnSearchAddTag);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(887, 279);
            pnlTop.TabIndex = 0;
            // 
            // tagListSuggest
            // 
            tagListSuggest.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tagListSuggest.AutoScroll = true;
            tagListSuggest.BorderStyle = BorderStyle.FixedSingle;
            tagListSuggest.Location = new Point(12, 135);
            tagListSuggest.Name = "tagListSuggest";
            tagListSuggest.Size = new Size(799, 51);
            tagListSuggest.TabIndex = 19;
            // 
            // btnTagListCopy
            // 
            btnTagListCopy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTagListCopy.Location = new Point(811, 28);
            btnTagListCopy.Name = "btnTagListCopy";
            btnTagListCopy.Size = new Size(47, 27);
            btnTagListCopy.TabIndex = 25;
            btnTagListCopy.Text = "Copy";
            btnTagListCopy.UseVisualStyleBackColor = true;
            btnTagListCopy.Click += BtnTagListCopy_Click;
            // 
            // txtTargetAddress
            // 
            txtTargetAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTargetAddress.Location = new Point(13, 209);
            txtTargetAddress.Name = "txtTargetAddress";
            txtTargetAddress.Size = new Size(798, 25);
            txtTargetAddress.TabIndex = 21;
            txtTargetAddress.TextChanged += TxtTargetAddress_TextChanged;
            // 
            // btnTargetBrowse
            // 
            btnTargetBrowse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTargetBrowse.Location = new Point(811, 208);
            btnTargetBrowse.Name = "btnTargetBrowse";
            btnTargetBrowse.Size = new Size(47, 27);
            btnTargetBrowse.TabIndex = 23;
            btnTargetBrowse.Text = "...";
            btnTargetBrowse.UseVisualStyleBackColor = true;
            btnTargetBrowse.Click += BtnTargetBrowse_Click;
            // 
            // txtTag
            // 
            txtTag.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTag.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtTag.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTag.Location = new Point(12, 81);
            txtTag.Name = "txtTag";
            txtTag.Size = new Size(799, 25);
            txtTag.TabIndex = 16;
            txtTag.KeyDown += TxtTag_KeyDown;
            // 
            // btnSaveTarget
            // 
            btnSaveTarget.Location = new Point(12, 234);
            btnSaveTarget.Name = "btnSaveTarget";
            btnSaveTarget.Size = new Size(85, 27);
            btnSaveTarget.TabIndex = 22;
            btnSaveTarget.Text = "Save Target";
            btnSaveTarget.UseVisualStyleBackColor = true;
            btnSaveTarget.Click += BtnSaveTarget_Click;
            // 
            // btnTagListClear
            // 
            btnTagListClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTagListClear.Location = new Point(811, 54);
            btnTagListClear.Name = "btnTagListClear";
            btnTagListClear.Size = new Size(47, 27);
            btnTagListClear.TabIndex = 24;
            btnTagListClear.Text = "Clear";
            btnTagListClear.UseVisualStyleBackColor = true;
            btnTagListClear.Click += BtnTagListClear_Click;
            // 
            // tagListMain
            // 
            tagListMain.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tagListMain.AutoScroll = true;
            tagListMain.BorderStyle = BorderStyle.FixedSingle;
            tagListMain.Location = new Point(12, 29);
            tagListMain.Name = "tagListMain";
            tagListMain.Size = new Size(799, 51);
            tagListMain.TabIndex = 18;
            // 
            // btnSearchAddTag
            // 
            btnSearchAddTag.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearchAddTag.Location = new Point(811, 80);
            btnSearchAddTag.Name = "btnSearchAddTag";
            btnSearchAddTag.Size = new Size(47, 27);
            btnSearchAddTag.TabIndex = 20;
            btnSearchAddTag.Text = "OK";
            btnSearchAddTag.UseVisualStyleBackColor = true;
            btnSearchAddTag.Click += BtnSearchAddTag_Click;
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(targetList);
            pnlMain.Controls.Add(lblTargetResults);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 279);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(887, 327);
            pnlMain.TabIndex = 1;
            // 
            // targetList
            // 
            targetList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            targetList.AutoScroll = true;
            targetList.BorderStyle = BorderStyle.FixedSingle;
            targetList.Location = new Point(12, 23);
            targetList.Name = "targetList";
            targetList.SelectedTarget = null;
            targetList.Size = new Size(863, 292);
            targetList.TabIndex = 3;
            // 
            // lblTargetResults
            // 
            lblTargetResults.AutoSize = true;
            lblTargetResults.Location = new Point(13, 3);
            lblTargetResults.Name = "lblTargetResults";
            lblTargetResults.Size = new Size(49, 17);
            lblTargetResults.TabIndex = 2;
            lblTargetResults.Text = "Results";
            // 
            // folderBrowse
            // 
            folderBrowse.RootFolder = Environment.SpecialFolder.MyComputer;
            // 
            // scMain
            // 
            scMain.Dock = DockStyle.Fill;
            scMain.FixedPanel = FixedPanel.Panel1;
            scMain.Location = new Point(0, 0);
            scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            scMain.Panel1.Controls.Add(btnGroups);
            scMain.Panel1.Controls.Add(gbGroups);
            scMain.Panel1.Controls.Add(gbUserData);
            // 
            // scMain.Panel2
            // 
            scMain.Panel2.Controls.Add(pnlMain);
            scMain.Panel2.Controls.Add(pnlTop);
            scMain.Size = new Size(1094, 606);
            scMain.SplitterDistance = 203;
            scMain.TabIndex = 2;
            // 
            // gbGroups
            // 
            gbGroups.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            gbGroups.Controls.Add(groupList);
            gbGroups.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            gbGroups.Location = new Point(12, 302);
            gbGroups.Name = "gbGroups";
            gbGroups.Size = new Size(188, 292);
            gbGroups.TabIndex = 2;
            gbGroups.TabStop = false;
            gbGroups.Text = "Group Sharings";
            // 
            // groupList
            // 
            groupList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupList.AutoScroll = true;
            groupList.BorderStyle = BorderStyle.FixedSingle;
            groupList.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            groupList.Location = new Point(6, 24);
            groupList.Name = "groupList";
            groupList.Padding = new Padding(2);
            groupList.Size = new Size(176, 262);
            groupList.TabIndex = 0;
            groupList.SelectionChanged += GroupList_SelectionChanged;
            // 
            // gbUserData
            // 
            gbUserData.Controls.Add(txtUserEmail);
            gbUserData.Controls.Add(txtUserUsername);
            gbUserData.Controls.Add(txtUserFullname);
            gbUserData.Controls.Add(lblUserFullname);
            gbUserData.Controls.Add(lblUserEmail);
            gbUserData.Controls.Add(lblUserUsername);
            gbUserData.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            gbUserData.Location = new Point(12, 12);
            gbUserData.Name = "gbUserData";
            gbUserData.Size = new Size(188, 194);
            gbUserData.TabIndex = 1;
            gbUserData.TabStop = false;
            gbUserData.Text = "User Data";
            // 
            // txtUserEmail
            // 
            txtUserEmail.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtUserEmail.Location = new Point(6, 152);
            txtUserEmail.Name = "txtUserEmail";
            txtUserEmail.ReadOnly = true;
            txtUserEmail.Size = new Size(176, 25);
            txtUserEmail.TabIndex = 4;
            // 
            // txtUserUsername
            // 
            txtUserUsername.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtUserUsername.Location = new Point(6, 99);
            txtUserUsername.Name = "txtUserUsername";
            txtUserUsername.ReadOnly = true;
            txtUserUsername.Size = new Size(176, 25);
            txtUserUsername.TabIndex = 3;
            // 
            // txtUserFullname
            // 
            txtUserFullname.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtUserFullname.Location = new Point(6, 46);
            txtUserFullname.Name = "txtUserFullname";
            txtUserFullname.ReadOnly = true;
            txtUserFullname.Size = new Size(176, 25);
            txtUserFullname.TabIndex = 2;
            // 
            // btnGroups
            // 
            btnGroups.Location = new Point(18, 234);
            btnGroups.Name = "btnGroups";
            btnGroups.Size = new Size(85, 27);
            btnGroups.TabIndex = 23;
            btnGroups.Text = "Groups";
            btnGroups.UseVisualStyleBackColor = true;
            btnGroups.Click += BtnGroups_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1094, 606);
            Controls.Add(scMain);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tagged World";
            FormClosing += FrmMain_FormClosing;
            Load += FrmMain_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            scMain.Panel1.ResumeLayout(false);
            scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scMain).EndInit();
            scMain.ResumeLayout(false);
            gbGroups.ResumeLayout(false);
            gbUserData.ResumeLayout(false);
            gbUserData.PerformLayout();
            ResumeLayout(false);
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
        private Button btnGroups;
    }
}