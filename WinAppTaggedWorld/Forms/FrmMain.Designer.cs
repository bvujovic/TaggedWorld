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
            System.Windows.Forms.Label label3;
            this.lblTargetResults = new System.Windows.Forms.Label();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.tagList = new WinAppTaggedWorld.Controls.TagLabelList();
            this.targetList = new WinAppTaggedWorld.Controls.TargetCtrlList();
            this.btnSearchAddTag = new System.Windows.Forms.Button();
            this.txtTargetAddress = new System.Windows.Forms.TextBox();
            this.fileBrowse = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.btnAddTarget = new System.Windows.Forms.Button();
            this.btnTargetBrowse = new System.Windows.Forms.Button();
            this.btnTagListClear = new System.Windows.Forms.Button();
            this.scTop = new System.Windows.Forms.SplitContainer();
            this.btnTagListCopy = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scTop)).BeginInit();
            this.scTop.Panel1.SuspendLayout();
            this.scTop.Panel2.SuspendLayout();
            this.scTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 10);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(35, 17);
            label1.TabIndex = 1;
            label1.Text = "Tags";
            // 
            // lblTargetResults
            // 
            this.lblTargetResults.AutoSize = true;
            this.lblTargetResults.Location = new System.Drawing.Point(12, 159);
            this.lblTargetResults.Name = "lblTargetResults";
            this.lblTargetResults.Size = new System.Drawing.Size(49, 17);
            this.lblTargetResults.TabIndex = 1;
            this.lblTargetResults.Text = "Results";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(3, 10);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(51, 17);
            label3.TabIndex = 12;
            label3.Text = "Targets";
            // 
            // txtTag
            // 
            this.txtTag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTag.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtTag.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtTag.Location = new System.Drawing.Point(3, 87);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(316, 25);
            this.txtTag.TabIndex = 0;
            this.txtTag.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtTag_KeyDown);
            // 
            // tagList
            // 
            this.tagList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagList.AutoScroll = true;
            this.tagList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tagList.Location = new System.Drawing.Point(3, 35);
            this.tagList.Name = "tagList";
            this.tagList.Size = new System.Drawing.Size(316, 51);
            this.tagList.TabIndex = 2;
            // 
            // targetList
            // 
            this.targetList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetList.AutoScroll = true;
            this.targetList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.targetList.Location = new System.Drawing.Point(12, 179);
            this.targetList.Name = "targetList";
            this.targetList.SelectedTarget = null;
            this.targetList.Size = new System.Drawing.Size(776, 248);
            this.targetList.TabIndex = 3;
            // 
            // btnSearchAddTag
            // 
            this.btnSearchAddTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchAddTag.Location = new System.Drawing.Point(319, 86);
            this.btnSearchAddTag.Name = "btnSearchAddTag";
            this.btnSearchAddTag.Size = new System.Drawing.Size(47, 27);
            this.btnSearchAddTag.TabIndex = 4;
            this.btnSearchAddTag.Text = "OK";
            this.btnSearchAddTag.UseVisualStyleBackColor = true;
            this.btnSearchAddTag.Click += new System.EventHandler(this.BtnSearchAddTag_Click);
            // 
            // txtTargetAddress
            // 
            this.txtTargetAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetAddress.Location = new System.Drawing.Point(4, 34);
            this.txtTargetAddress.Name = "txtTargetAddress";
            this.txtTargetAddress.Size = new System.Drawing.Size(338, 25);
            this.txtTargetAddress.TabIndex = 8;
            // 
            // folderBrowse
            // 
            this.folderBrowse.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // btnAddTarget
            // 
            this.btnAddTarget.Location = new System.Drawing.Point(3, 59);
            this.btnAddTarget.Name = "btnAddTarget";
            this.btnAddTarget.Size = new System.Drawing.Size(85, 27);
            this.btnAddTarget.TabIndex = 9;
            this.btnAddTarget.Text = "Add Target";
            this.btnAddTarget.UseVisualStyleBackColor = true;
            this.btnAddTarget.Click += new System.EventHandler(this.BtnAddTarget_Click);
            // 
            // btnTargetBrowse
            // 
            this.btnTargetBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTargetBrowse.Location = new System.Drawing.Point(342, 33);
            this.btnTargetBrowse.Name = "btnTargetBrowse";
            this.btnTargetBrowse.Size = new System.Drawing.Size(35, 27);
            this.btnTargetBrowse.TabIndex = 10;
            this.btnTargetBrowse.Text = "...";
            this.btnTargetBrowse.UseVisualStyleBackColor = true;
            this.btnTargetBrowse.Click += new System.EventHandler(this.BtnTargetBrowse_Click);
            // 
            // btnTagListClear
            // 
            this.btnTagListClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTagListClear.Location = new System.Drawing.Point(319, 60);
            this.btnTagListClear.Name = "btnTagListClear";
            this.btnTagListClear.Size = new System.Drawing.Size(47, 27);
            this.btnTagListClear.TabIndex = 11;
            this.btnTagListClear.Text = "Clear";
            this.btnTagListClear.UseVisualStyleBackColor = true;
            this.btnTagListClear.Click += new System.EventHandler(this.BtnTagListClear_Click);
            // 
            // scTop
            // 
            this.scTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scTop.Location = new System.Drawing.Point(12, 7);
            this.scTop.Name = "scTop";
            // 
            // scTop.Panel1
            // 
            this.scTop.Panel1.Controls.Add(this.btnTagListCopy);
            this.scTop.Panel1.Controls.Add(label1);
            this.scTop.Panel1.Controls.Add(this.txtTag);
            this.scTop.Panel1.Controls.Add(this.btnTagListClear);
            this.scTop.Panel1.Controls.Add(this.tagList);
            this.scTop.Panel1.Controls.Add(this.btnSearchAddTag);
            // 
            // scTop.Panel2
            // 
            this.scTop.Panel2.Controls.Add(label3);
            this.scTop.Panel2.Controls.Add(this.txtTargetAddress);
            this.scTop.Panel2.Controls.Add(this.btnTargetBrowse);
            this.scTop.Panel2.Controls.Add(this.btnAddTarget);
            this.scTop.Size = new System.Drawing.Size(776, 120);
            this.scTop.SplitterDistance = 388;
            this.scTop.TabIndex = 13;
            // 
            // btnTagListCopy
            // 
            this.btnTagListCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTagListCopy.Location = new System.Drawing.Point(319, 34);
            this.btnTagListCopy.Name = "btnTagListCopy";
            this.btnTagListCopy.Size = new System.Drawing.Size(47, 27);
            this.btnTagListCopy.TabIndex = 12;
            this.btnTagListCopy.Text = "Copy";
            this.btnTagListCopy.UseVisualStyleBackColor = true;
            this.btnTagListCopy.Click += new System.EventHandler(this.BtnTagListCopy_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 439);
            this.Controls.Add(this.scTop);
            this.Controls.Add(this.targetList);
            this.Controls.Add(this.lblTargetResults);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.scTop.Panel1.ResumeLayout(false);
            this.scTop.Panel1.PerformLayout();
            this.scTop.Panel2.ResumeLayout(false);
            this.scTop.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scTop)).EndInit();
            this.scTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtTag;
        private Controls.TagLabelList tagList;
        private Controls.TargetCtrlList targetList;
        private Button btnSearchAddTag;
        private TextBox txtTargetAddress;
        private OpenFileDialog fileBrowse;
        private FolderBrowserDialog folderBrowse;
        private Button btnAddTarget;
        private Button btnTargetBrowse;
        private Button btnTagListClear;
        private SplitContainer scTop;
        private Button btnTagListCopy;
        private Label lblTargetResults;
    }
}