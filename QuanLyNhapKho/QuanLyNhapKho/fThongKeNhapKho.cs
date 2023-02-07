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
using Microsoft.Reporting.WinForms;

namespace QuanLyNhapKho
{
    public partial class fThongKeNhapKho : Form
    {
        public fThongKeNhapKho()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=QL_Nhap_Kho;Integrated Security=True");
        private void fThongKeNhapKho_Load(object sender, EventArgs e)
        {

            this.rpvThongKe.RefreshReport();
        }

        private void btnTaoBaoCao_Click(object sender, EventArgs e)
        {
            var cmd = new SqlCommand("USP_ThongKeTheoNgay", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ngayNhap", SqlDbType.Date).Value = dtpkThongKe.Value;

            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            dap.Fill(ds);
            rpvThongKe.ProcessingMode = ProcessingMode.Local;
            rpvThongKe.LocalReport.ReportPath = "rptThongKeNhapKho.rdlc";

            ReportDataSource report_ds = new ReportDataSource();
            report_ds.Name = "dataset_NhapKho";
            report_ds.Value = ds.Tables[0];
            rpvThongKe.LocalReport.DataSources.Clear();
            rpvThongKe.LocalReport.DataSources.Add(report_ds);
            rpvThongKe.RefreshReport();
            
        }
    }
}
