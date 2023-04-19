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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dgvGroups = new DataGridView();
            bsGroups = new BindingSource(components);
            dgvcAmIaMember = new DataGridViewCheckBoxColumn();
            dgvcName = new DataGridViewTextBoxColumn();
            dgvcStrTags = new DataGridViewTextBoxColumn();
            dgvcCreated = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvGroups).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsGroups).BeginInit();
            SuspendLayout();
            // 
            // dgvGroups
            // 
            dgvGroups.AllowUserToAddRows = false;
            dgvGroups.AllowUserToDeleteRows = false;
            dgvGroups.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvGroups.AutoGenerateColumns = false;
            dgvGroups.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGroups.Columns.AddRange(new DataGridViewColumn[] { dgvcAmIaMember, dgvcName, dgvcStrTags, dgvcCreated });
            dgvGroups.DataSource = bsGroups;
            dgvGroups.Location = new Point(12, 89);
            dgvGroups.Name = "dgvGroups";
            dgvGroups.ReadOnly = true;
            dgvGroups.RowTemplate.Height = 25;
            dgvGroups.Size = new Size(776, 150);
            dgvGroups.TabIndex = 0;
            dgvGroups.CellClick += DgvGroups_CellClick;
            // 
            // bsGroups
            // 
            bsGroups.DataSource = typeof(Data.VM.GroupVM);
            bsGroups.Sort = "";
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
            // FrmGroups
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvGroups);
            MinimizeBox = false;
            Name = "FrmGroups";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Groups";
            Load += FrmGroups_Load;
            ((System.ComponentModel.ISupportInitialize)dgvGroups).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsGroups).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvGroups;
        private BindingSource bsGroups;
        private DataGridViewCheckBoxColumn memberDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn dgvcAmIaMember;
        private DataGridViewTextBoxColumn dgvcName;
        private DataGridViewTextBoxColumn dgvcStrTags;
        private DataGridViewTextBoxColumn dgvcCreated;
    }
}