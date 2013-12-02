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
    public partial class tab_CapNhatDanhSachBoSung : UserControl
    {
        string _madot="";
        public tab_CapNhatDanhSachBoSung(string madot)
        {
            InitializeComponent();
            this.cbCoTLK.Items.Add("15");
            this.cbCoTLK.Items.Add("25");
            this.cbCoTLK.Items.Add("40");
            this.cbCoTLK.Items.Add("50");
            this.cbCoTLK.Items.Add("80");
            this.cbCoTLK.Items.Add("100");
            this.cbCoTLK.Items.Add("150");
            this.cbCoTLK.Items.Add("200");
            this.cbCoTLK.SelectedIndex = 0;
            lbDotTc.Text = "ĐỢT THI CÔNG : " + madot.ToUpper();
            _madot = madot;
           
            this.txtSHS.Focus();
            cbSoLan.SelectedIndex = 0;
            KH_DOTTHICONG dottc = DAL.C_KH_DotThiCong.findByMadot(madot);
            if (dottc != null) {
                this.txtCanCu1.Text = "Căn cứ biên bản hiện trường ngày             của "+ DAL.C_KH_DonViTC.findDVTCbyID(int.Parse(dottc.DONVITHICONG + "")).TENCONGTY;;
            }
            this.txtCanCu2.Text = "Căn cứ phiếu tái nhập kho số ";
            // 
            loadDataGrid();
        }
        public void refesh(){
            this.txtSHS.Text = "";
            this.txtHoTenKH.Text = "";
            this.txtDiaChi.Text = "";
            this.txtPhuong.Text = "";
            this.txtQuan.Text = "";
            this.cbCoTLK.Text = "15";
            this.dateNgayDongTien.ValueObject = null;
            this.txtSoHoaDon.Text = "";
            this.txtSoTien.Text = "";
            this.txtTaiLapMĐ.Text = "";
            this.txtTinhTrangTLK.Text = "";
            this.txtSoDanhBo.Text = "";
            this.txtSHS.Focus();
        }
        public void DongTien() {
            if (!"".Equals(this.txtSoHoaDon.Text) && !"1/1/0001".Equals(this.dateNgayDongTien.Value.ToShortDateString()))
            {
                if (!"".Equals(this.txtSoHoaDon.Text) && !"1/1/0001".Equals(this.dateNgayDongTien.Value.ToShortDateString()))
                {
                    double sotien = 0;
                    try
                    {
                        sotien = double.Parse(this.txtSoTien.Text);
                    }
                    catch (Exception)
                    {
                    }


                    DAL.C_DonKhachHang.DongTienKH(this.txtSHS.Text, this.dateNgayDongTien.Value.Date, this.txtSoHoaDon.Text, this.txtSoDanhBo.Text, sotien, this.txtTinhTrangTLK.Text);
                };
            }
        }
        bool flag = true;
       public void add()
        {
            try
            {
                if ("".Equals(this.txtSHS.Text))
                {
                    MessageBox.Show(this, "Số Hồ Sơ Không Được Trống", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtSHS.Focus();
                }
                else
                {
                    KH_HOSOKHACHHANG_BS dottc = new KH_HOSOKHACHHANG_BS();
                    dottc.SHS = this.txtSHS.Text;
                    dottc.MADOTTC = _madot;
                    dottc.LANBOSUNG = int.Parse(this.cbSoLan.Text);
                    dottc.SOHOADON = this.txtSoHoaDon.Text;
                    try
                    {
                        dottc.TAILAPMATDUONG = double.Parse(this.txtTaiLapMĐ.Text);
                        dottc.TONGIATRI = double.Parse(this.txtSoTien.Text);
                    }
                    catch (Exception)
                    {

                    }

                    try
                    {
                        if (!"".Equals(this.txtSoHoaDon.Text) && !"1/1/0001".Equals(this.dateNgayDongTien.Value.ToShortDateString()))
                        {

                            dottc.NGAYDONGTIEN = dateNgayDongTien.Value.Date;
                        }
                    }
                    catch (Exception)
                    {
                        
                    }
                    if (DAL.C_KH_DotThiCong.InsertDotTC_BS(dottc) == false)
                    {
                        MessageBox.Show(this, "Lỗi Thêm Đợt Thi Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                   
                }
      
            }
            catch (Exception ex)
            {
                log.Error("add ho so kh -> ke hoach khLoi" + ex.Message);
            }
            
            loadDataGrid();
        }
     public void loadDataGrid()
     {
         dataGridViewDotTC.DataSource = DAL.C_KH_DotThiCong.getListDotThiCong_BS(_madot,cbSoLan.Text );
         Utilities.DataGridV.formatSoHoSo(dataGridViewDotTC);
         lbTongHoSo.Text = "Tổng Số Có " + dataGridViewDotTC.Rows.Count + " Hồ Sơ";
     }
        private void txtSHS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                flag = true;
                DataTable table = DAL.C_KH_DotThiCong.findByHSHT(this.txtSHS.Text);
                if (table.Rows.Count <= 0)
                {
                    MessageBox.Show(this, "Không Tìm Thấy Hồ Sơ Hoàn Tất Thiết Kế !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
                else
                {
                    this.txtHoTenKH.Text = table.Rows[0][2].ToString();
                    this.txtDiaChi.Text = table.Rows[0][3].ToString();
                    this.txtPhuong.Text = table.Rows[0][4].ToString();
                    this.txtQuan.Text = table.Rows[0][5].ToString();
                    this.dateNgayDongTien.ValueObject = table.Rows[0][6];
                    this.txtSoHoaDon.Text = table.Rows[0][7].ToString();
                    BG_KHOILUONGXDCB xdcb = DAL.C_KhoiLuongXDCB.findBySHS(this.txtSHS.Text.Trim());
                    if (xdcb != null)
                    {

                        this.txtTaiLapMĐ.Text = String.Format("{0:0,0}", xdcb.TAILAPMATDUONG).Replace(",", "");
                        this.txtSoTien.Text = String.Format("{0:0,0}", xdcb.TONGIATRI).Replace(",", "");

                    }
                }
            }
        }

        private void btThemMoiHoSo_Click(object sender, EventArgs e)
        {
            refesh();
        }

        private void btLuuHoSo_Click(object sender, EventArgs e)
        {
            add();
            refesh();
            this.txtSHS.Focus();
        }
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_CapNhatDanhSachND).Name);
        private void btPrint_Click(object sender, EventArgs e)
        {
            string ngaytk = "";
          //  KH_DOTTHICONG dotc = DAL.C_KH_DotThiCong.findByMadot(madot);
            ngaytk = "Ngày " + DateTime.Now.Date.Day + " tháng " + DateTime.Now.Date.Month + " năm " + DateTime.Now.Date.Year;
            
            string tendot = "GẮN MỚI";
            
            if (_madot.Contains("D"))
                tendot = "DỜI";
            else if  (_madot.Contains("BT"))
                tendot = "BỒI THƯỜNG";
                

            ReportDocument rp = new rpt_DanhSachHSTC_BOSUNG();
            rp.SetDataSource(DAL.C_KH_DotThiCong.BC_DanhSachDotThiCong_BS(_madot,cbSoLan.Text));
            rp.SetParameterValue("bs", cbSoLan.Text);
            rp.SetParameterValue("cc1", this.txtCanCu1.Text);
            rp.SetParameterValue("cc2", this.txtCanCu2.Text);
            rp.SetParameterValue("ngaytk", ngaytk);
            rp.SetParameterValue("tendot", tendot);
            

            rpt_Main mainReport = new rpt_Main(rp);
            mainReport.ShowDialog();
            
            
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
                        DAL.LinQConnection.ExecuteCommand_("DELETE FROM KH_HOSOKHACHHANG_BS WHERE SHS=N'" + _shs + "' AND LANBOSUNG=" + cbSoLan.Text);
                        loadDataGrid();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

       

        private void txtSoDanhBo_Leave_1(object sender, EventArgs e)
        {
            if (flag == true)
            {
                add();
                refesh();
                this.txtSHS.Focus();
            }
        }

        private void cbSoLan_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDataGrid();
        }
    }
}
