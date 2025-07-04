namespace Project.Forms
{
    partial class FormProdukAdmin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtDeskripsi = new System.Windows.Forms.TextBox();
            this.txtHarga = new System.Windows.Forms.TextBox();
            this.txtStok = new System.Windows.Forms.TextBox();
            this.pbGambar = new System.Windows.Forms.PictureBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dgvProduk = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelId = new System.Windows.Forms.Label();
            this.labelNama = new System.Windows.Forms.Label();
            this.labelDeskripsi = new System.Windows.Forms.Label();
            this.labelHarga = new System.Windows.Forms.Label();
            this.labelStok = new System.Windows.Forms.Label();
            this.groupBoxInput = new System.Windows.Forms.GroupBox();
            this.groupBoxImage = new System.Windows.Forms.GroupBox();
            this.btnBackToDashboard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbGambar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduk)).BeginInit();
            this.groupBoxInput.SuspendLayout();
            this.groupBoxImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtId.Location = new System.Drawing.Point(15, 60);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(250, 34);
            this.txtId.TabIndex = 0;
            // 
            // txtNama
            // 
            this.txtNama.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNama.Location = new System.Drawing.Point(15, 130);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(250, 34);
            this.txtNama.TabIndex = 1;
            // 
            // txtDeskripsi
            // 
            this.txtDeskripsi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDeskripsi.Location = new System.Drawing.Point(15, 200);
            this.txtDeskripsi.Multiline = true;
            this.txtDeskripsi.Name = "txtDeskripsi";
            this.txtDeskripsi.Size = new System.Drawing.Size(250, 80);
            this.txtDeskripsi.TabIndex = 2;
            // 
            // txtHarga
            // 
            this.txtHarga.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtHarga.Location = new System.Drawing.Point(15, 310);
            this.txtHarga.Name = "txtHarga";
            this.txtHarga.Size = new System.Drawing.Size(250, 34);
            this.txtHarga.TabIndex = 3;
            // 
            // txtStok
            // 
            this.txtStok.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtStok.Location = new System.Drawing.Point(15, 380);
            this.txtStok.Name = "txtStok";
            this.txtStok.Size = new System.Drawing.Size(250, 34);
            this.txtStok.TabIndex = 4;
            // 
            // pbGambar
            // 
            this.pbGambar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbGambar.Location = new System.Drawing.Point(15, 30);
            this.pbGambar.Name = "pbGambar";
            this.pbGambar.Size = new System.Drawing.Size(250, 200);
            this.pbGambar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbGambar.TabIndex = 5;
            this.pbGambar.TabStop = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnBrowse.FlatAppearance.BorderSize = 0;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Location = new System.Drawing.Point(15, 240);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(250, 40);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "Browse Image";
            this.btnBrowse.UseVisualStyleBackColor = false;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(500, 529);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(85, 39);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(591, 529);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(95, 39);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(692, 529);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 39);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(20, 20);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(130, 40);
            this.btnLoad.TabIndex = 10;
            this.btnLoad.Text = "Load Products";
            this.btnLoad.UseVisualStyleBackColor = false;
            // 
            // dgvProduk
            // 
            this.dgvProduk.AllowUserToAddRows = false;
            this.dgvProduk.AllowUserToDeleteRows = false;
            this.dgvProduk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProduk.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProduk.BackgroundColor = System.Drawing.Color.White;
            this.dgvProduk.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProduk.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvProduk.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProduk.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProduk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduk.EnableHeadersVisualStyles = false;
            this.dgvProduk.GridColor = System.Drawing.Color.LightGray;
            this.dgvProduk.Location = new System.Drawing.Point(20, 80);
            this.dgvProduk.Name = "dgvProduk";
            this.dgvProduk.ReadOnly = true;
            this.dgvProduk.RowHeadersVisible = false;
            this.dgvProduk.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgvProduk.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvProduk.RowTemplate.Height = 25;
            this.dgvProduk.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProduk.Size = new System.Drawing.Size(460, 485);
            this.dgvProduk.TabIndex = 11;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelId.Location = new System.Drawing.Point(15, 35);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(118, 28);
            this.labelId.TabIndex = 12;
            this.labelId.Text = "Product ID:";
            // 
            // labelNama
            // 
            this.labelNama.AutoSize = true;
            this.labelNama.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelNama.Location = new System.Drawing.Point(15, 105);
            this.labelNama.Name = "labelNama";
            this.labelNama.Size = new System.Drawing.Size(153, 28);
            this.labelNama.TabIndex = 13;
            this.labelNama.Text = "Product Name:";
            // 
            // labelDeskripsi
            // 
            this.labelDeskripsi.AutoSize = true;
            this.labelDeskripsi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelDeskripsi.Location = new System.Drawing.Point(15, 175);
            this.labelDeskripsi.Name = "labelDeskripsi";
            this.labelDeskripsi.Size = new System.Drawing.Size(206, 28);
            this.labelDeskripsi.TabIndex = 14;
            this.labelDeskripsi.Text = "Product Description:";
            // 
            // labelHarga
            // 
            this.labelHarga.AutoSize = true;
            this.labelHarga.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelHarga.Location = new System.Drawing.Point(15, 285);
            this.labelHarga.Name = "labelHarga";
            this.labelHarga.Size = new System.Drawing.Size(114, 28);
            this.labelHarga.TabIndex = 15;
            this.labelHarga.Text = "Price (Rp.):";
            // 
            // labelStok
            // 
            this.labelStok.AutoSize = true;
            this.labelStok.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelStok.Location = new System.Drawing.Point(15, 355);
            this.labelStok.Name = "labelStok";
            this.labelStok.Size = new System.Drawing.Size(70, 28);
            this.labelStok.TabIndex = 16;
            this.labelStok.Text = "Stock:";
            // 
            // groupBoxInput
            // 
            this.groupBoxInput.Controls.Add(this.labelStok);
            this.groupBoxInput.Controls.Add(this.labelHarga);
            this.groupBoxInput.Controls.Add(this.labelDeskripsi);
            this.groupBoxInput.Controls.Add(this.labelNama);
            this.groupBoxInput.Controls.Add(this.labelId);
            this.groupBoxInput.Controls.Add(this.txtId);
            this.groupBoxInput.Controls.Add(this.txtNama);
            this.groupBoxInput.Controls.Add(this.txtDeskripsi);
            this.groupBoxInput.Controls.Add(this.txtHarga);
            this.groupBoxInput.Controls.Add(this.txtStok);
            this.groupBoxInput.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBoxInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(66)))), ((int)(((byte)(138)))));
            this.groupBoxInput.Location = new System.Drawing.Point(500, 80);
            this.groupBoxInput.Name = "groupBoxInput";
            this.groupBoxInput.Padding = new System.Windows.Forms.Padding(10);
            this.groupBoxInput.Size = new System.Drawing.Size(280, 430);
            this.groupBoxInput.TabIndex = 17;
            this.groupBoxInput.TabStop = false;
            this.groupBoxInput.Text = "Product Details";
            // 
            // groupBoxImage
            // 
            this.groupBoxImage.Controls.Add(this.pbGambar);
            this.groupBoxImage.Controls.Add(this.btnBrowse);
            this.groupBoxImage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBoxImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(66)))), ((int)(((byte)(138)))));
            this.groupBoxImage.Location = new System.Drawing.Point(790, 80);
            this.groupBoxImage.Name = "groupBoxImage";
            this.groupBoxImage.Padding = new System.Windows.Forms.Padding(10);
            this.groupBoxImage.Size = new System.Drawing.Size(280, 290);
            this.groupBoxImage.TabIndex = 18;
            this.groupBoxImage.TabStop = false;
            this.groupBoxImage.Text = "Product Image";
            // 
            // btnBackToDashboard
            // 
            this.btnBackToDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnBackToDashboard.FlatAppearance.BorderSize = 0;
            this.btnBackToDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackToDashboard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBackToDashboard.ForeColor = System.Drawing.Color.White;
            this.btnBackToDashboard.Location = new System.Drawing.Point(940, 20);
            this.btnBackToDashboard.Name = "btnBackToDashboard";
            this.btnBackToDashboard.Size = new System.Drawing.Size(115, 40);
            this.btnBackToDashboard.TabIndex = 19;
            this.btnBackToDashboard.Text = "Back to Dashboard";
            this.btnBackToDashboard.UseVisualStyleBackColor = false;
            // 
            // FormProdukAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1090, 580);
            this.Controls.Add(this.btnBackToDashboard);
            this.Controls.Add(this.groupBoxImage);
            this.Controls.Add(this.groupBoxInput);
            this.Controls.Add(this.dgvProduk);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCreate);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProdukAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Management (Admin)";
            ((System.ComponentModel.ISupportInitialize)(this.pbGambar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduk)).EndInit();
            this.groupBoxInput.ResumeLayout(false);
            this.groupBoxInput.PerformLayout();
            this.groupBoxImage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtDeskripsi;
        private System.Windows.Forms.TextBox txtHarga;
        private System.Windows.Forms.TextBox txtStok;
        private System.Windows.Forms.PictureBox pbGambar;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataGridView dgvProduk;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelNama;
        private System.Windows.Forms.Label labelDeskripsi;
        private System.Windows.Forms.Label labelHarga;
        private System.Windows.Forms.Label labelStok;
        private System.Windows.Forms.GroupBox groupBoxInput;
        private System.Windows.Forms.GroupBox groupBoxImage;
        private System.Windows.Forms.Button btnBackToDashboard;
    }
}