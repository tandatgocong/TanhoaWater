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
            DataTable table = DAL.C_ToThietKe.GetDotToTK(this.cbDotNhanDon.Text);
            if (table.Rows.Count <= 0)
            {
                groupPanel1.Visible = false;
                MessageBox.Show(this, "Không Tìm Thấy Đợt Nhận Đơn !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);               
            }
            else {
                groupPanel1.Visible = true;
                string madot = table.Rows[0][0].ToString();
                _madot = madot;
                string ngay = table.Rows[0][1].ToString();
                string tendot = table.Rows[0][2].ToString();
                int tonghs = int.Parse(table.Rows[0][3].ToString());
                int trongai = int.Parse(table.Rows[0][4].ToString());
                int hoanthang = tonghs - trongai;
                lbKetQua.Text = "Đợt Nhận Đơn "+madot +" : "+ tendot +", Tồng Số "+ tonghs +" đơn. <br/>    Trong đó: ";
                lbHoanTat.Text = "- Hoàn Tất " + hoanthang + " đơn <br/>- Trở Ngại " + trongai + " đơn";
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
            //int count = 0;
            //try
            //{
            //    for (int i = 0; i < resultDGChuyen.Rows.Count; i++) {
            //        string shs = resultDGChuyen.Rows[i].Cells[0].Value + "";
            //        if (DAL.C_ToThietKe.chuyenhs(shs, this.bophanChuyen.SelectedValue.ToString()))
            //            count++;
            //    }
            //    MessageBox.Show(this,"Đã Chuyển " + count+ " hồ sơ đến " + this.bophanChuyen.Text +" !","..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}
            //catch (Exception ex)
            //{
            //    log.Error("Chuyen Hoan Tat Ho So Loi : " + ex.ToString());
            //}
            if(!"".Equals(_madot)){
                 ReportDocument rp = new rpt_CHUYENHS();
                rp.SetDataSource(DAL.C_ToThietKe.BC_CHUYENDON_TTK(_madot,DAL.C_USERS._userName));
                rpt_Main main = new rpt_Main(rp);
                main.ShowDialog();
            }
           
        }
    }
}
