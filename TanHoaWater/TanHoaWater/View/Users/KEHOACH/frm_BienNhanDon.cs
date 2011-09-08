using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using TanHoaWater.Database;

namespace TanHoaWater.View.Users.KEHOACH
{
    public partial class frm_BienNhanDon : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_BienNhanDon).Name);
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        public frm_BienNhanDon()
        {
            InitializeComponent();
            this.cbLoaiBN.Select();
            load();

        }
        public void load() {
           
            //try
            //{
                this.cbLoaiBN.DataSource = DAL.C_LoaiNhanDon.getList();
                this.cbLoaiBN.ValueMember = "LOAIDON";
                this.cbLoaiBN.DisplayMember = "TENLOAI";
                this.cbLoaiBN.SelectedIndex = 2;

                List <TENDUONG> list  = DAL.C_TenDuong.getList();
                foreach (var item in list)
                {
                    namesCollection.Add(item.DUONG);
                }
                txtDuong.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtDuong.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtDuong.AutoCompleteCustomSource = namesCollection;

                cbPhuong.DataSource = DAL.C_Phuong.getListAll();
                cbPhuong.ValueMember = "MAPHUONG";
                cbPhuong.DisplayMember = "TENPHUONG";
                Quan.DataSource = DAL.C_Quan.getList();
                Quan.ValueMember = "MAQUAN";
                Quan.DisplayMember = "TENQUAN";
                this.cbPhuong.Text = "";
                this.Quan.Text = "";
            //}
            //catch (Exception ex)
            //{
            //    log.Error("Load Bien Nhan Don Loi " +  ex.ToString());
            //}
            
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

      
        private void txtDuong_Leave(object sender, EventArgs e)
        {
            DataTable table = DAL.C_TenDuong.getQuanPhuong(this.txtDuong.Text);
            if (table.Rows.Count > 0)
            {
                this.cbPhuong.Text = table.Rows[0][0].ToString();
                this.Quan.Text = table.Rows[0][1].ToString();
            }
        }

        private void txtDuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 || e.KeyChar == 9) {
                DataTable table = DAL.C_TenDuong.getQuanPhuong(this.txtDuong.Text);
                if (table.Rows.Count > 0)
                {
                    this.cbPhuong.Text = table.Rows[0][0].ToString();
                    this.Quan.Text = table.Rows[0][1].ToString();
                }
            }
        }
    }
}
