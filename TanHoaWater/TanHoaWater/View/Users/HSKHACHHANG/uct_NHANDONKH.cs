using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;
using TanHoaWater.Class;
using System.Collections;
using log4net;

namespace TanHoaWater.View.Users.HSKHACHHANG
{
    public partial class uct_NHANDONKH : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(uct_NHANDONKH).Name);
        public uct_NHANDONKH()
        {
            InitializeComponent();
            formLoad();
            refresh();
            this.txtSHS.Focus();

        }

        private void txtghichukhan_MouseClick(object sender, MouseEventArgs e)
        {
            this.ghichukhan.Text = null;

        }
        public void formLoad()
        {
            #region Load Quan
            this.cbQuan.DataSource = DAL.C_QUAN.getList();
            this.cbQuan.DisplayMember = "TENQUAN";
            this.cbQuan.ValueMember = "MAQUAN";
            #endregion
            #region Loai HoSo
            this.cbLoaiHS.DataSource = DAL.C_LOAIHOSO.getList();
            this.cbLoaiHS.DisplayMember = "TENLOAI";
            this.cbLoaiHS.ValueMember = "MALOAI";
            #endregion
            #region Loai KhaHang
            this.cbLoaiKH.DataSource = DAL.C_LOAIKH.getList();
            this.cbLoaiKH.DisplayMember = "TENLOAI";
            this.cbLoaiKH.ValueMember = "MALOAI";
            #endregion
            #region Loai Dot Khach Hang
            this.cbDotNhanDon.DataSource = DAL.C_DOTNHANDON.getListtMa_Dot();
            this.cbDotNhanDon.DisplayMember = "TEND";
            this.cbDotNhanDon.ValueMember = "MADOT";          
            #endregion        
           
        }

        private void cbQuan_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int maquan = int.Parse(this.cbQuan.SelectedValue.ToString());
                this.cbPhuong.DataSource = DAL.C_PHUONG.getListByQuan(maquan);
                this.cbPhuong.DisplayMember = "TENPHUONG";
                this.cbPhuong.ValueMember = "MAPHUONG";
            }
            catch (Exception)
            {               
            }
        }

        private void cbPhuong_SelectedValueChanged(object sender, EventArgs e)
        {
            string sohoso = "";
            if (DateTime.Now.Month < 10)
            {
                sohoso = "0" + DateTime.Now.Month.ToString();
            }
            else
            {
                sohoso = DateTime.Now.Month.ToString();
            }
            this.txtSoHoSo.Text = this.cbQuan.SelectedValue + "" + this.cbPhuong.SelectedValue + sohoso+this.txtSHS.Text;
        }

        private void txtSHS_Leave(object sender, EventArgs e)
        {
            string sohoso = "";
            if (DateTime.Now.Month < 10)
            {
                sohoso = "0" + DateTime.Now.Month.ToString();
            }
            else
            {
                sohoso = DateTime.Now.Month.ToString();
            }
            this.txtSoHoSo.Text = this.cbQuan.SelectedValue + "" + this.cbPhuong.SelectedValue + sohoso + this.txtSHS.Text;

        }

        private void cbDotNhanDon_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.errorProvider1.Clear();
                string _madot = this.cbDotNhanDon.SelectedValue.ToString();
                this.dataG.DataSource = DAL.C_DONKHACHHANG.getListbyDot(_madot);
                int sokh = DAL.C_DONKHACHHANG.getListbyDot(_madot).Rows.Count;
                this.totalRecord.Text = "Tống công có " + sokh + " khách hàng đợt nhận đơn " + _madot;
                Utilities.DataGridV.formatRows(dataG);
            }
            catch (Exception )
            {
                 
            }
        }
        public void loadGird() {
            this.dataG.DataSource = DAL.C_DONKHACHHANG.getListbyDot(this.cbDotNhanDon.SelectedValue.ToString());
            Utilities.DataGridV.formatRows(dataG);
        }
        private void btInsert_Click(object sender, EventArgs e)
        {
            if (this.txtSHS.Text.Length < 5) {
                this.errorProvider1.Clear();
                this.errorProvider1.SetError(this.txtSHS,"Số Hồ Sơ Không Hợp Lệ.");
            }else if ("".Equals(this.txtHoTen.Text)) {
                this.errorProvider1.Clear();
                this.errorProvider1.SetError(this.txtHoTen, "Họ Tên Khách Hàng Không Được Trống.");
            }else if ("".Equals(this.sonha.Text)) {
                this.errorProvider1.Clear();
                this.errorProvider1.SetError(this.sonha, "Số Nhà Không Được Trống.");
            }else if ("".Equals(this.duong.Text))
            {
                this.errorProvider1.Clear();
                this.errorProvider1.SetError(this.duong, "Tên Đường Không Được Trống.");
            }
            else if (this.khan.Checked == true){
                this.errorProvider1.Clear();
                if ( "".Equals(this.ghichukhan.Text))
                {
                    this.errorProvider1.SetError(this.ghichukhan, "Ghi Chú Khẩn Không Được Trống.");
                }
            }
            else if (DAL.C_DONKHACHHANG.findBySOHOSO(this.txtSoHoSo.Text)!=null) {
                this.errorProvider1.Clear();
                this.errorProvider1.SetError(this.txtSHS, "Số Hồ Sơ Đã Tồn Tại.");
            }
            else if (DAL.C_DONKHACHHANG.findByAddressAndLoaiHS(this.cbDotNhanDon.SelectedValue.ToString(), this.cbLoaiHS.SelectedValue.ToString(), this.sonha.Text, this.duong.Text, this.cbPhuong.SelectedValue.ToString(), this.cbQuan.SelectedValue.ToString()))
            {
                this.errorProvider1.Clear();
                this.errorProvider1.SetError(this.sonha, "Địa Chỉ Khách Hàng Đã Được Nhận Đơn.");            }
            else
            {
                this.errorProvider1.Clear();
                DON_KHACHHANG donKH = new DON_KHACHHANG();
                donKH.MADOT = this.cbDotNhanDon.SelectedValue.ToString();
                donKH.SOHOSO = this.txtSoHoSo.Text;
                donKH.SHS = this.txtSHS.Text;
                donKH.HOTEN = this.txtHoTen.Text;
                donKH.DIENTHOAI = this.dienthoai.Text;
                donKH.SOHO = int.Parse(this.soho.Value.ToString());
                donKH.SONHA = this.sonha.Text;
                donKH.DUONG = this.duong.Text;
                donKH.PHUONG = this.cbPhuong.SelectedValue.ToString();
                donKH.QUAN = int.Parse(this.cbQuan.SelectedValue.ToString());
                donKH.NGAYNHAN = DateTime.Now;
                donKH.LOAIKH = this.cbLoaiKH.SelectedValue.ToString();
                donKH.LOAIHOSO = this.cbLoaiHS.SelectedValue.ToString();
                donKH.GHICHU = this.ghichu.Text;
                if (this.khan.Checked == true)
                {
                    donKH.HOSOKHAN = true;
                    donKH.GHICHUKHAN = this.ghichukhan.Text;
                }
                DAL.C_DONKHACHHANG.InsertDonHK(donKH);
                loadGird();
            }
        }

        private void khan_CheckedChanged(object sender, EventArgs e)
        {
            if (this.khan.Checked == true)
            {
                this.ghichukhan.Visible = true;
            }
            else
            {
                this.ghichukhan.Visible = false;
            }
        }
        public void refresh() {
            this.txtSHS.Text = null;
            this.txtSHS.Mask = DateTime.Now.Year.ToString().Substring(2) + "00000";
            this.txtHoTen.Text = null;
            this.dienthoai.Text = null;
            this.sonha.Text = null;
            this.duong.Text = null;
            this.txtSoHoSo.Text = null;
            this.errorProvider1.Clear();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void tabItem2_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(new tab_TimKiemDonKH());
        }
    }
}
