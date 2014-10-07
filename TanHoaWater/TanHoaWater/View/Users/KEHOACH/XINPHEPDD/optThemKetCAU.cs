using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TanHoaWater.View.Users.KEHOACH.XINPHEPDD
{
    public partial class optThemKetCAU : Form
    {
        public optThemKetCAU()
        {
            InitializeComponent();

            GridPhuiDao.DataSource = DAL.LinQConnection.getDataTable("SELECT * FROM KH_XINPHEPDAODUONG_KETCAU ORDER BY MADANHMUC ASC ");
        }

        private void txtMaSHS_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                txtDiaChi.Focus();
            }
        }

        private void txtDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (DAL.LinQConnection.ExecuteCommand_("INSERT INTO KH_XINPHEPDAODUONG_KETCAU VALUES(N'" + txtMaSHS.Text + "',N'" + txtDiaChi.Text + "') ") < 1)
                {
                    MessageBox.Show(this,"Thêm Kết Cấu Thất Bại !","..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    GridPhuiDao.DataSource = DAL.LinQConnection.getDataTable("SELECT * FROM KH_XINPHEPDAODUONG_KETCAU ");
                }
            }
        }
    }
}
