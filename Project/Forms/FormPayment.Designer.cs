namespace Project.Forms
{
    partial class FormPayment
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmountPaid = new System.Windows.Forms.TextBox();
            this.lblChange = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.lblNamaPenerima = new System.Windows.Forms.Label();
            this.lblAlamatPengiriman = new System.Windows.Forms.Label();
            this.lblNomorTeleponPenerima = new System.Windows.Forms.Label();
            this.lblBuktiTransfer = new System.Windows.Forms.Label();
            this.txtBuktiTransferPath = new System.Windows.Forms.TextBox();
            this.btnBrowseProof = new System.Windows.Forms.Button();
            this.lblAdminRekening = new System.Windows.Forms.Label(); // *** KOMPONEN BARU INI ***
            this.SuspendLayout();
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(66)))), ((int)(((byte)(138)))));
            this.label1.Location = new System.Drawing.Point(40, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Amount:";
            //
            // lblGrandTotal
            //
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblGrandTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblGrandTotal.Location = new System.Drawing.Point(230, 40);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(169, 45);
            this.lblGrandTotal.TabIndex = 1;
            this.lblGrandTotal.Text = "Rp 00.000";
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(40, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Amount Paid:";
            //
            // txtAmountPaid
            //
            this.txtAmountPaid.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAmountPaid.Location = new System.Drawing.Point(40, 130);
            this.txtAmountPaid.Name = "txtAmountPaid";
            this.txtAmountPaid.Size = new System.Drawing.Size(350, 39);
            this.txtAmountPaid.TabIndex = 3;
            //
            // lblChange
            //
            this.lblChange.AutoSize = true;
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblChange.Location = new System.Drawing.Point(40, 331);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(165, 32);
            this.lblChange.TabIndex = 4;
            this.lblChange.Text = "Change: Rp 0";
            //
            // btnPay
            //
            this.btnPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnPay.FlatAppearance.BorderSize = 0;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(40, 375);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(120, 45);
            this.btnPay.TabIndex = 5;
            this.btnPay.Text = "Pay";
            this.btnPay.UseVisualStyleBackColor = false;
            //
            // btnCancel
            //
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(170, 375);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 45);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(240, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 25);
            this.label4.TabIndex = 7;
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(40, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(216, 32);
            this.label5.TabIndex = 8;
            this.label5.Text = "Payment Method:";
            //
            // cmbPaymentMethod
            //
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPaymentMethod.FormattingEnabled = true;
            // Items akan diisi dari kode di FormPayment.cs
            // this.cmbPaymentMethod.Items.AddRange(new object[] { "Cash", "Credit Card", "Debit Card", "Bank Transfer" });
            this.cmbPaymentMethod.Location = new System.Drawing.Point(40, 210);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(350, 36);
            this.cmbPaymentMethod.TabIndex = 9;
            //
            // lblNamaPenerima
            //
            this.lblNamaPenerima.AutoSize = true;
            this.lblNamaPenerima.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamaPenerima.Location = new System.Drawing.Point(420, 40);
            this.lblNamaPenerima.Name = "lblNamaPenerima";
            this.lblNamaPenerima.Size = new System.Drawing.Size(150, 25);
            this.lblNamaPenerima.TabIndex = 10;
            this.lblNamaPenerima.Text = "Penerima: [Nama]";
            //
            // lblAlamatPengiriman
            //
            this.lblAlamatPengiriman.AutoSize = true;
            this.lblAlamatPengiriman.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlamatPengiriman.Location = new System.Drawing.Point(420, 70);
            this.lblAlamatPengiriman.Name = "lblAlamatPengiriman";
            this.lblAlamatPengiriman.Size = new System.Drawing.Size(215, 25);
            this.lblAlamatPengiriman.TabIndex = 11;
            this.lblAlamatPengiriman.Text = "Alamat: [Alamat Lengkap]";
            //
            // lblNomorTeleponPenerima
            //
            this.lblNomorTeleponPenerima.AutoSize = true;
            this.lblNomorTeleponPenerima.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblNomorTeleponPenerima.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomorTeleponPenerima.Location = new System.Drawing.Point(420, 100);
            this.lblNomorTeleponPenerima.Name = "lblNomorTeleponPenerima";
            this.lblNomorTeleponPenerima.Size = new System.Drawing.Size(185, 25);
            this.lblNomorTeleponPenerima.TabIndex = 12;
            this.lblNomorTeleponPenerima.Text = "Telp: [Nomor Telepon]";
            //
            // lblBuktiTransfer
            //
            this.lblBuktiTransfer.AutoSize = true;
            this.lblBuktiTransfer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBuktiTransfer.Location = new System.Drawing.Point(41, 262);
            this.lblBuktiTransfer.Name = "lblBuktiTransfer";
            this.lblBuktiTransfer.Size = new System.Drawing.Size(204, 25);
            this.lblBuktiTransfer.TabIndex = 13;
            this.lblBuktiTransfer.Text = "Upload Bukti Transfer:";
            this.lblBuktiTransfer.Visible = false;
            //
            // txtBuktiTransferPath
            //
            this.txtBuktiTransferPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBuktiTransferPath.Location = new System.Drawing.Point(40, 290);
            this.txtBuktiTransferPath.Name = "txtBuktiTransferPath";
            this.txtBuktiTransferPath.ReadOnly = true;
            this.txtBuktiTransferPath.Size = new System.Drawing.Size(250, 31);
            this.txtBuktiTransferPath.TabIndex = 14;
            this.txtBuktiTransferPath.Visible = false;
            //
            // btnBrowseProof
            //
            this.btnBrowseProof.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnBrowseProof.FlatAppearance.BorderSize = 0;
            this.btnBrowseProof.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseProof.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBrowseProof.ForeColor = System.Drawing.Color.White;
            this.btnBrowseProof.Location = new System.Drawing.Point(309, 290);
            this.btnBrowseProof.Name = "btnBrowseProof";
            this.btnBrowseProof.Size = new System.Drawing.Size(90, 27);
            this.btnBrowseProof.TabIndex = 15;
            this.btnBrowseProof.Text = "Browse...";
            this.btnBrowseProof.UseVisualStyleBackColor = false;
            this.btnBrowseProof.Visible = false;
            //
            // lblAdminRekening
            //
            this.lblAdminRekening.AutoSize = true;
            this.lblAdminRekening.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAdminRekening.Location = new System.Drawing.Point(420, 130); // Sesuaikan posisi
            this.lblAdminRekening.Name = "lblAdminRekening";
            this.lblAdminRekening.Size = new System.Drawing.Size(200, 25);
            this.lblAdminRekening.TabIndex = 16;
            this.lblAdminRekening.Text = "No. Rekening Admin:";
            this.lblAdminRekening.Visible = false; // Awalnya tidak terlihat
            //
            // FormPayment
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 423);
            this.Controls.Add(this.lblAdminRekening); // Tambahkan kontrol baru ke Controls
            this.Controls.Add(this.btnBrowseProof);
            this.Controls.Add(this.txtBuktiTransferPath);
            this.Controls.Add(this.lblBuktiTransfer);
            this.Controls.Add(this.lblNomorTeleponPenerima);
            this.Controls.Add(this.lblAlamatPengiriman);
            this.Controls.Add(this.lblNamaPenerima);
            this.Controls.Add(this.cmbPaymentMethod);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.lblChange);
            this.Controls.Add(this.txtAmountPaid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblGrandTotal);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Complete Payment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAmountPaid;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;

        private System.Windows.Forms.Label lblNamaPenerima;
        private System.Windows.Forms.Label lblAlamatPengiriman;
        private System.Windows.Forms.Label lblNomorTeleponPenerima;

        private System.Windows.Forms.Label lblBuktiTransfer;
        private System.Windows.Forms.TextBox txtBuktiTransferPath;
        private System.Windows.Forms.Button btnBrowseProof;

        private System.Windows.Forms.Label lblAdminRekening; // Deklarasi Variabel Kontrol Baru
    }
}
