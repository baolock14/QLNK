using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhapKho
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=QL_Nhap_Kho;Integrated Security=True");
            
            try
            {
                conn.Open();
                var query = "select * from TaiKhoan where UserName = @UserName and PassWord = @PassWord";
                var cmd = new SqlCommand(query, conn); // Xử lý lỗi SQL Injection
                cmd.Parameters.AddWithValue("UserName", txbUserName.Text);
                cmd.Parameters.AddWithValue("PassWord", txbPassWord.Text);
                var data = cmd.ExecuteReader();

                if (data.Read() == true)
                {
                    PhieuNK f = new PhieuNK();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch 
            {
                MessageBox.Show("Lỗi kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txbPassWord.UseSystemPasswordChar = false;
            }
            else
            {
                txbPassWord.UseSystemPasswordChar = true;
            }
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình? ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

    }
}
