using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;

namespace TanHoaWater.View.QLDHN
{
    public partial class controlAddLich : UserControl
    {
        public controlAddLich()
        {
            InitializeComponent();
            try
            {
                loadCombobox();
                for (int i = 0; i < dtg2.ColumnCount; i++)
                {                   
                    dtg2.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Lỗi kết nối database, kiểm tra quá trình kết nối !!", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
            }
        }
        public void frmVisible(bool value)
        {
            this.cbDot.Visible = value;
            this.cbKy.Visible = value;

            this.cbPhuong.Visible = value;
            this.cbQuan.Visible = value;
            this.calendar.Visible = value;
        }

        public void loadCombobox()
        {
            #region Load Combobox Nam
            int year = DateTime.Now.Year;
            this.nam.Items.Add(year - 1);
            this.nam.Items.Add(year);
            this.nam.Items.Add(year + 1);
            this.nam.SelectedIndex = 1;
            #endregion

            #region Load Combobox Quan
            TanHoaDataContext data = new TanHoaDataContext();
            var quan = from p in data.QUANs select p;
            this.cbQuan.DataSource = quan.ToList();
            cbQuan.DisplayMember = "TENQUAN";
            cbQuan.ValueMember = "MAQUAN";
            #endregion


        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmVisible(false);
            if (e.RowIndex < 0) return;
            else if (e.ColumnIndex == 0)
            {
                cbQuan.Visible = true;
                cbQuan.Top = dtg2.Top + dtg2.GetRowDisplayRectangle(e.RowIndex, true).Top; ;
                cbQuan.Left = dtg2.Left + dtg2.GetColumnDisplayRectangle(e.ColumnIndex, true).Left; ;
                cbQuan.Width = dtg2.Columns[e.ColumnIndex].Width;
                cbQuan.Height = dtg2.Rows[e.RowIndex].Height;
                cbQuan.BringToFront();
                //cb.SelectedValue = dtg2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
            else if (e.ColumnIndex == 1)
            {
                cbPhuong.Visible = true;
                cbPhuong.Top = dtg2.Top + dtg2.GetRowDisplayRectangle(e.RowIndex, true).Top; ;
                cbPhuong.Left = dtg2.Left + dtg2.GetColumnDisplayRectangle(e.ColumnIndex, true).Left; ;
                cbPhuong.Width = dtg2.Columns[e.ColumnIndex].Width;
                cbPhuong.Height = dtg2.Rows[e.RowIndex].Height;
                cbPhuong.BringToFront();
            }
            else if (e.ColumnIndex == 2)
            {
                cbKy.Visible = true;
                cbKy.Top = dtg2.Top + dtg2.GetRowDisplayRectangle(e.RowIndex, true).Top; ;
                cbKy.Left = dtg2.Left + dtg2.GetColumnDisplayRectangle(e.ColumnIndex, true).Left; ;
                cbKy.Width = dtg2.Columns[e.ColumnIndex].Width;
                cbKy.Height = dtg2.Rows[e.RowIndex].Height;
                cbKy.BringToFront();
            }
            else if (e.ColumnIndex == 3)
            {
                cbDot.Visible = true;
                cbDot.Top = dtg2.Top + dtg2.GetRowDisplayRectangle(e.RowIndex, true).Top; ;
                cbDot.Left = dtg2.Left + dtg2.GetColumnDisplayRectangle(e.ColumnIndex, true).Left; ;
                cbDot.Width = dtg2.Columns[e.ColumnIndex].Width;
                cbDot.Height = dtg2.Rows[e.RowIndex].Height;
                cbDot.BringToFront();
            }
            else if (e.ColumnIndex == 4)
            {
                calendar.Visible = true;
                calendar.Top = dtg2.Top + dtg2.GetRowDisplayRectangle(e.RowIndex, true).Top; ;
                calendar.Left = dtg2.Left + dtg2.GetColumnDisplayRectangle(e.ColumnIndex, true).Left; ;
                calendar.Width = dtg2.Columns[e.ColumnIndex].Width;
                calendar.Height = dtg2.Rows[e.RowIndex].Height;
                calendar.BringToFront();
            }

        }

        private void cbQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dtg2.Rows[dtg2.CurrentCell.RowIndex].Cells[dtg2.CurrentCell.ColumnIndex].Value = cbQuan.Text;
            }
            catch (Exception)
            {


            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dtg2.Rows.Insert(dtg2.CurrentCell.RowIndex, 1);
            }
            catch (Exception)
            {


            }

        }

        private void cbPhuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dtg2.Rows[dtg2.CurrentCell.RowIndex].Cells[dtg2.CurrentCell.ColumnIndex].Value = cbPhuong.Text;
            }
            catch (Exception)
            {


            }

        }


        private void cbKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dtg2.Rows[dtg2.CurrentCell.RowIndex].Cells[dtg2.CurrentCell.ColumnIndex].Value = cbKy.Text;
            }
            catch (Exception)
            {


            }

        }

        private void cbDot_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dtg2.Rows[dtg2.CurrentCell.RowIndex].Cells[dtg2.CurrentCell.ColumnIndex].Value = cbDot.Text;
            }
            catch (Exception)
            {


            }

        }

        private void calendar_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtg2.Rows[dtg2.CurrentCell.RowIndex].Cells[dtg2.CurrentCell.ColumnIndex].Value = calendar.Value.ToShortDateString();
            }
            catch (Exception)
            {

            }

        }

        private void cbQuan_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                #region Load Combobox Phuong
                TanHoaDataContext data = new TanHoaDataContext();
                var quan = from p in data.PHUONGs where p.MAQUAN == int.Parse(this.cbQuan.SelectedValue.ToString()) select p;
                this.cbPhuong.DataSource = quan.ToList();
                cbPhuong.DisplayMember = "TENPHUONG";
                cbPhuong.ValueMember = "MAPHUONG";
                #endregion
            }
            catch (Exception)
            {

            }

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Có thực sự muốn hủy ?", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                dtg2.Rows.Clear();

        }

        int getMaQuan(TanHoaDataContext data, string tenquan)
        {
            var quan = from p in data.QUANs where p.TENQUAN == tenquan select p.MAQUAN;
            return quan.Single();
        }
        string getMaPhuong(TanHoaDataContext data, int maQuan, string tenphuong)
        {
            var quan = from p in data.PHUONGs where p.MAQUAN == maQuan && p.TENPHUONG == tenphuong select p.MAPHUONG;
            return quan.Single();
        }

        bool checkPrimaryKey(TanHoaDataContext data, int maQuan, string maphuong, int ky, int dot)
        {
            var result = from p in data.LICHDOCSOs where p.MAQUAN == maQuan && p.MAPHUONG == maphuong && p.KY == ky && p.DOT == dot select p.ID;
            if (result.ToList() == null || result.ToList().Count == 0)
                return true;
            return false;

        }
        private void btSave_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show(this, "Lưu Lịch Ghi Chỉ Số Nước ?", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int recordSuccess = 0;
                    int recordFaild = 0;
                    TanHoaDataContext data = new TanHoaDataContext();
                    for (int i = 0; i < dtg2.Rows.Count; i++)
                    {
                        LICHDOCSO ldso = new LICHDOCSO();
                        ldso.MAQUAN = getMaQuan(data, this.dtg2.Rows[i].Cells[0].Value != null ? this.dtg2.Rows[i].Cells[0].Value.ToString() : "");
                        ldso.MAPHUONG = getMaPhuong(data, ldso.MAQUAN, this.dtg2.Rows[i].Cells[1].Value != null ? this.dtg2.Rows[i].Cells[1].Value.ToString() : "");
                        ldso.KY = this.dtg2.Rows[i].Cells[2].Value != null ? int.Parse(this.dtg2.Rows[i].Cells[2].Value.ToString()) : 0;
                        ldso.NAM = this.nam.SelectedItem != null ? int.Parse(this.nam.SelectedItem.ToString()) : 0;
                        ldso.DOT = this.dtg2.Rows[i].Cells[3].Value != null ? int.Parse(this.dtg2.Rows[i].Cells[3].Value.ToString()) : 0;
                        ldso.NGAY = this.dtg2.Rows[i].Cells[4].Value != null ? DateTime.Parse(this.dtg2.Rows[i].Cells[4].Value.ToString()) : DateTime.Now;
                        if (checkPrimaryKey(data, ldso.MAQUAN, ldso.MAPHUONG, ldso.KY, ldso.DOT) == true)
                        {
                            data.LICHDOCSOs.InsertOnSubmit(ldso);
                            recordSuccess++;
                        }
                        else
                        {
                            recordFaild++;
                        }
                    }
                    data.SubmitChanges();

                    MessageBox.Show(this, "Có " + recordSuccess + " dòng thêm thành công và có " + recordFaild + " dòng lỗi.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtg2.Rows.Clear();
                }
                catch (Exception)
                {

                    MessageBox.Show(this, "Có Lỗi !!", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void dtg2_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtg2.Rows[e.RowIndex].Cells[0].Value == null)
            {
                this.dtg2.Rows[e.RowIndex].Cells[0].ErrorText = "Dữ liệu không được trống.";
            }
            else
            {
                this.dtg2.Rows[e.RowIndex].Cells[0].ErrorText = null;
            }
            if (this.dtg2.Rows[e.RowIndex].Cells[1].Value == null)
            {
                this.dtg2.Rows[e.RowIndex].Cells[1].ErrorText = "Dữ liệu không được trống.";
            }
            else
            {
                this.dtg2.Rows[e.RowIndex].Cells[1].ErrorText = null;
            }
            if (this.dtg2.Rows[e.RowIndex].Cells[2].Value == null || Convert.ToInt16(this.dtg2.Rows[e.RowIndex].Cells[2].Value.ToString()) <= 0)
            {
                this.dtg2.Rows[e.RowIndex].Cells[2].ErrorText = "Dữ liệu không được trống.";

            }
            else
            {
                this.dtg2.Rows[e.RowIndex].Cells[2].ErrorText = null;
            }

            if (this.dtg2.Rows[e.RowIndex].Cells[3].Value == null || Convert.ToInt16(this.dtg2.Rows[e.RowIndex].Cells[3].Value.ToString()) <= 0)
            {
                this.dtg2.Rows[e.RowIndex].Cells[3].ErrorText = "Dữ liệu không được trống.";

            }
            else
            {
                this.dtg2.Rows[e.RowIndex].Cells[3].ErrorText = null;
            }

            if (this.dtg2.Rows[e.RowIndex].Cells[4].Value == null)
            {
                this.dtg2.Rows[e.RowIndex].Cells[4].ErrorText = "Dữ liệu không được trống.";
            }
            else
            {
                this.dtg2.Rows[e.RowIndex].Cells[4].ErrorText = null;
            }
        }
    }
}
