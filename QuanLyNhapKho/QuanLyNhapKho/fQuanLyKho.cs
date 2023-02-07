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
    public partial class fQuanLyKho : Form
    {
        public fQuanLyKho()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=QL_Nhap_Kho;Integrated Security=True");
        private void fQuanLyKho_Load(object sender, EventArgs e)
        {
            var dap = new SqlDataAdapter("select * from HangSX", conn);
            var table = new DataTable();
            dap.Fill(table);
            cbLoaiSP.DisplayMember = "tenHang";
            cbLoaiSP.ValueMember = "IDHang";
            cbLoaiSP.DataSource = table;

            txbQLMaHang.DataBindings.Clear();
            txbQLMaHang.DataBindings.Add("Text", cbLoaiSP.DataSource, "IDHang", true, DataSourceUpdateMode.Never);
            txbQLTenHang.DataBindings.Clear();
            txbQLTenHang.DataBindings.Add("Text", cbLoaiSP.DataSource, "tenHang", true, DataSourceUpdateMode.Never);

            dis_enb(false);
        }

        private void cbLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cbLoaiSP.SelectedValue);
            var dap = new SqlDataAdapter("select * from SanPham where IDHang = "+id+"", conn);
            var table = new DataTable();
            dap.Fill(table);
            dtgvSanPham.DataSource = table;

            txbQLMaSP.DataBindings.Clear();
            txbQLMaSP.DataBindings.Add("Text", dtgvSanPham.DataSource, "maSP", true, DataSourceUpdateMode.Never);
            txbQLTenSP.DataBindings.Clear();
            txbQLTenSP.DataBindings.Add("Text", dtgvSanPham.DataSource, "tenSP", true, DataSourceUpdateMode.Never);
            txbQLNuocSX.DataBindings.Clear();
            txbQLNuocSX.DataBindings.Add("Text", dtgvSanPham.DataSource, "nuocSX", true, DataSourceUpdateMode.Never);
            txbQLGiaSP.DataBindings.Clear();
            txbQLGiaSP.DataBindings.Add("Text", dtgvSanPham.DataSource, "gia", true, DataSourceUpdateMode.Never);
        }

        int flag = 0;
        void dis_enb(bool e)
        {
            btnHuyHang.Enabled = e;
            btnLuuHang.Enabled = e;
            btnLuuSP.Enabled = e;
            btnHuySP.Enabled = e;

            btnThemHang.Enabled = !e;
            btnXoaHang.Enabled = !e;
            btnSuaHang.Enabled = !e;

            btnThemSP.Enabled = !e;
            btnXoaSP.Enabled = !e;
            btnSuaSP.Enabled = !e;
        }
        private void btnHuyHang_Click(object sender, EventArgs e)
        {
            fQuanLyKho_Load(sender, e);
            dis_enb(false);
        }

        private void btnLuuHang_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                // Thêm
                if (txbQLTenHang.Text != "")
                {
                    conn.Open();
                    var cmd = new SqlCommand("Insert into HangSX values ('" + txbQLTenHang.Text + "')", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Thêm hãng mới thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fQuanLyKho_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Xin hãy nhập đầy đủ thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Sửa
                if (txbQLTenHang.Text != "")
                {
                    conn.Open();
                    var cmd = new SqlCommand(string.Format("Update HangSX set tenHang = N'{0}' where IDHang = '{1}'", txbQLTenHang.Text, Convert.ToInt32(txbQLMaHang.Text)), conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Sửa hãng thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fQuanLyKho_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Xin hãy nhập đầy đủ thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private void btnThemHang_Click(object sender, EventArgs e)
        {
            flag = 0;
            txbQLTenHang.Text = "";
            dis_enb(true);
        }

        private void btnXoaHang_Click(object sender, EventArgs e)
        {
            string name = txbQLTenHang.Text;

            if (MessageBox.Show(string.Format("Bạn có muốn xóa hãng {0} ", name), "Thông báo ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                conn.Open();
                var cmd = new SqlCommand("Delete From HangSX where IDHang = '" + txbQLMaHang.Text + "' ", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Xóa hãng thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fQuanLyKho_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Xóa thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSuaHang_Click(object sender, EventArgs e)
        {
            flag = 1;
            dis_enb(true);
        }

        // Sản Phẩm
        private void btnLuuSP_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                // Thêm
                if (txbQLMaSP.Text != "" && txbQLTenSP.Text != "" && txbQLNuocSX.Text != "" && txbQLGiaSP.Text != "")
                {
                    conn.Open();
                    var cmd = new SqlCommand("Insert into SanPham (maSP, tenSP, IDHang , nuocSX, gia) values ('" + txbQLMaSP.Text + "', N'" + txbQLTenSP.Text + "' , " + txbQLMaHang.Text + " , N'" + txbQLNuocSX.Text + "', " + txbQLGiaSP.Text + ")", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Thêm sản phẩm mới thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fQuanLyKho_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Xin hãy nhập đầy đủ thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Sửa
                if (txbQLMaSP.Text != "" && txbQLTenSP.Text != "" && txbQLNuocSX.Text != "" && txbQLGiaSP.Text != "")
                {
                    conn.Open();
                    var cmd = new SqlCommand("Update SanPham SET tenSP = N'" + txbQLTenSP.Text + "', nuocSX = N'" + txbQLNuocSX.Text + "', gia = " + txbQLGiaSP.Text +" where maSP = '" + txbQLMaSP.Text + "' ", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Sửa sản phẩm thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fQuanLyKho_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Xin hãy nhập đầy đủ thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnHuySP_Click(object sender, EventArgs e)
        {
            fQuanLyKho_Load(sender, e);
            dis_enb(false);
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            flag = 0;
            txbQLMaSP.Text = "";
            txbQLTenSP.Text = "";
            txbQLGiaSP.Text = "";
            dis_enb(true);
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            string name = txbQLTenSP.Text;

            if (MessageBox.Show(string.Format("Bạn có muốn xóa sản phẩm {0} ", name), "Thông báo ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                conn.Open();
                var cmd = new SqlCommand("Delete From SanPham where maSP = '" + txbQLMaSP.Text + "' ", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Xóa hãng thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fQuanLyKho_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Xóa thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            flag = 1;
            dis_enb(true);
        }

        private void btnTimSP_Click(object sender, EventArgs e)
        {
            var dap = new SqlDataAdapter(string.Format("select * from SanPham where tenSP like '%" + txbTimSP.Text + "%'"), conn);
            DataTable table = new DataTable();
            table.Clear();
            dap.Fill(table);
            dtgvSanPham.DataSource = table;
        }
    }
}
