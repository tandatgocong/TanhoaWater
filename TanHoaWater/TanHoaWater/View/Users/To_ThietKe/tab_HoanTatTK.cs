using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using TanHoaWater.View.Users.Report;
using CrystalDecisions.CrystalReports.Engine;
using TanHoaWater.View.Users.To_ThietKe.Report;
using TanHoaWater.Database;

namespace TanHoaWater.View.Users.To_ThietKe
{
    public partial class tab_HoanTatTK : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_HoanTatTK).Name);
        public tab_HoanTatTK()
        {
            InitializeComponent();
            this.cbDotNhanDon.DataSource = DAL.C_ToThietKe.DANHSACHDOTNHANDON();
            this.cbDotNhanDon.ValueMember = "MADOT";
            this.cbDotNhanDon.DisplayMember = "MADOT";
            #region Load Bo Phan Chuyen
            this.bophanChuyen.DataSource = DAL.C_PhongBan.getList();
            this.bophanChuyen.DisplayMember = "TENPHONG";
            this.bophanChuyen.ValueMember = "MAPHONG";
            #endregion

        }
        string _madot = "";

        private void bt_XemBC_Click(object sender, EventArgs e)
        {
            DAL.C_ToThietKe.HoaTatTKbyDot(this.cbDotNhanDon.Text);
            DataTable table = DAL.C_ToThietKe.GetDotToTK(this.cbDotNhanDon.Text);
            if (table.Rows.Count <= 0)
            {
                groupPanel1.Visible = false;
                MessageBox.Show(this, "Không Tìm Thấy Đợt Nhận Đơn !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                groupPanel1.Visible = true;
                string madot = table.Rows[0][0].ToString();
                _madot = madot;
                string ngay = table.Rows[0][1].ToString();
                string tendot = table.Rows[0][2].ToString();
                int tonghs = int.Parse(table.Rows[0][3].ToString());
                int trongai = int.Parse(table.Rows[0][4].ToString());
                int hoanthanh = int.Parse(table.Rows[0][5].ToString());
                int chualam = tonghs - (trongai + hoanthanh);
                lbKetQua.Text = "Đợt Nhận Đơn " + madot + " : " + tendot + ", Tồng Số " + tonghs + " đơn. <br/>    Trong đó: ";
                lbHoanTat.Text = "- Hoàn Tất " + hoanthanh + " đơn <br/>- Trở Ngại " + trongai + " đơn <br/> - Chưa Làm " + chualam + " đơn ";
                this.resultDGChuyen.DataSource = DAL.C_ToThietKe.ListHoanTatTK(madot);
                Utilities.DataGridV.formatRows(resultDGChuyen);
            }
        }

        private void resultDGChuyen_Sorted(object sender, EventArgs e)
        {
            Utilities.DataGridV.formatRows(resultDGChuyen);
        }

        private void chuyenDot_Click(object sender, EventArgs e)
        {
            int count = 0;
            try
            {
                for (int i = 0; i < resultDGChuyen.Rows.Count; i++)
                {
                    string shs = resultDGChuyen.Rows[i].Cells[0].Value + "";
                    if (DAL.C_ToThietKe.chuyenhs(shs, this.bophanChuyen.SelectedValue.ToString()))
                        count++;
                }
                MessageBox.Show(this, "Đã Chuyển " + count + " hồ sơ đến " + this.bophanChuyen.Text + " !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                log.Error("Chuyen Hoan Tat Ho So Loi : " + ex.ToString());
            }
            if (!"".Equals(_madot))
            {
                ReportDocument rp = new rpt_CHUYENHS();
                rp.SetDataSource(DAL.C_ToThietKe.BC_CHUYENDON_TTK(_madot, DAL.C_USERS._userName));
                rpt_Main aaa = new rpt_Main(rp);
                aaa.ShowDialog();
            }

        }

        public void hoantatTK()
        {
            TOTHIETKE ttk = DAL.C_ToThietKe.findBySHS(this.txtSHS.Text);
            if (ttk != null)
            {
                if (DAL.C_ToThietKe.HoaTatTK(ttk.SHS))
                {
                    DataTable table = DAL.C_ToThietKe.GetDotToTK(ttk.MADOT);
                    //groupPanel2.Visible = true;
                    string madot = table.Rows[0][0].ToString();
                    _madot = madot;
                    string ngay = table.Rows[0][1].ToString();
                    string tendot = table.Rows[0][2].ToString();
                    int tonghs = int.Parse(table.Rows[0][3].ToString());
                    int trongai = int.Parse(table.Rows[0][4].ToString());
                    int hoanthanh = int.Parse(table.Rows[0][5].ToString());
                    int chualam = tonghs - (trongai + hoanthanh);
                    ///  lbKetQuaHS.Text = "Đợt Nhận Đơn " + madot + " : " + tendot + ", Tồng Số " + tonghs + " đơn. <br/>    Trong đó: ";
                    //  lbKetQuaHSHT.Text = "- Hoàn Tất " + hoanthanh + " đơn <br/>- Trở Ngại " + trongai + " đơn <br/> - Chưa Làm " + chualam + " đơn ";
                    this.dataGridView1.DataSource = DAL.C_ToThietKe.ListHoanTatTK(madot);
                    Utilities.DataGridV.formatRows(dataGridView1);


                }
                else
                {
                    MessageBox.Show(this, " Lỗi Cập Nhật Hồ Sơ!", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(this, "Không Tìm Thấy Số Hồ Sơ !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtSHS.Text = "";
                this.txtSHS.Focus();
            }
        }
        private void btCapNhat_Click(object sender, EventArgs e)
        {
            hoantatTK();
        }
        string madot = "";

        private void txtSHS_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    if (e.KeyChar == 13)
                    {
                        DataTable table = DAL.C_ToThietKe.findByHSHT(this.txtSHS.Text);
                        if (table.Rows.Count <= 0)
                        {
                            MessageBox.Show(this, "Không Tìm Thấy Hồ Sơ !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.txtSHS.Text = "";
                            this.txtHoTen.Text = "";
                            this.txtGhiChu.Text = "";
                            this.txtDiaChi.Text = "";
                            this.txtSHS.Focus();
                        }
                        else
                        {
                            string _shs = table.Rows[0][0].ToString();
                            this.txtHoTen.Text = table.Rows[0][1].ToString();
                            this.txtDiaChi.Text = table.Rows[0][2].ToString();
                            madot = table.Rows[0][3].ToString();
                            this.txtGhiChu.Text = "";
                            this.txtGhiChu.Focus();
                            //this.dataGridView1.DataSource = DAL.C_ToThietKe.ListHoanTatTK(madot);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Loi Tim Ho So Hoan Tat" + ex.Message);
            }

        }
        //        this.dataGridView1.DataSource = DAL.C_ToThietKe.ListHoanTatTK(madot);
        //Utilities.DataGridV.formatRows(dataGridView1);
        private void printHoanTat_Click(object sender, EventArgs e)
        {

        }

        private void txtGhiChu_Leave(object sender, EventArgs e)
        {


        }

        private void InBangKe(object sender, EventArgs e)
        {
            try
            {
                if (!"".Equals(madot))
                {
                    ReportDocument rp = new rpt_HoanTatTK();
                    rp.SetDataSource(DAL.C_ToThietKe.BC_HOANTATTK(madot, DAL.C_USERS._userName, null));
                    DataTable table = DAL.C_ToThietKe.DIEMHOSO(madot, DAL.C_USERS._userName);
                    int trongai = 0;
                    int chualam = 0;
                    int hoantat = 0;
                    for (int i = 0; i < table.Rows.Count; i++)
                    {

                        if ("".Equals(table.Rows[i][0].ToString()))
                        {
                            chualam = int.Parse(table.Rows[i][1].ToString());
                        }
                        else if ("Trở Ngại".Equals(table.Rows[i][0].ToString()))
                        {
                            trongai = int.Parse(table.Rows[i][1].ToString());
                        }
                        else if ("Hoàn Tất".Equals(table.Rows[i][0].ToString()))
                        {
                            hoantat = int.Parse(table.Rows[i][1].ToString());
                        }
                    }
                    rp.SetParameterValue("HOANTAT", hoantat);
                    rp.SetParameterValue("TRONGAI", trongai);
                    rp.SetParameterValue("CHUATRA", chualam);
                    rpt_Main rpt = new rpt_Main(rp);
                    rpt.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("Loi In Bang Ke : " + ex.Message);
            }

        }

        private void txtGhiChu_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                if (e.KeyChar == 13)
                {
                    try
                    {
                        if (!"".Equals(txtSHS.Text))
                        {
                            DAL.C_ToThietKe.HoaTatTK(txtSHS.Text.Trim(), this.txtGhiChu.Text);
                            this.dataGridView1.DataSource = DAL.C_ToThietKe.ListHoanTatTK(madot);
                            Utilities.DataGridV.formatRows(dataGridView1);
                        }
                    }
                    catch (Exception)
                    {

                    }
                    txtSHS.Focus();
                }
            }
            catch (Exception ex)
            {
                log.Error("Loi In Bang Ke : " + ex.Message);
            }

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!"".Equals(cbDotNhanDon.Text))
                {
                    ReportDocument rp = new rpt_HoanTatTK();
                    rp.SetDataSource(DAL.C_ToThietKe.BC_HOANTATTK(cbDotNhanDon.Text, DAL.C_USERS._userName, null));
                    DataTable table = DAL.C_ToThietKe.DIEMHOSO(cbDotNhanDon.Text, DAL.C_USERS._userName);
                    int trongai = 0;
                    int chualam = 0;
                    int hoantat = 0;
                    for (int i = 0; i < table.Rows.Count; i++)
                    {

                        if ("".Equals(table.Rows[i][0].ToString()))
                        {
                            chualam = int.Parse(table.Rows[i][1].ToString());
                        }
                        else if ("Trở Ngại".Equals(table.Rows[i][0].ToString()))
                        {
                            trongai = int.Parse(table.Rows[i][1].ToString());
                        }
                        else if ("Hoàn Tất".Equals(table.Rows[i][0].ToString()))
                        {
                            hoantat = int.Parse(table.Rows[i][1].ToString());
                        }
                    }
                    rp.SetParameterValue("HOANTAT", hoantat);
                    rp.SetParameterValue("TRONGAI", trongai);
                    rp.SetParameterValue("CHUATRA", chualam);
                    rpt_Main rpt = new rpt_Main(rp);
                    rpt.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("Loi In Bang Ke : " + ex.Message);
            }

        }

        private void btDanhSachHoanTat_Click(object sender, EventArgs e)
        {
            try
            {
                if (!"".Equals(madot))
                {
                    ReportDocument rp = new rpt_DSHoanTat();
                    rp.SetDataSource(DAL.C_ToThietKe.BC_HOANTATTK(madot, DAL.C_USERS._userName, "True"));
                    rp.SetParameterValue("Title", "DANH SÁCH HOÀN TẤT THIẾT KẾ");
                    rpt_Main rpt = new rpt_Main(rp);
                    rpt.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("Loi In Bang Ke : " + ex.Message);
            }

        }

        private void btTronNgai_Click(object sender, EventArgs e)
        {
            try
            {
                if (!"".Equals(madot))
                {
                    ReportDocument rp = new rpt_DSHoanTat();
                    rp.SetDataSource(DAL.C_ToThietKe.BC_HOANTATTK(madot, DAL.C_USERS._userName, "False"));
                    rp.SetParameterValue("Title", "DANH SÁCH TRỞ NGẠI THIẾT KẾ");
                    rpt_Main rpt = new rpt_Main(rp);
                    rpt.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("Loi In Bang Ke : " + ex.Message);
            }

        }

        private void dot_printHoanTat_Click(object sender, EventArgs e)
        {
            try
            {
                if (!"".Equals(cbDotNhanDon.Text))
                {
                    ReportDocument rp = new rpt_DSHoanTat();
                    rp.SetDataSource(DAL.C_ToThietKe.BC_HOANTATTK(cbDotNhanDon.Text, DAL.C_USERS._userName, "True"));
                    rp.SetParameterValue("Title", "DANH SÁCH HOÀN TẤT THIẾT KẾ");
                    rpt_Main rpt = new rpt_Main(rp);
                    rpt.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("Loi In Bang Ke : " + ex.Message);
            }

        }

        private void dotprintTrongai_Click(object sender, EventArgs e)
        {
            try
            {
                if (!"".Equals(cbDotNhanDon.Text))
                {
                    ReportDocument rp = new rpt_DSHoanTat();
                    rp.SetDataSource(DAL.C_ToThietKe.BC_HOANTATTK(cbDotNhanDon.Text, DAL.C_USERS._userName, "False"));
                    rp.SetParameterValue("Title", "DANH SÁCH TRỞ NGẠI THIẾT KẾ");
                    rpt_Main rpt = new rpt_Main(rp);
                    rpt.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("Loi In Bang Ke : " + ex.Message);
            }

        }
    }
}