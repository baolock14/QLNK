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
    public partial class fCapNhatPNK : Form
    {
        public fCapNhatPNK()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=QL_Nhap_Kho;Integrated Security=True");
        private void fCapNhatPNK_Load(object sender, EventArgs e)
        {
            var dapPNK = new SqlDataAdapter("select maPhieu, sp.tenSP, pnk.maSP, ngayNhap, soLuong, soLuong * gia as thanhTien  from PhieuNK as pnk join SanPham as sp on sp.maSP = pnk.maSP", conn);
            var tablePNK = new DataTable();
            dapPNK.Fill(tablePNK);
            dtgvPhieuNKupdate.DataSource = tablePNK;
            txbTenSPPNK.DataBindings.Clear();
            txbTenSPPNK.DataBindings.Add("Text", dtgvPhieuNKupdate.DataSource, "tenSP", true, DataSourceUpdateMode.Never);
            txbMaSPPNK.DataBindings.Clear();
            txbMaSPPNK.DataBindings.Add("Text", dtgvPhieuNKupdate.DataSource, "maSP", true, DataSourceUpdateMode.Never);
            dtNgayNhapPNK.DataBindings.Clear();
            dtNgayNhapPNK.DataBindings.Add("Text", dtgvPhieuNKupdate.DataSource, "ngayNhap", true, DataSourceUpdateMode.Never);
            nmSoLuongSPPNK.DataBindings.Clear();
            nmSoLuongSPPNK.DataBindings.Add("Text", dtgvPhieuNKupdate.DataSource, "soLuong", true, DataSourceUpdateMode.Never);
            txbMaPhieu.DataBindings.Clear();
            txbMaPhieu.DataBindings.Add("Text", dtgvPhieuNKupdate.DataSource, "maPhieu", true, DataSourceUpdateMode.Never);
        }

        private void btnSuaPhieu_Click(object sender, EventArgs e)
        {
            DialogResult lenh = MessageBox.Show("Bạn có chắc chắn xóa phiếu nhập kho này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (lenh == DialogResult.Yes)
            {
                try
                {
                    if (nmSoLuongSPPNK.Value > 0)
                    {
                        conn.Open();
                        var cmd = new SqlCommand("USP_UpdatePNK", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@maSP", SqlDbType.NVarChar).Value = txbMaSPPNK.Text;
                        cmd.Parameters.Add("@ngayNhap", SqlDbType.Date).Value = dtNgayNhapPNK.Text;
                        cmd.Parameters.Add("@soLuong", SqlDbType.Int).Value = nmSoLuongSPPNK.Value;
                        cmd.Parameters.Add("@maPhieu", SqlDbType.Int).Value = txbMaPhieu.Text;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Sửa phiếu nhập kho thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fCapNhatPNK_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Vui lòng nhập số lượng sản phẩm"), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("Xóa dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult lenh = MessageBox.Show("Bạn có chắc chắn xóa phiếu nhập kho này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (lenh == DialogResult.Yes)
            {
                try
                {
                    if (nmSoLuongSPPNK.Value > 0)
                    {
                        conn.Open();
                        var cmd = new SqlCommand("USP_DeletePNK", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@maPhieu", SqlDbType.Int).Value = txbMaPhieu.Text;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Xóa phiếu nhập kho thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fCapNhatPNK_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Vui lòng nhập số lượng sản phẩm"), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("Xóa dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}

