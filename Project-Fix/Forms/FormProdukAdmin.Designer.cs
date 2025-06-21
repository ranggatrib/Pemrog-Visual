namespace Project.Forms // Penting: Namespace untuk form ini
{
    partial class FormProdukAdmin
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
            this.btnBackToDashboard = new System.Windows.Forms.Button(); // Deklarasi tombol baru
            ((System.ComponentModel.ISupportInitialize)(this.pbGambar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduk)).BeginInit();
            this.groupBoxInput.SuspendLayout();
            this.groupBoxImage.SuspendLayout();
            this.SuspendLayout();
            //
            // Form Styling
            //
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(950, 650); // Ukuran form disesuaikan
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Management (Admin)";
            //
            // groupBoxInput
            //
            this.groupBoxInput.Controls.Add(this.labelId);
            this.groupBoxInput.Controls.Add(this.txtId);
            this.groupBoxInput.Controls.Add(this.labelNama);
            this.groupBoxInput.Controls.Add(this.txtNama);
            this.groupBoxInput.Controls.Add(this.labelDeskripsi);
            this.groupBoxInput.Controls.Add(this.txtDeskripsi);
            this.groupBoxInput.Controls.Add(this.labelHarga);
            this.groupBoxInput.Controls.Add(this.txtHarga);
            this.groupBoxInput.Controls.Add(this.labelStok);
            this.groupBoxInput.Controls.Add(this.txtStok);
            this.groupBoxInput.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxInput.Location = new System.Drawing.Point(20, 20);
            this.groupBoxInput.Name = "groupBoxInput";
            this.groupBoxInput.Padding = new System.Windows.Forms.Padding(10); // Tambahkan padding
            this.groupBoxInput.Size = new System.Drawing.Size(350, 300);
            this.groupBoxInput.TabIndex = 0;
            this.groupBoxInput.TabStop = false;
            this.groupBoxInput.Text = "Product Information";
            //
            // txtId
            //
            this.txtId.Location = new System.Drawing.Point(120, 30);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(200, 23);
            this.txtId.TabIndex = 0;
            //
            // labelId
            //
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(20, 33);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(18, 15);
            this.labelId.TabIndex = 1;
            this.labelId.Text = "ID";
            //
            // txtNama
            //
            this.txtNama.Location = new System.Drawing.Point(120, 70);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(200, 23);
            this.txtNama.TabIndex = 1;
            //
            // labelNama
            //
            this.labelNama.AutoSize = true;
            this.labelNama.Location = new System.Drawing.Point(20, 73);
            this.labelNama.Name = "labelNama";
            this.labelNama.Size = new System.Drawing.Size(39, 15);
            this.labelNama.TabIndex = 1;
            this.labelNama.Text = "Name";
            //
            // txtDeskripsi
            //
            this.txtDeskripsi.Location = new System.Drawing.Point(120, 110);
            this.txtDeskripsi.Multiline = true;
            this.txtDeskripsi.Name = "txtDeskripsi";
            this.txtDeskripsi.Size = new System.Drawing.Size(200, 60);
            this.txtDeskripsi.TabIndex = 2;
            //
            // labelDeskripsi
            //
            this.labelDeskripsi.AutoSize = true;
            this.labelDeskripsi.Location = new System.Drawing.Point(20, 113);
            this.labelDeskripsi.Name = "labelDeskripsi";
            this.labelDeskripsi.Size = new System.Drawing.Size(67, 15);
            this.labelDeskripsi.TabIndex = 1;
            this.labelDeskripsi.Text = "Description";
            //
            // txtHarga
            //
            this.txtHarga.Location = new System.Drawing.Point(120, 190);
            this.txtHarga.Name = "txtHarga";
            this.txtHarga.Size = new System.Drawing.Size(200, 23);
            this.txtHarga.TabIndex = 3;
            //
            // labelHarga
            //
            this.labelHarga.AutoSize = true;
            this.labelHarga.Location = new System.Drawing.Point(20, 193);
            this.labelHarga.Name = "labelHarga";
            this.labelHarga.Size = new System.Drawing.Size(36, 15);
            this.labelHarga.TabIndex = 1;
            this.labelHarga.Text = "Price";
            //
            // txtStok
            //
            this.txtStok.Location = new System.Drawing.Point(120, 230);
            this.txtStok.Name = "txtStok";
            this.txtStok.Size = new System.Drawing.Size(200, 23);
            this.txtStok.TabIndex = 4;
            //
            // labelStok
            //
            this.labelStok.AutoSize = true;
            this.labelStok.Location = new System.Drawing.Point(20, 233);
            this.labelStok.Name = "labelStok";
            this.labelStok.Size = new System.Drawing.Size(33, 15);
            this.labelStok.TabIndex = 1;
            this.labelStok.Text = "Stock";
            //
            // groupBoxImage
            //
            this.groupBoxImage.Controls.Add(this.pbGambar);
            this.groupBoxImage.Controls.Add(this.btnBrowse);
            this.groupBoxImage.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxImage.Location = new System.Drawing.Point(400, 20);
            this.groupBoxImage.Padding = new System.Windows.Forms.Padding(10);
            this.groupBoxImage.Size = new System.Drawing.Size(250, 300);
            this.groupBoxImage.TabIndex = 1;
            this.groupBoxImage.TabStop = false;
            this.groupBoxImage.Text = "Product Image";
            //
            // pbGambar
            //
            this.pbGambar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbGambar.Location = new System.Drawing.Point(20, 30);
            this.pbGambar.Name = "pbGambar";
            this.pbGambar.Size = new System.Drawing.Size(210, 180);
            this.pbGambar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbGambar.TabIndex = 5;
            this.pbGambar.TabStop = false;
            //
            // btnBrowse
            //
            this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnBrowse.FlatAppearance.BorderSize = 0;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Location = new System.Drawing.Point(20, 230);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(210, 30);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "Browse Image";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            //
            // Buttons Panel
            //
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(20, 340);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(100, 35);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            //
            // btnUpdate
            //
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(140, 340);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 35);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            //
            // btnDelete
            //
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(260, 340);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 35);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // btnLoad
            //
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(380, 340);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 35);
            this.btnLoad.TabIndex = 9;
            this.btnLoad.Text = "Refresh Data";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.FormProdukAdmin_Load);
            //
            // btnBackToDashboard
            //
            this.btnBackToDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64))))); // Dark Gray for Back
            this.btnBackToDashboard.FlatAppearance.BorderSize = 0;
            this.btnBackToDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackToDashboard.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackToDashboard.ForeColor = System.Drawing.Color.White;
            this.btnBackToDashboard.Location = new System.Drawing.Point(790, 20); // Posisi di kanan atas
            this.btnBackToDashboard.Name = "btnBackToDashboard";
            this.btnBackToDashboard.Size = new System.Drawing.Size(110, 50);
            this.btnBackToDashboard.TabIndex = 11;
            this.btnBackToDashboard.Text = "Back to Dashboard";
            this.btnBackToDashboard.UseVisualStyleBackColor = false;
            this.btnBackToDashboard.Click += new System.EventHandler(this.btnBackToDashboard_Click); // Event handler
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
            this.dgvProduk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduk.Location = new System.Drawing.Point(20, 390);
            this.dgvProduk.Name = "dgvProduk";
            this.dgvProduk.ReadOnly = true;
            this.dgvProduk.RowHeadersWidth = 51;
            this.dgvProduk.RowTemplate.Height = 25;
            this.dgvProduk.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProduk.Size = new System.Drawing.Size(910, 230);
            this.dgvProduk.TabIndex = 10;
            this.dgvProduk.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduk_CellClick);
            //
            // openFileDialog1
            //
            this.openFileDialog1.FileName = "openFileDialog1";
            //
            // FormProdukAdmin
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBackToDashboard);
            this.Controls.Add(this.dgvProduk);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.groupBoxImage);
            this.Controls.Add(this.groupBoxInput);
            this.Name = "FormProdukAdmin";
            this.Load += new System.EventHandler(this.FormProdukAdmin_Load);
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
        private System.Windows.Forms.Button btnBackToDashboard; // Deklarasi tombol baru
    }
}