namespace WinAppTaggedWorld.Forms
{
    partial class FrmTestPerformance
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
            btnTargetsCreate = new Button();
            numTargetsCount = new NumericUpDown();
            txtStatus = new TextBox();
            btnRemoveTestTargets = new Button();
            ((System.ComponentModel.ISupportInitialize)numTargetsCount).BeginInit();
            SuspendLayout();
            // 
            // btnTargetsCreate
            // 
            btnTargetsCreate.Location = new Point(69, 68);
            btnTargetsCreate.Name = "btnTargetsCreate";
            btnTargetsCreate.Size = new Size(120, 23);
            btnTargetsCreate.TabIndex = 0;
            btnTargetsCreate.Text = "Create Targets";
            btnTargetsCreate.UseVisualStyleBackColor = true;
            btnTargetsCreate.Click += BtnTargetsCreate_Click;
            // 
            // numTargetsCount
            // 
            numTargetsCount.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            numTargetsCount.Location = new Point(69, 39);
            numTargetsCount.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numTargetsCount.Name = "numTargetsCount";
            numTargetsCount.Size = new Size(120, 23);
            numTargetsCount.TabIndex = 1;
            numTargetsCount.ThousandsSeparator = true;
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(470, 12);
            txtStatus.Multiline = true;
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.ScrollBars = ScrollBars.Vertical;
            txtStatus.Size = new Size(318, 426);
            txtStatus.TabIndex = 2;
            // 
            // btnRemoveTestTargets
            // 
            btnRemoveTestTargets.Location = new Point(69, 134);
            btnRemoveTestTargets.Name = "btnRemoveTestTargets";
            btnRemoveTestTargets.Size = new Size(134, 23);
            btnRemoveTestTargets.TabIndex = 3;
            btnRemoveTestTargets.Text = "Remove Test Targets";
            btnRemoveTestTargets.UseVisualStyleBackColor = true;
            btnRemoveTestTargets.Click += BtnRemoveTestTargets_Click;
            // 
            // FrmTestPerformance
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRemoveTestTargets);
            Controls.Add(txtStatus);
            Controls.Add(numTargetsCount);
            Controls.Add(btnTargetsCreate);
            Name = "FrmTestPerformance";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tagged World - Performance Testing";
            ((System.ComponentModel.ISupportInitialize)numTargetsCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTargetsCreate;
        private NumericUpDown numTargetsCount;
        private TextBox txtStatus;
        private Button btnRemoveTestTargets;
    }
}