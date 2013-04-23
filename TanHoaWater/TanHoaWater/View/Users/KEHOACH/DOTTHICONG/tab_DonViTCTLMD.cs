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
        string id_GS= "";
        public tab_DonViTCTLMD()
        {
            InitializeComponent();
            fromLoad();
        }
        public void fromLoad() {
            this.dotc_GridList.DataSource = DAL.C_KH_DonViTC.getDonViThiCong();
            this.tlmd_GridList.DataSource = DAL.C_KH_DonViTC.getDonViTaiLap();
            this.donvigiamsat.DataSource = DAL.C_KH_DotThiCong.DonViGiamSat();
            this.gridDonViGiamSatTL.DataSource = DAL.C_KH_DonViTC.getDonViGiamSatTL();
            this.dottc_NgayKyhd.ValueObject = DateTime.Now.Date;
            this.tlmd_ngaykyhd.ValueObject = DateTime.Now.Date;
        }
        public void addDonVITC(){
            string tencty = this.dottc_tencongty.Text;
            string sohop = this.dotc_sohopdong.Text;
            if ("".Equals(tencty)) {
                MessageBox.Show(this, "Nhập Tên Đơn Vị Thi Công.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(this, "Nhập Tên Đơn Vị Tái Lập ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.tlmd_tencongty.Focus();
            }
            else if ("".Equals(sohop))
            {
                MessageBox.Show(this, "Nhập Số Hợp Đồng Đơn Vị Tái Lập.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void addDonVIGIAMSATTL()
        {
            string tencty = this.gstl_TenCTy.Text;
            string sohop = this.gstl_HopDong.Text;
            if ("".Equals(tencty))
            {
                MessageBox.Show(this, "Nhập Tên Đơn Vị Giám Sát Tái Lập ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.gstl_TenCTy.Focus();
            }
            else if ("".Equals(sohop))
            {
                MessageBox.Show(this, "Nhập Số Hợp Đồng Đơn Vị Giám Sát Tái Lập.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.gstl_HopDong.Focus();
            }
            else
            {
                try
                {
                    KH_DONVIGIAMSATTL dovtc = new KH_DONVIGIAMSATTL();
                    dovtc.TENCONGTY = tencty;
                    dovtc.SOHOPDONG = sohop;
                    dovtc.NGAYKYHD = this.dottc_NgayKyhd.Value.Date;
                    dovtc.XOA = false;
                    dovtc.CREATEDATE = DateTime.Now;
                    dovtc.CREATEBY = DAL.C_USERS._userName;
                    DAL.C_KH_DonViTC.AddDonViGiamSatTL(dovtc);
                    this.gridDonViGiamSatTL.DataSource = DAL.C_KH_DonViTC.getDonViGiamSatTL();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Thêm Đơn Vị Đơn Vị Tái Lập Lỗi.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("" + ex.Message);
                }
            }
        }


        /// <summary>
        /// update
        /// </summary>
        public void UpdateDonVITC()
        {
            string tencty = this.dottc_tencongty.Text;
            string sohop = this.dotc_sohopdong.Text;
            if ("".Equals(tencty))
            {
                MessageBox.Show(this, "Nhập Tên Đơn Vị Thi Công.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dottc_tencongty.Focus();
            }
            else if ("".Equals(sohop))
            {
                MessageBox.Show(this, "Nhập Số Hợp Đồng Công Ty Thi Công.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dotc_sohopdong.Focus();
            }
            else
            {
                try
                {
                    KH_DONVITHICONG dovtc = DAL.C_KH_DonViTC.findDVTCbyID(int.Parse(id_TC));
                    if (dovtc != null)
                    {
                        dovtc.TENCONGTY = tencty;
                        dovtc.SOHOPDONG = sohop;
                        dovtc.NGAYKYHD = this.dottc_NgayKyhd.Value.Date;
                        dovtc.XOA = false;
                        dovtc.MODIFYDATE = DateTime.Now;
                        dovtc.MODIFYBY = DAL.C_USERS._userName;
                        DAL.C_KH_DonViTC.Update();
                        this.dotc_GridList.DataSource = DAL.C_KH_DonViTC.getDonViThiCong();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Cập Hồ Sơ Đơn Vị Thi Công Bị Lỗi.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("" + ex.Message);
                }


            }
        }

        public void UpdateDonVITLMD()
        {
            string tencty = this.tlmd_tencongty.Text;
            string sohop = this.tlmd_sohopdong.Text;
            if ("".Equals(tencty))
            {
                MessageBox.Show(this, "Nhập Tên Đơn Vị Tái Lập ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.tlmd_tencongty.Focus();
            }
            else if ("".Equals(sohop))
            {
                MessageBox.Show(this, "Nhập Số Hợp Đồng Đơn Vị Tái Lập.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.tlmd_sohopdong.Focus();
            }
            else
            {
                try
                {
                    KH_DONVITAILAP dovtc = DAL.C_KH_DonViTC.findDVTLbyID(int.Parse(id_TLMD));
                    if (dovtc != null)
                    {
                        dovtc.TENCONGTY = tencty;
                        dovtc.SOHOPDONG = sohop;
                        dovtc.NGAYKYHD = this.dottc_NgayKyhd.Value.Date;
                        dovtc.XOA = false;
                        dovtc.MODIFYDATE = DateTime.Now;
                        dovtc.MODIFYBY = DAL.C_USERS._userName;
                        DAL.C_KH_DonViTC.Update();
                        this.tlmd_GridList.DataSource = DAL.C_KH_DonViTC.getDonViTaiLap();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Cập Nhật Đơn Vị Tái Lập Bị Lỗi.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("" + ex.Message);
                }
            }
        }

        public void UpdateDonVIGIAMSATTL()
        {
            string tencty = this.gstl_TenCTy.Text;
            string sohop = this.gstl_HopDong.Text;
            if ("".Equals(tencty))
            {
                MessageBox.Show(this, "Nhập Tên Đơn Vị Giám Sát Tái Lập ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.gstl_TenCTy.Focus();
            }
            else if ("".Equals(sohop))
            {
                MessageBox.Show(this, "Nhập Số Hợp Đồng Đơn Vị Giám Sát Tái Lập.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.gstl_HopDong.Focus();
            }
            else
            {
                try
                {
                    KH_DONVIGIAMSATTL dovtc = DAL.C_KH_DonViTC.findDVGSTCbyID(int.Parse(id_GS));
                    if (dovtc != null)
                    {
                        dovtc.TENCONGTY = tencty;
                        dovtc.SOHOPDONG = sohop;
                        dovtc.NGAYKYHD = this.dottc_NgayKyhd.Value.Date;
                        dovtc.XOA = false;
                        dovtc.MODIFYDATE = DateTime.Now;
                        dovtc.MODIFYBY = DAL.C_USERS._userName;
                        DAL.C_KH_DonViTC.Update();
                        this.gridDonViGiamSatTL.DataSource = DAL.C_KH_DonViTC.getDonViGiamSatTL();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Thêm Đơn Vị Giám Sát Thi Công Lỗi.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if(this.txtDonGiamSatTC.Text.Equals("")){
                    MessageBox.Show(this, "Nhập Tên Đơn Vị Giám Sát Thi Công. ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtDonGiamSatTC.Focus();
                }else{
                    KH_DONVIGIAMSAT dovgs = new KH_DONVIGIAMSAT();
                    dovgs.TENDONVI = this.txtDonGiamSatTC.Text;
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

        private void dotc_btCapNhat_Click(object sender, EventArgs e)
        {
            UpdateDonVITC();
        }

        private void gstl_ThemMoi_Click(object sender, EventArgs e)
        {
            addDonVIGIAMSATTL();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            UpdateDonVITLMD();
        }

        private void gstl_CapNhat_Click(object sender, EventArgs e)
        {
            UpdateDonVIGIAMSATTL();
        }

        private void gridDonViGiamSatTL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id_GS = gridDonViGiamSatTL.Rows[e.RowIndex].Cells["gs_ID"].Value + "";
                this.gstl_TenCTy.Text = gridDonViGiamSatTL.Rows[e.RowIndex].Cells["gs_TENCTY"].Value + "";
                this.gstl_HopDong.Text = gridDonViGiamSatTL.Rows[e.RowIndex].Cells["gs_HOPDONG"].Value + "";
                this.gstl_NgayKyHD.ValueObject = gridDonViGiamSatTL.Rows[e.RowIndex].Cells["gs_NGAYKY"].Value;
                
            }
            catch (Exception)
            {

            }
        }

        private void gstl_Xoa_Click(object sender, EventArgs e)
        {
            if (!"".Equals(id_GS))
            {
                try
                {
                    KH_DONVIGIAMSATTL dvtc = DAL.C_KH_DonViTC.findDVGSTCbyID(int.Parse(id_GS));
                    if (dvtc != null)
                    {
                        dvtc.XOA = true;
                        DAL.C_KH_DonViTC.Update();
                    }
                    MessageBox.Show(this, "Đã Xóa Đơn Vị Giám Sát Tái Lập Thành Công.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    log.Error("Xoa Don Vi TC Loi " + ex.Message);
                    MessageBox.Show(this, "Xóa Đơn Vị Giám Sát Tái Lập Bị Lỗi.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.gridDonViGiamSatTL.DataSource = DAL.C_KH_DonViTC.getDonViGiamSatTL();
            }
        }

        string id_donvigiamsattc = "";
        private void btCapNhat_Click(object sender, EventArgs e)
        {
            string donvigs = this.txtDonGiamSatTC.Text;
            if ("".Equals(donvigs))
            {
                MessageBox.Show(this, "Nhập Tên Đơn Vị Giám Sát ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dottc_tencongty.Focus();
            }
            
            else
            {
                try
                {
                    KH_DONVIGIAMSAT dovtc = DAL.C_KH_DonViTC.findDVGiamSatID(int.Parse(id_donvigiamsattc));
                    if (dovtc != null)
                    {
                        dovtc.TENDONVI = donvigs;
                        DAL.C_KH_DonViTC.Update();
                    
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Cập Hồ Sơ Đơn Vị Thi Công Bị Lỗi.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("" + ex.Message);
                }

                this.donvigiamsat.DataSource = DAL.LinQConnection.getDataTable("SELECT * FROM KH_DONVIGIAMSAT ORDER BY ID DESC");
            }
        }

        private void donvigiamsat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id_donvigiamsattc = donvigiamsat.Rows[e.RowIndex].Cells["gstcID"].Value + "";
                this.txtDonGiamSatTC.Text = donvigiamsat.Rows[e.RowIndex].Cells["gstcdv"].Value + "";
              
            }
            catch (Exception)
            {

            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.LinQConnection.ExecuteCommand_("DELETE FROM KH_DONVIGIAMSAT WHERE ID='" + id_donvigiamsattc + "'");
                this.donvigiamsat.DataSource = DAL.LinQConnection.getDataTable("SELECT * FROM KH_DONVIGIAMSAT ORDER BY ID DESC");
                
            }
            catch (Exception)
            {
            }
           
            
        }
    }
}
