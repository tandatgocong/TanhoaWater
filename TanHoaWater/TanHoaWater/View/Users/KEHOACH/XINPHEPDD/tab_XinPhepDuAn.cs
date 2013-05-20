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
using TanHoaWater.View.Users.KEHOACH.XINPHEPDD.BC;
using log4net;

namespace TanHoaWater.View.Users.KEHOACH.XINPHEPDD
{
    public partial class tab_XinPhepDuAn : UserControl
    {
        DateTime _ngaylap = DateTime.Now.Date;
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_CapNhatTheoDot).Name);
        KH_XINPHEPDAODUONG xinphep = null;
        public tab_XinPhepDuAn(string madot, DateTime ngaylap)
        {
            InitializeComponent();


            this.cbMaDotDuAn.DataSource = DAL.C_KH_XinPhepDD.ListAllXinPhepDD();
            this.cbMaDotDuAn.ValueMember = "MADOT";
            this.cbMaDotDuAn.DisplayMember = "MADOT";
            cbMaDotDuAn.Text = madot;
            xinphep = DAL.C_KH_XinPhepDD.finbyMaDot(madot);
            loadDataGrid(this.cbMaDotDuAn.SelectedValue.ToString());
            _ngaylap = ngaylap;
            try
            {
                cbDonViTaiLap.DataSource = DAL.C_KH_DonViTC.getDonViTaiLap();
                cbDonViTaiLap.DisplayMember = "TENCONGTY";
                cbDonViTaiLap.ValueMember = "TENCONGTY";
            }
            catch (Exception)
            {


            }


            //this.cbMaDotDuAn.DataSource = DAL.C_KH_XinPhepDD.ListAllXinPhepDD();
            //this.cbMaDotDuAn.ValueMember = "MADOT";
            //this.cbMaDotDuAn.DisplayMember = "MADOT";
            //cbMaDotDuAn.Text = madot;
            //xinphep = DAL.C_KH_XinPhepDD.finbyMaDot(madot);
            //loadDataGrid(this.cbMaDotDuAn.SelectedValue.ToString());
            //_ngaylap = ngaylap;
            //try
            //{
            //    cbDonViTaiLap.DataSource = DAL.C_KH_DonViTC.getDonViTaiLap();
            //    cbDonViTaiLap.DisplayMember = "TENCONGTY";
            //    cbDonViTaiLap.ValueMember = "TENCONGTY";
            //}
            //catch (Exception)
            //{
            //}

            //this.pd_MaKetCau.DataSource = DAL.LinQConnection.getDataTable("SELECT MADANHMUC , (MADANHMUC + ' ______ '+   UPPER(TENKETCAU) ) as 'TENKETCAU' FROM KH_XINPHEPDAODUONG_KETCAU ");
            //this.pd_MaKetCau.ValueMember = "MADANHMUC";
            //this.pd_MaKetCau.DisplayMember = "TENKETCAU";
            //this.pd_MaKetCau.DropDownWidth = 300;
            
        }

        private void checkLayBangGia_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkLayBangGia.Checked)
            //{
            //    this.GridViewPhuiDao.Visible = true;
            //}
            //else {
            //    this.GridViewPhuiDao.Visible = false;
            //}
        }

        private void txtMaSHS_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                DataTable table = DAL.C_KH_XinPhepDD.findByHSHT(this.txtMaSHS.Text);
                this.txtGhiChu.Text = this.txtMaSHS.Text;
                if (table.Rows.Count <= 0)
                {
                  
               
                }
                else
                {
                    string _shs = table.Rows[0][0].ToString();
                    //if (DAL.C_KH_XinPhepDD.getListBCPhuiDao(_shs).Count <= 0)
                    //{

                    //    DAL.C_KH_XinPhepDD.getPhuiDao(_shs);
                    //    DAL.C_KH_XinPhepDD.TinhPhuiDao(_shs);
                    //    GridViewPhuiDao.DataSource = DAL.C_KH_XinPhepDD.getListBCPhuiDao(_shs);
                    //}
                    //else {
                    //    GridViewPhuiDao.DataSource = DAL.C_KH_XinPhepDD.getListBCPhuiDao(_shs);
                    //}
                    //DAL.LinQConnection.ExecuteCommand_("DELETE FROM KH_BAOCAOPHUIDAO WHERE SHS='" + _shs + "'");
                    //DAL.C_KH_XinPhepDD.getPhuiDao(_shs);
                    //DAL.C_KH_XinPhepDD.TinhPhuiDao(_shs);
                    //GridViewPhuiDao.DataSource = DAL.C_KH_XinPhepDD.getListBCPhuiDao(_shs);

                    if ("DD".Contains(_shs))
                    {
                        cbMucDichDD.SelectedIndex = 1;
                    }
                    else
                    {
                        cbMucDichDD.SelectedIndex = 0;
                    }
                    cbPhuongPhapDao.SelectedIndex = 0;
                    try
                    {
                        KH_HOSOKHACHHANG kh_sh = DAL.C_KH_HoSoKhachHang.findBySHS(this.txtMaSHS.Text);
                        if (kh_sh != null)
                        {
                            if (kh_sh.MADOTTC != null || !"".Equals(kh_sh.MADOTTC + ""))
                            {
                                KH_DOTTHICONG dottc = DAL.C_KH_DotThiCong.findByMadot(kh_sh.MADOTTC);
                                this.cbDonViTaiLap.Text = DAL.C_KH_DonViTC.findDVTLbyID(dottc.DONVITAILAP.Value).TENCONGTY;
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                    /* Ko tìm bảng vẽ
                     try
                     {
                         if (xinphep != null) {
                             if (xinphep.MAQUANLY.Contains("QTP"))
                             {
                                 if (Utilities.Files.CheckFile(_shs) == false) {
                                     MessageBox.Show(this,"Không Tìm Thấy File Bảng Vẽ Kỹ Thuật.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                 }
                             }
                         }
                     }
                     catch (Exception)
                     {
                        
                     }
                     * */
                    this.txtHoTen.Text = table.Rows[0][1].ToString();
                    this.txtDiaChi.Text = table.Rows[0][2].ToString();
                    this.txtGhiChu.Text = table.Rows[0][0].ToString();
                    this.txtGhiChu.Focus();
                }
            }
        }
        public void Refresh()
        {
            txtMaSHS.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGhiChu.Text = "";
            txtMaSHS.Focus();
        }

        public void loadDataGrid(string sodot) {
            DataTable table = DAL.C_KH_HoSoKhachHang.getListHSbyDot(sodot); 
            this.gridXiPhepDD.DataSource = table;
            this.lbTongHoSo.Text = "Tổng Số Hồ Sơ XPĐĐ: " + table.Rows.Count + " hồ sơ.";
        }

        public void UpdatePhuiDao() {
            for (int i = 0; i < GridPhuiDao.Rows.Count; i++)
              {
                  try
                  {
                      KH_BAOCAOPHUIDAO phui = new KH_BAOCAOPHUIDAO();
                      phui.SHS = this.txtMaSHS.Text;
                      phui.MADANHMUC = (GridPhuiDao.Rows[i].Cells["pd_MaKetCau"].Value + "");
                      phui.TENKETCAU = (GridPhuiDao.Rows[i].Cells["phuidao_tenketcau"].Value + "");
                      phui.DAI = "";
                      phui.RONG = "";
                      phui.SAU = "";
                      phui.KICHTHUOC = (GridPhuiDao.Rows[i].Cells["phuikichthuoc"].Value + "");
                      DAL.C_KH_XinPhepDD.InsertPhuiDao(phui);
                  }
                  catch (Exception ex)
                  {
                      log.Error("Loi Cap Nhat Phui Dao " + ex.Message);
                  }
              }
             
        }
        public void add() {
            try
            {
                InsertDonKhachHang();
                if ("".Equals(this.cbMaDotDuAn.Text))
                {
                    MessageBox.Show(this, "Chọn Mã Đợt Xin Phép Đào Đường ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.cbMaDotDuAn.Select();
                }
                else if ("".Equals(this.txtMaSHS.Text))
                {
                    MessageBox.Show(this, "Nhập Số Số Hồ Sơ ! ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtMaSHS.Focus();
                }
                else
                {

                    KH_HOSOKHACHHANG kh_sh = DAL.C_KH_HoSoKhachHang.findBySHS(this.txtMaSHS.Text);
                    if (kh_sh == null)
                    {
                        kh_sh = new KH_HOSOKHACHHANG();
                        kh_sh.SHS = this.txtMaSHS.Text;
                        kh_sh.MADOTDD = this.cbMaDotDuAn.Text;
                        kh_sh.NGAYNHAN = _ngaylap;
                        kh_sh.GHICHU = this.txtGhiChu.Text;
                        kh_sh.CREATEBY = DAL.C_USERS._userName;
                        kh_sh.CREATEDATE = DateTime.Now.Date;
                        if (DAL.C_KH_HoSoKhachHang.Insert(kh_sh) == false)
                        {// co roi do len dot thi cong truoc
                            MessageBox.Show(this, "Thêm Hồ Sơ Xin Phép Bị lỗi, Hoặc Đã Xin Phép Rồi !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.txtMaSHS.Focus();
                        }
                    }
                    else
                    {
                        if (kh_sh.MADOTDD != null || !"".Equals(kh_sh.MADOTDD + ""))
                        {
                            if (MessageBox.Show(this, "Hồ Sơ Đã Lên Đợt Xin Phép Đào Đường.", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                kh_sh.MADOTDD = this.cbMaDotDuAn.Text;
                                kh_sh.MUCDICHDD = this.cbMucDichDD.Text;
                                kh_sh.PHUONGPHAPDD = this.cbPhuongPhapDao.Text;
                                kh_sh.DVITAILAPDD = this.cbDonViTaiLap.Text;
                                kh_sh.NGAYNHAN = _ngaylap;
                                DAL.C_KH_HoSoKhachHang.Update();
                            }
                        }
                        else
                        {
                            kh_sh.MADOTDD = this.cbMaDotDuAn.Text;
                            kh_sh.MUCDICHDD = this.cbMucDichDD.Text;
                            kh_sh.PHUONGPHAPDD = this.cbPhuongPhapDao.Text;
                            kh_sh.DVITAILAPDD = this.cbDonViTaiLap.Text;
                            kh_sh.NGAYNHAN = _ngaylap;
                            DAL.C_KH_HoSoKhachHang.Update();
                        }

                    }

                    DAL.LinQConnection.ExecuteCommand_("DELETE FROM KH_BAOCAOPHUIDAO WHERE SHS='" + this.txtMaSHS.Text + "'");
                    UpdatePhuiDao();
                  
                 
                    loadDataGrid(this.cbMaDotDuAn.Text);
                    Refresh();
                    try
                    {
                        //this.txtMaSHS.Text = (int.Parse(txtMaSHS.Text) + 1)+"";
                    }
                    catch (Exception)
                    {
                        
                    }
                    
                }
            }
            catch (Exception ex)
            {
                log.Error("Cap Nhat Xin Phep Dao Duong Loi " + ex.Message);
            }
            
        }

        private void txtGhiChu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                add();
                Refresh();
            }
        }

        private void cbMaDot_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                loadDataGrid(this.cbMaDotDuAn.SelectedValue.ToString());
            }
            catch (Exception)
            {
            }
            
        }
        bool flag = false;
        private void GridViewPhuiDao_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            flag = true;
        }
        private void gridXiPhepDD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (gridXiPhepDD.CurrentCell.OwningColumn.Name == "thaotac")
                {
                    string _shs = gridXiPhepDD.Rows[gridXiPhepDD.CurrentRow.Index].Cells["gridMaHS"].Value + "";
                    if (MessageBox.Show(this, "Có Muốn Hủy Hồ Sơ " + _shs + " Không ?", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DAL.C_KH_HoSoKhachHang.HuyDaoDuong(_shs);
                        loadDataGrid(this.cbMaDotDuAn.Text);
                    }
                }
                //if (gridXiPhepDD.CurrentCell.OwningColumn.Name == "gridMaHS")
                //{
                //    string _shs = gridXiPhepDD.Rows[gridXiPhepDD.CurrentRow.Index].Cells["gridMaHS"].Value + "";
                //    if (MessageBox.Show(this, "Có Muốn Hủy Hồ Sơ " + _shs + " Không ?", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //    {
                //        DAL.C_KH_HoSoKhachHang.HuyDaoDuong(_shs);
                //        loadDataGrid(this.cbMaDot.Text);
                //    }
                //}
            }
            catch (Exception)
            {
                 
            }
            
        }


        private void inDanhSachCoPhep_Click(object sender, EventArgs e)
        {
            string madot = this.cbMaDotDuAn.Text;
            ReportDocument rp = new rpt_XinPhep();
            rp.SetDataSource(DAL.C_KH_XinPhepDD.ReportxinPhepDD(madot, "", "", "", ""));

            rpt_Main mainreport = new rpt_Main(rp);
            mainreport.ShowDialog();
        }

        private void btInDanhSachMienPhep_Click(object sender, EventArgs e)
        {
            string madot = this.cbMaDotDuAn.Text;
            frmDialogPrintting frm = new frmDialogPrintting(madot);
            frm.ShowDialog();
        }

        public void InsertDonKhachHang() { 
        
                    DON_KHACHHANG donKH = new DON_KHACHHANG();
                    donKH.MADOT = "HSDUAN";
                    donKH.SOHOSO = this.txtMaSHS.Text;
                    donKH.SHS = this.txtMaSHS.Text;
                    donKH.TAPTHE = true;                 
                    donKH.HOTEN = this.txtHoTen.Text;
                    donKH.DIENTHOAI ="";
                    donKH.SOHO = 1;
                    donKH.SONHA = "";
                    donKH.TINHKHOAN = true;
                    donKH.LOAIMIENPHI = "Mặt tiền";
                    donKH.DUONG = txtDiaChi.Text;
                    donKH.PHUONG = "01";
                    donKH.QUAN = 23;                    
                    donKH.LOAIKH = "CT";
                    donKH.LOAIHOSO = "CT";
                    donKH.GHICHU = "";                   
                    donKH.NGAYNHAN = DateTime.Now.Date;
                    donKH.HOPDONG = "";
                    donKH.CREATEBY = DAL.C_USERS._userName;
                    donKH.CREATEDATE = DateTime.Now;
                    DAL.C_DonKhachHang.InsertDonHK(donKH);
        }
        public void InsertHoSoKhachHang()
        {

        }
        private void btThem_Click(object sender, EventArgs e)
        {
            add();
        }
       

       
        
        private void btExport_Click(object sender, EventArgs e)
        {
            if (xinphep != null)
            {
                if (xinphep.MAQUANLY.Contains("QTP"))
                {
                    frm_Export frm = new frm_Export(this.cbMaDotDuAn.Text);
                    frm.ShowDialog();
                }
                else
                {

                    MessageBox.Show(this, "Chỉ lấy bảng vẽ của Q. Tân Phú.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
            
        }

        private void GridPhuiDao_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (GridPhuiDao.CurrentCell.OwningColumn.Name == "pd_MaKetCau")
            {

                KH_XINPHEPDAODUONG_KETCAU dmvt = DAL.C_DanhMucTaiLapMD.finbyMaDM_XPDD(GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells["pd_MaKetCau"].Value + "");
                if (dmvt != null)
                {
                    GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells["phuidao_tenketcau"].Value = dmvt.TENKETCAU.ToUpper();
                    //GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells["Phui_DonGia"].Value = dmvt.DONGIA;
                    //GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells["phuidao_dvt"].Value = dmvt.DVT;
                    //if (mahieuvt.Equals("TNHA"))
                    //{
                    //    GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells["phuidao_Daii"].Value = this.txtSoHo.Value;
                    //}
                }
                //else
                //{
                //    MessageBox.Show(this, "Không Tìm Thấy Mã Kết Cấu.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    GridPhuiDao.Rows[GridPhuiDao.CurrentRow.Index].Cells["pd_MaKetCau"].Selected = true;
                //    return;
                //}
                //Utilities.DataGridV.formatRows(GridPhuiDao);
            }
        }

       
    }
}
