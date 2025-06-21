namespace Project.Forms
{
    partial class FormProdukUser
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
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtDeskripsi = new System.Windows.Forms.TextBox();
            this.txtHarga = new System.Windows.Forms.TextBox();
            this.pbGambar = new System.Windows.Forms.PictureBox();
            this.dgvProduk = new System.Windows.Forms.DataGridView();
            this.labelNama = new System.Windows.Forms.Label();
            this.labelDeskripsi = new System.Windows.Forms.Label();
            this.labelHarga = new System.Windows.Forms.Label();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.numJumlah = new System.Windows.Forms.NumericUpDown();
            this.labelJumlah = new System.Windows.Forms.Label();
            this.labelStok = new System.Windows.Forms.Label();
            this.txtStok = new System.Windows.Forms.TextBox();
            this.groupBoxImage = new System.Windows.Forms.GroupBox();
            this.btnBeli = new System.Windows.Forms.Button();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnViewCart = new System.Windows.Forms.Button();
            this.btnMyOrders = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbGambar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduk)).BeginInit();
            this.groupBoxInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numJumlah)).BeginInit();
            this.groupBoxImage.SuspendLayout();
            this.SuspendLayout();
            //
            // txtNama
            //
            this.txtNama.Location = new System.Drawing.Point(171, 67);
            this.txtNama.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNama.Name = "txtNama";
            this.txtNama.ReadOnly = true;
            this.txtNama.Size = new System.Drawing.Size(284, 31);
            this.txtNama.TabIndex = 0;
            //
            // txtDeskripsi
            //
            this.txtDeskripsi.Location = new System.Drawing.Point(171, 150);
            this.txtDeskripsi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDeskripsi.Multiline = true;
            this.txtDeskripsi.Name = "txtDeskripsi";
            this.txtDeskripsi.ReadOnly = true;
            this.txtDeskripsi.Size = new System.Drawing.Size(284, 97);
            this.txtDeskripsi.TabIndex = 1;
            //
            // txtHarga
            //
            this.txtHarga.Location = new System.Drawing.Point(171, 283);
            this.txtHarga.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHarga.Name = "txtHarga";
            this.txtHarga.ReadOnly = true;
            this.txtHarga.Size = new System.Drawing.Size(284, 31);
            this.txtHarga.TabIndex = 2;
            //
            // pbGambar
            //
            this.pbGambar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbGambar.Location = new System.Drawing.Point(29, 50);
            this.pbGambar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbGambar.Name = "pbGambar";
            this.pbGambar.Size = new System.Drawing.Size(299, 299);
            this.pbGambar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbGambar.TabIndex = 0;
            this.pbGambar.TabStop = false;
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
            this.dgvProduk.Location = new System.Drawing.Point(29, 500);
            this.dgvProduk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvProduk.Name = "dgvProduk";
            this.dgvProduk.ReadOnly = true;
            this.dgvProduk.RowHeadersWidth = 62;
            this.dgvProduk.RowTemplate.Height = 25;
            this.dgvProduk.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProduk.Size = new System.Drawing.Size(1086, 417);
            this.dgvProduk.TabIndex = 2;
            this.dgvProduk.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduk_CellClick);
            //
            // labelNama
            //
            this.labelNama.AutoSize = true;
            this.labelNama.Location = new System.Drawing.Point(29, 72);
            this.labelNama.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNama.Name = "labelNama";
            this.labelNama.Size = new System.Drawing.Size(59, 25);
            this.labelNama.TabIndex = 1;
            this.labelNama.Text = "Name";
            //
            // labelDeskripsi
            //
            this.labelDeskripsi.AutoSize = true;
            this.labelDeskripsi.Location = new System.Drawing.Point(29, 155);
            this.labelDeskripsi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDeskripsi.Name = "labelDeskripsi";
            this.labelDeskripsi.Size = new System.Drawing.Size(102, 25);
            this.labelDeskripsi.TabIndex = 1;
            this.labelDeskripsi.Text = "Description";
            //
            // labelHarga
            //
            this.labelHarga.AutoSize = true;
            this.labelHarga.Location = new System.Drawing.Point(29, 288);
            this.labelHarga.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHarga.Name = "labelHarga";
            this.labelHarga.Size = new System.Drawing.Size(49, 25);
            this.labelHarga.TabIndex = 1;
            this.labelHarga.Text = "Price";
            //
            // groupBoxInfo
            //
            this.groupBoxInfo.Controls.Add(this.numJumlah);
            this.groupBoxInfo.Controls.Add(this.labelJumlah);
            this.groupBoxInfo.Controls.Add(this.labelStok);
            this.groupBoxInfo.Controls.Add(this.txtStok);
            this.groupBoxInfo.Controls.Add(this.labelNama);
            this.groupBoxInfo.Controls.Add(this.txtNama);
            this.groupBoxInfo.Controls.Add(this.labelDeskripsi);
            this.groupBoxInfo.Controls.Add(this.txtDeskripsi);
            this.groupBoxInfo.Controls.Add(this.labelHarga);
            this.groupBoxInfo.Controls.Add(this.txtHarga);
            this.groupBoxInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxInfo.Location = new System.Drawing.Point(29, 33);
            this.groupBoxInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxInfo.Size = new System.Drawing.Size(500, 450);
            this.groupBoxInfo.TabIndex = 0;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Product Information";
            //
            // numJumlah
            //
            this.numJumlah.Location = new System.Drawing.Point(171, 415);
            this.numJumlah.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numJumlah.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numJumlah.Name = "numJumlah";
            this.numJumlah.Size = new System.Drawing.Size(180, 31);
            this.numJumlah.TabIndex = 4;
            this.numJumlah.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            //
            // labelJumlah
            //
            this.labelJumlah.AutoSize = true;
            this.labelJumlah.Location = new System.Drawing.Point(29, 420);
            this.labelJumlah.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelJumlah.Name = "labelJumlah";
            this.labelJumlah.Size = new System.Drawing.Size(80, 25);
            this.labelJumlah.TabIndex = 1;
            this.labelJumlah.Text = "Quantity";
            //
            // labelStok
            //
            this.labelStok.AutoSize = true;
            this.labelStok.Location = new System.Drawing.Point(29, 355);
            this.labelStok.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStok.Name = "labelStok";
            this.labelStok.Size = new System.Drawing.Size(55, 25);
            this.labelStok.TabIndex = 1;
            this.labelStok.Text = "Stock";
            //
            // txtStok
            //
            this.txtStok.Location = new System.Drawing.Point(171, 350);
            this.txtStok.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtStok.Name = "txtStok";
            this.txtStok.ReadOnly = true;
            this.txtStok.Size = new System.Drawing.Size(284, 31);
            this.txtStok.TabIndex = 3;
            //
            // groupBoxImage
            //
            this.groupBoxImage.Controls.Add(this.btnAddToCart);
            this.groupBoxImage.Controls.Add(this.btnBeli);
            this.groupBoxImage.Controls.Add(this.pbGambar);
            this.groupBoxImage.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxImage.Location = new System.Drawing.Point(571, 33);
            this.groupBoxImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxImage.Name = "groupBoxImage";
            this.groupBoxImage.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxImage.Size = new System.Drawing.Size(357, 450);
            this.groupBoxImage.TabIndex = 1;
            this.groupBoxImage.TabStop = false;
            this.groupBoxImage.Text = "Product Image";
            //
            // btnBeli
            //
            this.btnBeli.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnBeli.FlatAppearance.BorderSize = 0;
            this.btnBeli.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBeli.ForeColor = System.Drawing.Color.White;
            this.btnBeli.Location = new System.Drawing.Point(197, 370);
            this.btnBeli.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBeli.Name = "btnBeli";
            this.btnBeli.Size = new System.Drawing.Size(131, 48);
            this.btnBeli.TabIndex = 4;
            this.btnBeli.Text = "Buy Now";
            this.btnBeli.UseVisualStyleBackColor = false;
            this.btnBeli.Click += new System.EventHandler(this.btnBeli_Click);
            //
            // btnAddToCart
            //
            this.btnAddToCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.btnAddToCart.FlatAppearance.BorderSize = 0;
            this.btnAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToCart.ForeColor = System.Drawing.Color.White;
            this.btnAddToCart.Location = new System.Drawing.Point(29, 370);
            this.btnAddToCart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(131, 48);
            this.btnAddToCart.TabIndex = 5;
            this.btnAddToCart.Text = "Add to Cart";
            this.btnAddToCart.UseVisualStyleBackColor = false;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            //
            // btnLogout
            //
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(971, 33);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(143, 58);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            //
            // btnViewCart
            //
            this.btnViewCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.btnViewCart.FlatAppearance.BorderSize = 0;
            this.btnViewCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewCart.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewCart.ForeColor = System.Drawing.Color.White;
            this.btnViewCart.Location = new System.Drawing.Point(971, 100);
            this.btnViewCart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnViewCart.Name = "btnViewCart";
            this.btnViewCart.Size = new System.Drawing.Size(143, 58);
            this.btnViewCart.TabIndex = 6;
            this.btnViewCart.Text = "View Cart";
            this.btnViewCart.UseVisualStyleBackColor = false;
            this.btnViewCart.Click += new System.EventHandler(this.btnViewCart_Click);
            //
            // btnMyOrders
            //
            this.btnMyOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.btnMyOrders.FlatAppearance.BorderSize = 0;
            this.btnMyOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyOrders.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMyOrders.ForeColor = System.Drawing.Color.White;
            this.btnMyOrders.Location = new System.Drawing.Point(971, 170);
            this.btnMyOrders.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMyOrders.Name = "btnMyOrders";
            this.btnMyOrders.Size = new System.Drawing.Size(143, 58);
            this.btnMyOrders.TabIndex = 7;
            this.btnMyOrders.Text = "My Orders";
            this.btnMyOrders.UseVisualStyleBackColor = false;
            this.btnMyOrders.Click += new System.EventHandler(this.btnMyOrders_Click);
            //
            // FormProdukUser
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1143, 1000);
            this.Controls.Add(this.btnMyOrders);
            this.Controls.Add(this.btnViewCart);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.dgvProduk);
            this.Controls.Add(this.groupBoxImage);
            this.Controls.Add(this.groupBoxInfo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormProdukUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product List";
            ((System.ComponentModel.ISupportInitialize)(this.pbGambar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduk)).EndInit();
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numJumlah)).EndInit();
            this.groupBoxImage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtDeskripsi;
        private System.Windows.Forms.TextBox txtHarga;
        private System.Windows.Forms.TextBox txtStok;
        private System.Windows.Forms.PictureBox pbGambar;
        private System.Windows.Forms.DataGridView dgvProduk;
        private System.Windows.Forms.Label labelNama;
        private System.Windows.Forms.Label labelDeskripsi;
        private System.Windows.Forms.Label labelHarga;
        private System.Windows.Forms.Label labelStok;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.GroupBox groupBoxImage;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnBeli;
        private System.Windows.Forms.NumericUpDown numJumlah;
        private System.Windows.Forms.Label labelJumlah;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.Button btnViewCart;
        private System.Windows.Forms.Button btnMyOrders;
    }
}