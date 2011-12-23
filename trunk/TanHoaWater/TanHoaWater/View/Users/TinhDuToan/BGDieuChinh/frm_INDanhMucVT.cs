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
            // TODO: This line of code loads data into the 'dataSet.BGDC_CHITIETBG' table. You can move, or remove it, as needed.
            this.bGDC_CHITIETBGTableAdapter.Fill(this.dataSet.BGDC_CHITIETBG);
            //TanHoaDataContext db = new TanHoaDataContext();
            //db.Connection.Open();
            //string sql = " SELECT * FROM BGDC_CHITIETBG WHERE SHS='11000024'";

            //SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            //DataSet dataset = new DataSet();
            //adapter.Fill(dataset, "DataSet");
            //db.Connection.Close();

            //reportViewer1.LocalReport.ReportEmbeddedResource = "TanHoaWater.View.Users.TinhDuToan.BGDieuChinh.Report1.rdlc";
            //ReportDataSource datasource = new ReportDataSource("DataSet_DataSet1", dataset.Tables[0]);
         
            //reportViewer1.LocalReport.DataSources.Clear();
            //reportViewer1.LocalReport.DataSources.Add(datasource);
            

            //reportViewer1.LocalReport.Refresh();

            this.reportViewer1.RefreshReport();
        }
    }
}
