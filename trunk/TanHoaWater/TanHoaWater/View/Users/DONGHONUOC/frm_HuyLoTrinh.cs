using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;

namespace TanHoaWater.View.Users.DONGHONUOC
{
    public partial class frm_HuyLoTrinh : Form
    {
        public frm_HuyLoTrinh()
        {
            InitializeComponent();
        }
        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                LoadThongTinDB();
            }
        }

        TB_DULIEUKHACHHANG khachhang = null;
        void LoadThongTinDB()
        {
            string sodanhbo = this.txtDanhBo.Text.Replace("-", "");
            if (sodanhbo.Length == 11)
            {
                khachhang = DULIEUKH.C_DuLieuKhachHang.finByDanhBo(sodanhbo);
                if (khachhang != null)
                {
                    LOTRINH.Text = khachhang.LOTRINH;
                    DOT.Text = khachhang.DOT;
                    HOPDONG.Text = khachhang.HOPDONG;
                    HOTEN.Text = khachhang.HOTEN;
                    SONHA.Text = khachhang.SONHA;
                    TENDUONG.Text = khachhang.TENDUONG;
                    txtDienThoai.Text = khachhang.DIENTHOAI;
                    try
                    {
                      QUAN q = DAL.C_Quan.finByMaQuan(int.Parse(khachhang.QUAN));
                        if (q != null)
                        {
                            QUAN.Text = q.TENQUAN;
                          PHUONG ph = DAL.C_Phuong.finbyPhuong(q.MAQUAN, khachhang.PHUONG.Trim());
                            PHUONGT.Text = ph.TENPHUONG;
                        }
                    }
                    catch (Exception)
                    {
                    }
                    txtHieuLuc.Text = String.Format("{0:00}", khachhang.KY) + "/" + khachhang.NAM;
                    GIABIEU.Text = khachhang.GIABIEU;
                    DINHMUC.Text = khachhang.DINHMUC;
                    NGAYGAN.ValueObject = khachhang.NGAYTHAY;
                    KIEMDINH.ValueObject = khachhang.NGAYKIEMDINH;
                    HIEUDH.Text = khachhang.HIEUDH;
                    CO.Text = khachhang.CODH;
                    CAP.Text = khachhang.CAP;
                    SOTHAN.Text = khachhang.SOTHANDH;
                    VITRI.Text = khachhang.VITRIDHN;
                    CHITHAN.Text = khachhang.CHITHAN;
                    CHIGOC.Text = khachhang.CHIGOC;
                    btCapNhatThongTin.Enabled = true;
                    txtGhiChu.Text = "";
                }
                
            }
        }

        public void Refesh()
        {
            LOTRINH.Text = "";
            DOT.Text = "";
            HOPDONG.Text = "";
            HOTEN.Text = "";
            SONHA.Text = "";
            TENDUONG.Text = "";
            QUAN.Text = "";
            PHUONGT.Text = "";
            GIABIEU.Text = "";
            DINHMUC.Text = "";
            NGAYGAN.ValueObject = DateTime.Now.Date;
            KIEMDINH.ValueObject = DateTime.Now.Date;
            HIEUDH.Text = "";
            CO.Text = "";
            CAP.Text = "";
            SOTHAN.Text = "";
            VITRI.Text = "";
            CHITHAN.Text = "";
            CHIGOC.Text = "";

            txtDanhBo.Focus();

        }

        private void btCapNhatThongTin_Click(object sender, EventArgs e)
        {
            if (khachhang != null)
            {
                if (MessageBox.Show(this, "Bạn Có Chắc Muốn Xóa Không ? ", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
                    DULIEUKH.C_GanMoi.ExecuteCommand_("DELETE FROM DocSo_PHT.dbo.KHACHHANG where danhba IN ('" + khachhang.DANHBO + "')");
                    DULIEUKH.C_GanMoi.ExecuteCommand_("DELETE FROM TB_DULIEUKHACHHANG WHERE danhbo IN ('" + khachhang.DANHBO + "')");
                    DULIEUKH.C_GanMoi.ExecuteCommand_("DELETE FROM TB_GANMOI WHERE danhbo IN ('" + khachhang.DANHBO + "')");
                    DULIEUKH.C_GanMoi.ExecuteCommand_("DELETE FROM TB_YEUCAUDC WHERE danhbo IN ('" + khachhang.DANHBO + "')");
                    MessageBox.Show(this, "Xóa Thông Tin Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            else
            {
                MessageBox.Show(this, "Xóa Thông Tin Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
