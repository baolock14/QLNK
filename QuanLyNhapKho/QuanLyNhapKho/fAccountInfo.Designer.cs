namespace QuanLyNhapKho
{
    partial class fAccountInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txbPassWord = new System.Windows.Forms.TextBox();
            this.btnThemTK = new System.Windows.Forms.Button();
            this.btnHuyTK = new System.Windows.Forms.Button();
            this.dtgvTaiKhoan = new System.Windows.Forms.DataGridView();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSuaTK = new System.Windows.Forms.Button();
            this.btnXoaTK = new System.Windows.Forms.Button();
            this.btnLuuTK = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTaiKhoan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(408, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(408, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(530, 67);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(214, 25);
            this.txtUserName.TabIndex = 2;
            // 
            // txbPassWord
            // 
            this.txbPassWord.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPassWord.Location = new System.Drawing.Point(530, 103);
            this.txbPassWord.Name = "txbPassWord";
            this.txbPassWord.Size = new System.Drawing.Size(214, 25);
            this.txbPassWord.TabIndex = 3;
            // 
            // btnThemTK
            // 
            this.btnThemTK.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnThemTK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemTK.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemTK.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnThemTK.Location = new System.Drawing.Point(412, 173);
            this.btnThemTK.Name = "btnThemTK";
            this.btnThemTK.Size = new System.Drawing.Size(96, 31);
            this.btnThemTK.TabIndex = 9;
            this.btnThemTK.Text = "Thêm";
            this.btnThemTK.UseVisualStyleBackColor = false;
            this.btnThemTK.Click += new System.EventHandler(this.btnThemTK_Click);
            // 
            // btnHuyTK
            // 
            this.btnHuyTK.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnHuyTK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyTK.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyTK.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnHuyTK.Location = new System.Drawing.Point(648, 230);
            this.btnHuyTK.Name = "btnHuyTK";
            this.btnHuyTK.Size = new System.Drawing.Size(96, 31);
            this.btnHuyTK.TabIndex = 10;
            this.btnHuyTK.Text = "Hủy";
            this.btnHuyTK.UseVisualStyleBackColor = false;
            this.btnHuyTK.Click += new System.EventHandler(this.btnHuyTK_Click);
            // 
            // dtgvTaiKhoan
            // 
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Navy;
            this.dtgvTaiKhoan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgvTaiKhoan.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvTaiKhoan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dtgvTaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvTaiKhoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserName,
            this.Password});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvTaiKhoan.DefaultCellStyle = dataGridViewCellStyle9;
            this.dtgvTaiKhoan.Location = new System.Drawing.Point(24, 67);
            this.dtgvTaiKhoan.Name = "dtgvTaiKhoan";
            this.dtgvTaiKhoan.Size = new System.Drawing.Size(334, 194);
            this.dtgvTaiKhoan.TabIndex = 11;
            // 
            // UserName
            // 
            this.UserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "Tên tài khoản";
            this.UserName.Name = "UserName";
            // 
            // Password
            // 
            this.Password.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Password.DataPropertyName = "Password";
            this.Password.HeaderText = "Mật khẩu";
            this.Password.Name = "Password";
            // 
            // btnSuaTK
            // 
            this.btnSuaTK.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSuaTK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaTK.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaTK.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnSuaTK.Location = new System.Drawing.Point(647, 173);
            this.btnSuaTK.Name = "btnSuaTK";
            this.btnSuaTK.Size = new System.Drawing.Size(96, 31);
            this.btnSuaTK.TabIndex = 13;
            this.btnSuaTK.Text = "Sửa";
            this.btnSuaTK.UseVisualStyleBackColor = false;
            this.btnSuaTK.Click += new System.EventHandler(this.btnSuaTK_Click);
            // 
            // btnXoaTK
            // 
            this.btnXoaTK.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnXoaTK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaTK.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaTK.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnXoaTK.Location = new System.Drawing.Point(530, 173);
            this.btnXoaTK.Name = "btnXoaTK";
            this.btnXoaTK.Size = new System.Drawing.Size(96, 31);
            this.btnXoaTK.TabIndex = 12;
            this.btnXoaTK.Text = "Xóa";
            this.btnXoaTK.UseVisualStyleBackColor = false;
            this.btnXoaTK.Click += new System.EventHandler(this.btnXoaTK_Click);
            // 
            // btnLuuTK
            // 
            this.btnLuuTK.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnLuuTK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuTK.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuTK.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnLuuTK.Location = new System.Drawing.Point(530, 230);
            this.btnLuuTK.Name = "btnLuuTK";
            this.btnLuuTK.Size = new System.Drawing.Size(96, 31);
            this.btnLuuTK.TabIndex = 14;
            this.btnLuuTK.Text = "Lưu";
            this.btnLuuTK.UseVisualStyleBackColor = false;
            this.btnLuuTK.Click += new System.EventHandler(this.btnLuuTK_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MediumBlue;
            this.label3.Location = new System.Drawing.Point(88, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 30);
            this.label3.TabIndex = 15;
            this.label3.Text = "Thông tin tài khoản";
            // 
            // fAccountInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(770, 328);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLuuTK);
            this.Controls.Add(this.btnSuaTK);
            this.Controls.Add(this.btnXoaTK);
            this.Controls.Add(this.dtgvTaiKhoan);
            this.Controls.Add(this.btnHuyTK);
            this.Controls.Add(this.btnThemTK);
            this.Controls.Add(this.txbPassWord);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "fAccountInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin tài khoản";
            this.Load += new System.EventHandler(this.fAccountInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTaiKhoan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txbPassWord;
        private System.Windows.Forms.Button btnThemTK;
        private System.Windows.Forms.Button btnHuyTK;
        private System.Windows.Forms.DataGridView dtgvTaiKhoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.Button btnSuaTK;
        private System.Windows.Forms.Button btnXoaTK;
        private System.Windows.Forms.Button btnLuuTK;
        private System.Windows.Forms.Label label3;
    }
}