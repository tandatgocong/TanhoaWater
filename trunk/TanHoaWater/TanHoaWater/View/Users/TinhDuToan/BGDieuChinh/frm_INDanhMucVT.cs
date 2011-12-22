using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace TanHoaWater.View.Users.TinhDuToan.BGDieuChinh
{
    public partial class frm_INDanhMucVT : Form
    {
        public frm_INDanhMucVT()
        {
            InitializeComponent();
        }

        private void frm_INDanhMucVT_Load(object sender, EventArgs e)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT * FROM BGDC_CHITIETBG WHERE SHS='11000024'";

            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet("TANHOA_WATERDataset");
            adapter.Fill(dataset, "Table");
            db.Connection.Close();

            reportViewer1.LocalReport.ReportEmbeddedResource = "TanHoaWater.View.Users.TinhDuToan.BGDieuChinh.Report1.rdlc";

            //prepare report data source
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "TANHOA_WATERDataset_Table";
            rds.Value = dataset.Tables[0];
            reportViewer1.LocalReport.DataSources.Add(rds);

            //load report viewer
            reportViewer1.RefreshReport();

            //ReportDataSource rds = new ReportDataSource("ds_viewTest", dataset.Tables);

            //reportViewer1.LocalReport.DataSources.Clear();
            //reportViewer1.LocalReport.DataSources.Add(rds);
            //reportViewer1.LocalReport.Refresh();

            //reportViewer1.Enabled = true;
            //reportViewer1.Reset();
            //reportViewer1.LocalReport.ReportEmbeddedResource = "TanHoaWater.View.Users.TinhDuToan.BGDieuChinh.Report1.rdlc";
            //Microsoft.Reporting.WinForms.ReportDataSource rds = new Microsoft.Reporting.WinForms.ReportDataSource();
            //rds.Value = dataset.Tables[0];
            //reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            //Microsoft.Reporting.WinForms.LocalReport rep = reportViewer1.LocalReport;
            //rep.DataSources.Add(rds);
            //reportViewer1.RefreshReport();

            //this.reportViewer1.RefreshReport();
        }
    }
}
