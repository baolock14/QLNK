using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace QuanLyNhapKho
{
    public partial class fAccountInfo : Form
    {
        public fAccountInfo()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=QL_Nhap_Kho;Integrated Security=True");

        private void fAccountInfo_Load(object sender, EventArgs e)
        {
            var dap = new SqlDataAdapter("select * from TaiKhoan ", conn);
            var table = new DataTable();
            dap.Fill(table);
            dtgvTaiKhoan.DataSource = table;

            txtUserName.DataBindings.Clear();
            txtUserName.DataBindings.Add("Text", dtgvTaiKhoan.DataSource, "UserName", true, DataSourceUpdateMode.Never);
            txbPassWord.DataBindings.Clear();
            txbPassWord.DataBindings.Add("Text", dtgvTaiKhoan.DataSource, "Password", true, DataSourceUpdateMode.Never);
            dis_enb(false);
        }


        int flag = 0;
        void dis_enb(bool e)
        {
            btnHuyTK.Enabled = e;
            btnLuuTK.Enabled = e;

            btnThemTK.Enabled = !e;
            btnXoaTK.Enabled = !e;
            btnSuaTK.Enabled = !e;
        }

        private void btnHuyTK_Click(object sender, EventArgs e)
        {
            fAccountInfo_Load(sender, e);
            dis_enb(false);
        }

        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            //Xóa
            string name = txtUserName.Text;

            if (MessageBox.Show(string.Format("Bạn có muốn xóa tài khoản {0} ", name), "Thông báo ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                conn.Open();
                var cmd = new SqlCommand("Delete From TaiKhoan where UserName = '" + txtUserName.Text + "' ", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Xóa tài khoản thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fAccountInfo_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSuaTK_Click(object sender, EventArgs e)
        {
            flag = 1;
            dis_enb(true);
            txtUserName.Enabled = false;
        }

        private void btnLuuTK_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                // Thêm
                if (txtUserName.Text != "" && txbPassWord.Text != "")
                {
                    conn.Open();
                    var cmd = new SqlCommand("Insert into TaiKhoan values (N'" + txtUserName.Text + "', N'" + txbPassWord.Text + "')", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Thêm tài khoản mới thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fAccountInfo_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Xin hãy nhập đầy đủ thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Sửa
                if (txbPassWord.Text != "" && txtUserName.Text != "")
                {
                    conn.Open();
                    var cmd = new SqlCommand("Update TaiKhoan SET Password = N'" + txbPassWord.Text + "', UserName = N'" + txtUserName.Text + "' where UserName = N'" + txtUserName.Text + "' ", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Sửa tài khoản thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fAccountInfo_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Xin hãy nhập đầy đủ thông tin tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnThemTK_Click(object sender, EventArgs e)
        {
            flag = 0;
            txtUserName.Text = "";
            txbPassWord.Text = "";
            dis_enb(true);
        }

    }
}
