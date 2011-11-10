using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using TanHoaWater.Database;

namespace TanHoaWater.View.Users.KEHOACH.DOTTHICONG
{
    public partial class tab_DonViTCTLMD : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_DonViTCTLMD).Name);
        string id_TC = "";
        string id_TLMD = "";
        public tab_DonViTCTLMD()
        {
            InitializeComponent();
            fromLoad();
        }
        public void fromLoad() {
            this.dotc_GridList.DataSource = DAL.C_KH_DonViTC.getDonViThiCong();
            this.tlmd_GridList.DataSource = DAL.C_KH_DonViTC.getDonViTaiLap();
            this.donvigiamsat.DataSource = DAL.C_KH_DotThiCong.DonViGiamSat();
            this.dottc_NgayKyhd.ValueObject = DateTime.Now.Date;
            this.tlmd_ngaykyhd.ValueObject = DateTime.Now.Date;
        }
        public void addDonVITC(){
            string tencty = this.dottc_tencongty.Text;
            string sohop = this.dotc_sohopdong.Text;
            if ("".Equals(tencty)) {
                MessageBox.Show(this, "Nhập Tên Công Ty Đơn Vị Thi Công.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dottc_tencongty.Focus();
            }
            else if ("".Equals(sohop))
            {
                MessageBox.Show(this, "Nhập Số Hợp Đồng Công Ty Thi Công.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dotc_sohopdong.Focus();
            }
            else {
                try
                {
                    KH_DONVITHICONG dovtc = new KH_DONVITHICONG();
                    dovtc.TENCONGTY = tencty;
                    dovtc.SOHOPDONG = sohop;
                    dovtc.NGAYKYHD = this.dottc_NgayKyhd.Value.Date;
                    dovtc.XOA = false;
                    dovtc.CREATEDATE = DateTime.Now;
                    dovtc.CREATEBY = DAL.C_USERS._userName;
                    DAL.C_KH_DonViTC.AddDonViTC(dovtc);
                    this.dotc_GridList.DataSource = DAL.C_KH_DonViTC.getDonViThiCong();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Thêm Đơn Vị Thi Công Bị Lỗi.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("" + ex.Message);
                }
                

            }
        }

        public void addDonVITLMD()
        {
            string tencty = this.tlmd_tencongty.Text;
            string sohop = this.tlmd_sohopdong.Text;
            if ("".Equals(tencty))
            {
                MessageBox.Show(this, "Nhập Tên Công Ty Đơn Vị Tái Lập ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.tlmd_tencongty.Focus();
            }
            else if ("".Equals(sohop))
            {
                MessageBox.Show(this, "Nhập Số Hợp Đồng Công Ty Đơn Vị Tái Lập.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.tlmd_sohopdong.Focus();
            }
            else
            {
                try
                {
                    KH_DONVITAILAP dovtc = new KH_DONVITAILAP();
                    dovtc.TENCONGTY = tencty;
                    dovtc.SOHOPDONG = sohop;
                    dovtc.NGAYKYHD = this.dottc_NgayKyhd.Value.Date;
                    dovtc.XOA = false;
                    dovtc.CREATEDATE = DateTime.Now;
                    dovtc.CREATEBY = DAL.C_USERS._userName;
                    DAL.C_KH_DonViTC.AddDonViTLMD(dovtc);
                    this.tlmd_GridList.DataSource = DAL.C_KH_DonViTC.getDonViTaiLap();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Thêm Đơn Vị Thi Công Bị Lỗi.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("" + ex.Message);
                }
            }
        }

        public void DeleteDonVITC()
        {
            if (!"".Equals(id_TC))
            {
                try
                {
                    KH_DONVITHICONG dvtc = DAL.C_KH_DonViTC.findDVTCbyID(int.Parse(id_TC));
                    if (dvtc != null)
                    {
                        dvtc.XOA = true;
                        DAL.C_KH_DonViTC.Update();
                    }
                    MessageBox.Show(this, "Đã Xóa Đơn Vị Thi Công.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    log.Error("Xoa Don Vi TC Loi " + ex.Message);
                    MessageBox.Show(this, "Xóa Đơn Vị Thi Công Bị Lỗi.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.dotc_GridList.DataSource = DAL.C_KH_DonViTC.getDonViThiCong();
            }
        }

        public void DeleteDonVITLMD()
        {
            if (!"".Equals(id_TLMD))
            {
                try
                {
                    KH_DONVITAILAP dvtc = DAL.C_KH_DonViTC.findDVTLbyID(int.Parse(id_TLMD));
                    if (dvtc != null)
                    {
                        dvtc.XOA = true;
                        DAL.C_KH_DonViTC.Update();
                    }
                    MessageBox.Show(this, "Đã Xóa Đơn Vị Thi Công.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    log.Error("Xoa Don Vi TC Loi " + ex.Message);
                    MessageBox.Show(this, "Xóa Đơn Vị Thi Công Bị Lỗi.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.tlmd_GridList.DataSource = DAL.C_KH_DonViTC.getDonViTaiLap();
            }
        }

        private void dotc_GridList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id_TC = dotc_GridList.Rows[e.RowIndex].Cells["tc_ID"].Value + "";
                this.dottc_tencongty.Text = dotc_GridList.Rows[e.RowIndex].Cells["TC_TENCONGTY"].Value + "";
                this.dotc_sohopdong.Text = dotc_GridList.Rows[e.RowIndex].Cells["TC_SOHOPDONG"].Value + "";
                this.dottc_NgayKyhd.ValueObject = dotc_GridList.Rows[e.RowIndex].Cells["tc_ngaykyhd"].Value;
            }
            catch (Exception)
            {
                 
            }
            
        }

        private void tlmd_GridList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id_TLMD = tlmd_GridList.Rows[e.RowIndex].Cells["TL_ID"].Value + "";
                this.tlmd_tencongty.Text = tlmd_GridList.Rows[e.RowIndex].Cells["TL_TENCONGTY"].Value + "";
                this.tlmd_sohopdong.Text = tlmd_GridList.Rows[e.RowIndex].Cells["TL_SOHOPDONG"].Value + "";
                this.tlmd_ngaykyhd.ValueObject = tlmd_GridList.Rows[e.RowIndex].Cells["TL_NGAYKYHD"].Value;
            }
            catch (Exception)
            {

            }
        }

        private void dottc_btThemMoi_Click(object sender, EventArgs e)
        {
            addDonVITC();
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            addDonVITLMD();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            DeleteDonVITLMD();
        }

        private void dottc_btXoa_Click(object sender, EventArgs e)
        {
            DeleteDonVITC();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.textBoxX1.Text.Equals("")){
                    MessageBox.Show(this, "Nhập Tên Đơn Vị Giám Sát Thi Công. ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.textBoxX1.Focus();
                }else{
                    KH_DONVIGIAMSAT dovgs = new KH_DONVIGIAMSAT();
                    dovgs.TENDONVI = this.textBoxX1.Text;
                    DAL.C_KH_DonViTC.AddDonViGiamSat(dovgs);
                    this.donvigiamsat.DataSource = DAL.C_KH_DotThiCong.DonViGiamSat();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Thêm Đơn Vị Giám Sát Thi Công Bị Lỗi.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("" + ex.Message);
            }
            
        }
    }
}
