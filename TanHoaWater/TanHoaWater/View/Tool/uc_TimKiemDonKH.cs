using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;
using log4net;

namespace TanHoaWater.View.Tool
{
    public partial class uc_TimKiemDonKH : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(uc_TimKiemDonKH).Name);
        public uc_TimKiemDonKH()
        {
            InitializeComponent();
        }

        private void uc_TimKiemDonKH_Load(object sender, EventArgs e)
        {
           
        }
        public void refesh() { 
            //this.SearchMaHoSo.Text="";
            //this.searchHoTenKH.Text="";
            //this.searchDiaChi.Text = "";          
            this.SearchMaHoSo.Focus();
            DataTable table = DAL.C_TimKiemDonKhachHang.TimBienNhan("13", null,null,0,0);
            this.dataGridView1.DataSource = table;
            clearText();
            this.groupBox1.Visible = false;
        }
        string title ="";
        string ngaytrongai = "";
        string noidungtrongai = "";
       
        void search() {
            try
            {
                rows = DAL.C_TimKiemDonKhachHang.TotalRecord(this.SearchMaHoSo.Text, this.searchHoTenKH.Text, this.searchDiaChi.Text);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            PageTotal();

            DataTable table = DAL.C_TimKiemDonKhachHang.TimBienNhan(this.SearchMaHoSo.Text, this.searchHoTenKH.Text, this.searchDiaChi.Text, FirstRow, pageSize);
            this.dataGridView1.DataSource = table;
            Utilities.DataGridV.formatRows(dataGridView1);
            if (table.Rows.Count <= 0) {
                MessageBox.Show(this, "Không Tìm Thấy Thông Tin Khách Hàng !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refesh();
            }
            if (table.Rows.Count == 1)
            {
                try
                {
                    clearText();
                    this.txtNgayNhanHS.Text = dataGridView1.Rows[0].Cells["NGAYNHAN"].Value + "";
                    this.txtLoaiHS.Text = dataGridView1.Rows[0].Cells["LOAIHS"].Value + "";
                    this.txtNgayNhanHS.Text = dataGridView1.Rows[0].Cells["NGAYNHAN"].Value + "";
                    this.txtLoaiHS.Text = dataGridView1.Rows[0].Cells["LOAIHS"].Value + "";
                    DON_KHACHHANG donkh = DAL.C_DonKhachHang.searchTimKiemDon(dataGridView1.Rows[0].Cells["g_SoHoSo"].Value + "");
                    if (donkh != null)
                    {
                        this.DotNhanDon.Text = donkh.MADOT;
                        this.NgayLenDotNhanDon.Text = Utilities.DateToString.NgayVNVN(donkh.CREATEDATE.Value);
                        if (donkh.NGAYCHUYEN_HOSO != null)
                        {
                            this.txtNgayGiaoTTK.Text = Utilities.DateToString.NgayVNVN(donkh.NGAYCHUYEN_HOSO.Value);
                            TOTHIETKE ttk = DAL.C_ToThietKe.findBySHS(donkh.SHS);
                            if (ttk != null)
                            {
                                if (ttk.SODOVIEN != null)
                                {
                                    this.SoDoVienTK.Text = DAL.C_USERS.findByUserName(ttk.SODOVIEN).FULLNAME;
                                    this.txtNgayGiaoSDV.Text = ttk.NGAYGIAOSDV != null ? Utilities.DateToString.NgayVNVN(ttk.NGAYGIAOSDV.Value) : "";
                                    if (ttk.TRONGAITHIETKE == true)
                                    {
                                        title = "HỒ SƠ TRỞ NGẠI THIẾT KẾ";
                                        noidungtrongai = ttk.NOIDUNGTRONGAI;
                                    }
                                    else
                                    {

                                        BG_KHOILUONGXDCB xdcb = DAL.C_KhoiLuongXDCB.findBySHS(donkh.SHS);
                                        if (xdcb != null)
                                        {
                                            NgayLapBG.Text = xdcb.CREATEDATE != null ? Utilities.DateToString.NgayVNVN(xdcb.CREATEDATE.Value) : "";
                                            SoTienDong.Text = String.Format("{0:0,0.00}", xdcb.TONGIATRI != null ? xdcb.TONGIATRI : 0.0);
                                            NgayTrinhKyGD.Text = ttk.NGAYTKGD != null ? Utilities.DateToString.NgayVNVN(ttk.NGAYTKGD.Value) : "";
                                            NgayHoanTat.Text = ttk.NGAYHOANTATTK != null ? Utilities.DateToString.NgayVNVN(ttk.NGAYHOANTATTK.Value) : "";
                                            NgayTraHoSoKH.Text = ttk.NGAYTRAHS != null ? Utilities.DateToString.NgayVNVN(ttk.NGAYTRAHS.Value) : "";
                                            KH_HOSOKHACHHANG hoskh = DAL.C_KH_HoSoKhachHang.findBySHS(donkh.SHS);
                                            if (hoskh != null)
                                            {
                                                if (hoskh.MADOTDD != null)
                                                {
                                                    KH_XINPHEPDAODUONG xiphep = DAL.C_KH_XinPhepDD.finbyMaDot(hoskh.MADOTDD);
                                                    DotXinPhepDD.Text = xiphep.MAQUANLY;
                                                    NgayXinPhepDD.Text = Utilities.DateToString.NgayVNVN(xiphep.NGAYLAP.Value);
                                                    NgayCoPhep.Text = xiphep.NGAYCOPHEP != null ? Utilities.DateToString.NgayVNVN(xiphep.NGAYCOPHEP.Value) : "";
                                                }
                                                else
                                                {
                                                    title = "HỒ SƠ CHƯA LÊN ĐỢT <br/> ĐÀO ĐƯỜNG";
                                                }
                                                if (hoskh.MADOTTC != null)
                                                {
                                                    KH_DOTTHICONG dotc = DAL.C_KH_DotThiCong.findByMadot(hoskh.MADOTTC);
                                                    DotThiCong.Text = dotc.MADOTTC;
                                                    NgayLenDotTC.Text = Utilities.DateToString.NgayVNVN(dotc.NGAYLAP.Value);

                                                }
                                                else
                                                {
                                                    title = "HỒ SƠ CHƯA LÊN ĐỢT <br/> THI CÔNG";
                                                }
                                                NgayThiCong.Text = hoskh.NGAYTHICONG != null ? Utilities.DateToString.NgayVNVN(hoskh.NGAYTHICONG.Value) : "";
                                                NgayHoanCong.Text = hoskh.NGAYHOANCONG != null ? Utilities.DateToString.NgayVNVN(hoskh.NGAYHOANCONG.Value) : "";
                                                ChoDanhBo.Text = hoskh.DHN_NGAYCHOSODB != null ? Utilities.DateToString.NgayVNVN(hoskh.DHN_NGAYCHOSODB.Value) : "";
                                                if (hoskh.DHN_NGAYCHOSODB != null) {
                                                    title = "HỒ SƠ ĐÃ HOÀN TẤT";
                                                }
                                                if (hoskh.NGAYHOANCONG != null)
                                                {
                                                    title = "HỒ CHƯA CHO DANH BỘ.";
                                                }
                                                if (hoskh.TRONGAI == true)
                                                {
                                                    title = "HỒ SƠ TRỞ NGẠI THI CÔNG";
                                                    noidungtrongai = hoskh.NOIDUNGTN;
                                                }
                                            }
                                            else {
                                                title = "HỒ SƠ CHƯA LÊN ĐỢT <br/> ĐÀO ĐƯỜNG";
                                            }
                                        }
                                        else
                                        {
                                            title = "HỒ SƠ CHƯA CHẠY BẢNG GIÁ.";
                                        }
                                    }

                                }
                                else
                                {
                                    title = "CHƯA GIAO HỒ SƠ <br/>CHO SƠ ĐỒ VIÊN";
                                }
                            }
                            else
                            {
                                title = "TỔ THIẾT KẾ KHÔNG NHẬN HỒ SƠ NÀY.";
                            }

                        }
                        else
                        {
                            title = "HỒ SƠ CHƯA CHUYỂN <br/> TỔ THIẾT KẾ";
                        }
                    }
                    else
                    {
                        title = "CHƯA LÊN ĐỢT NHẬN ĐƠN <br/> CHUYỂN TỔ THIẾT KẾ";
                    }
                    // this.txtDotND.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value+"";
                    //this.txtShs.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value + "";
                    //this.txtSoHoSo.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value + "";
                    //this.txtHoTen.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value + "";
                    //this.txtdiachi.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value + "";
                    //this.txtSoDT.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value + "";
                    //this.txtLoaiKH.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value + "";
                    //this.txtLoaiHS.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value + "";
                    //this.txtNgayNhanHS.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value + "";
                    //ngaygiaoTTK = dataGridView1.Rows[e.RowIndex].Cells[11].Value + "";
                    //this.txtNgayGiaoTTK.Text = ngaygiaoTTK;
                    //ngaygiaoSDV = DAL.C_USERS.findByUserName(dataGridView1.Rows[e.RowIndex].Cells[12].Value + "").FULLNAME;
                    //this.SoDoVienTK.Text = ngaygiaoSDV;
                    //ngaytringky = dataGridView1.Rows[e.RowIndex].Cells[13].Value + "";
                    //this.NgayTrinhKyGD.Text = ngaytringky;
                    //trongaiTK = dataGridView1.Rows[e.RowIndex].Cells[15].Value + "";
                    //noidungTK = dataGridView1.Rows[e.RowIndex].Cells[16].Value + "";
                    //result();
                    groupBox1.Visible = true;
                    if (title.Contains("HỒ SƠ TRỞ NGẠI"))
                    {
                        this.lbresult.ForeColor = Color.Red;
                        this.lbresult.Text = title;
                        this.resultNoiDung.Text = noidungtrongai;
                    }
                    else
                    {
                        this.lbresult.ForeColor = Color.Blue;
                        this.lbresult.Text = title;
                    }
                }
                catch (Exception ex)
                {
                    log.Error("Tim Bien Nhan Loi" + ex.Message);
                }
            }   
        }
        private void btSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            Utilities.DataGridV.formatRows(dataGridView1);
        }
       
        void clearText()
        {
            this.txtNgayNhanHS.Text = "";
            this.txtLoaiHS.Text = "";
            this.txtNgayNhanHS.Text = "";
            this.txtLoaiHS.Text = "";
            this.DotNhanDon.Text = "";
            this.NgayLenDotNhanDon.Text = "";
            this.txtNgayGiaoTTK.Text = "";
            this.SoDoVienTK.Text = "";
            this.txtNgayGiaoSDV.Text = "";
            NgayLapBG.Text = "";
            SoTienDong.Text = "";
            NgayTrinhKyGD.Text = "";
            NgayHoanTat.Text = "";
            NgayTraHoSoKH.Text = "";
            DotXinPhepDD.Text = "";
            NgayXinPhepDD.Text = "";
            NgayCoPhep.Text = "";
            DotThiCong.Text = "";
            NgayLenDotTC.Text = "";
            NgayThiCong.Text = "";
            NgayHoanCong.Text = "";
            ChoDanhBo.Text = "";
            title = "";
            ngaytrongai = "";
            noidungtrongai = "";
            this.resultNoiDung.Text = "";
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                clearText();
                groupBox1.Visible = true;
                this.txtNgayNhanHS.Text = dataGridView1.Rows[e.RowIndex].Cells["NGAYNHAN"].Value + "";
                this.txtLoaiHS.Text = dataGridView1.Rows[e.RowIndex].Cells["LOAIHS"].Value + "";
                this.txtNgayNhanHS.Text = dataGridView1.Rows[e.RowIndex].Cells["NGAYNHAN"].Value + "";
                this.txtLoaiHS.Text = dataGridView1.Rows[e.RowIndex].Cells["LOAIHS"].Value + "";
                DON_KHACHHANG donkh = DAL.C_DonKhachHang.searchTimKiemDon(dataGridView1.Rows[e.RowIndex].Cells["g_SoHoSo"].Value + "");
                if (donkh != null)
                {
                    this.DotNhanDon.Text = donkh.MADOT;
                    this.NgayLenDotNhanDon.Text = Utilities.DateToString.NgayVNVN(donkh.CREATEDATE.Value);
                    if (donkh.NGAYCHUYEN_HOSO != null)
                    {
                        this.txtNgayGiaoTTK.Text = Utilities.DateToString.NgayVNVN(donkh.NGAYCHUYEN_HOSO.Value);
                        TOTHIETKE ttk = DAL.C_ToThietKe.findBySHS(donkh.SHS);
                        if (ttk != null)
                        {
                            if (ttk.SODOVIEN != null)
                            {
                                this.SoDoVienTK.Text = DAL.C_USERS.findByUserName(ttk.SODOVIEN).FULLNAME;
                                this.txtNgayGiaoSDV.Text = ttk.NGAYGIAOSDV != null ? Utilities.DateToString.NgayVNVN(ttk.NGAYGIAOSDV.Value) : "";
                                if (ttk.TRONGAITHIETKE == true)
                                {
                                    title = "HỒ SƠ TRỞ NGẠI THIẾT KẾ";
                                    noidungtrongai = ttk.NOIDUNGTRONGAI;
                                }
                                else
                                {

                                    BG_KHOILUONGXDCB xdcb = DAL.C_KhoiLuongXDCB.findBySHS(donkh.SHS);
                                    if (xdcb != null)
                                    {
                                        NgayLapBG.Text = xdcb.CREATEDATE != null ? Utilities.DateToString.NgayVNVN(xdcb.CREATEDATE.Value) : "";
                                        SoTienDong.Text = String.Format("{0:0,0.00}", xdcb.TONGIATRI != null ? xdcb.TONGIATRI : 0.0);
                                        NgayTrinhKyGD.Text = ttk.NGAYTKGD != null ? Utilities.DateToString.NgayVNVN(ttk.NGAYTKGD.Value) : "";
                                        NgayHoanTat.Text = ttk.NGAYHOANTATTK != null ? Utilities.DateToString.NgayVNVN(ttk.NGAYHOANTATTK.Value) : "";
                                        NgayTraHoSoKH.Text = ttk.NGAYTRAHS != null ? Utilities.DateToString.NgayVNVN(ttk.NGAYTRAHS.Value) : "";
                                        KH_HOSOKHACHHANG hoskh = DAL.C_KH_HoSoKhachHang.findBySHS(donkh.SHS);
                                        if (hoskh != null)
                                        {
                                            if (hoskh.MADOTDD != null)
                                            {
                                                KH_XINPHEPDAODUONG xiphep = DAL.C_KH_XinPhepDD.finbyMaDot(hoskh.MADOTDD);
                                                DotXinPhepDD.Text = xiphep.MAQUANLY;
                                                NgayXinPhepDD.Text = Utilities.DateToString.NgayVNVN(xiphep.NGAYLAP.Value);
                                                NgayCoPhep.Text = xiphep.NGAYCOPHEP != null ? Utilities.DateToString.NgayVNVN(xiphep.NGAYCOPHEP.Value) : "";
                                            }
                                            else
                                            {
                                                title = "HỒ SƠ CHƯA LÊN ĐỢT <br/> ĐÀO ĐƯỜNG";
                                            }
                                            if (hoskh.MADOTTC != null)
                                            {
                                                KH_DOTTHICONG dotc = DAL.C_KH_DotThiCong.findByMadot(hoskh.MADOTTC);
                                                DotThiCong.Text = dotc.MADOTTC;
                                                NgayLenDotTC.Text = Utilities.DateToString.NgayVNVN(dotc.NGAYLAP.Value);

                                            }
                                            else
                                            {
                                                title = "HỒ SƠ CHƯA LÊN ĐỢT <br/> THI CÔNG";
                                            }
                                            NgayThiCong.Text = hoskh.NGAYTHICONG != null ? Utilities.DateToString.NgayVNVN(hoskh.NGAYTHICONG.Value) : "";
                                            NgayHoanCong.Text = hoskh.NGAYHOANCONG != null ? Utilities.DateToString.NgayVNVN(hoskh.NGAYHOANCONG.Value) : "";
                                            ChoDanhBo.Text = hoskh.DHN_NGAYCHOSODB != null ? Utilities.DateToString.NgayVNVN(hoskh.DHN_NGAYCHOSODB.Value) : "";
                                            title = "HỒ SƠ ĐÃ HOÀN CÔNG";
                                            if (hoskh.TRONGAI == true)
                                            {
                                                title = "HỒ SƠ TRỞ NGẠI THI CÔNG";
                                                noidungtrongai = hoskh.NOIDUNGTN;
                                            }
                                        }
                                        else
                                        {
                                            title = "HỒ SƠ CHƯA LÊN ĐỢT <br/> ĐÀO ĐƯỜNG";
                                        }
                                    }
                                    else
                                    {
                                        title = "HỒ SƠ CHƯA CHẠY BẢNG GIÁ.";
                                    }
                                }

                            }
                            else
                            {
                                title = "CHƯA GIAO HỒ SƠ <br/>CHO SƠ ĐỒ VIÊN";
                            }
                        }
                        else
                        {
                            title = "TỔ THIẾT KẾ KHÔNG NHẬN HỒ SƠ NÀY.";
                        }

                    }
                    else
                    {
                        title = "HỒ SƠ CHƯA CHUYỂN <br/> TỔ THIẾT KẾ";
                    }
                }
                else
                {
                    title = "CHƯA LÊN ĐỢT NHẬN ĐƠN <br/> CHUYỂN TỔ THIẾT KẾ";
                }
                // this.txtDotND.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value+"";
                //this.txtShs.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value + "";
                //this.txtSoHoSo.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value + "";
                //this.txtHoTen.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value + "";
                //this.txtdiachi.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value + "";
                //this.txtSoDT.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value + "";
                //this.txtLoaiKH.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value + "";
                //this.txtLoaiHS.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value + "";
                //this.txtNgayNhanHS.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value + "";
                //ngaygiaoTTK = dataGridView1.Rows[e.RowIndex].Cells[11].Value + "";
                //this.txtNgayGiaoTTK.Text = ngaygiaoTTK;
                //ngaygiaoSDV = DAL.C_USERS.findByUserName(dataGridView1.Rows[e.RowIndex].Cells[12].Value + "").FULLNAME;
                //this.SoDoVienTK.Text = ngaygiaoSDV;
                //ngaytringky = dataGridView1.Rows[e.RowIndex].Cells[13].Value + "";
                //this.NgayTrinhKyGD.Text = ngaytringky;
                //trongaiTK = dataGridView1.Rows[e.RowIndex].Cells[15].Value + "";
                //noidungTK = dataGridView1.Rows[e.RowIndex].Cells[16].Value + "";
                //result();
                groupBox1.Visible = true;
                if (title.Contains("HỒ SƠ TRỞ NGẠI"))
                {
                    this.lbresult.ForeColor = Color.Red;
                    this.lbresult.Text = title;
                    this.resultNoiDung.Text = noidungtrongai;
                }
                else
                {
                    this.lbresult.ForeColor = Color.Blue;
                    this.lbresult.Text = title;
                }
            }
            catch (Exception)
            {
                
            } 


        }

        private void SearchMaHoSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                search();
            }
        }

        private void searchHoTenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                search();
            }
        }

        private void searchDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                search();
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            refesh();
        }
        //public void result() {
          
        //    groupBox1.Visible = true;
        //    if ("True".Equals(trongaiTK)) {
        //        lbresult.Text = "HỒ SƠ TRỞ NGẠI THIẾT KẾ";
        //        lbresult.ForeColor = Color.Red;
        //        resultNoiDung.Text = noidungTK;
        //    } else {
        //        lbresult.ForeColor = Color.Blue;
        //        if (!"".Equals(ngaytringky))
        //        {
        //            lbresult.Text = "HỒ SƠ ĐANG HOÀN THÀNH ";
        //            resultNoiDung.Text = "Hồ Sơ Trình Ký Ban Giám Đốc";
        //        }
        //        else if (!"".Equals(ngaygiaoTTK))
        //        {
        //            lbresult.Text = "HỒ SƠ ĐANG HOÀN THÀNH ";
        //            resultNoiDung.Text = "Hồ Sơ Đang Khảo Sát Thiết Kế";
        //        }
        //        else {
        //            lbresult.Text = "HỒ SƠ ĐANG HOÀN THÀNH ";
        //            resultNoiDung.Text = "Hồ Sơ Chưa Chuyển Tồ Thiết Kế";
        //        }
                    
        //        //string ngaygiaoTTK = "";
        //        //string ngaygiaoSDV = "";
        //        //string ngaytringky = "";
        //    }
        
        //}

        int currentPageIndex = 1;
        int pageSize = 18;
        int pageNumber = 0;
        int FirstRow, LastRow;
        int rows;

        private void next_Click(object sender, EventArgs e)
        {
            if (currentPageIndex < pageNumber)
            {
                currentPageIndex = currentPageIndex + 1;
                FirstRow = pageSize * (currentPageIndex - 1);
                LastRow = pageSize * (currentPageIndex);
                PageTotal();
                search();
            }

        }
        private void PageTotal()
        {
            try
            {
                pageNumber = rows % pageSize != 0 ? rows / pageSize + 1 : rows / pageSize;
                lbPaing.Text = currentPageIndex + "/" + pageNumber;
            }
            catch (Exception ex)
            {
                log.Error(ex); ;
            }

        }
        private void pre(object sender, EventArgs e)
        {
            try
            {
                if (currentPageIndex > 1)
                {
                    currentPageIndex = currentPageIndex - 1;
                    FirstRow = pageSize * (currentPageIndex - 1);
                    LastRow = pageSize * (currentPageIndex);
                    PageTotal();
                    search();
                }
            }
            catch (Exception)
            {

            }

        }

    
    
    }
}
