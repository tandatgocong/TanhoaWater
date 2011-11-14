using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using TanHoaWater.View.Users.HOANCONG.BC;
using CrystalDecisions.CrystalReports.Engine;
using TanHoaWater.View.Users.KEHOACH.HOANCONG.BC;
using TanHoaWater.View.Users.Report;

namespace TanHoaWater.View.Users.KEHOACH.HOANCONG
{
    public partial class tab_TroNgaiHoanCong : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_DanhSachHoanCong).Name);
        public tab_TroNgaiHoanCong(string madottc)
        {
            InitializeComponent();
            cbDotHoanCong.DataSource = DAL.C_KH_DotThiCong.getListDTC();
            cbDotHoanCong.DisplayMember = "MADOTTC";
            cbDotHoanCong.ValueMember = "MADOTTC";
            try
            {
                gridHoanCong.DataSource = DAL.C_KH_HoanCong.getListHoanCongTroNgai(madottc, -1);
            }
            catch (Exception)
            {
                
            }
            
        }
        public void loadData() { 
        
        }

        private void checkChuaHoanCong_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                gridHoanCong.DataSource = DAL.C_KH_HoanCong.getListHoanCongTroNgai(this.cbDotHoanCong.Text, -1);
            }
            catch (Exception)
            {

            }
        }

        private void chekDaHoanCong_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                gridHoanCong.DataSource = DAL.C_KH_HoanCong.getListHoanCongTroNgai(this.cbDotHoanCong.Text, 1);
            }
            catch (Exception)
            {

            }
        }

        private void checkALl_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                gridHoanCong.DataSource = DAL.C_KH_HoanCong.getListHoanCongTroNgai(this.cbDotHoanCong.Text, 0);
            }
            catch (Exception)
            {

            }
        }

        private void cbDotHoanCong_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               if(checkALl.Checked)
                   gridHoanCong.DataSource = DAL.C_KH_HoanCong.getListHoanCongTroNgai(this.cbDotHoanCong.Text, 0);
               else if(checkChuaHoanCong.Checked)
                   gridHoanCong.DataSource = DAL.C_KH_HoanCong.getListHoanCongTroNgai(this.cbDotHoanCong.Text, -1);
               else if (chekDaHoanCong.Checked)
                   gridHoanCong.DataSource = DAL.C_KH_HoanCong.getListHoanCongTroNgai(this.cbDotHoanCong.Text, 1);

            }
            catch (Exception)
            {

            }
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

        bool flag = true;
        void updateDulieu() {
            try
            {
                for (int i = 0; i < gridHoanCong.Rows.Count; i++)
                {
                    string ngaytc = "";
                    string chiso = "";
                    string shs = this.gridHoanCong.Rows[i].Cells["hc_SHS"].Value + "";
                    string tn = this.gridHoanCong.Rows[i].Cells["hc_trongai"].Value + "";
                    string noidung = this.gridHoanCong.Rows[i].Cells["hc_noidungtrongai"].Value + "";
                    bool TroNgai = false;
                    try
                    {
                        TroNgai = bool.Parse(tn);
                    }
                    catch (Exception)
                    {
                    }
                    
                        DAL.C_KH_HoanCong.TroNgai(shs,TroNgai,noidung);
                    }
                //DAL.C_KH_HoanCong.CapNhat();
            }
            catch (Exception ex)
            {
                log.Error("Loi Hoan Tat Hoan Cong" + ex.Message);
            }
            
        }

        private void btHoanTat_Click(object sender, EventArgs e)
        {
            updateDulieu();
           
          
        }

        public string getSHS() {
            string result="";
            for (int i = 0; i < gridHoanCong.Rows.Count; i++)
            {
                string shs = this.gridHoanCong.Rows[i].Cells["hc_SHS"].Value + "";
                string chonin = this.gridHoanCong.Rows[i].Cells["hc_ChonIn"].Value + "";
                if ("True".Equals(chonin))
                    result += "'" + shs + "',";
            }
            if (result.Length > 0)
                result = result.Substring(0, result.Length - 1);
            return result;
        }
        private void btTachChiPhi_Click(object sender, EventArgs e)
        {
            if (getSHS().Equals(""))
                MessageBox.Show(this, "Cần Chọn Hồ Sơ In", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                frmDialogPrintting frm = new frmDialogPrintting(getSHS());
                frm.ShowDialog();
            }
        }

        private void btInBangKe_Click(object sender, EventArgs e)
        {
            if (getSHS().Equals(""))
                MessageBox.Show(this, "Cần Chọn Hồ Sơ In", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                ReportDocument rp = new rpt_HoanCong();
                rp.SetDataSource(DAL.C_KH_HoanCong.BC_HOANCONG(this.cbDotHoanCong.Text));
                rpt_Main rpt = new rpt_Main(rp);
                rpt.ShowDialog();
            }
           
        }

        private void gridHoanCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridHoanCong_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridHoanCong_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridHoanCong_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }
    }
}
