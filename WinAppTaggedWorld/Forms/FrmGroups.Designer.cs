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
            dgvGroups = new DataGridView();
            bsGroups = new BindingSource(components);
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            createdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            strTagsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
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
            dgvGroups.Columns.AddRange(new DataGridViewColumn[] { nameDataGridViewTextBoxColumn, createdDataGridViewTextBoxColumn, strTagsDataGridViewTextBoxColumn });
            dgvGroups.DataSource = bsGroups;
            dgvGroups.Location = new Point(12, 89);
            dgvGroups.Name = "dgvGroups";
            dgvGroups.ReadOnly = true;
            dgvGroups.RowTemplate.Height = 25;
            dgvGroups.Size = new Size(776, 150);
            dgvGroups.TabIndex = 0;
            // 
            // bsGroups
            // 
            bsGroups.DataSource = typeof(TaggedWorldLibrary.Model.Group);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // createdDataGridViewTextBoxColumn
            // 
            createdDataGridViewTextBoxColumn.DataPropertyName = "Created";
            createdDataGridViewTextBoxColumn.HeaderText = "Created";
            createdDataGridViewTextBoxColumn.Name = "createdDataGridViewTextBoxColumn";
            createdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // strTagsDataGridViewTextBoxColumn
            // 
            strTagsDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            strTagsDataGridViewTextBoxColumn.DataPropertyName = "StrTags";
            strTagsDataGridViewTextBoxColumn.HeaderText = "StrTags";
            strTagsDataGridViewTextBoxColumn.Name = "strTagsDataGridViewTextBoxColumn";
            strTagsDataGridViewTextBoxColumn.ReadOnly = true;
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
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn createdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn strTagsDataGridViewTextBoxColumn;
    }
}