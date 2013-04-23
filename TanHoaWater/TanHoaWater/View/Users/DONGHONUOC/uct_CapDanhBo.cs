using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using log4net;
using TanHoaWater.Database;
using CrystalDecisions.CrystalReports.Engine;
using TanHoaWater.View.Users.DONGHONUOC.BC;
using TanHoaWater.View.Users.Report;
using System.Globalization;

namespace TanHoaWater.View.Users.DONGHONUOC
{
    public partial class UCT_CapDanhBo : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(UCT_CapDanhBo).Name);
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        public UCT_CapDanhBo()
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

            List<GNKDT_THONGTINDMA> dmaList = DULIEUKH.C_GanMoi.getThongTinDMA();
            foreach (var item in dmaList)
            {
                namesCollection.Add(item.MADMA);
            }
            txtMaDMA.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtMaDMA.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtMaDMA.AutoCompleteCustomSource = namesCollection;

            //cbDotHoanCong.DataSource = DAL.C_KH_DotThiCong.getListDTC();
            //cbDotHoanCong.DisplayMember = "MADOTTC";
            //cbDotHoanCong.ValueMember = "MADOTTC";
            try
            {
                gridHoanCong.DataSource = DAL.C_DHN_ChoDanhBo.getListHoanCong(cbDotTC.Text, 0);
                for (int i = 0; i < gridHoanCong.Rows.Count; i++)
                {
                    gridHoanCong.Rows[i].Cells["hc_SoDanhBo"].Value = Utilities.FormatSoHoSoDanhBo.sodanhbo(gridHoanCong.Rows[i].Cells["hc_SoDanhBo"].Value + "", ".");
                    gridHoanCong.Rows[i].Cells["dhn_lotrinh"].Value = Utilities.FormatSoHoSoDanhBo.phienlotrinh(gridHoanCong.Rows[i].Cells["dhn_lotrinh"].Value + "", " ");
                }
            }
            catch (Exception)
            {

            }
        }

        private void checkChuaHoanCong_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                gridHoanCong.DataSource = DAL.C_DHN_ChoDanhBo.getListHoanCong(this.cbDotTC.Text, -1);
                gridHoanCong.Columns["hc_SoDot"].Visible = false;
                for (int i = 0; i < gridHoanCong.Rows.Count; i++)
                {
                    gridHoanCong.Rows[i].Cells["hc_SoDanhBo"].Value = Utilities.FormatSoHoSoDanhBo.sodanhbo(gridHoanCong.Rows[i].Cells["hc_SoDanhBo"].Value + "", ".");
                    gridHoanCong.Rows[i].Cells["dhn_lotrinh"].Value = Utilities.FormatSoHoSoDanhBo.phienlotrinh(gridHoanCong.Rows[i].Cells["dhn_lotrinh"].Value + "", " ");
                }
            }
            catch (Exception)
            {

            }
        }

        private void chekDaHoanCong_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                gridHoanCong.DataSource = DAL.C_DHN_ChoDanhBo.getListHoanCong(this.cbDotTC.Text, 1);
                gridHoanCong.Columns["hc_SoDot"].Visible = true;
                for (int i = 0; i < gridHoanCong.Rows.Count; i++)
                {
                    gridHoanCong.Rows[i].Cells["hc_SoDanhBo"].Value = Utilities.FormatSoHoSoDanhBo.sodanhbo(gridHoanCong.Rows[i].Cells["hc_SoDanhBo"].Value + "", ".");
                    gridHoanCong.Rows[i].Cells["dhn_lotrinh"].Value = Utilities.FormatSoHoSoDanhBo.phienlotrinh(gridHoanCong.Rows[i].Cells["dhn_lotrinh"].Value + "", " ");
                }
            }
            catch (Exception)
            {

            }
        }

        private void checkALl_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                gridHoanCong.DataSource = DAL.C_DHN_ChoDanhBo.getListHoanCong(this.cbDotTC.Text, 0);
                gridHoanCong.Columns["hc_SoDot"].Visible = true;
                for (int i = 0; i < gridHoanCong.Rows.Count; i++)
                {
                    gridHoanCong.Rows[i].Cells["hc_SoDanhBo"].Value = Utilities.FormatSoHoSoDanhBo.sodanhbo(gridHoanCong.Rows[i].Cells["hc_SoDanhBo"].Value + "", ".");
                    gridHoanCong.Rows[i].Cells["dhn_lotrinh"].Value = Utilities.FormatSoHoSoDanhBo.phienlotrinh(gridHoanCong.Rows[i].Cells["dhn_lotrinh"].Value + "", " ");
                }
            }
            catch (Exception)
            {

            }
        }

        public void hoantat()
        {
            try
            {
                if (checkALl.Checked)
                {
                    gridHoanCong.DataSource = DAL.C_DHN_ChoDanhBo.getListHoanCong(this.cbDotTC.Text, 0);
                    gridHoanCong.Columns["hc_SoDot"].Visible = true;
                }
                else if (checkChuaHoanCong.Checked)
                {
                    gridHoanCong.DataSource = DAL.C_DHN_ChoDanhBo.getListHoanCong(this.cbDotTC.Text, -1);
                    gridHoanCong.Columns["hc_SoDot"].Visible = false;
                }
                else if (chekDaHoanCong.Checked)
                {
                    gridHoanCong.DataSource = DAL.C_DHN_ChoDanhBo.getListHoanCong(this.cbDotTC.Text, 1);
                    gridHoanCong.Columns["hc_SoDot"].Visible = true;
                }
                for (int i = 0; i < gridHoanCong.Rows.Count; i++)
                {
                    gridHoanCong.Rows[i].Cells["hc_SoDanhBo"].Value = Utilities.FormatSoHoSoDanhBo.sodanhbo(gridHoanCong.Rows[i].Cells["hc_SoDanhBo"].Value + "", ".");
                    gridHoanCong.Rows[i].Cells["dhn_lotrinh"].Value = Utilities.FormatSoHoSoDanhBo.phienlotrinh(gridHoanCong.Rows[i].Cells["dhn_lotrinh"].Value + "", " ");
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void cbDotHoanCong_SelectedIndexChanged(object sender, EventArgs e)
        {
            hoantat();
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

        string _sohopdong = "";
        string _sodanhbo = "";
        string _maDMA = "";
        string _hieuluc = "";
        string formatDanhBo(string db)
        {
            db = db.Insert(4, ".");
            db = db.Insert(8, ".");
            return db;
        }
        private void gridHoanCong_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_SoHo")
                //{
                //    int soho = int.Parse(gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_SoHo"].Value + "");
                //    if (soho >= 1)
                //    {
                //        string shs = gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_SHS"].Value + "";
                //        string danhbo = gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_SoDanhBo"].Value + "";
                //        string hoten = gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_Hoten"].Value + "";
                //        string diachi = gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_DiaChi"].Value + "";
                //        if ("".Equals(danhbo))
                //        {
                //            MessageBox.Show(this, "Nhập Số Danh Bộ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        }
                //        else
                //        {
                //            frm_NhapSoHoKhau frm = new frm_NhapSoHoKhau(danhbo, shs, hoten, diachi);
                //            frm.ShowDialog();
                //        }
                //    }
                //}
            }
            catch (Exception)
            {
            }
        }

        private void gridHoanCong_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            try
            {
                if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_hopdong")
                {
                    if ("".Equals(_sodanhbo))
                    {
                        gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_SoDanhBo"].Value = "13" + ((gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_Ma_QP"].Value + "").Substring(2, 2));
                    }
                    else
                    {
                        gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_SoDanhBo"].Value = "13" + ((gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_Ma_QP"].Value + "").Substring(2, 2)) + "" + _sodanhbo.Substring(4, 3);
                    }
                }
            }
            catch (Exception)
            {

            }

            try
            {
                if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_SoDanhBo")
                {

                    _sodanhbo = gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_SoDanhBo"].Value.ToString().Replace(".", "");
                    gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_SoDanhBo"].Value = formatDanhBo(_sodanhbo);
                }

                if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_hopdong")
                {
                    _sohopdong = gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_hopdong"].Value + "";
                    gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_MaDMA"].Value = _maDMA;
                    gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_hieuLuc"].Value = _hieuluc;

                }
            }
            catch (Exception)
            {

            }

            try
            {
                if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_sotlk")
                {
                    if (!"".Equals(_sohopdong))
                    {
                        gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_hopdong"].Value = DAL.Idetity.IdentitySoHopDong(_sohopdong);
                    }
                }
            }
            catch (Exception)
            {

            }

            try
            {
                if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_DMucGoc")
                {
                    if (gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_ngaythicong"].Value != null && !"".Equals(gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_ngaythicong"].Value + "") && gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_hieuLuc"].Value != null && !"".Equals(gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_hieuLuc"].Value + ""))
                    {
                        if (int.Parse(gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_DMucGoc"].Value + "") > 0)
                        {
                            string[] ngaytc = Regex.Split(gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_ngaythicong"].Value + "", "\\/");
                            string[] ngayhl = Regex.Split(gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_hieuLuc"].Value + "", "\\/");
                            int namhl = int.Parse(ngayhl[1]);
                            int namtc = int.Parse(ngaytc[2]);
                            int thanghl = int.Parse(ngayhl[0]);
                            int thangtc = int.Parse(ngaytc[1]);

                            if (namhl == namtc && thanghl >= thangtc)
                            {
                                int dmcapnu = int.Parse(gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_DMucGoc"].Value + "") * (int.Parse(ngayhl[0]) - int.Parse(ngaytc[1]) + 1);
                                gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_DMCapBu"].Value = dmcapnu;
                            }
                            else if (namhl == namtc && thanghl < thangtc)
                            {
                                MessageBox.Show(this, "Ngày Hiệu Lực Kỳ Nhỏ Hơn Ngày Thi Công", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (namhl > namtc)
                            {
                                gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_DMCapBu"].Value = int.Parse(gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_DMucGoc"].Value + "") * ((namhl - namtc) * 12 + (thanghl - thangtc) + 1);
                            }
                            else if (namhl < namtc)
                            {
                                MessageBox.Show(this, "Ngày Hiệu Lực Kỳ Nhỏ Hơn Ngày Thi Công", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                    }
                }
            }
            catch (Exception)
            {

            }
        }
        public int checktrungdanhbo(string danhbo)
        {
            int count = 0;
            for (int i = 0; i < gridHoanCong.Rows.Count; i++)
                if (danhbo.Equals((this.gridHoanCong.Rows[i].Cells["hc_SoDanhBo"].Value + "").Trim()))
                    count++;
            return count;
        }
        public int checktrunghopdong(string hopdong)
        {
            int count = 0;
            for (int i = 0; i < gridHoanCong.Rows.Count; i++)
                if (hopdong.Equals((this.gridHoanCong.Rows[i].Cells["hc_hopdong"].Value + "").Trim()))
                    count++;
            return count;
        }
        private void gridHoanCong_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_SoDanhBo")
                {

                    try
                    {
                        string hc_SoDanhBo = gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_SoDanhBo"].Value + "";
                        if (hc_SoDanhBo.Replace(".", "").Length != 11)
                        {
                            MessageBox.Show(this, "Sai Số Danh Bộ ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_SoDanhBo"].Selected = true;
                        }
                        else if (checktrungdanhbo(this.gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_SoDanhBo"].Value + "") > 1)
                        {
                            MessageBox.Show(this, "Trùng Số Danh Bộ.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (DAL.C_KH_HoSoKhachHang.checkSoDanhBo((this.gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_SoDanhBo"].Value + "").Replace(".", "")) >= 1)
                        {
                            MessageBox.Show(this, "Trùng Số Danh Bộ.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception)
                    {
                    }

                    this.btInBangKe.Enabled = false;
                    this.btInBangDC.Enabled = false;
                }

                if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_hopdong")
                {
                    gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_hopdong"].Value = gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_hopdong"].Value.ToString().ToUpper();
                    _sohopdong = gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_hopdong"].Value.ToString().ToUpper();

                    if (checktrunghopdong(this.gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_hopdong"].Value + "") > 1)
                    {
                        MessageBox.Show(this, "Trùng Số Hợp Đồng.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (DAL.C_KH_HoSoKhachHang.countSoHopDong(this.gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_hopdong"].Value + "") >= 1)
                    {
                        MessageBox.Show(this, "Trùng Số Hợp Đồng.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_MaDMA")
                {
                    _maDMA = gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_MaDMA"].Value.ToString().ToUpper();
                    gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_MaDMA"].Value = gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_MaDMA"].Value.ToString().ToUpper();
                }
                if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_hieuLuc")
                {
                    _hieuluc = gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_hieuLuc"].Value.ToString();
                }

                if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_SoHo")
                {
                    int soho = int.Parse(gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_SoHo"].Value + "");
                    if (soho >= 1)
                    {
                        string shs = gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_SHS"].Value + "";
                        string danhbo = gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_SoDanhBo"].Value + "";
                        string hoten = gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_Hoten"].Value + "";
                        string diachi = gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_DiaChi"].Value + "";
                        if ("".Equals(danhbo))
                        {
                            MessageBox.Show(this, "Nhập Số Danh Bộ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            frm_NhapSoHoKhau frm = new frm_NhapSoHoKhau(danhbo, shs, hoten, diachi);
                            if (frm.ShowDialog() == DialogResult.OK)
                            {

                                gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_SoNhanKhau"].Value = frm.sonk;
                            }

                        }
                    }
                }


                /////
                if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_GiaBieu")
                {
                    string number = gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_GiaBieu"].Value + "";
                    if ("".Equals(number) || int.Parse(number) < 0)
                    {
                        MessageBox.Show(this, "Số không được trống, và lớn hơn không ?", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_GiaBieu"].Selected = true;
                    }
                }
                if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_DMucGoc")
                {
                    string number = gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_DMucGoc"].Value + "";
                    if ("".Equals(number) || int.Parse(number) < 0)
                    {
                        MessageBox.Show(this, "Số không được trống, và lớn hơn không ?", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_DMucGoc"].Selected = true;
                    }
                }
                if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_DMCapBu")
                {
                    string number = gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_DMCapBu"].Value + "";
                    if ("".Equals(number) || int.Parse(number) < 0)
                    {
                        MessageBox.Show(this, "Số không được trống, và lớn hơn không ?", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_DMCapBu"].Selected = true;
                    }
                }
                if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_SoHo")
                {
                    string number = gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_SoHo"].Value + "";
                    if ("".Equals(number) || int.Parse(number) < 0)
                    {
                        MessageBox.Show(this, "Số không được trống, và lớn hơn không ?", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_SoHo"].Selected = true;
                    }
                }
                if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_SoNhanKhau")
                {
                    string number = gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_SoNhanKhau"].Value + "";
                    if ("".Equals(number) || int.Parse(number) < 0)
                    {
                        MessageBox.Show(this, "Số không được trống, và lớn hơn không ?", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_SoNhanKhau"].Selected = true;
                    }
                }

                if (gridHoanCong.CurrentCell.OwningColumn.Name == "dhn_lotrinh")
                {
                    gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["dhn_lotrinh"].Value = Utilities.FormatSoHoSoDanhBo.phienlotrinh(gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["dhn_lotrinh"].Value.ToString().Trim(), " ");
                }

            }
            catch (Exception)
            {

            }

        }
        /// <summary>
        /// ///////////
        /// </summary>
        void updateDulieu()
        {
            try
            {
                bool flag = false;
                for (int i = 0; i < gridHoanCong.Rows.Count; i++)
                {
                    flag = false;
                    string hc_SoDanhBo = gridHoanCong.Rows[i].Cells["hc_SoDanhBo"].Value + "";
                    if (hc_SoDanhBo.Replace(".", "").Length == 11)
                    {
                        gridHoanCong.Rows[i].Cells["hc_SoDanhBo"].ErrorText = null;
                        string shs = this.gridHoanCong.Rows[i].Cells["hc_shs"].Value + "";
                        string hc_hopdong = this.gridHoanCong.Rows[i].Cells["hc_hopdong"].Value + "";
                        string hc_hieuLuc = this.gridHoanCong.Rows[i].Cells["hc_hieuLuc"].Value + "";
                        string hc_GiaBieu = this.gridHoanCong.Rows[i].Cells["hc_GiaBieu"].Value + "";
                        string hc_DMucGoc = this.gridHoanCong.Rows[i].Cells["hc_DMucGoc"].Value + "";
                        string hc_DMCapBu = this.gridHoanCong.Rows[i].Cells["hc_DMCapBu"].Value + "";
                        string hc_MaDMA = this.gridHoanCong.Rows[i].Cells["hc_MaDMA"].Value + "";
                        string hc_HsCty = this.gridHoanCong.Rows[i].Cells["hc_HsCty"].Value + "";
                        string hc_MasothueCT = this.gridHoanCong.Rows[i].Cells["hc_MasothueCT"].Value + "";
                        string hc_SoHo = this.gridHoanCong.Rows[i].Cells["hc_SoHo"].Value + "";
                        string hc_SoNhanKhau = this.gridHoanCong.Rows[i].Cells["hc_SoNhanKhau"].Value + "";
                        string hc_phienlotrinh = this.gridHoanCong.Rows[i].Cells["dhn_lotrinh"].Value + "";
                        if ("".Equals(hc_hopdong))
                        {
                            this.gridHoanCong.Rows[i].Cells["hc_hopdong"].ErrorText = "Nhập Hợp Đồng";
                            break;
                        }
                        else
                            this.gridHoanCong.Rows[i].Cells["hc_hopdong"].ErrorText = null;
                        /////

                        if ("".Equals(hc_hieuLuc))
                        {
                            this.gridHoanCong.Rows[i].Cells["hc_hieuLuc"].ErrorText = "Nhập Ngày Hiệu Lực.";
                            break;
                        }
                        else
                            this.gridHoanCong.Rows[i].Cells["hc_hieuLuc"].ErrorText = null;
                        /////
                        if ("".Equals(hc_GiaBieu))
                        {
                            this.gridHoanCong.Rows[i].Cells["hc_GiaBieu"].ErrorText = "Nhập Giá Biểu.";
                            break;
                        }
                        else
                            this.gridHoanCong.Rows[i].Cells["hc_GiaBieu"].ErrorText = null;
                        /////
                        if ("".Equals(hc_DMucGoc))
                        {
                            this.gridHoanCong.Rows[i].Cells["hc_DMucGoc"].ErrorText = "Nhập Định Mức Gốc";
                            break;
                        }
                        else
                            this.gridHoanCong.Rows[i].Cells["hc_DMucGoc"].ErrorText = null;
                        /////
                        if ("".Equals(hc_DMCapBu))
                        {
                            this.gridHoanCong.Rows[i].Cells["hc_DMCapBu"].ErrorText = "Nhập Định Mức Cấp Bù.";
                            break;
                        }
                        else
                            this.gridHoanCong.Rows[i].Cells["hc_DMCapBu"].ErrorText = null;

                        /////
                        if ("".Equals(hc_SoHo))
                        {
                            this.gridHoanCong.Rows[i].Cells["hc_SoHo"].ErrorText = "Nhập Số Hộ";
                            break;
                        }
                        else
                            this.gridHoanCong.Rows[i].Cells["hc_SoHo"].ErrorText = null;
                        /////
                        if ("".Equals(hc_SoNhanKhau))
                        {
                            this.gridHoanCong.Rows[i].Cells["hc_SoNhanKhau"].ErrorText = "Nhập Số Nhân Khấu";
                            break;
                        }
                        else
                            this.gridHoanCong.Rows[i].Cells["hc_SoNhanKhau"].ErrorText = null;

                        /////
                        if ("".Equals(hc_phienlotrinh))
                        {
                            this.gridHoanCong.Rows[i].Cells["dhn_lotrinh"].ErrorText = "Nhập Phiên Lộ Trình";
                            break;
                        }
                        else
                            this.gridHoanCong.Rows[i].Cells["dhn_lotrinh"].ErrorText = null;
                        /////
                        ////////////////////
                        try
                        {
                            KH_HOSOKHACHHANG hskh = DAL.C_DHN_ChoDanhBo.findbySHS(shs);
                            if (hskh != null)
                            {
                                hskh.DHN_SOHOPDONG = hc_hopdong;
                                hskh.DHN_GIABIEU = int.Parse(hc_GiaBieu);
                                hskh.DHN_DMGOC = int.Parse(hc_DMucGoc);
                                hskh.DHN_DMCAPBU = int.Parse(hc_DMCapBu);
                                hskh.DHN_SODANHBO = hc_SoDanhBo.Replace(".", "");
                                hskh.DHN_PHIENLOTRINH = hc_phienlotrinh.Trim();
                                hskh.DHN_MADMA = hc_MaDMA;
                                hskh.DHN_HIEULUC = hc_hieuLuc;
                                hskh.DHN_HSCONGTY = hc_HsCty;
                                hskh.DHN_MASOTHUE = hc_MasothueCT;
                                hskh.DHN_SOHO = int.Parse(hc_SoHo);
                                hskh.DHN_SONHANKHAU = int.Parse(hc_SoNhanKhau);
                                hskh.DHN_SODOT = this.txtDotBangKe.Text;
                                hskh.DHN_CHODB = true;
                                hskh.DHN_NGAYCHOSODB = DateTime.Now;
                                DAL.C_DHN_ChoDanhBo.UpdateDB();
                                flag = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            log.Error("Cap Danh Bo Loi" + ex.Message);
                        }


                    }
                    else if (!"".Equals(hc_SoDanhBo) && hc_SoDanhBo.Replace(".", "").Length != 11)
                    {
                        gridHoanCong.Rows[i].Cells["hc_SoDanhBo"].ErrorText = "Sai Số Danh Bộ !";
                    }
                    //if (this.gridHoanCong.Rows[i].Cells["hc_SoTLK"].Value != null && !"".Equals(this.gridHoanCong.Rows[i].Cells["hc_SoTLK"].Value + ""))
                    //{
                    //    if (this.gridHoanCong.Rows[i].Cells["hc_NgayTC"].Value != null && "".Equals(this.gridHoanCong.Rows[i].Cells["hc_NgayTC"].Value + ""))
                    //    {
                    //        this.gridHoanCong.Rows[i].Cells["hc_NgayTC"].ErrorText = "Ngày Thi Công Không Được Trống";
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        this.gridHoanCong.Rows[i].Cells["hc_NgayTC"].ErrorText = null;
                    //        ngaytc = this.gridHoanCong.Rows[i].Cells["hc_NgayTC"].Value + "";
                    //    }


                    //    if (Utilities.DateToString.checkDate(Utilities.DateToString.convartddMMyyyy(this.gridHoanCong.Rows[i].Cells["hc_NgayTC"].Value + "")) == false)
                    //    {
                    //        this.gridHoanCong.Rows[i].Cells["hc_NgayTC"].ErrorText = "Ngày Thi Công Không Hợp Lệ";
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        this.gridHoanCong.Rows[i].Cells["hc_NgayTC"].ErrorText = null;
                    //        ngaytc = Utilities.DateToString.convartddMMyyyy(this.gridHoanCong.Rows[i].Cells["hc_NgayTC"].Value + "");
                    //    }

                    //    if (this.gridHoanCong.Rows[i].Cells["hc_ChiSo"].Value != null && "".Equals(this.gridHoanCong.Rows[i].Cells["hc_ChiSo"].Value + ""))
                    //    {
                    //        this.gridHoanCong.Rows[i].Cells["hc_ChiSo"].ErrorText = "Chi Số Ko Được Trống";
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        this.gridHoanCong.Rows[i].Cells["hc_ChiSo"].ErrorText = null;
                    //        chiso = this.gridHoanCong.Rows[i].Cells["hc_ChiSo"].Value + "";
                    //    }
                    //    DAL.C_KH_HoanCong.HoanCong(shs, DateTime.ParseExact(ngaytc, "dd/MM/yyyy", null), int.Parse(chiso), sothanTLK, HoanCong);
                    //}


                }
                this.btInBangKe.Enabled = true;
                this.btInBangDC.Enabled = true;
                if (flag)
                {
                    MessageBox.Show(this, "Hoàn Tất.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, "Lỗi Cập Nhật Dữ Liệu.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //  hoantat();
            }
            catch (Exception ex)
            {
                log.Error("Cho Hop Dong & So Danh Bo" + ex.Message);
            }

        }
        private void btHoanTat_Click(object sender, EventArgs e)
        {
            string bangke = this.txtDotBangKe.Text + ""; ;
            if ("".Equals(bangke))
            {
                MessageBox.Show(this, "Nhập Bảng Kê Của Đợt.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtDotBangKe.Focus();
                this.txtDotBangKe.BackColor = Color.PeachPuff;
            }
            else
            {
                updateDulieu();

            }
        }

        private void gridHoanCong_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void gridHoanCong_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                txtKeypress = e.Control;
                if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_DMucGoc"
                    | gridHoanCong.CurrentCell.OwningColumn.Name == "hc_GiaBieu"
                    | gridHoanCong.CurrentCell.OwningColumn.Name == "hc_DMCapBu"
                    | gridHoanCong.CurrentCell.OwningColumn.Name == "hc_SoHo"
                    | gridHoanCong.CurrentCell.OwningColumn.Name == "hc_SoNhanKhau")
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
        public void LoadDataGridHC()
        {
            try
            {
                chekDaHoanCong.Checked = true;
                gridHoanCong.DataSource = DAL.C_DHN_ChoDanhBo.findByDotBangKe(this.txtDotBangKe.Text);
                for (int i = 0; i < gridHoanCong.Rows.Count; i++)
                {
                    gridHoanCong.Rows[i].Cells["hc_SoDanhBo"].Value = Utilities.FormatSoHoSoDanhBo.sodanhbo(gridHoanCong.Rows[i].Cells["hc_SoDanhBo"].Value + "", ".");
                    gridHoanCong.Rows[i].Cells["dhn_lotrinh"].Value = Utilities.FormatSoHoSoDanhBo.phienlotrinh(gridHoanCong.Rows[i].Cells["dhn_lotrinh"].Value + "", " ");
                }
            }
            catch (Exception)
            {
            }
        }
        private void btTimKiemDotBangKe_Click(object sender, EventArgs e)
        {
            LoadDataGridHC();
        }

        private void btInBangKe_Click(object sender, EventArgs e)
        {
            string bangke = this.txtDotBangKe.Text + ""; ;
            if ("".Equals(bangke))
            {
                MessageBox.Show(this, "Nhập Bảng Kê Của Đợt.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtDotBangKe.Focus();
                this.txtDotBangKe.BackColor = Color.PeachPuff;
            }
            else if (getSHS().Equals(""))
                MessageBox.Show(this, "Cần Chọn Hồ Sơ In", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                ReportDocument rp = new rpt_DANHBO();
                rp.SetDataSource(DAL.C_DHN_ChoDanhBo.BC_CHODANHBO(bangke, getSHS()));
                rpt_Main rpt = new rpt_Main(rp);
                rpt.ShowDialog();

            }
        }


        public string getSHS()
        {
            string result = "";
            for (int i = 0; i < gridHoanCong.Rows.Count; i++)
            {
                string shs = this.gridHoanCong.Rows[i].Cells["hc_SHS"].Value + "";
                string chonin = this.gridHoanCong.Rows[i].Cells["hc_chonin"].Value + "";
                if ("True".Equals(chonin))
                {
                    result += "'" + shs + "',";
                    string sql = "UPDATE KH_HOSOKHACHHANG SET DHN_SODOT='" + this.txtDotBangKe.Text + "' WHERE SHS='" + shs + "'";
                    DAL.LinQConnection.ExecuteCommand_(sql);
                }
            }
            if (result.Length > 0)
                result = result.Substring(0, result.Length - 1);
            return result;
        }

        private void btInBangDC_Click(object sender, EventArgs e)
        {
            string bangke = this.txtDotBangKe.Text + ""; ;
            if ("".Equals(bangke))
            {
                MessageBox.Show(this, "Nhập Bảng Kê Của Đợt.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtDotBangKe.Focus();
                this.txtDotBangKe.BackColor = Color.PeachPuff;
            }
            else if (getSHS().Equals(""))
                MessageBox.Show(this, "Cần Chọn Hồ Sơ In", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else
            {
                ReportDocument rp = new rpt_DIEUCHINH();
                rp.SetDataSource(DAL.C_DHN_ChoDanhBo.BC_DIEUCHINH(bangke, getSHS()));
                rpt_Main rpt = new rpt_Main(rp);
                rpt.ShowDialog();

            }
        }

        // 02/04/2013 Update BEGIN


        public void Refresh()
        {
            this.txtChiSo.Text = "00";
            this.txtDanhBo.Text = "";
            this.txtDiaChi.Text = "";
            this.txtDMBu.Text = "";
            this.txtDMGoc.Text = "";
            this.txtGiaBieu.Text = "";
            this.txtHieuĐHN.Text = "";
            this.txtHieuLuc.Text = "";
            this.txtHopDong.Text = "";
            this.txtHoSoCTy.Text = "";
            this.txtHoTen.Text = "";
            this.txtMaDMA.Text = "";
            this.txtSoHoSo.Text = "";
            this.txtMaQP.Text = "";
            this.txtMaSoThue.Text = "";
            this.txtSoHo.Text = "";
            this.txtSoNhanKhau.Text = "";
            this.txtSoTLK.Text = "";
            this.txtTLK.Text = "";
            this.dateNgayThiCong.ValueObject = null;
            this.txtSoHoSo.Focus();

        }


        private void gridHoanCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_chonin")
                {
                }
                else
                {
                    Refresh();
                    this.txtDotBangKe.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_SoDot"].Value + "";
                    this.txtSoHoSo.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_SHS"].Value + "";
                    this.txtHoTen.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_HoTen"].Value + "";
                    this.txtDiaChi.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_DiaChi"].Value + "";
                    this.txtSoTLK.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_sotlk"].Value + "";
                    this.txtTLK.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_tlk"].Value + "";
                    this.dateNgayThiCong.ValueObject = null;

                    this.txtDHN_HOTEN.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["DHN_HOTEN"].Value + "";
                    this.txDHNSONHA.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["DHN_SONHA"].Value + "";
                    this.txtDHNDUONG.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["DHN_DIACHI"].Value + "";
                    //string str_NgayThiCong = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_ngaythicong"].Value.ToString();

                    //DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                    //dtfi.ShortDatePattern = "dd/MM/yyyy";
                    //dtfi.DateSeparator = "/";
                    //DateTime dt_NgayThiCong = Convert.ToDateTime(str_NgayThiCong, dtfi);
                    //this.dateNgayThiCong.ValueObject = dt_NgayThiCong;

                    if (this.gridHoanCong.Rows[e.RowIndex].Cells["hc_ngaythicong"].Value != null && !"".Equals(this.gridHoanCong.Rows[e.RowIndex].Cells["hc_ngaythicong"].Value + ""))
                    {
                        this.dateNgayThiCong.ValueObject = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_ngaythicong"].Value;
                    }

                    this.txtDanhBo.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_SoDanhBo"].Value + "";
                    //if ("".Equals(this.gridHoanCong.Rows[e.RowIndex].Cells["hc_ChiSo"].Value + ""))
                    //{
                    //    this.txtChiSo.Text = "00";
                    //}
                    //else
                    //{
                    this.txtChiSo.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_ChiSo"].Value + "";
                    //}

                    this.txtHieuĐHN.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["gr_HIEUDONGHO"].Value + "";
                    this.txtHopDong.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_hopdong"].Value + "";

                    this.txtHieuLuc.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_hieuLuc"].Value + "";
                    this.txtGiaBieu.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_GiaBieu"].Value + "";
                    this.txtDMGoc.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_DMucGoc"].Value + "";
                    this.txtDMBu.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_DMCapBu"].Value + "";
                    this.txtLoTrinhTam.Text = (this.gridHoanCong.Rows[e.RowIndex].Cells["dhn_lotrinh"].Value + "").Replace(" ","");
                    this.txtMaDMA.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_MaDMA"].Value + "";
                    this.txtMaQP.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_Ma_QP"].Value + "";
                    this.txtHoSoCTy.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_HsCty"].Value + "";
                    this.txtMaSoThue.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_MasothueCT"].Value + "";
                    this.txtSoHo.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_SoHo"].Value + "";
                    this.txtSoNhanKhau.Text = this.gridHoanCong.Rows[e.RowIndex].Cells["hc_SoNhanKhau"].Value + "";

                    this.txtSoHoSo.Focus();
                    TB_GANMOI tb = DULIEUKH.C_GanMoi.finByDanhBo((this.txtDanhBo.Text).Replace("-", ""));
                    if (tb != null)
                    {
                        cbDotDS.Text = tb.DOT;
                        cbToDocSo.Text = tb.TODS;
                        cbMayDocSo.Text = int.Parse(tb.PLT.Substring(2,2)).ToString();
                    }
                    else {
                        cbDotDS.Text = "";
                        cbToDocSo.Text = "";
                        cbMayDocSo.Text = "";
                    }

                }

            }
            catch (Exception)
            {
            }
        }


        private void btCapNhat_Click(object sender, EventArgs e)
        {
            try
            {   //updateDulieu();
                string shs = this.txtSoHoSo.Text;
                // KH_HOSOKHACHHANG hskh = DAL.C_HoanCongDHN_DotTCTB.findByHoSoHC(shs);
                KH_HOSOKHACHHANG hskh = DAL.C_DHN_ChoDanhBo.findbySHS(shs);

                if (hskh != null)
                {
                    try
                    {
                        hskh.COTLK = int.Parse(this.txtTLK.Text);
                    }
                    catch (Exception)
                    { }
                    if (!"1/1/0001".Equals(this.dateNgayThiCong.Value.ToShortDateString()))
                    {
                        hskh.NGAYTHICONG = dateNgayThiCong.Value.Date;
                    }
                    try
                    {
                        hskh.CHISO = int.Parse(this.txtChiSo.Text);
                    }
                    catch (Exception)
                    { }
                    hskh.SOTHANTLK = this.txtSoTLK.Text;
                    hskh.DHN_SODANHBO = this.txtDanhBo.Text.Replace("-", "");
                    hskh.HIEUDONGHO = this.txtHieuĐHN.Text;
                    hskh.DHN_HIEULUC = this.txtHieuLuc.Text;
                    hskh.DHN_SOHOPDONG = this.txtHopDong.Text;
                    hskh.DHN_GIABIEU = int.Parse(this.txtGiaBieu.Text);
                    hskh.DHN_DMGOC = int.Parse(this.txtDMGoc.Text);
                    hskh.DHN_DMCAPBU = int.Parse(this.txtDMBu.Text);
                    hskh.DHN_PHIENLOTRINH = this.txtLoTrinhTam.Text;
                    hskh.DHN_MADMA = this.txtMaDMA.Text;
                    hskh.DHN_MAQUANPHUONG = this.txtMaQP.Text;
                    hskh.DHN_MASOTHUE = this.txtMaSoThue.Text;
                    hskh.DHN_HSCONGTY = this.txtHoSoCTy.Text;
                    hskh.DHN_SOHO = int.Parse(this.txtSoHo.Text);
                    hskh.DHN_SONHANKHAU = int.Parse(this.txtSoNhanKhau.Text);
                    int flag = 0;
                    int flag_SoHopDong = 0;
                    for (int i = 0; i < gridHoanCong.Rows.Count; i++)
                    {
                        if (this.gridHoanCong.Rows[i].Cells["hc_MaDMA"].Value.ToString() == "")
                        {
                            flag++;
                        }
                        if (this.gridHoanCong.Rows[i].Cells["hc_hopdong"].Value.ToString() == "")
                        {
                            flag_SoHopDong++;
                        }

                    }
                    hskh.DHN_MADMA = txtMaDMA.Text;
                    hskh.DHN_CHODB = true;
                    if (DAL.C_DHN_ChoDanhBo.UpdateDB() == false)
                        MessageBox.Show(this, "Cập Nhật Thông Tin Danh Bộ Không Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        /////
                        LoTrinhDocSo();
                        //MessageBox.Show(this, "Cập Nhật Thông Tin Danh Bộ Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //capnhat();
                       /* if (flag_SoHopDong == gridHoanCong.Rows.Count)
                        {
                            string shd = this.txtHopDong.Text;

                            for (int i = 0; i < gridHoanCong.Rows.Count; i++)
                            {
                                if (this.gridHoanCong.Rows[i].Cells["hc_SHS"].Value.ToString() == shs)
                                {

                                    continue;
                                }
                                else
                                {
                                    KH_HOSOKHACHHANG hskh_temp = DAL.C_DHN_ChoDanhBo.findbySHS(this.gridHoanCong.Rows[i].Cells["hc_SHS"].Value.ToString());
                                    //int so = int.Parse(shd) + 1;
                                    string HopDong_Increase = HopDongTangTuDong(shd, 2);
                                    hskh_temp.DHN_SOHOPDONG = HopDong_Increase;

                                    if (DAL.C_DHN_ChoDanhBo.UpdateDB() == false)
                                    {
                                        MessageBox.Show(this, "Cập Nhật Thông Tin Danh Bộ Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        shd = HopDong_Increase;


                                    }

                                }
                            }
                        }*/

/*

                        if (flag == gridHoanCong.Rows.Count)
                        {
                            string madma = this.txtMaDMA.Text;
                            for (int i = 0; i < gridHoanCong.Rows.Count; i++)
                            {
                                if (this.gridHoanCong.Rows[i].Cells["hc_SHS"].Value.ToString() == shs)
                                {

                                    continue;
                                }
                                else
                                {
                                    KH_HOSOKHACHHANG hskh_temp = DAL.C_DHN_ChoDanhBo.findbySHS(this.gridHoanCong.Rows[i].Cells["hc_SHS"].Value.ToString());
                                    int so_dma = int.Parse(madma);

                                    hskh_temp.DHN_MADMA = so_dma.ToString();

                                    if (DAL.C_DHN_ChoDanhBo.UpdateDB() == false)
                                    {
                                        MessageBox.Show(this, "Cập Nhật Thông Tin Danh Bộ Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        madma = so_dma.ToString();


                                    }

                                }
                            }
                        }*/
                        //string madma = this.txtMaDMA.Text;
                        //for (int i = 0; i < gridHoanCong.Rows.Count; i++)
                        //{
                        //    if (this.gridHoanCong.Rows[i].Cells["hc_SHS"].Value.ToString() == shs) 
                        //    {
                        //        continue;

                        //    }
                        //    else
                        //    {
                        //        KH_HOSOKHACHHANG hskh_temp = DAL.C_HoanCongDHN_DotTCTB.findByHoSoHC(this.gridHoanCong.Rows[i].Cells["hc_SHS"].Value.ToString());

                        //        int ma = int.Parse(madma);
                        //        hskh_temp.DHN_MADMA = ma.ToString();
                        //        if (DAL.C_HoanCongDHN_DotTCTB.Update() == false)
                        //        {
                        //            MessageBox.Show(this, "Cập Nhật Hoàn Công Không Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        }
                        //        else
                        //        {

                        //            madma = ma.ToString();

                        //        }
                        //    }
                        //}


                        hoantat();

                    }
                }

            }
            catch (Exception)
            {

            }

        }

        //private void txtSoNhanKhau_Click(object sender, EventArgs e)
        //{
        //    string shs = this.txtSoHoSo.Text;
        //    string danhbo = this.txtDanhBo.Text;
        //    string hoten = this.txtHoTen.Text;
        //    string diachi = this.txtDiaChi.Text;
        //    frm_NhapSoHoKhau frm = new frm_NhapSoHoKhau(shs, danhbo, hoten, diachi);


        //}



        private void txtSoHo_Leave(object sender, EventArgs e)
        {

            string shs = this.txtSoHoSo.Text;
            string danhbo = this.txtDanhBo.Text;
            string hoten = this.txtHoTen.Text;
            string diachi = this.txtDiaChi.Text;
            int soho = int.Parse(this.txtSoHo.Text);
            if (soho >= 1)
            {
                if ("".Equals(danhbo))
                {
                    MessageBox.Show(this, "Hồ Sơ Chưa Nhập Danh Bộ ", ".. Thông Báo..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    frm_NhapSoHoKhau frm = new frm_NhapSoHoKhau(shs, danhbo, hoten, diachi);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_SoNhanKhau"].Value = frm.sonk;
                        this.txtSoNhanKhau.Text = frm.sonk.ToString();
                    }
                }

            }

        }



        // 02/04/2013 Update END


        private string HopDongTangTuDong(string maHD, int length_slpit)
        {
            string kq = maHD;
            string name = maHD.Substring(0, length_slpit);
            string number = maHD.Substring(length_slpit, maHD.Length - length_slpit);
            int auto_number = int.Parse(number) + 1;
            string format_number = string.Format("{0:00000}", auto_number);
            kq = name + format_number;
            return kq;
        }

        private void cbDotTC_Leave(object sender, EventArgs e)
        {
            this.txtDotBangKe.Text = "";
            hoantat();
        }

        private void txtDMGoc_Leave(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(this.txtDMGoc.Text + "") > 0)
                {
                    string[] ngaytc = Regex.Split(dateNgayThiCong.Value.ToShortDateString() + "", "\\/");
                    string[] ngayhl = Regex.Split(this.txtHieuLuc.Text + "", "\\/");
                    int namhl = int.Parse(ngayhl[1]);
                    int namtc = int.Parse(ngaytc[2]);
                    int thanghl = int.Parse(ngayhl[0]);
                    int thangtc = int.Parse(ngaytc[0]);

                    if (namhl == namtc && thanghl >= thangtc)
                    {
                        int dmcapnu = int.Parse(this.txtDMGoc.Text + "") * (int.Parse(ngayhl[0]) - int.Parse(ngaytc[0]) + 1);
                        this.txtDMBu.Text = dmcapnu + "";
                    }
                    else if (namhl == namtc && thanghl < thangtc)
                    {
                        MessageBox.Show(this, "Ngày Hiệu Lực Kỳ Nhỏ Hơn Ngày Thi Công", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (namhl > namtc)
                    {
                        //  gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_DMCapBu"].Value = ;
                        this.txtDMBu.Text = (int.Parse(this.txtDMGoc.Text + "") * ((namhl - namtc) * 12 + (thanghl - thangtc) + 1)) + "";
                    }
                    else if (namhl < namtc)
                    {
                        MessageBox.Show(this, "Ngày Hiệu Lực Kỳ Nhỏ Hơn Ngày Thi Công", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void cbDotDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtLoTrinhTam.Text = "";
        }

        private void cbMayDocSo_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtLoTrinhTam.Text = "";
                int t1 = int.Parse(cbDotDS.Items[cbDotDS.SelectedIndex].ToString());
                int t2 = int.Parse(cbMayDocSo.Items[cbMayDocSo.SelectedIndex].ToString());

                if (t2 < 15)
                {
                    this.cbToDocSo.SelectedIndex = 0;
                }
                else if (t2 > 15 && t2 < 30)
                {
                    this.cbToDocSo.SelectedIndex = 1;
                }
                else if (t2 > 30)
                {
                    this.cbToDocSo.SelectedIndex = 2;

                }
                string dot = t1 + "";
                if (t1 < 10)
                {
                    dot = "0" + t1;
                }
                string may = t2 + "";
                if (t2 < 10)
                {
                    may = "0" + t2;
                }
                DataTable table = DULIEUKH.C_GanMoi.getMaxLoTrinh(dot + may);
                string lotrinh = (int.Parse(table.Rows[0][0] + "") + 1) + "";
                if (lotrinh.Length < 9)
                {
                    lotrinh = "0" + lotrinh;
                }
                this.txtLoTrinhTam.Text = lotrinh;
            }
            catch (Exception)
            {
                this.txtLoTrinhTam.Text = "";
            }

        }

        //////////////////////////////////////////////////////////////////////////////////////////////
        public void LoTrinhDocSo()
        {
            {
                try
                {
                     string SHS = this.txtSoHoSo.Text;
                     DON_KHACHHANG kh = DAL.C_DonKhachHang.findBySHS(SHS);
                     if (kh != null) {
                         string DANHBO = this.txtDanhBo.Text.Replace("-", "");
                         string HOPDONG = this.txtHopDong.Text;
                         DateTime NGAYGAN = this.dateNgayThiCong.Value;
                         string HIEULUC = this.txtHieuLuc.Text;
                         string GIABIEU = this.txtGiaBieu.Text;
                         string DINHMUC = this.txtDMGoc.Text;
                         string SOHO = this.txtSoHo.Text;
                         string HOTEN = this.txtDHN_HOTEN.Text;
                         string SONHA = this.txDHNSONHA.Text;
                         string DUONG = this.txtDHNDUONG.Text;
                         string PHUONG = kh.PHUONG;
                         string QUAN = kh.QUAN+"";
                         string HIEU = this.txtHieuĐHN.Text;
                         string COTLK = this.txtTLK.Text;
                         string SOTLK = this.txtSoTLK.Text;
                         string CHISOTLK = this.txtChiSo.Text;
                         string MAYDS = "0";
                         string DOTDS = cbDotDS.Items[cbDotDS.SelectedIndex].ToString();
                         string TODS = "TB01";
                         string LOTRINH = this.txtLoTrinhTam.Text;
                         string _dt = kh.DIENTHOAI;
                         int tods = 1;
                         if (this.cbToDocSo.SelectedIndex == 1)
                         {
                             TODS = "TB02";
                             tods = 2;
                         }
                         else if (this.cbToDocSo.SelectedIndex == 2)
                         {
                             tods = 3;
                             TODS = "TP";
                         }
                         else
                         {
                             tods = 1;
                             TODS = "TB01";
                         }
                         if (DULIEUKH.C_DuLieuKhachHang.finByDanhBo(DANHBO) == null && "".Equals(LOTRINH.Replace(" ", "")) == false)
                         {

                             TB_GANMOI tb = DULIEUKH.C_GanMoi.finByDanhBo(DANHBO);
                             if (tb == null)
                             {
                                 tb = new TB_GANMOI();
                                 tb.SHS = SHS;
                                 tb.DANHBO = DANHBO;
                                 tb.HOPDONG = HOPDONG;
                                 tb.HOTEN = HOTEN;
                                 tb.SONHA = SONHA;
                                 tb.DUONG = DUONG;
                                 tb.MAPHUONG = PHUONG;
                                 tb.MAQUAN = QUAN;
                                 tb.GIABIEU = GIABIEU;
                                 tb.DINHMUC = DINHMUC;
                                 tb.HIEULUC = HIEULUC;
                                 tb.NGAYGANTLK = NGAYGAN;
                                 tb.HIEU = HIEU;
                                 tb.COTLK = COTLK;
                                 tb.SOTLK = SOTLK;
                                 tb.CHISOTLK = CHISOTLK;
                                 tb.SOHO = SOHO;
                                 tb.TODS = TODS;
                                 tb.DOT = DOTDS;
                                 tb.PLT = LOTRINH;
                                 tb.MAYDS = MAYDS;
                                 tb.BANGKE = this.txtDotBangKe.Text;
                                 tb.CREATEDATE = DateTime.Now;
                                 tb.CREATEBY = DAL.C_USERS._userName;
                                 if (DULIEUKH.C_GanMoi.Insert(tb))
                                 {
                                     log.Info("--------------- GAN MOI - " + DANHBO + "");
                                     int ky = DateTime.Now.Month + 1;
                                     int nam = DateTime.Now.Year;
                                     try
                                     {
                                         ky = int.Parse(tb.HIEULUC.Substring(0, 2));
                                         nam = int.Parse(tb.HIEULUC.Substring(3, 4));
                                     }
                                     catch (Exception)
                                     {

                                     }
                                     /////
                                    // DAL.OledbConnection.ExecuteCommand_UpdatLoTrinh(connectionString, DANHBO, LOTRINH);

                                     ////
                                     string insert = "INSERT INTO TB_DULIEUKHACHHANG(DANHBO,HOPDONG,HOTEN,SONHA,TENDUONG,QUAN,PHUONG,GIABIEU,DINHMUC,NGAYGANDH,NGAYTHAY,HIEUDH,CODH,SOTHANDH,CHISOKYTRUOC,CODE, KY,NAM,LOTRINH,DIENTHOAI,KY_,MADMA) VALUES ";
                                     insert += "('" + DANHBO + "','" + HOPDONG + "','" + HOTEN + "','" + SONHA + "','" + DUONG + "','" + QUAN + "','" + PHUONG + "','" + GIABIEU + "','" + DINHMUC + "','" + NGAYGAN + "','" + NGAYGAN + "','" + HIEU + "','" + COTLK + "','" + tb.SOTLK + "','" + CHISOTLK + "','M','" + ky + "','" + nam + "','" + LOTRINH + "','" + _dt + "','" + ky + "','"+txtMaDMA.Text+"')";
                                     if (DULIEUKH.C_GanMoi.ExecuteCommand_(insert) > 0)
                                     {
                                         log.Info("+++++++++++ TB_DULIEUKHACHHANG : " + DANHBO + "");
                                         //int may = int.Parse(cbMayDocSo.Items[cbMayDocSo.SelectedIndex].ToString());
                                         //int dot = int.Parse(cbDotDS.Items[cbDotDS.SelectedIndex].ToString());
                                         // inset Table Doc So

                                         string insertGM = "INSERT INTO LENHDONGNUOC(DANHBA, HIEU, CO, SOTHAN,LOAI_LENH, NGAYTHUCHIEN, GHICHU, NGAYCAPNHAT, SOLENH, NAM, CSDONG_MO) ";
                                         insertGM += " VALUES ('" + DANHBO + "','" + HIEU + "','" + COTLK + "','" + tb.SOTLK + "','2','" + NGAYGAN + "','GM',GETDATE(),'123','" + nam + "','" + CHISOTLK + "')";
                                         log.Info("+++++++++++ LENHDONGNUOC : " + DANHBO + "");
                                         DULIEUKH.C_GanMoi.InsertDocSo_(insertGM);
                                         MessageBox.Show(this, "Cập Nhật Thông Tin Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                     }
                                     else
                                     {
                                         MessageBox.Show(this, "Kiểm Tra Sai Dữ Liệu ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                     }
                                 }
                                 else
                                 {
                                     MessageBox.Show(this, "Cập Nhật Thông Tin Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                 }
                             }
                             else
                             {
                                 tb.SHS = SHS;
                                 tb.DANHBO = DANHBO;
                                 tb.HOPDONG = HOPDONG;
                                 tb.HOTEN = HOTEN;
                                 tb.SONHA = SONHA;
                                 tb.DUONG = DUONG;
                                 tb.MAPHUONG = PHUONG;
                                 tb.MAQUAN = QUAN;
                                 tb.GIABIEU = GIABIEU;
                                 tb.DINHMUC = DINHMUC;
                                 tb.HIEULUC = HIEULUC;
                                 tb.NGAYGANTLK = NGAYGAN;
                                 tb.HIEU = HIEU;
                                 tb.COTLK = COTLK;
                                 tb.SOTLK = SOTLK;
                                 tb.CHISOTLK = CHISOTLK;
                                 tb.SOHO = SOHO;
                                 tb.TODS = TODS;
                                 tb.DOT = DOTDS;
                                 tb.PLT = LOTRINH;
                                 tb.MAYDS = MAYDS;
                                 tb.BANGKE = this.txtDotBangKe.Text;
                                 tb.CREATEDATE = DateTime.Now;
                                 tb.CREATEBY = DAL.C_USERS._userName;
                                 if (DULIEUKH.C_GanMoi.Update())
                                 {
                                     MessageBox.Show(this, "Cập Nhật Thông Tin Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                     ///// CAP NHAT DANH DU LIEU KHACH AHNG
                                     //TB_DULIEUKHACHHANG khUPdate = DULIEUKH.C_DuLieuKhachHang.finByDanhBo(DANHBO);
                                     //if (khUPdate != null)
                                     //{                                       
                                     //    HIEU, CO, SOTHAN,LOAI_LENH, NGAYTHUCHIEN, GHICHU, NGAYCAPNHAT, SOLENH, NAM, CSDONG_MO) ";
                                     //    insertGM += " VALUES ('" + DANHBO + "','" + HIEU + "','" + COTLK + "','" + tb.SOTLK + "','2','" + NGAYGAN + "','GM',GETDATE(),'123','" + nam + "','" + CHISOTLK + "')";

                                     //    DULIEUKH.C_DuLieuKhachHang.Update();
                                     //}

                                     ////
                                 }
                                 else
                                 {
                                     MessageBox.Show(this, "Cập Nhật Thông Tin Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                 }
                             }

                             //try
                             //{
                             //    dataGanMoiBK.Rows[rowIndex].Cells["DOT"].Value = DOTDS;
                             //    dataGanMoiBK.Rows[rowIndex].Cells["TODS"].Value = TODS;
                             //    dataGanMoiBK.Rows[rowIndex].Cells["MAYDS"].Value = MAYDS;
                             //    dataGanMoiBK.Rows[rowIndex].Cells["PLT"].Value = LOTRINH;
                             //}
                             //catch (Exception)
                             //{

                             //}
                         }
                         else
                         {
                             MessageBox.Show(this, "Danh Bộ Đã Tồn Tại Hoặc Lộ Trình Không Được Trống !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         }
                     }

                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                }
            }
        }

        private void btHuyLoTrinh_Click(object sender, EventArgs e)
        {
            frm_HuyLoTrinh frm = new frm_HuyLoTrinh();
            frm.ShowDialog();
        }
    }
}