using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;

namespace TanHoaWater.View.Users.KEHOACH.HOANCONG
{
    public partial class UCT_HOANCONG : UserControl
    {
        string _madotthicong = "";
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        public UCT_HOANCONG()
        {
            InitializeComponent();

            //cbDotHoanCong.DataSource = DAL.C_KH_DotThiCong.getListDTC();
            //cbDotHoanCong.DisplayMember = "MADOTTC";
            //cbDotHoanCong.ValueMember = "MADOTTC";

            List<KH_DOTTHICONG> list = DAL.C_KH_DotThiCong.getListDTC();
            foreach (var item in list)
            {
                namesCollection.Add(item.MADOTTC);
            }
            cbDotTC.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbDotTC.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbDotTC.AutoCompleteCustomSource = namesCollection;
            this.cbDotTC.Text = DAL.C_KH_DotThiCong.__dotthicong;
            load(this.cbDotTC.Text);

        }
        private void tabItem2_Click(object sender, EventArgs e)
        {
            this.tabCapNhatDS.Controls.Clear();
            this.tabCapNhatDS.Controls.Add(new tab_DanhSachHoanCong(this.cbDotTC.Text));
            this.tabControl1.SelectedTabIndex = 1;
        }
        public void load(string dottc){

            this.gridHoSoHoanCong.DataSource = DAL.C_KH_HoanCong.getListThiCongbyDot(dottc, true);
            this.gridHoSoTHiCong.DataSource = DAL.C_KH_HoanCong.getListThiCongbyDot(dottc, false);
            lbThiCong.Text = "Tổng cộng có " + gridHoSoTHiCong .Rows.Count + " hồ sơ Thi Công";
            lbHoanCong.Text = "Tổng cộng có " + gridHoSoHoanCong.Rows.Count + " hồ sơ Hoàn Công";
        }

        private void btChuyenHC_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridHoSoTHiCong.Rows.Count; i++)
            {
                string shs = gridHoSoTHiCong.Rows[i].Cells["hoancong_shs"].Value + "";
                DAL.C_KH_HoanCong.UpdateChuyenHC(shs);
            }
            load(this.cbDotTC.Text);
            _madotthicong = this.cbDotTC.Text;
        }

        //private void cbDotHoanCong_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 13) {
        //        load(this.cbDotHoanCong.Text);
        //    }
        //}

        private void cbDotHoanCong_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void tabItem3_Click(object sender, EventArgs e)
        {
            this.tabControlPanel1.Controls.Clear();
            this.tabControlPanel1.Controls.Add(new tab_TroNgaiHoanCong(DAL.C_KH_DotThiCong.__dotthicong));
            this.tabControl1.SelectedTabIndex = 2;
        }

        //private void cbDotTC_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 13) {
        //        try
        //        {
        //            load(this.cbDotTC.Text);
        //        }
        //        catch (Exception)
        //        {

        //        }
        //    }
            
        //}

        //private void cbDotTC_Enter(object sender, EventArgs e)
        //{
        //    load(this.cbDotTC.Text);
        //}

        private void cbDotTC_Leave(object sender, EventArgs e)
        {
            load(this.cbDotTC.Text);
            DAL.C_KH_DotThiCong.__dotthicong = this.cbDotTC.Text;
        }

        private void tabItem1_Click(object sender, EventArgs e)
        {
            this.cbDotTC.Text = DAL.C_KH_DotThiCong.__dotthicong;
            load(this.cbDotTC.Text);
        }

        private void UCT_HOANCONG_Load(object sender, EventArgs e)
        {
          
        }

        private void tabItem4_Click(object sender, EventArgs e)
        {
            this.tabControlPanel2.Controls.Clear();
            this.tabControlPanel2.Controls.Add(new tab_TraHoSoHC());
            this.tabControl1.SelectedTabIndex = 3;
        }
    }
}
