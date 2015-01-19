using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using TanHoaWater.View.Users.KEHOACH.XINPHEPDD.BC;
using System.IO;
using System.Data.OleDb;
using TanHoaWater.Database;

namespace TanHoaWater.View.Users.KEHOACH.XINPHEPDD
{
    public partial class frmDialogDonXP_DA : Form
    {
        public frmDialogDonXP_DA(string madot)
        {
            InitializeComponent();

            this.cbMaDot.DataSource = DAL.C_KH_XinPhepDD.ListAllXinPhepDD();
            this.cbMaDot.ValueMember = "MADOT";
            this.cbMaDot.DisplayMember = "MADOT";
            cbMaDot.Text = madot;
            Load(madot);
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            ReportDocument rp = new rpt_XinPhep2014();
            string TUNGAY = Utilities.DateToString.NgayVN(tungay);
            string DENNGAY = Utilities.DateToString.NgayVN(denngay);
            rp.SetDataSource(DAL.C_KH_XinPhepDD.ReportxinPhepDD(this.cbMaDot.Text, TUNGAY, DENNGAY, TUNGAY, DENNGAY));
            rp.SetParameterValue("vv", this.txtVv.Text);
            rp.SetParameterValue("congtac", this.txtCongTac.Text);
            rp.SetParameterValue("tungay", TUNGAY);
            rp.SetParameterValue("denngay", DENNGAY);
            rp.SetParameterValue("tc1", this.thicong.Text);
            rp.SetParameterValue("tt", 1);
            
            crystalReportViewer1.ReportSource = rp;
           
            try
            {
                DA_XINPHEP xp = DAL.C_KH_XinPhepDD.finbyMaDotDA(this.cbMaDot.Text);
                if (xp != null)
                {

                    xp.VV = txtVv.Text;
                    xp.CONGTAC = txtCongTac.Text;
                    xp.DVTC = thicong.Text;
                    xp.DVTL = richTextBox1.Text;
                    xp.TUNGAY = tungay.Value;
                    xp.DENNGAY = denngay.Value;
                    DAL.C_KH_XinPhepDD.Update();
                }
                else
                {
                    xp = new DA_XINPHEP();
                    xp.MADOT = this.cbMaDot.Text;
                    xp.VV = txtVv.Text;
                    xp.CONGTAC = txtCongTac.Text;
                    xp.DVTC = thicong.Text;
                    xp.DVTL = richTextBox1.Text;
                    xp.TUNGAY = tungay.Value;
                    xp.DENNGAY = denngay.Value;
                    DAL.C_KH_XinPhepDD.InsertDA(xp);
                }
            }
            catch (Exception)
            {

            }
           
        }

        private void btExit_Click(object sender, EventArgs e)
        {
           
        }
       
        void Load(string madot)
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + @"XINPHEPDAODUONG.xls";
            if (!File.Exists(filePath))
            {
                System.Windows.Forms.MessageBox.Show("Không tìm thấy tập tin.");
                return;
            }
            var connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", filePath);
            var adapter = new OleDbDataAdapter("select * from [Sheet1$]", connectionString);
            var ds = new DataSet();
            string tableName = "excelData";
            adapter.Fill(ds, tableName);
            DataTable data = ds.Tables[tableName];
            this.thicong.Text = data.Rows[0][0].ToString();
            //MessageBox.Show(this, data.Rows[0][0].ToString());
            //MessageBox.Show(this, data.Rows[1][0].ToString());

            DA_XINPHEP xp = DAL.C_KH_XinPhepDD.finbyMaDotDA(madot);
            if (xp != null)
            {
                txtVv.Text = xp.VV;
                txtCongTac.Text = xp.CONGTAC;
                thicong.Text = xp.DVTC;
                richTextBox1.Text = xp.DVTL;
                tungay.Value = xp.TUNGAY.Value;
                denngay.Value = xp.DENNGAY.Value;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}