using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;

namespace TanHoaWater.View.Users.HSKHACHHANG
{
    public partial class uct_DOTNHANDON : UserControl
    {

        public uct_DOTNHANDON()
        {
            InitializeComponent();
        }

        private void DOTNHANDON_Load(object sender, EventArgs e)
        {
            formLoad();
        }

        public void formLoad()
        {
            #region Load Combox Loai Ho So
            this.cbLoaiHS.DataSource = DAL.LOAIHOSO.getListCombobox();
            this.cbLoaiHS.DisplayMember = "Display";
            this.cbLoaiHS.ValueMember = "Value";            
            #endregion
            //#region Load Marsk TextBox
            //DateTime now = DateTime.Now;           
            //this.createDate.Value = now;
            //#endregion
            #region Load Data
                loadGrid();
            #endregion
        }

        private void addNewDot_Click(object sender, EventArgs e)
        {
            string madot = this.txtsoDot.Text;
            DateTime ngaylap = this.createDate.Value;
            string loaiDonNhan = this.cbLoaiHS.SelectedValue.ToString();
            if (madot.Length != 9)
            {
                errorProvider1.SetError(this.txtsoDot,"Nhập đợt nhận đơn không hợp lệ.");
            }else if ("1/1/0001".Equals(ngaylap.ToShortDateString()))
            {
                errorProvider1.SetError(this.createDate, "Ngày nhận đơn không hợp lệ.");
            }
            else if ("".Equals(loaiDonNhan))
            {
                errorProvider1.SetError(this.cbLoaiHS, "Chọn loại nhận đơn.");
            }
            else {
                errorProvider1.Clear();
                DOT_NHAN_DON dotnhan = new DOT_NHAN_DON();
                dotnhan.MADOT = madot;
                dotnhan.NGAYLAPDON = ngaylap;
                dotnhan.LOAIDON = loaiDonNhan;
                dotnhan.CREATEBY = DAL.Users._userName;
                dotnhan.CREATEDATE = DateTime.Now;
                dotnhan.CHUYENDON = false;
                DAL.DOTNHANDON.InsertDot(dotnhan);
                loadGrid();   
            }
  
        }
        public void loadGrid() {
            
            this.dataGridView1.DataSource = DAL.DOTNHANDON.getList();
        }
       

        private void SearchDot_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = DAL.DOTNHANDON.Search(this.txtsoDot.Text, this.createDate.Value, this.cbLoaiHS.SelectedValue.ToString());           
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            this.cbLoaiHS.SelectedIndex = 0;
            this.txtsoDot.Text = null;        
            this.createDate.ValueObject = null;
            this.loadGrid();
        }
        int sokh = 0;
        public void loadDetail(string madot) {

            this.detail.DataSource = DAL.DONKHACHHANG.getListbyDot(madot);
            sokh = DAL.DONKHACHHANG.getListbyDot(madot).Rows.Count;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string _madot = dataGridView1.Rows[e.RowIndex].Cells[0].Value != null ? dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() : null;
                loadDetail(_madot);
                this.lbSoKHNhanDon.Text = "Có " + sokh + " khách hàng đợt nhận đơn " + _madot;
            }
            catch (Exception){
             }
            
        }
    }
}
