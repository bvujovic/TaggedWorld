namespace WinAppTaggedWorld.Forms
{
    partial class FrmGroups
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
            components = new System.ComponentModel.Container();
            Label label1;
            Label label2;
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dgvGroups = new DataGridView();
            dgvcAmIaMember = new DataGridViewCheckBoxColumn();
            dgvcName = new DataGridViewTextBoxColumn();
            dgvcStrTags = new DataGridViewTextBoxColumn();
            dgvcCreated = new DataGridViewTextBoxColumn();
            bsGroups = new BindingSource(components);
            btnTagListCopy = new Button();
            btnTagListClear = new Button();
            tagList = new Controls.TagLabelList();
            btnSearchAddTag = new Button();
            txtTag = new TextBox();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvGroups).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsGroups).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(36, 17);
            label1.TabIndex = 26;
            label1.Text = "Tags";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(12, 117);
            label2.Name = "label2";
            label2.Size = new Size(52, 17);
            label2.TabIndex = 26;
            label2.Text = "Groups";
            // 
            // dgvGroups
            // 
            dgvGroups.AllowUserToAddRows = false;
            dgvGroups.AllowUserToDeleteRows = false;
            dgvGroups.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvGroups.AutoGenerateColumns = false;
            dgvGroups.BackgroundColor = Color.White;
            dgvGroups.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGroups.Columns.AddRange(new DataGridViewColumn[] { dgvcAmIaMember, dgvcName, dgvcStrTags, dgvcCreated });
            dgvGroups.DataSource = bsGroups;
            dgvGroups.Location = new Point(12, 137);
            dgvGroups.Name = "dgvGroups";
            dgvGroups.ReadOnly = true;
            dgvGroups.RowTemplate.Height = 25;
            dgvGroups.Size = new Size(846, 302);
            dgvGroups.TabIndex = 0;
            dgvGroups.CellClick += DgvGroups_CellClick;
            // 
            // dgvcAmIaMember
            // 
            dgvcAmIaMember.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvcAmIaMember.DataPropertyName = "AmIaMember";
            dgvcAmIaMember.HeaderText = "Member";
            dgvcAmIaMember.Name = "dgvcAmIaMember";
            dgvcAmIaMember.ReadOnly = true;
            dgvcAmIaMember.Width = 58;
            // 
            // dgvcName
            // 
            dgvcName.DataPropertyName = "Name";
            dgvcName.HeaderText = "Name";
            dgvcName.Name = "dgvcName";
            dgvcName.ReadOnly = true;
            dgvcName.Width = 150;
            // 
            // dgvcStrTags
            // 
            dgvcStrTags.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvcStrTags.DataPropertyName = "StrTags";
            dgvcStrTags.HeaderText = "Tags";
            dgvcStrTags.Name = "dgvcStrTags";
            dgvcStrTags.ReadOnly = true;
            // 
            // dgvcCreated
            // 
            dgvcCreated.DataPropertyName = "Created";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            dgvcCreated.DefaultCellStyle = dataGridViewCellStyle1;
            dgvcCreated.HeaderText = "Created";
            dgvcCreated.Name = "dgvcCreated";
            dgvcCreated.ReadOnly = true;
            // 
            // bsGroups
            // 
            bsGroups.DataSource = typeof(Data.VM.GroupVM);
            bsGroups.Sort = "";
            // 
            // btnTagListCopy
            // 
            btnTagListCopy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTagListCopy.Location = new Point(811, 28);
            btnTagListCopy.Name = "btnTagListCopy";
            btnTagListCopy.Size = new Size(47, 27);
            btnTagListCopy.TabIndex = 30;
            btnTagListCopy.Text = "Copy";
            btnTagListCopy.UseVisualStyleBackColor = true;
            btnTagListCopy.Click += BtnTagListCopy_Click;
            // 
            // btnTagListClear
            // 
            btnTagListClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTagListClear.Location = new Point(811, 54);
            btnTagListClear.Name = "btnTagListClear";
            btnTagListClear.Size = new Size(47, 27);
            btnTagListClear.TabIndex = 29;
            btnTagListClear.Text = "Clear";
            btnTagListClear.UseVisualStyleBackColor = true;
            btnTagListClear.Click += BtnTagListClear_Click;
            // 
            // tagList
            // 
            tagList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tagList.AutoScroll = true;
            tagList.BorderStyle = BorderStyle.FixedSingle;
            tagList.Location = new Point(12, 29);
            tagList.Name = "tagList";
            tagList.Size = new Size(799, 51);
            tagList.TabIndex = 27;
            // 
            // btnSearchAddTag
            // 
            btnSearchAddTag.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearchAddTag.Location = new Point(811, 80);
            btnSearchAddTag.Name = "btnSearchAddTag";
            btnSearchAddTag.Size = new Size(47, 27);
            btnSearchAddTag.TabIndex = 28;
            btnSearchAddTag.Text = "OK";
            btnSearchAddTag.UseVisualStyleBackColor = true;
            btnSearchAddTag.Click += BtnSearchAddTag_Click;
            // 
            // txtTag
            // 
            txtTag.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTag.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtTag.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTag.Location = new Point(12, 82);
            txtTag.Name = "txtTag";
            txtTag.Size = new Size(799, 23);
            txtTag.TabIndex = 31;
            txtTag.KeyDown += TxtTag_KeyDown;
            // 
            // FrmGroups
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(870, 454);
            Controls.Add(txtTag);
            Controls.Add(btnTagListCopy);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnTagListClear);
            Controls.Add(tagList);
            Controls.Add(btnSearchAddTag);
            Controls.Add(dgvGroups);
            MinimizeBox = false;
            Name = "FrmGroups";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Groups";
            Load += FrmGroups_Load;
            ((System.ComponentModel.ISupportInitialize)dgvGroups).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsGroups).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvGroups;
        private BindingSource bsGroups;
        private DataGridViewCheckBoxColumn memberDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn dgvcAmIaMember;
        private DataGridViewTextBoxColumn dgvcName;
        private DataGridViewTextBoxColumn dgvcStrTags;
        private DataGridViewTextBoxColumn dgvcCreated;
        private Button btnTagListCopy;
        private Button btnTagListClear;
        private Controls.TagLabelList tagList;
        private Button btnSearchAddTag;
        private TextBox txtTag;
    }
}