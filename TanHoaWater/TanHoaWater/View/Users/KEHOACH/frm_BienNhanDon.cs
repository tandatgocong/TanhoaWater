using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;

namespace TanHoaWater.View.Users.KEHOACH
{
    public partial class frm_BienNhanDon : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_BienNhanDon).Name);
        public frm_BienNhanDon()
        {
            InitializeComponent();
            this.cbLoaiBN.Select();
            load();

        }
        public void load() {
           
            try
            {
                this.cbLoaiBN.DataSource = DAL.C_LoaiNhanDon.getList();
                this.cbLoaiBN.ValueMember = "LOAIDON";
                this.cbLoaiBN.DisplayMember = "TENLOAI";
                this.cbLoaiBN.SelectedIndex = 2;

                this.comboBoxEx1.DataSource = DAL.C_TenDuong.getList();
                this.comboBoxEx1.ValueMember = "DUONG";
                this.comboBoxEx1.DisplayMember = "DUONG";
            }
            catch (Exception ex)
            {
                log.Error("Load Bien Nhan Don Loi " +  ex.ToString());
            }
            
        }
             
        private void frm_BienNhanDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27) {
                this.Close();
            }
        }

        private void btTinhBangGia_Click(object sender, EventArgs e)
        {
            MessageBox.Show("fdsa");
        }

        private void cbLoaiBN_SelectedValueChanged(object sender, EventArgs e)
        {
            if("GM".Equals(this.cbLoaiBN.SelectedValue+"")){
                this.soBienNhan.Text = "GM";
            }
            else if ("BT".Equals(this.cbLoaiBN.SelectedValue + ""))
            {
                this.soBienNhan.Text = "BT";
            }
            else if ("DD".Equals(this.cbLoaiBN.SelectedValue + ""))
            {
                this.soBienNhan.Text = "DD";
            }
            
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
