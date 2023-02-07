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
    public partial class PhieuNK : Form
    {
        public PhieuNK()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=QL_Nhap_Kho;Integrated Security=True");
        
        private void PhieuNK_Load(object sender, EventArgs e)
        {
            try
            {
                var dap = new SqlDataAdapter("select * from HangSX", conn);
                var table = new DataTable();
                dap.Fill(table);
                cbLoaiSP.DisplayMember = "tenHang";
                cbLoaiSP.ValueMember = "IDHang";
                cbLoaiSP.DataSource = table;
                txbMaHang.DataBindings.Clear();
                txbMaHang.DataBindings.Add("Text", cbLoaiSP.DataSource, "IDHang", true, DataSourceUpdateMode.Never);

                var dapPNK = new SqlDataAdapter("select maPhieu, sp.tenSP, pnk.maSP, ngayNhap, soLuong, soLuong * gia as thanhTien  from PhieuNK as pnk join SanPham as sp on sp.maSP = pnk.maSP", conn);
                var tablePNK = new DataTable();
                dapPNK.Fill(tablePNK);
                dtgvPhieuNK.DataSource = tablePNK;
            }
            catch
            {
                MessageBox.Show("Load dữ liệu từ Database thất bại. Kiểm tra lại SQl Server trên máy tính của bạn",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cbLoaiSP.SelectedValue);
            var dap = new SqlDataAdapter("select * from SanPham where IDHang = " + id + "", conn);
            var table = new DataTable();
            dap.Fill(table);
            dtgvSanPham.DataSource = table;

            txbTenSP.DataBindings.Clear();
            txbTenSP.DataBindings.Add("Text", dtgvSanPham.DataSource, "tenSP", true, DataSourceUpdateMode.Never);
            txbMaSP.DataBindings.Clear();
            txbMaSP.DataBindings.Add("Text", dtgvSanPham.DataSource, "maSP", true, DataSourceUpdateMode.Never);
        }

        private void phiếuNhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuanLyKho f = new fQuanLyKho();
            this.Hide();
            f.ShowDialog();
            PhieuNK_Load(sender,e);
            this.Show();
        }
        private void đăngXuấtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void báoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThongKeNhapKho f = new fThongKeNhapKho();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnThemPhieu_Click(object sender, EventArgs e)
        {
            if (nmSoLuongSP.Value > 0)
            {
                conn.Open();
                var cmd = new SqlCommand("USP_InsertPNK", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@maSP", SqlDbType.NVarChar).Value = txbMaSP.Text;
                cmd.Parameters.Add("@ngayNhap", SqlDbType.Date).Value = dtNgayNhap.Text;
                cmd.Parameters.Add("@soLuong", SqlDbType.Int).Value = nmSoLuongSP.Value;
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show(string.Format("Nhập kho thành công {0} điện thoại {1}", nmSoLuongSP.Value, txbTenSP.Text), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                MessageBox.Show(string.Format("Vui lòng nhập số lượng sản phẩm"), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            PhieuNK_Load(sender, e);
        }

        private void tàiKhoảnCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountInfo f = new fAccountInfo();
            this.Hide();
            f.ShowDialog();
            PhieuNK_Load(sender, e);
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fCapNhatPNK f = new fCapNhatPNK();
            this.Hide();
            f.ShowDialog();
            PhieuNK_Load(sender, e);
            this.Show();
        }
    }
}
