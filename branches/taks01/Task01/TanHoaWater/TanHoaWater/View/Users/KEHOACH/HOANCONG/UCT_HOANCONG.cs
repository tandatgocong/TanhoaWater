using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TanHoaWater.View.Users.KEHOACH.HOANCONG
{
    public partial class UCT_HOANCONG : UserControl
    {
        string _madotthicong = "";
        public UCT_HOANCONG()
        {
            InitializeComponent();
           
            cbDotHoanCong.DataSource = DAL.C_KH_DotThiCong.getListDTC();
            cbDotHoanCong.DisplayMember = "MADOTTC";
            cbDotHoanCong.ValueMember = "MADOTTC";
        }

        private void tabItem2_Click(object sender, EventArgs e)
        {
            this.tabCapNhatDS.Controls.Clear();
            this.tabCapNhatDS.Controls.Add(new tab_DanhSachHoanCong(this.cbDotHoanCong.Text));
            this.tabControl1.SelectedTabIndex = 1;
        }
        public void load(string dottc){
            this.gridHoSoHoanCong.DataSource = DAL.C_KH_HoanCong.getListThiCongbyDot(dottc, true);
            this.gridHoSoTHiCong.DataSource = DAL.C_KH_HoanCong.getListThiCongbyDot(dottc, false);
        }

        private void btChuyenHC_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridHoSoTHiCong.Rows.Count; i++)
            {
                string shs = gridHoSoTHiCong.Rows[i].Cells["hoancong_shs"].Value + "";
                DAL.C_KH_HoanCong.UpdateChuyenHC(shs);
            }
            load(this.cbDotHoanCong.Text);
            _madotthicong = this.cbDotHoanCong.Text;
        }

        private void cbDotHoanCong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                load(this.cbDotHoanCong.Text);
            }
        }

        private void cbDotHoanCong_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                load(this.cbDotHoanCong.Text);
            }
            catch (Exception)
            {
                
            }
        }

        private void tabItem3_Click(object sender, EventArgs e)
        {
            this.tabControlPanel1.Controls.Clear();
            this.tabControlPanel1.Controls.Add(new tab_TroNgaiHoanCong(this.cbDotHoanCong.Text));
            this.tabControl1.SelectedTabIndex = 2;
        }
    }
}
