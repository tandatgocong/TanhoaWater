using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;
using CrystalDecisions.CrystalReports.Engine;
using TanHoaWater.View.Users.Report;
using TanHoaWater.View.Users.KEHOACH.DOTTHICONG.BC;
using log4net;

namespace TanHoaWater.View.Users.KEHOACH.DOTTHICONG
{
    public partial class Tab_EditDanhSachTC  : UserControl
    {
        string _madot="";
        public Tab_EditDanhSachTC(string madot)
        {
            InitializeComponent();
            lbDotTc.Text = "ĐỢT THI CÔNG : " + madot.ToUpper();
            _madot = madot;
            loadDataGrid();
        }
        private Control txtKeypress;
        private void KeyPressHandle(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
            {
                if ((e.KeyChar) != 8 && (e.KeyChar) != 46 && (e.KeyChar) != 37 && (e.KeyChar) != 39 && (e.KeyChar) != 188)
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
        }
      
      
     public void loadDataGrid()
     {
         dataGridViewDotTC.DataSource = DAL.C_KH_DotThiCong.getListDotThiCong(_madot);
         Utilities.DataGridV.formatSoHoSo(dataGridViewDotTC);
     }
        
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_CapNhatDanhSachND).Name);
        private void btPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string tendot = DAL.C_KH_DotThiCong.findByMadot(_madot).LOAIBANGKE;
                if (tendot.Equals("Gắn Mới(NĐ117)"))
                {
                    ReportDocument rp = new rpt_DanhSachHSTC_GM();
                    rp.SetDataSource(DAL.C_KH_DotThiCong.BC_DanhSachDotThiCong(_madot));
                    rpt_Main mainReport = new rpt_Main(rp);
                    mainReport.ShowDialog();
                }
                else if (tendot.Equals("Ống Cái") || tendot.Equals("Gắn Mới"))
                {
                    ReportDocument rp = new rpt_DanhSachHSTC_OC();
                    rp.SetDataSource(DAL.C_KH_DotThiCong.BC_DanhSachDotThiCong_OC(_madot));
                    rpt_Main mainReport = new rpt_Main(rp);
                    mainReport.ShowDialog();
                }
                else if (tendot.Equals("Bồi Thường"))
                {
                    ReportDocument rp = new rpt_DanhSachHSTC_BT();
                    rp.SetDataSource(DAL.C_KH_DotThiCong.BC_DanhSachDotThiCong_BT(_madot));
                    rpt_Main mainReport = new rpt_Main(rp);
                    mainReport.ShowDialog();
                }
                else if (tendot.Equals("Dời-BT"))
                {
                    reportValues rpt = new reportValues(2, _madot);
                    rpt.ShowDialog();
                }
                else if (tendot.Equals("Dời"))
                {
                    ReportDocument rp = new rpt_DanhSachHSTC_DOI();
                    rp.SetDataSource(DAL.C_KH_DotThiCong.BC_DanhSachDotThiCong_OC(_madot));
                    rpt_Main mainReport = new rpt_Main(rp);
                    mainReport.ShowDialog();
                }
                else
                {
                    reportValues rpt = new reportValues(1, _madot);
                    rpt.ShowDialog();
                }  
            }
            catch (Exception ex)
            {
                log.Error("In danh sach dot thi cong " + ex.Message);
            }
        }

        private void dataGridViewDotTC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewDotTC.CurrentCell.OwningColumn.Name == "thaotac")
                {
                    string _shs = dataGridViewDotTC.Rows[dataGridViewDotTC.CurrentRow.Index].Cells["SHS"].Value + "";
                    if (MessageBox.Show(this, "Có Muốn Hủy Hồ Sơ " + _shs + " Không ?", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DAL.C_KH_HoSoKhachHang.HuyDotTC(_shs);
                        loadDataGrid();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void dataGridViewDotTC_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                txtKeypress = e.Control;
                if (dataGridViewDotTC.CurrentCell.OwningColumn.Name == "STT")
                {
                    txtKeypress.KeyPress -= KeyPressHandle;
                    txtKeypress.KeyPress += KeyPressHandle;
                }
                else
                {
                    txtKeypress.KeyPress -= KeyPressHandle;
                }
            }
            catch (Exception)
            {
            }
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewDotTC.Rows.Count; i++) { 
                string shs = dataGridViewDotTC.Rows[i].Cells["SHS"].Value+"";
                string stt = dataGridViewDotTC.Rows[i].Cells["STT"].Value + "";
                double n_tlmt = 0;
                double n_tongcong = 0;
                try
                {
                    n_tlmt = double.Parse(dataGridViewDotTC.Rows[i].Cells["gridTLMD"].Value + "");
                }
                catch (Exception)
                {
                }
                try
                {
                    n_tongcong = double.Parse(dataGridViewDotTC.Rows[i].Cells["gridGiaTriSauThue"].Value + "");
                }
                catch (Exception)
                {
                }
                string sql = " UPDATE KH_HOSOKHACHHANG SET TONGIATRI='" + n_tongcong + "',TAILAPMATDUONG='" + n_tlmt + "' WHERE SHS='" + shs + "'";
                DAL.LinQConnection.ExecuteCommand_(sql);
                if (!"".Equals(stt)) {
                    try
                    {
                        DAL.C_KH_DotThiCong.UpdateSTT(shs, int.Parse(stt));
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            loadDataGrid();
        }
    }
}
