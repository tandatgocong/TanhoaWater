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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using TanHoaWater.View.Users.KEHOACH.Report;
using CrystalDecisions.Shared;
using TanHoaWater.View.Users.Report;

namespace TanHoaWater.View.Users.KEHOACH
{
    public partial class frm_BienNhanDon : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_BienNhanDon).Name);
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        public frm_BienNhanDon()
        {
            InitializeComponent();
            load();
            this.tabControl1.SelectedTabIndex = 0;
            this.txtHoTen.Focus();

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

                this.cbPhuong.DataSource = DAL.C_Phuong.getListPhuong();
                this.cbPhuong.DisplayMember = "Display";
                this.cbPhuong.ValueMember = "Value";
                
                //this.comboBoxEx1.DataSource = DAL.C_LoaiHoSo.getListCombobox();
                //this.comboBoxEx1.DisplayMember = "Display";
                //this.comboBoxEx1.ValueMember = "Value";    
                
                Quan.DataSource = DAL.C_Quan.getList();
                Quan.ValueMember = "MAQUAN";
                Quan.DisplayMember = "TENQUAN";
                this.cbPhuong.Text = "";
                this.Quan.Text = "";

               
                editTenDuong.AutoCompleteMode = AutoCompleteMode.Suggest;
                editTenDuong.AutoCompleteSource = AutoCompleteSource.CustomSource;
                editTenDuong.AutoCompleteCustomSource = namesCollection;

                this.editPhuong.DataSource = DAL.C_Phuong.getListPhuong();
                this.editPhuong.DisplayMember = "Display";
                this.editPhuong.ValueMember = "Value";

                //this.comboBoxEx1.DataSource = DAL.C_LoaiHoSo.getListCombobox();
                //this.comboBoxEx1.DisplayMember = "Display";
                //this.comboBoxEx1.ValueMember = "Value";    

                editQuan.DataSource = DAL.C_Quan.getList();
                editQuan.ValueMember = "MAQUAN";
                editQuan.DisplayMember = "TENQUAN";    

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
            if ((this.cbLoaiBN.SelectedValue + "").Equals("GM")) {
                groupDiDoi.Visible = false;
                groupganmoi.Visible = true;
            }
            else if ((this.cbLoaiBN.SelectedValue + "").Equals("DD"))
            {
                groupDiDoi.Visible = true;
                groupganmoi.Visible = false;
            }
            else {
                groupDiDoi.Visible = false;
                groupganmoi.Visible = false;
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

        public void reset()
        {
            this.soBienNhan.Text = DAL.Idetity.IdentityBienNhan(this.cbLoaiBN.SelectedValue + "");
            this.txtHoTen.Text = "";
            this.txtDt.Text = "";
            this.txtsonha.Text = "";
            this.txtDuong.Text = "";
            this.cbPhuong.Text = null;
            this.Quan.Text = null;

            this.cbPhuong.DataSource = DAL.C_Phuong.getListPhuong();
            this.cbPhuong.DisplayMember = "Display";
            this.cbPhuong.ValueMember = "Value";

            Quan.DataSource = DAL.C_Quan.getList();
            Quan.ValueMember = "MAQUAN";
            Quan.DisplayMember = "TENQUAN";

            checkHK.Checked = false; ;
            checkChuQuyen.Checked = false; ;
            checkGiayPhepXD.Checked = false;
            checkGiayPhepKD.Checked = false;
            GM_giaytokhac.Checked = false;
            DD_GiayToKhac.Checked = false;
            checkBienLaiTN.Checked = false;
            checkSoTTKT3.Checked = false;
            this.txtHoTen.Focus();

        }

        public void printingBienNhan(string mabiennhan, string dienthoai, string user)
        {
          // CrystalReportViewer r = new CrystalReportViewer();
           ReportDocument rp = new crp_BIENNHAN_GM();
           if (mabiennhan.Contains("DD"))
            {
                rp = new crp_BIENNHAN_DD();
            }
           rp.PrintOptions.PaperSize = PaperSize.Paper11x17;
           rp.SetDataSource(DAL.C_BienNhanDon.printBienNhan(mabiennhan, user));
           rp.SetParameterValue("dienthoai", dienthoai);
            rpt_InBienNhan  inp = new rpt_InBienNhan(rp);
            inp.ShowDialog();
          // r.ReportSource = rp; 
         // r.PrintReport();

        }
        private void btBienNhanDon_Click(object sender, EventArgs e)
        {
            try
            {
                string loaihs = cbLoaiBN.SelectedValue + "";
                string soshs = this.soBienNhan.Text.ToUpper();
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
                    MessageBox.Show(this, "Nhập Họ Tên.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtHoTen.Focus();
                }
                else if ("".Equals(sonha))
                {
                    MessageBox.Show(this, "Nhập Số Nhà.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtsonha.Focus();
                }
                else if ("".Equals(tenduong))
                {
                    MessageBox.Show(this, "Nhập Tên Đường.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtDuong.Focus();
                }
                else if (quan == null)
                {
                    MessageBox.Show(this, "Chọn Quận.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Quan.Select();
                }
                else if (phuong == null)
                {
                    cbPhuong.DataSource = DAL.C_Phuong.getListByQuan(quan.MAQUAN);
                    cbPhuong.ValueMember = "MAPHUONG";
                    cbPhuong.DisplayMember = "TENPHUONG";
                    MessageBox.Show(this, "Chọn Phường.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.cbPhuong.Select();
                }
                else
                {
                    if (DAL.C_DonKhachHang.findByAddressAndLoaiHS("", loaihs, sonha, tenduong, phuong.MAPHUONG, "" + quan.MAQUAN))
                    {
                        if (MessageBox.Show(this, "Địa Chỉ Khách Hàng Đã Được Nhận Đơn. Có Muốn Thêm Mới Hồ Sơ ?", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            BIENNHANDON biennhan = new BIENNHANDON();
                            biennhan.SHS = this.soBienNhan.Text;
                            biennhan.LOAIDON = cbLoaiBN.SelectedValue + "";
                            biennhan.HOTEN = hoten;
                            biennhan.SONHA = sonha;
                            biennhan.DUONG = txtDuong.Text;
                            biennhan.PHUONG = phuong.MAPHUONG;
                            biennhan.QUAN = quan.MAQUAN;
                            biennhan.NGAYNHAN = DateTime.Now.Date;
                            biennhan.SOHO = int.Parse(this.numericUpDown1.Value + "");
                            biennhan.DIENTHOAI = txtDt.Text;
                            //1
                            if (checkHK.Checked)
                            {
                                biennhan.HKTK = true;
                            }
                            else
                            {
                                biennhan.HKTK = false;
                            }
                            //2
                            if (checkChuQuyen.Checked)
                            {
                                biennhan.CHUQUYENNHA = true;
                            }
                            else
                            {
                                biennhan.CHUQUYENNHA = false;
                            }
                            //3
                            if (checkGiayPhepXD.Checked)
                            {
                                biennhan.GIAYPHEPXD = true;
                            }
                            else
                            {
                                biennhan.GIAYPHEPXD = false;
                            }
                            //4
                            if (checkSoTTKT3.Checked)
                            {
                                biennhan.TAMTRU = true;
                            }
                            else
                            {
                                biennhan.TAMTRU = false;
                            }
                            //5
                            if (checkGiayPhepKD.Checked)
                            {
                                biennhan.GIAYPHEPKD = true;
                            }
                            else
                            {
                                biennhan.GIAYPHEPKD = false;
                            }
                            //6
                            if (GM_giaytokhac.Checked)
                            {
                                biennhan.GIAYTOKHAC = true;
                            }
                            else
                            {
                                biennhan.GIAYTOKHAC = false;
                            }
                            if ((cbLoaiBN.SelectedValue + "").Equals("DD"))
                            {
                                if (DD_GiayToKhac.Checked)
                                {
                                    biennhan.GIAYTOKHAC = true;
                                }
                                else
                                {
                                    biennhan.GIAYTOKHAC = false;
                                }
                                //8
                                if (checkBienLaiTN.Checked)
                                {
                                    biennhan.BIENLAITIENUOC = true;
                                }
                                else
                                {
                                    biennhan.BIENLAITIENUOC = false;
                                }
                            }
                            biennhan.CREATEBY = DAL.C_USERS._userName;
                            biennhan.CREATEDATE = DateTime.Now;
                            DAL.C_BienNhanDon.InsertBienNhanDon(biennhan);
                            printingBienNhan(biennhan.SHS, biennhan.DIENTHOAI, DAL.C_USERS._userName);
                            reset();
                        }
                    }
                    else {
                        BIENNHANDON biennhan = new BIENNHANDON();
                        biennhan.SHS = this.soBienNhan.Text;
                        biennhan.LOAIDON = cbLoaiBN.SelectedValue + "";
                        biennhan.HOTEN = hoten;
                        biennhan.SONHA = sonha;
                        biennhan.DUONG = txtDuong.Text;
                        biennhan.PHUONG = phuong.MAPHUONG;
                        biennhan.QUAN = quan.MAQUAN;
                        biennhan.NGAYNHAN = DateTime.Now.Date;
                        biennhan.SOHO = int.Parse(this.numericUpDown1.Value + "");
                        biennhan.DIENTHOAI = txtDt.Text;
                        //1
                        if (checkHK.Checked)
                        {
                            biennhan.HKTK = true;
                        }
                        else
                        {
                            biennhan.HKTK = false;
                        }
                        //2
                        if (checkChuQuyen.Checked)
                        {
                            biennhan.CHUQUYENNHA = true;
                        }
                        else
                        {
                            biennhan.CHUQUYENNHA = false;
                        }
                        //3
                        if (checkGiayPhepXD.Checked)
                        {
                            biennhan.GIAYPHEPXD = true;
                        }
                        else
                        {
                            biennhan.GIAYPHEPXD = false;
                        }
                        //4
                        if (checkSoTTKT3.Checked)
                        {
                            biennhan.TAMTRU = true;
                        }
                        else
                        {
                            biennhan.TAMTRU = false;
                        }
                        //5
                        if (checkGiayPhepKD.Checked)
                        {
                            biennhan.GIAYPHEPKD = true;
                        }
                        else
                        {
                            biennhan.GIAYPHEPKD = false;
                        }
                        //6
                        if (GM_giaytokhac.Checked)
                        {
                            biennhan.GIAYTOKHAC = true;
                        }
                        else
                        {
                            biennhan.GIAYTOKHAC = false;
                        }
                        if ((cbLoaiBN.SelectedValue + "").Equals("DD"))
                        {
                            if (DD_GiayToKhac.Checked)
                            {
                                biennhan.GIAYTOKHAC = true;
                            }
                            else
                            {
                                biennhan.GIAYTOKHAC = false;
                            }
                            //8
                            if (checkBienLaiTN.Checked)
                            {
                                biennhan.BIENLAITIENUOC = true;
                            }
                            else
                            {
                                biennhan.BIENLAITIENUOC = false;
                            }
                        }
                        biennhan.CREATEBY = DAL.C_USERS._userName;
                        biennhan.CREATEDATE = DateTime.Now;
                        DAL.C_BienNhanDon.InsertBienNhanDon(biennhan);
                        printingBienNhan(biennhan.SHS, biennhan.DIENTHOAI, DAL.C_USERS._userName);
                        reset();
                    
                    }
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
            catch (Exception )
            {
               
            }
        }
        public void baocao()
        {
            this.dataGridViewDC.DataSource = DAL.C_BienNhanDon.BaoCaoTinhHinhNhanDon(Utilities.DateToString.NgayVN(tungay), Utilities.DateToString.NgayVN(denngay));
            this.lbTotalNhanDon.Text = "Tổng số có " + DAL.C_BienNhanDon.totalDon(Utilities.DateToString.NgayVN(tungay), Utilities.DateToString.NgayVN(denngay)) + " biên nhận đơn. Trong đó:";            
        }

        private void tabItem2_Click(object sender, EventArgs e)
        {
            
        }

      
        private void buttonX1_Click(object sender, EventArgs e)
        {
            baocao();
        }

        public void resetedit()
        {

            editSoBN.Text = "";
            editLoaiBN.Text = "";
            editHoTen.Text = "";
            editSoNha.Text = "";
            editTenDuong.Text = "";
            editDienThoai.Text = null;
            editPhuong.Text = null;
            editQuan.Text = null;

            eddit_checkhokhau.Checked = false;
            editcheckchuquyennha.Checked = false;
            edit_giayphepxd.Checked = false;
            edit_tamtrukt3.Checked = false;
            edit_giayphepkd.Checked = false;
            editgiaytokhac.Checked = false;
            editddgiaytokhac.Checked = false;
            editbienlaithutien.Checked = false;

            editSoBN.Focus();

        }
        int soho = 0;
        private void editSoBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {

                if (!"".Equals(this.editSoBN.Text))
                {
                    BIENNHANDON biennhan = DAL.C_BienNhanDon.finbyMabienNhanEdit(this.editSoBN.Text);
                    if (biennhan != null)
                    {
                        if(biennhan.LOAIDON.Equals("DD")){
                            editGM.Visible = false;
                            editDD.Visible = true;
                        }else{
                            editGM.Visible = true;
                            editDD.Visible = false;
                        }

                        editSoho.Value = biennhan.SOHO.Value;
                        soho = biennhan.SOHO.Value; ;
                        editSoBN.Text = biennhan.SHS;
                        editLoaiBN.Text = biennhan.LOAI_NHANDON.TENLOAI;
                        editHoTen.Text = biennhan.HOTEN;
                        editSoNha.Text = biennhan.SONHA;
                        editDienThoai.Text = biennhan.DIENTHOAI;
                        editTenDuong.Text = biennhan.DUONG;
                        QUAN q = DAL.C_Quan.finByMaQuan(biennhan.QUAN);
                        editQuan.Text = q.TENQUAN;
                        editPhuong.Text = DAL.C_Phuong.finbyPhuong(q.MAQUAN, biennhan.PHUONG).TENPHUONG ;
                        try
                        {
                            eddit_checkhokhau.Checked = bool.Parse(biennhan.HKTK + "");
                            editcheckchuquyennha.Checked = bool.Parse(biennhan.CHUQUYENNHA + "");
                            edit_giayphepxd.Checked = bool.Parse(biennhan.GIAYPHEPXD + "");
                            edit_tamtrukt3.Checked = bool.Parse(biennhan.TAMTRU + "");
                            edit_giayphepkd.Checked = bool.Parse(biennhan.GIAYPHEPKD + "");
                            editgiaytokhac.Checked = bool.Parse(biennhan.GIAYTOKHAC + "");
                        }
                        catch (Exception)
                        {
                        }
                        try
                        {
                            editddgiaytokhac.Checked = bool.Parse(biennhan.GIAYTOKHAC + "");
                            editbienlaithutien.Checked = bool.Parse(biennhan.BIENLAITIENUOC + "");
                        }
                        catch (Exception)
                        {
                        }
                    }
                    else {
                        MessageBox.Show(this, "Không Tìm Thấy Biên Nhận !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        resetedit();
                    }

                }
                else {
                    MessageBox.Show(this, "Nhập Số Biên Nhận KH ?", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.editSoBN.Focus();
                }
            }
        }

        private void tabItem3_Click(object sender, EventArgs e)
        {
            this.editSoBN.Mask = "CCCCCCCC";
            editSoBN.Focus();
        }

        private void btEditLamLai_Click(object sender, EventArgs e)
        {
            resetedit();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string soshs = this.editSoBN.Text;
                string hoten = this.editHoTen.Text;
                string sonha = this.editSoNha.Text;
                string tenduong = this.editTenDuong.Text;
                string tenphuong = this.editPhuong.Text;
                string tenquan = this.editQuan.Text;
                QUAN quan = DAL.C_Quan.finbyTenQuan(tenquan);
                PHUONG phuong = null;
                if (quan != null)
                {
                    phuong = DAL.C_Phuong.finbyTenPhuong(quan.MAQUAN, tenphuong);
                }
                if ("".Equals(hoten))
                {
                    MessageBox.Show(this, "Nhập Họ Tên.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.editHoTen.Focus();
                }
                else if ("".Equals(sonha))
                {
                    MessageBox.Show(this, "Nhập Số Nhà.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.editSoNha.Focus();
                }
                else if ("".Equals(tenduong))
                {
                    MessageBox.Show(this, "Nhập Số Nhà.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtDuong.Focus();
                }
                else if (quan == null)
                {
                    MessageBox.Show(this, "Chọn Quận.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.editQuan.Select();
                }
                else if (phuong == null)
                {
                    editPhuong.DataSource = DAL.C_Phuong.getListByQuan(quan.MAQUAN);
                    editPhuong.ValueMember = "MAPHUONG";
                    editPhuong.DisplayMember = "TENPHUONG";
                    MessageBox.Show(this, "Chọn Phường.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.editPhuong.Select();
                }
                else
                {

                    BIENNHANDON biennhan = DAL.C_BienNhanDon.finbyMabienNhanEdit(soshs);
                    if (biennhan != null)
                    {
                      
                        biennhan.HOTEN = hoten;
                        biennhan.SONHA = sonha;
                        biennhan.DUONG = tenduong;
                        biennhan.PHUONG = phuong.MAPHUONG;
                        biennhan.QUAN = quan.MAQUAN;
                        biennhan.DIENTHOAI = editDienThoai.Text;
                        //1
                        if (eddit_checkhokhau.Checked)
                        {
                            biennhan.HKTK = true;
                        }
                        else
                        {
                            biennhan.HKTK = false;
                        }
                        //2
                        if (editcheckchuquyennha.Checked)
                        {
                            biennhan.CHUQUYENNHA = true;
                        }
                        else
                        {
                            biennhan.CHUQUYENNHA = false;
                        }
                        //3
                        if (edit_giayphepxd.Checked)
                        {
                            biennhan.GIAYPHEPXD = true;
                        }
                        else
                        {
                            biennhan.GIAYPHEPXD = false;
                        }
                        //4
                        if (edit_tamtrukt3.Checked)
                        {
                            biennhan.TAMTRU = true;
                        }
                        else
                        {
                            biennhan.TAMTRU = false;
                        }
                        //5
                        if (edit_giayphepkd.Checked)
                        {
                            biennhan.GIAYPHEPKD = true;
                        }
                        else
                        {
                            biennhan.GIAYPHEPKD = false;
                        }
                        //6
                        if (editgiaytokhac.Checked)
                        {
                            biennhan.GIAYTOKHAC = true;
                        }
                        else
                        {
                            biennhan.GIAYTOKHAC = false;
                        }
                        if (biennhan.LOAIDON.Equals("DD"))
                        {
                            //7
                            if (editddgiaytokhac.Checked)
                            {
                                biennhan.GIAYTOKHAC = true;
                            }
                            else
                            {
                                biennhan.GIAYTOKHAC = false;
                            }
                            //8
                            if (editbienlaithutien.Checked)
                            {
                                biennhan.BIENLAITIENUOC = true;
                            }
                            else
                            {
                                biennhan.BIENLAITIENUOC = false;
                            }
                        }
                       
                        biennhan.MODIFYBY = DAL.C_USERS._userName;
                        biennhan.MODIFYDATE = DateTime.Now;
                        DON_KHACHHANG donkh=  DAL.C_DonKhachHang.findBySOHOSO(biennhan.SHS);
                        bool flag = true;
                        if (donkh != null)
                        {
                            flag = DAL.C_DonKhachHang.updateDoninBienNhan(biennhan.SHS, biennhan.HOTEN, biennhan.DIENTHOAI, biennhan.SONHA, biennhan.DUONG, biennhan.PHUONG, biennhan.QUAN);
                        }
                        if (flag  == true && DAL.C_BienNhanDon.UpdateDonKH())
                        {
                            
                            MessageBox.Show(this, "Cập Nhật Biên Nhận Thành Công!", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //printingBienNhan(biennhan.SHS, DAL.C_USERS._userName);
                            //resetedit();
                        } else {
                            MessageBox.Show(this, "Cập Nhật Biên Nhận Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                      

                    }
                    else {
                        MessageBox.Show(this, "Không Tìm Thấy Số Biên Nhận !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.editSoBN.Focus();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                log.Error("Lỗi Edit Biên Nhận " + ex.Message);
                MessageBox.Show(this, "Cập Nhật Biên Nhận Lỗi.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void inreview(string maquan, string maloai)
        {
            ReportDocument rp = new rpt_BaoCaoTinhHinhNhanDon();
            rp.SetDataSource(DAL.C_BienNhanDon.ViewBaoCao(maquan,maloai, Utilities.DateToString.NgayVN(tungay), Utilities.DateToString.NgayVN(denngay)));
            rpt_Main rpt = new rpt_Main(rp);
            rpt.ShowDialog();
            
        }
        private void dataGridViewDC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == 7)
            {
                string maquan = dataGridViewDC.Rows[e.RowIndex].Cells[2].Value + "";
                string maloai = dataGridViewDC.Rows[e.RowIndex].Cells[3].Value + "";
                inreview(maquan, maloai);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //if (numericUpDown1.Value > 1)
            //{
            //    txtHoTen.Text = txtHoTen.Text  +" (ĐD " + numericUpDown1.Value + " Hộ)";
            //}
        }

        private void btInBN(object sender, EventArgs e)
        {
            printingBienNhan(editSoBN.Text, editDienThoai.Text, DAL.C_USERS._userName);
        }

        private void numericUpDown1_Leave(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 1)
            {
                txtHoTen.Text = txtHoTen.Text + " (ĐD " + numericUpDown1.Value + " Hộ)";
            }
        }

        private void editSoho_Leave(object sender, EventArgs e)
        {
            if (editSoho.Value > 1)
            {
                txtHoTen.Text = txtHoTen.Text.Replace(" (ĐD " + soho + " Hộ)","") + " (ĐD " + editSoho.Value + " Hộ)";
            }
        }
    }
}
