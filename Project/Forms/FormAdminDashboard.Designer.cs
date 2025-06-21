namespace Project.Forms
{
    partial class FormAdminDashboard
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnManageProducts = new System.Windows.Forms.Button();
            this.btnViewTransactions = new System.Windows.Forms.Button();
            this.btnManageUsers = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Admin Dashboard";
            //
            // btnManageProducts
            //
            this.btnManageProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnManageProducts.FlatAppearance.BorderSize = 0;
            this.btnManageProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageProducts.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageProducts.ForeColor = System.Drawing.Color.White;
            this.btnManageProducts.Location = new System.Drawing.Point(50, 100);
            this.btnManageProducts.Name = "btnManageProducts";
            this.btnManageProducts.Size = new System.Drawing.Size(200, 80);
            this.btnManageProducts.TabIndex = 1;
            this.btnManageProducts.Text = "Manage Products";
            this.btnManageProducts.UseVisualStyleBackColor = false;
            this.btnManageProducts.Click += new System.EventHandler(this.btnManageProducts_Click);
            //
            // btnViewTransactions
            //
            this.btnViewTransactions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.btnViewTransactions.FlatAppearance.BorderSize = 0;
            this.btnViewTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewTransactions.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewTransactions.ForeColor = System.Drawing.Color.White;
            this.btnViewTransactions.Location = new System.Drawing.Point(280, 100);
            this.btnViewTransactions.Name = "btnViewTransactions";
            this.btnViewTransactions.Size = new System.Drawing.Size(200, 80);
            this.btnViewTransactions.TabIndex = 2;
            this.btnViewTransactions.Text = "View All Transactions";
            this.btnViewTransactions.UseVisualStyleBackColor = false;
            this.btnViewTransactions.Click += new System.EventHandler(this.btnViewTransactions_Click);
            //
            // btnManageUsers
            //
            this.btnManageUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.btnManageUsers.FlatAppearance.BorderSize = 0;
            this.btnManageUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageUsers.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageUsers.ForeColor = System.Drawing.Color.White;
            this.btnManageUsers.Location = new System.Drawing.Point(50, 200);
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.Size = new System.Drawing.Size(200, 80);
            this.btnManageUsers.TabIndex = 3;
            this.btnManageUsers.Text = "Manage Users";
            this.btnManageUsers.UseVisualStyleBackColor = false;
            this.btnManageUsers.Click += new System.EventHandler(this.btnManageUsers_Click);
            //
            // btnLogout
            //
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(370, 300);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(110, 50);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            //
            // FormAdminDashboard
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(520, 380);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnManageUsers);
            this.Controls.Add(this.btnViewTransactions);
            this.Controls.Add(this.btnManageProducts);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnManageProducts;
        private System.Windows.Forms.Button btnViewTransactions;
        private System.Windows.Forms.Button btnManageUsers;
        private System.Windows.Forms.Button btnLogout;
    }
}