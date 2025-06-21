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
            this.SuspendLayout();
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Payment Details";
            //
            // lblGrandTotal
            //
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblGrandTotal.Location = new System.Drawing.Point(30, 80);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(161, 28);
            this.lblGrandTotal.TabIndex = 1;
            this.lblGrandTotal.Text = "Grand Total: Rp";
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Amount Paid:";
            //
            // txtAmountPaid
            //
            this.txtAmountPaid.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountPaid.Location = new System.Drawing.Point(160, 167);
            this.txtAmountPaid.Name = "txtAmountPaid";
            this.txtAmountPaid.Size = new System.Drawing.Size(200, 30);
            this.txtAmountPaid.TabIndex = 3;
            this.txtAmountPaid.TextChanged += new System.EventHandler(this.txtAmountPaid_TextChanged);
            //
            // lblChange
            //
            this.lblChange.AutoSize = true;
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblChange.Location = new System.Drawing.Point(30, 230);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(125, 28);
            this.lblChange.TabIndex = 4;
            this.lblChange.Text = "Change: Rp";
            //
            // btnPay
            //
            this.btnPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnPay.FlatAppearance.BorderSize = 0;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(230, 290);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(130, 45);
            this.btnPay.TabIndex = 5;
            this.btnPay.Text = "Pay";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            //
            // btnCancel
            //
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(35, 290);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 45);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(123, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Rp";
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Payment Method:";
            //
            // cmbPaymentMethod
            //
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Items.AddRange(new object[] {
            "Tunai",
            "Transfer Bank"});
            this.cmbPaymentMethod.Location = new System.Drawing.Point(190, 127);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(170, 28);
            this.cmbPaymentMethod.TabIndex = 9;
            //
            // FormPayment
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 360);
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
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Complete Payment";
            this.Load += new System.EventHandler(this.FormPayment_Load);
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
    }
}