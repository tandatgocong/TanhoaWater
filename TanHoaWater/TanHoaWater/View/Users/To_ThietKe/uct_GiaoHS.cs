using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using TanHoaWater.View.Users.To_ThietKe.Report;

namespace TanHoaWater.View.Users.To_ThietKe
{
    public partial class uct_GiaoHS : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(uct_GiaoHS).Name);
        public uct_GiaoHS()
        {
            InitializeComponent();
            this.dateNhanDon.Value = DateTime.Now;
            formLoad();


        }

        private void theongay_CheckedChanged(object sender, EventArgs e)
        {
            this.dateNhanDon.Enabled = true;
            this.DotNhanDon.Enabled = false;

        }

        private void theodot_CheckedChanged(object sender, EventArgs e)
        {
            this.dateNhanDon.Enabled = false;
            this.DotNhanDon.Enabled = true;
        }
        int flag = 0;
        CheckBox checkboxHeader1 = new CheckBox();
        CheckBox checkboxHeader = new CheckBox();
        public void formLoad()
        {

            #region Load SDV
            this.sodovien.DataSource = DAL.C_USERS.getUserByMaPhongAndLevel("TTK", 2);
            this.sodovien.DisplayMember = "FULLNAME";
            this.sodovien.ValueMember = "USERNAME";
            #endregion
            #region Loai Dot Khach Hang
            this.DotNhanDon.DataSource = DAL.C_DotNhanDon.getListtMa_Dot_DaChuyen();
            this.DotNhanDon.DisplayMember = "TEND";
            this.DotNhanDon.ValueMember = "MADOT";
            #endregion
            //#region DS Chua Giao Theo Ngay
            //this.DG_ChuaGiao.DataSource = DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, Utilities.DateToString.NgayVN(this.dateNhanDon), null);
            //#endregion
            //#region DS Da Giao Theo Ngay
            //this.DG_ChuaGiao.DataSource = DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, Utilities.DateToString.NgayVN(this.dateNhanDon), this.sodovien.SelectedValue.ToString());
            //#endregion

            //customize dataviewgrid, add checkbox column
            if (flag == 0)
            {
                //DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
                //checkboxColumn.Width = 30;
                //checkboxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //DG_ChuaGiao.Columns.Insert(0, checkboxColumn);

                // add checkbox header
                Rectangle rect = DG_ChuaGiao.GetCellDisplayRectangle(0, -1, true);
                // set checkbox header to center of header cell. +1 pixel to position correctly.
                rect.X = rect.Location.X + (rect.Width / 4);

                CheckBox checkboxHeader = new CheckBox();
                checkboxHeader.Name = "checkboxHeader";
                checkboxHeader.Size = new Size(17, 17);
                checkboxHeader.Location = rect.Location;
                checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged);
                DG_ChuaGiao.Controls.Add(checkboxHeader);

                Rectangle rect1 = DG_ChuaGiao.GetCellDisplayRectangle(0, -1, true);
                // set checkbox header to center of header cell. +1 pixel to position correctly.
                rect1.X = rect.Location.X + (rect.Width / 4);

                CheckBox checkboxHeader1 = new CheckBox();
                checkboxHeader1.Name = "checkboxHeader";
                checkboxHeader1.Size = new Size(17, 17);
                checkboxHeader1.Location = rect.Location;
                checkboxHeader1.CheckedChanged += new EventHandler(checkboxHeader1_CheckedChanged);
                DG_SDV.Controls.Add(checkboxHeader1);

                flag = 1;
            }
        }
        public void dagiaoviec()
        {
            int count = 0;
            try
            {
                if (btAll.Checked == true)
                {
                    //#region DS Chua Giao Theo Ngay
                    //this.DG_ChuaGiao.DataSource = DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, null, null);
                    //labelDSChuaGiao.Text = "Tổng Số " + DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, null, null).Rows.Count + " Hồ Sơ Chưa Giao Sơ Đồ Viên. ";
                    //#endregion
                    count = DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, null, this.sodovien.SelectedValue.ToString()).Rows.Count;
                    #region DS Da Giao Theo Ngay
                    this.DG_SDV.DataSource = DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, null, this.sodovien.SelectedValue.ToString());
                    lableGIAO_SDV.Text = this.sodovien.Text + " Có " + count + " Hồ Sơ Được Giao";
                    #endregion
                }
                else if (theodot.Checked == true)
                {
                    //#region DS Chua Giao Theo Ngay
                    //this.DG_ChuaGiao.DataSource = DAL.C_ToThietKe.DachSachHoSoGiaoViec(this.DotNhanDon.SelectedValue.ToString(), null, null);
                    //labelDSChuaGiao.Text = "Tổng Số " + DAL.C_ToThietKe.DachSachHoSoGiaoViec(this.DotNhanDon.SelectedValue.ToString(), null, null).Rows.Count + " Hồ Sơ Chưa Giao Sơ Đồ Viên. ";
                    //#endregion
                    count = DAL.C_ToThietKe.DachSachHoSoGiaoViec(this.DotNhanDon.SelectedValue.ToString(), null, this.sodovien.SelectedValue.ToString()).Rows.Count;
                    #region DS Da Giao Theo Ngay
                    this.DG_SDV.DataSource = DAL.C_ToThietKe.DachSachHoSoGiaoViec(this.DotNhanDon.SelectedValue.ToString(), null, this.sodovien.SelectedValue.ToString());
                    lableGIAO_SDV.Text = this.sodovien.Text + " Có " + count + " Hồ Sơ Được Giao";
                    #endregion

                }
                else
                {
                    //#region DS Chua Giao Theo Ngay
                    //this.DG_ChuaGiao.DataSource = DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, Utilities.DateToString.NgayVN(this.dateNhanDon), null);
                    //labelDSChuaGiao.Text = "Tổng Số " + DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, Utilities.DateToString.NgayVN(this.dateNhanDon), null).Rows.Count + " Hồ Sơ Chưa Giao Sơ Đồ Viên. ";
                    //#endregion
                    #region DS Da Giao Theo Ngay
                    this.DG_SDV.DataSource = DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, Utilities.DateToString.NgayVN(this.dateNhanDon), this.sodovien.SelectedValue.ToString());
                    count = DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, Utilities.DateToString.NgayVN(this.dateNhanDon), this.sodovien.SelectedValue.ToString()).Rows.Count;
                    lableGIAO_SDV.Text = this.sodovien.Text + " Có " + count + " Hồ Sơ Được Giao";
                    #endregion
                }
            }
            catch (Exception)
            { }
            if (count > 0)
            {
                resultPrint.Visible = true;
            }
            else
            {
                resultPrint.Visible = false;
            }
        }
        public void giaoviec()
        {
            int count = 0;
            try
            {
                if (btAll.Checked == true) {
                    #region DS Chua Giao Theo Ngay
                    this.DG_ChuaGiao.DataSource = DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, null, null);
                    labelDSChuaGiao.Text = "Tổng Số " + DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, null, null).Rows.Count + " Hồ Sơ Chưa Giao Sơ Đồ Viên. ";
                    #endregion
                    count = DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, null, this.sodovien.SelectedValue.ToString()).Rows.Count;
                    #region DS Da Giao Theo Ngay
                    this.DG_SDV.DataSource = DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, null, this.sodovien.SelectedValue.ToString());
                    lableGIAO_SDV.Text = this.sodovien.Text + " Có " + count + " Hồ Sơ Được Giao";
                    #endregion
                }
                else if (theodot.Checked == true)
                {
                    #region DS Chua Giao Theo Ngay
                    this.DG_ChuaGiao.DataSource = DAL.C_ToThietKe.DachSachHoSoGiaoViec(this.DotNhanDon.SelectedValue.ToString(), null, null);
                    labelDSChuaGiao.Text = "Tổng Số " + DAL.C_ToThietKe.DachSachHoSoGiaoViec(this.DotNhanDon.SelectedValue.ToString(), null, null).Rows.Count + " Hồ Sơ Chưa Giao Sơ Đồ Viên. ";
                    #endregion
                    count = DAL.C_ToThietKe.DachSachHoSoGiaoViec(this.DotNhanDon.SelectedValue.ToString(), null, this.sodovien.SelectedValue.ToString()).Rows.Count;
                    #region DS Da Giao Theo Ngay
                    this.DG_SDV.DataSource = DAL.C_ToThietKe.DachSachHoSoGiaoViec(this.DotNhanDon.SelectedValue.ToString(), null, this.sodovien.SelectedValue.ToString());
                    lableGIAO_SDV.Text = this.sodovien.Text + " Có " + count + " Hồ Sơ Được Giao";
                    #endregion

                }
                else
                {
                    #region DS Chua Giao Theo Ngay
                    this.DG_ChuaGiao.DataSource = DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, Utilities.DateToString.NgayVN(this.dateNhanDon), null);
                    labelDSChuaGiao.Text = "Tổng Số " + DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, Utilities.DateToString.NgayVN(this.dateNhanDon), null).Rows.Count + " Hồ Sơ Chưa Giao Sơ Đồ Viên. ";
                    #endregion
                    #region DS Da Giao Theo Ngay
                    this.DG_SDV.DataSource = DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, Utilities.DateToString.NgayVN(this.dateNhanDon), this.sodovien.SelectedValue.ToString());
                    count = DAL.C_ToThietKe.DachSachHoSoGiaoViec(null, Utilities.DateToString.NgayVN(this.dateNhanDon), this.sodovien.SelectedValue.ToString()).Rows.Count;
                    lableGIAO_SDV.Text = this.sodovien.Text + " Có " + count + " Hồ Sơ Được Giao";
                    #endregion
                }
            }
            catch (Exception)
            { }
            if (count > 0)
            {
                resultPrint.Visible = true;
            }
            else
            {
                resultPrint.Visible = false;
            }
        }
        private void btView_Click(object sender, EventArgs e)
        {
            giaoviec();
        }

        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < DG_ChuaGiao.RowCount; i++)
            {
                DG_ChuaGiao[0, i].Value = ((CheckBox)DG_ChuaGiao.Controls.Find("checkboxHeader", true)[0]).Checked;
            }
        }
        private void checkboxHeader1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < DG_SDV.RowCount; i++)
            {
                DG_SDV[0, i].Value = ((CheckBox)DG_SDV.Controls.Find("checkboxHeader", true)[0]).Checked;
            }
        }
        private void sodovien_SelectedValueChanged(object sender, EventArgs e)
        {
            dagiaoviec();
        }

        private void btGiaoViec_Click(object sender, EventArgs e)
        {
            try
            {
                bool chek = false;
                for (int i = 0; i < DG_ChuaGiao.RowCount; i++)
                {
                    if (DG_ChuaGiao[0, i].Value != null && "True".Equals(DG_ChuaGiao[0, i].Value.ToString()))
                    {
                        chek = true;
                        string shs = DG_ChuaGiao.Rows[i].Cells[2].Value.ToString();
                        DAL.C_ToThietKe.giaoviecSDV(shs, this.sodovien.SelectedValue.ToString(), DAL.C_USERS._userName);
                    }
                }

                if (chek == false)
                {
                    MessageBox.Show(this, "Chưa Chọn Hồ Sơ Để Giao Cho Sơ Đồ Viên.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    giaoviec();
                }
            }
            catch (Exception ex)
            {
                log.Error("TTK Giao Viec Loi " + ex.Message);
            }

        }

        private void DG_ChuaGiao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DG_ChuaGiao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex == 0)
            {
                if (DG_ChuaGiao.Rows[e.RowIndex].Cells[0].Value == null)
                {
                    DG_ChuaGiao.Rows[e.RowIndex].Cells[0].Value = true;
                }
                else
                {
                    bool bChecked = (bool)DG_ChuaGiao.Rows[e.RowIndex].Cells[0].Value;
                    DG_ChuaGiao.Rows[e.RowIndex].Cells[0].Value = !bChecked;
                }
            }
        }

        private void DotNhanDon_SelectedValueChanged(object sender, EventArgs e)
        {
            giaoviec();
        }

        private void dateNhanDon_ValueChanged(object sender, EventArgs e)
        {
            giaoviec();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                bool chek = false;
                for (int i = 0; i < DG_SDV.RowCount; i++)
                {
                    if (DG_SDV[0, i].Value != null && "True".Equals(DG_SDV[0, i].Value.ToString()))
                    {
                        chek = true;
                        string shs = DG_SDV.Rows[i].Cells[2].Value.ToString();
                        DAL.C_ToThietKe.giaoviecSDV(shs, null, DAL.C_USERS._userName);
                    }
                }

                if (chek == false)
                {
                    MessageBox.Show(this, "Chưa Chọn Hồ Sơ Để Hủy Giao Cho Sơ Đồ Viên.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    giaoviec();
                }
            }
            catch (Exception ex)
            {
                log.Error("TTK Giao Viec Loi " + ex.Message);
            }
        }

        private void DG_SDV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex == 0)
            {
                if (DG_SDV.Rows[e.RowIndex].Cells[0].Value == null)
                {
                    DG_SDV.Rows[e.RowIndex].Cells[0].Value = true;
                }
                else
                {
                    bool bChecked = (bool)DG_SDV.Rows[e.RowIndex].Cells[0].Value;
                    DG_SDV.Rows[e.RowIndex].Cells[0].Value = !bChecked;
                }
            }
        }

        private void resultPrint_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if (theodot.Checked == true)
            {

                ds = DAL.C_ToThietKe.BC_GIAOHS_SDV(this.DotNhanDon.SelectedValue.ToString(), null, this.sodovien.SelectedValue.ToString(), DAL.C_USERS._userName);


            }
            else
            {
                ds = DAL.C_ToThietKe.BC_GIAOHS_SDV(null, Utilities.DateToString.NgayVN(this.dateNhanDon), this.sodovien.SelectedValue.ToString(), DAL.C_USERS._userName);

            }
            rpt_View rpt = new rpt_View(ds);
            rpt.ShowDialog();
        }

        private void btAll_CheckedChanged(object sender, EventArgs e)
        {
            giaoviec();
            this.dateNhanDon.Enabled = false;
            this.DotNhanDon.Enabled = false;
        }
    }
}