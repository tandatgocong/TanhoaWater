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
    public partial class tab_DSKHHoangCongTcy : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_DanhSachHoanCong).Name);
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        KH_DOTTHICONG dottc = null;
        public tab_DSKHHoangCongTcy()
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
            //try
            //{
            //    gridHoanCong.DataSource = DAL.C_KH_HoanCong.getListHoanCong(DAL.C_KH_DotThiCong.__dotthicong, 0);
            //    lbHoanCong.Text = "Tổng cộng có " + gridHoanCong.Rows.Count + " hồ sơ Hoàn Công";
            //}
            //catch (Exception)
            //{
            //}
            //dottc = DAL.C_KH_DotThiCong.findByMadot(DAL.C_KH_DotThiCong.__dotthicong);
            //if (dottc != null)
            //{
            //    this.dateNgayChuyenHC.ValueObject = dottc.NGAYCHUYENHC;
            //    this.txtGhiChuHoanCong.Text = dottc.GHICHUHC;
            //    this.txtTon.Text = dottc.CONLAI_TLK != null ? dottc.CONLAI_TLK + "" : "0";
            //    this.txtSoLuong.Text = dottc.SOLUONG_HCTLK != null ? dottc.SOLUONG_HCTLK + "" : "0";
            //    if (dottc.QUYETTOAN == true)
            //        this.txtQuetToan.Checked = true;
            //    else
            //        this.txtQuetToan.Checked = false;

            //}
            //cbDotTC.Text = DAL.C_KH_DotThiCong.__dotthicong;
        }

        private void cbDotTC_Leave(object sender, EventArgs e)
        {
            try
            {
                gridHoanCong.DataSource = DAL.C_KH_HoanCong.getListHoanCong(this.cbDotTC.Text, 0);
            }
            catch (Exception)
            {

            }
        }

        private void btGiaoViec_Click(object sender, EventArgs e)
        {
            try
            {
               
              
                    bool chek = false;
                    for (int i = 0; i < gridHoanCong.RowCount; i++)
                    {
                        if (gridHoanCong["hc_ChonIn", i].Value != null && "True".Equals(gridHoanCong["hc_ChonIn", i].Value.ToString()))
                        {
                            chek = true;
                            string shs = gridHoanCong["hc_SHS", i].Value.ToString();

                            if (dataCopy2.Rows.Count > 0)
                            {
                                DataTable tb = (DataTable)dataCopy2.DataSource;
                                DataTable t2 = DAL.C_KH_HoanCong.getListHoanCong_Cp(shs);
                                tb.Merge(t2);
                                dataCopy2.DataSource = tb;
                            }
                            else {
                                dataCopy2.DataSource = DAL.C_KH_HoanCong.getListHoanCong_Cp(shs);
                            }
                        }
                    }
                    if (chek == false)
                    {
                        MessageBox.Show(this, "Chưa Chọn Hồ Sơ Để Giao Cho Sơ Đồ Viên.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                              
                //else
                //{
                //   // giaoviec();
                //}
            }
            catch (Exception ex)
            {
                log.Error("TTK Giao Viec Loi " + ex.Message);
            }
        }

        private void btHoanTat_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.Export.export(dataCopy2);
            }
            catch (Exception)
            {

                MessageBox.Show(this, "Lỗi Xuất File !");
            }
        }
    }
}