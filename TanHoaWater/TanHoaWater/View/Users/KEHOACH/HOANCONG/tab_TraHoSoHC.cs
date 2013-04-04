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
using TanHoaWater.Database;
namespace TanHoaWater.View.Users.KEHOACH.HOANCONG
{
    public partial class tab_TraHoSoHC : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_DanhSachHoanCong).Name);
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        KH_DOTTHICONG dottc = null;
        public tab_TraHoSoHC()
        {

            InitializeComponent();
            List<KH_DOTTHICONG> list = DAL.C_KH_DotThiCong.getListDTC();
            foreach (var item in list)
            {
                namesCollection.Add(item.MADOTTC);
            }
            cbDotTC.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbDotTC.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbDotTC.AutoCompleteCustomSource = namesCollection;
            try
            {
                gridHoanCong.DataSource = DAL.C_KH_HoanCong.getListHoanCong(DAL.C_KH_DotThiCong.__dotthicong, 0);
                lbHoanCong.Text = "Tổng cộng có " + gridHoanCong.Rows.Count + " hồ sơ Hoàn Công";
            }
            catch (Exception)
            {
            }
            dottc = DAL.C_KH_DotThiCong.findByMadot(DAL.C_KH_DotThiCong.__dotthicong);
            if (dottc != null)
            {
                this.dateNgayChuyenHC.ValueObject = dottc.NGAYCHUYENHC;
                this.txtGhiChuHoanCong.Text = dottc.GHICHUHC;
                this.txtTon.Text = dottc.CONLAI_TLK != null ? dottc.CONLAI_TLK + "" : "0";
                this.txtSoLuong.Text = dottc.SOLUONG_HCTLK != null ? dottc.SOLUONG_HCTLK + "" : "0";
                if (dottc.QUYETTOAN == true)
                    this.txtQuetToan.Checked = true;
                else
                    this.txtQuetToan.Checked = false;
               
            }
            cbDotTC.Text = DAL.C_KH_DotThiCong.__dotthicong;
        }

        private void cbDotTC_Leave(object sender, EventArgs e)
        {
            try
            {
                gridHoanCong.DataSource = DAL.C_KH_HoanCong.getListHoanCong(this.cbDotTC.Text, 0);
                lbHoanCong.Text = "Tổng cộng có " + gridHoanCong.Rows.Count + " hồ sơ Hoàn Công";
                DAL.C_KH_DotThiCong.__dotthicong = this.cbDotTC.Text;
                dottc = DAL.C_KH_DotThiCong.findByMadot(DAL.C_KH_DotThiCong.__dotthicong);
                if (dottc != null)
                {
                    this.dateNgayChuyenHC.ValueObject = dottc.NGAYCHUYENHC;
                    this.txtGhiChuHoanCong.Text = dottc.GHICHUHC;
                    this.txtTon.Text = dottc.CONLAI_TLK != null ? dottc.CONLAI_TLK + "" : "0";
                    this.txtSoLuong.Text = dottc.SOLUONG_HCTLK != null ? dottc.SOLUONG_HCTLK + "" : "0";
                    if (dottc.QUYETTOAN == true)
                        this.txtQuetToan.Checked = true;
                    else
                        this.txtQuetToan.Checked = false;

                }
            }
            catch (Exception)
            {

            }
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            if (dottc != null) {
                if (!"1/1/0001".Equals(this.dateNgayChuyenHC.Value.ToShortDateString()))
                {
                    dottc.NGAYCHUYENHC = dateNgayChuyenHC.Value.Date;
                }
                if (!"".Equals(txtGhiChuHoanCong.Text))
                {
                    dottc.GHICHUHC = txtGhiChuHoanCong.Text;
                }
                if (!"".Equals(txtSoLuong.Text))
                {
                    dottc.SOLUONG_HCTLK = int.Parse(txtSoLuong.Text);
                }
                if (!"".Equals(txtTon.Text))
                {
                    dottc.CONLAI_TLK = int.Parse(txtTon.Text);
                }
                bool quyettoan = false;
                if (this.txtQuetToan.Checked)
                    quyettoan = true;
                else
                    quyettoan = false;
                dottc.QUYETTOAN = quyettoan;
                if (DAL.C_KH_DotThiCong.UpdateDotTC(dottc) == false)
                        MessageBox.Show(this, "Cập Nhật Thông Tin Không Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show(this, "Cập Nhật Thông Tin Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}