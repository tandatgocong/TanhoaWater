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
           
            try
            {
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
            }
            catch (Exception ex)
            {
                log.Error("Load Bien Nhan Don Loi " + ex.ToString());
            }
            
        }
             
        private void frm_BienNhanDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27) {
                this.Close();
            }
        }


      
        private void cbLoaiBN_SelectedValueChanged(object sender, EventArgs e)
        {

            this.soBienNhan.Text = DAL.Idetity.IdentityBienNhan(this.cbLoaiBN.SelectedValue + "");
            
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

        public void reset() {
            errorProvider1.Clear();
            this.soBienNhan.Text = DAL.Idetity.IdentityBienNhan(this.cbLoaiBN.SelectedValue + "");
            this.txtHoTen.Text="";
            this.txtsonha.Text="";
            this.txtDuong.Text="";
            this.cbPhuong.Text="";
            this.Quan.Text="";
            cbPhuong.DataSource = DAL.C_Phuong.getListAll();
            cbPhuong.ValueMember = "MAPHUONG";
            cbPhuong.DisplayMember = "TENPHUONG";
            Quan.DataSource = DAL.C_Quan.getList();
            Quan.ValueMember = "MAQUAN";
            Quan.DisplayMember = "TENQUAN";
            this.txtHoTen.Focus();

        }
        private void btBienNhanDon_Click(object sender, EventArgs e)
        {
            try
            {
                string loaihs = cbLoaiBN.SelectedValue + "";
                string soshs = this.soBienNhan.Text;
                string hoten = this.txtHoTen.Text;
                string sonha = this.txtsonha.Text;
                string tenduong = this.txtDuong.Text;
                string tenphuong = this.cbPhuong.Text;
                string tenquan = this.Quan.Text;
                QUAN quan = DAL.C_Quan.finbyTenQuan(tenquan);
                PHUONG phuong = null;
                if (quan != null)
                {
                    phuong = DAL.C_Phuong.finbyTenPhuong(quan.MAQUAN, tenphuong);
                }
                if ("".Equals(hoten))
                {
                    errorProvider1.SetError(txtHoTen, "Nhập Họ Tên.");
                    this.txtHoTen.Focus();
                }
                else if ("".Equals(sonha))
                {
                    errorProvider1.SetError(txtsonha, "Nhập Số Nhà.");
                    this.txtsonha.Focus();
                }
                else if ("".Equals(tenduong))
                {
                    errorProvider1.SetError(txtDuong, "Nhập Số Nhà.");
                    this.txtDuong.Focus();
                }
                else if (quan == null)
                {
                    errorProvider1.SetError(Quan, "Chọn Quận .");
                    this.Quan.Select();
                }
                else if (phuong == null)
                {
                    cbPhuong.DataSource = DAL.C_Phuong.getListByQuan(quan.MAQUAN);
                    cbPhuong.ValueMember = "MAPHUONG";
                    cbPhuong.DisplayMember = "TENPHUONG";                    
                    errorProvider1.SetError(cbPhuong, "Chọn Phường.");
                    this.cbPhuong.Select();
                }
                else
                {
                    errorProvider1.Clear();
                    BIENNHANDON biennhan = new BIENNHANDON();
                    biennhan.SHS = this.soBienNhan.Text;
                    biennhan.LOAIDON = cbLoaiBN.SelectedValue + "";
                    biennhan.SONHA = sonha;
                    biennhan.DUONG = txtDuong.Text;
                    biennhan.PHUONG = phuong.MAPHUONG;
                    biennhan.QUAN = quan.MAQUAN;
                    biennhan.NGAYNHAN = DateTime.Now.Date;

                    if (checkHK.Checked)
                    {
                        biennhan.HKTK = true;
                    }
                    else
                    {
                        biennhan.HKTK = false;
                    }

                    if (checkChuQuyen.Checked)
                    {
                        biennhan.CHUQUYENNHA = true;
                    }
                    else
                    {
                        biennhan.CHUQUYENNHA = false;
                    }

                    if (checkGiayPhep.Checked)
                    {
                        biennhan.GIAYPHEPXD = true;
                    }
                    else
                    {
                        biennhan.GIAYPHEPXD = false;
                    }
                    biennhan.CREATEBY = DAL.C_USERS._userName;
                    biennhan.CREATEDATE = DateTime.Now;
                    DAL.C_BienNhanDon.InsertBienNhanDon(biennhan);
                    reset();
                }
            }
            catch (Exception ex)
            {
                log.Error("Lỗi Thêm Biên Nhận " + ex.Message);
                MessageBox.Show(this, "Thêm Biên Nhận Lỗi.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btLamLai_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void cbPhuong_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                List<PHUONG> phuong = DAL.C_Phuong.ListPhuongByTenPhuong(this.cbPhuong.Text);
                if (phuong.Count > 0)
                {
                    PHUONG p = phuong[0];
                    Quan.Text = p.QUAN.TENQUAN;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
