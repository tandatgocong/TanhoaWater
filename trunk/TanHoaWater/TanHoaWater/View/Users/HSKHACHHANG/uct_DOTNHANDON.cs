﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;
using TanHoaWater.View.Report;
using log4net;

namespace TanHoaWater.View.Users.HSKHACHHANG
{
    public partial class uct_DOTNHANDON : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(uct_DOTNHANDON).Name);
        string _madot_ = null;
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
            this.cbLoaiHS.DataSource = DAL.C_LOAIHOSO.getListCombobox();
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
            try
            {
                string madot = this.txtsoDot.Text.ToUpper();
                DateTime ngaylap = this.createDate.Value;
                string loaiDonNhan = this.cbLoaiHS.SelectedValue.ToString();
                if (madot.Length != 9)
                {
                    errorProvider1.SetError(this.txtsoDot, "Nhập đợt nhận đơn không hợp lệ.");
                }
                else if ("1/1/0001".Equals(ngaylap.ToShortDateString()))
                {
                    errorProvider1.SetError(this.createDate, "Ngày nhận đơn không hợp lệ.");
                }
                else if ("".Equals(loaiDonNhan))
                {
                    errorProvider1.SetError(this.cbLoaiHS, "Chọn loại nhận đơn.");
                }
                else if (DAL.C_DOTNHANDON.findByMaDot(madot) != null)
                {
                    errorProvider1.SetError(this.txtsoDot, "Số đợt đã tồn tại.");
                }
                else
                {
                    errorProvider1.Clear();
                    DOT_NHAN_DON dotnhan = new DOT_NHAN_DON();
                    dotnhan.MADOT = madot;
                    dotnhan.NGAYLAPDON = ngaylap;
                    dotnhan.LOAIDON = loaiDonNhan;
                    dotnhan.CREATEBY = DAL.Users._userName;
                    dotnhan.CREATEDATE = DateTime.Now;
                    dotnhan.CHUYENDON = false;
                    DAL.C_DOTNHANDON.InsertDot(dotnhan);
                    loadGrid();
                }
            }
            catch (Exception ex)
            {
                log.Error("Insert Dot KHACH HANG " + ex.Message);
            }           
  
        }
        public void loadGrid() {
            
            this.dataGridView1.DataSource = DAL.C_DOTNHANDON.getList();
        }
       

        private void SearchDot_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = DAL.C_DOTNHANDON.Search(this.txtsoDot.Text, this.createDate.Value, this.cbLoaiHS.SelectedValue.ToString());           
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

            this.detail.DataSource = DAL.C_DONKHACHHANG.getListbyDot(madot);
            sokh = DAL.C_DONKHACHHANG.getListbyDot(madot).Rows.Count;
            if (sokh > 0)
            {
                this.print.Visible = true;    
                this.checkCD.Visible = true; 
                
            }
            else {
                this.print.Visible = false;              
                this.checkCD.Visible = false; 
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string _madot = dataGridView1.Rows[e.RowIndex].Cells[0].Value != null ? dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() : null;
                loadDetail(_madot);
                this.lbSoKHNhanDon.Text = "Có " + sokh + " khách hàng đợt nhận đơn " + _madot;
                _madot_ = _madot;
            }
            catch (Exception ex){
                log.Error(ex.Message);
             }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                rpt_View rpt = new rpt_View(_madot_);
                rpt.ShowDialog();
            }
            catch (Exception ex)
            { log.Error("In Loi " + ex.Message); }

        }

        private void chyenTTK_Click(object sender, EventArgs e)
        {
            try
            {
                #region Update DOT NHAN DON
                string _madot = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value != null ? dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString() : null;
                DOT_NHAN_DON dot = DAL.C_DOTNHANDON.findByMaDot(_madot);
                dot.CHUYENDON = true;
                dot.NGAYCHUYEN = DateTime.Now;
                dot.NGUOICHUYEN = DAL.Users._userName;
                dot.BOPHANCHUYEN = this.cbBOPHAN.SelectedValue.ToString();
                DAL.C_DOTNHANDON.UpdateDot(dot);
                #endregion
                #region Update DON KHACH HANG
                for (int i = 0; i < detail.Rows.Count; i++) {
                    string sohoso = detail.Rows[i].Cells[0].Value != null ? detail.Rows[i].Cells[0].Value.ToString() : null;
                    if (sohoso != null) {
                        DON_KHACHHANG donkh = DAL.C_DONKHACHHANG.findBySOHOSO(sohoso);
                        if (donkh != null) {
                            donkh.CHUYEN_HOSO = true;
                            DAL.C_DONKHACHHANG.UpdateDONKH(donkh);
                        }
                    }
                }

                #endregion
              
            }
            catch (Exception ex)
            { log.Error("Chuyen TTT Loi " + ex.Message); }
            
        }

        private void checkCD_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCD.Checked == true) {
                this.cbBOPHAN.Visible = true;
                this.chyenTTK.Visible = true;
                this.cbBOPHAN.DataSource = DAL.C_PHONGBAN.getList();
                this.cbBOPHAN.DisplayMember = "TENPHONG";
                this.cbBOPHAN.ValueMember = "MAPHONG";
            } else {
                this.cbBOPHAN.Visible = false;
                this.chyenTTK.Visible = false;
                this.cbBOPHAN.DataSource = null;
            }
        }

        private void txtsoDot_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.txtsoDot.Text = this.txtsoDot.Text.ToUpper();

        }
    }
}
