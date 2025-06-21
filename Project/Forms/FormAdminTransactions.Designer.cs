namespace Project.Forms
{
    partial class FormAdminTransactions
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBackToDashboard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.SuspendLayout();
            //
            // dgvTransactions
            //
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.AllowUserToDeleteRows = false;
            this.dgvTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransactions.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Location = new System.Drawing.Point(20, 70);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.ReadOnly = true;
            this.dgvTransactions.RowHeadersWidth = 51;
            this.dgvTransactions.RowTemplate.Height = 25;
            this.dgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransactions.Size = new System.Drawing.Size(760, 280);
            this.dgvTransactions.TabIndex = 0;
            this.dgvTransactions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransactions_CellClick);
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "All Transactions:";
            //
            // cmbStatus
            //
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Pending",
            "Diproses",
            "Dikirim",
            "Selesai",
            "Dibatalkan"});
            this.cmbStatus.Location = new System.Drawing.Point(190, 370);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 28);
            this.cmbStatus.TabIndex = 2;
            //
            // btnUpdateStatus
            //
            this.btnUpdateStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnUpdateStatus.FlatAppearance.BorderSize = 0;
            this.btnUpdateStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateStatus.ForeColor = System.Drawing.Color.White;
            this.btnUpdateStatus.Location = new System.Drawing.Point(360, 360);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(130, 45);
            this.btnUpdateStatus.TabIndex = 3;
            this.btnUpdateStatus.Text = "Update Status";
            this.btnUpdateStatus.UseVisualStyleBackColor = false;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 375);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Update Selected Status:";
            //
            // btnBackToDashboard
            //
            this.btnBackToDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.btnBackToDashboard.FlatAppearance.BorderSize = 0;
            this.btnBackToDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackToDashboard.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackToDashboard.ForeColor = System.Drawing.Color.White;
            this.btnBackToDashboard.Location = new System.Drawing.Point(670, 20);
            this.btnBackToDashboard.Name = "btnBackToDashboard";
            this.btnBackToDashboard.Size = new System.Drawing.Size(110, 50);
            this.btnBackToDashboard.TabIndex = 5;
            this.btnBackToDashboard.Text = "Back to Dashboard";
            this.btnBackToDashboard.UseVisualStyleBackColor = false;
            this.btnBackToDashboard.Click += new System.EventHandler(this.btnBackToDashboard_Click);
            //
            // FormAdminTransactions
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBackToDashboard);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnUpdateStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTransactions);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAdminTransactions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "All Transactions";
            this.Load += new System.EventHandler(this.FormAdminTransactions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBackToDashboard;
    }
}