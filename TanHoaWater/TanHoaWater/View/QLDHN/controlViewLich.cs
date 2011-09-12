using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;
using System.Collections;
using TanHoaWater.Utilities;
using System.Data.SqlClient;

namespace TanHoaWater.View.QLDHN
{
    public partial class controlViewLich : UserControl
    {
        public controlViewLich()
        {
            InitializeComponent();
           
            try
            {
                for (int i = 0; i < dtgSearch.ColumnCount; i++)
                {
                    dtgSearch.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                loadCombobox();
                loadDataGird();


            }
            catch (Exception)
            {
                MessageBox.Show(this, "Lỗi kết nối database, kiểm tra quá trình kết nối !!", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
            }
        }
        public void loadDataGird()
        {
            //TanHoaDataContext db = new TanHoaDataContext();
            //var data = from lich in db.LICHDOCSOs
            //           join quan in db.QUANs on lich.MAQUAN equals quan.MAQUAN
            //           join phuong in db.PHUONGs on lich.MAQUAN equals phuong.MAQUAN
            //           where lich.MAQUAN == phuong.MAQUAN && lich.MAPHUONG == phuong.MAPHUONG && lich.NAM == DateTime.Now.Year
            //           select new { lich.ID, quan.TENQUAN, phuong.TENPHUONG, lich.KY, lich.NAM, lich.DOT, lich.NGAY };
            //dtgSearch.DataSource = data.ToList();
            search();
            
        }

        public void loadCombobox()
        {
            #region Load Combobox Nam
            int year = DateTime.Now.Year;
            this.cbNam.Items.Add(year - 1);
            this.cbNam.Items.Add(year);
            this.cbNam.Items.Add(year + 1);
            editNam.Items.Clear();
            this.editNam.Items.Add(year - 1);
            this.editNam.Items.Add(year);
            this.editNam.Items.Add(year + 1);
            this.editNam.SelectedIndex = 1;

            #endregion

            #region Load Combobox Quan

            TanHoaDataContext db = new TanHoaDataContext();
            var data = from lich in db.QUANs select lich;
            ArrayList list = new ArrayList();
            list.Add(new AddValueCombox("  Chọn Quận  ", ""));
            foreach (var a in data)
            {
                list.Add(new AddValueCombox(a.TENQUAN, a.MAQUAN.ToString()));
            }
            cbQuan.DataSource = list;
            this.cbQuan.DisplayMember = "Display";
            this.cbQuan.ValueMember = "Value";
            #endregion
        }

        private void btUndo_Click(object sender, EventArgs e)
        {
            this.cbPhuong.DataSource = null;
            this.cbQuan.SelectedIndex = 0;
            this.cbNam.Text = null;
            this.cbDot.Text = null;
            this.cbKy.Text = null;
            this.calendar.ValueObject = null;
            this.loadDataGird();
        }

        private void cbQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbQuan.SelectedIndex != 0)
            {
                #region Load Combobox Phuong
                TanHoaDataContext data = new TanHoaDataContext();
                var phuong = from p in data.PHUONGs where p.MAQUAN == int.Parse(this.cbQuan.SelectedValue.ToString()) select p;
                ArrayList list = new ArrayList();
                list.Add(new AddValueCombox("  Chọn Phường  ", ""));
                foreach (var a in phuong)
                {
                    list.Add(new AddValueCombox(a.TENPHUONG, a.MAPHUONG));
                }
                cbPhuong.DataSource = list;
                this.cbPhuong.DisplayMember = "Display";
                this.cbPhuong.ValueMember = "Value";
                #endregion
            }
        }

        public void search()
        {
            TanHoaDataContext db = new TanHoaDataContext();
            try
            {
                dtgSearch.DataSource = null;
                db.Connection.Open();
                string sql = "SELECT ID, TENQUAN as 'Quận', TENPHUONG as 'Phường', KY as 'Kỳ', NAM as 'Năm', DOT as 'Đợt', NGAY as 'Ngày'";
              //  string sql = "SELECT ID, TENQUAN , TENPHUONG, KY, NAM, DOT, NGAY ";
                sql += "FROM LICHDOCSO as lich, PHUONG as phuong, QUAN as quan  ";
                sql += " WHERE lich.MAPHUONG = phuong.MAPHUONG AND lich.MAQUAN= quan.MAQUAN AND phuong.MAQUAN = quan.MAQUAN ";
                if (this.cbQuan.SelectedIndex != 0 )
                    sql += " AND lich.MAQUAN=" + this.cbQuan.SelectedValue;
                if (this.cbPhuong.SelectedIndex != 0 && this.cbPhuong.Text != null && !"".Equals(this.cbPhuong.Text))
                    sql += " AND lich.MAPHUONG=" + this.cbPhuong.SelectedValue;
                if (this.cbKy.Text != null && !"".Equals(this.cbKy.Text))
                    sql += " AND lich.KY=" + this.cbKy.Text.Trim();
                if (this.cbNam.Text != null && !"".Equals(this.cbNam.Text))
                    sql += " AND lich.NAM=" + this.cbNam.Text.Trim();
                if (this.cbDot.Text != null && !"".Equals(this.cbDot.Text))
                    sql += " AND lich.DOT=" + this.cbDot.Text.Trim();
                if (!"1/1/0001".Equals(calendar.Value.ToShortDateString()))
                    sql += " AND lich.NGAY='" + calendar.Value.ToShortDateString() + "' ";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dtgSearch.DataSource = table;
                dtgSearch.AllowUserToAddRows = false;
                formatDataGird(dtgSearch);
                if (this.dtgSearch.Rows.Count>0)
                 {
                       this.delete.Visible = true;
                       this.update.Visible = true;
                 }
                 else
                 {     this.delete.Visible = false;
                       this.update.Visible = false;
                 }
            }
            catch (Exception)
            { }
            finally
            {
                db.Connection.Close();
            }
        }
        private void btSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        public void formatDataGird(DataGridView dt)
        {
            dtgSearch.Columns["ID"].Visible = false;
            dtgSearch.AllowUserToOrderColumns = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i].Cells[0].ReadOnly = true;
                dt.Rows[i].Cells[1].ReadOnly = true;
                dt.Rows[i].Cells[2].ReadOnly = true;
                dt.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                for (int j = 2; j < dt.Rows[i].Cells.Count; j++)
                {
                    dt.Rows[i].Cells[j].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            for (int i = 0; i < dtgSearch.ColumnCount; i++)
            {
                dtgSearch.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(this.dtgSearch.Rows[dtgSearch.CurrentRow.Index].Cells[0].Value.ToString());
                TanHoaDataContext db = new TanHoaDataContext();
                var data = from lich in db.LICHDOCSOs where lich.ID == id select lich;
                LICHDOCSO lds = data.Single();
                db.LICHDOCSOs.DeleteOnSubmit(lds);
                db.SubmitChanges();
                search();
            }
            catch (Exception)
            {
            }

        }

        bool checkPrimaryKey(TanHoaDataContext data, int maQuan, string maphuong, int ky, int dot)
        {
            var result = from p in data.LICHDOCSOs where p.MAQUAN == maQuan && p.MAPHUONG == maphuong && p.KY == ky && p.DOT == dot select p.ID;
            if (result.ToList() == null || result.ToList().Count == 0)
                return true;
            return false;

        }


        public void frmVisible(bool value)
        {
            this.editKy.Visible = value;
            this.editNam.Visible = value;
            this.editDot.Visible = value;
            this.editNgay.Visible = value;
        }
        private void update_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show(this, "Lưu Lịch Ghi Chỉ Số Nước ?", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    int id = int.Parse(this.dtgSearch.Rows[dtgSearch.CurrentRow.Index].Cells[0].Value.ToString());
                    TanHoaDataContext db = new TanHoaDataContext();
                    var data = from lich in db.LICHDOCSOs where lich.ID == id select lich;
                    LICHDOCSO ldso = data.Single();
                    if (ldso != null)
                    {
                        ldso.KY = this.dtgSearch.Rows[dtgSearch.CurrentRow.Index].Cells[3].Value != null ? int.Parse(this.dtgSearch.Rows[dtgSearch.CurrentRow.Index].Cells[3].Value.ToString()) : 0;
                        ldso.NAM = this.dtgSearch.Rows[dtgSearch.CurrentRow.Index].Cells[4].Value != null ? int.Parse(this.dtgSearch.Rows[dtgSearch.CurrentRow.Index].Cells[4].Value.ToString()) : 0;
                        ldso.DOT = this.dtgSearch.Rows[dtgSearch.CurrentRow.Index].Cells[5].Value != null ? int.Parse(this.dtgSearch.Rows[dtgSearch.CurrentRow.Index].Cells[5].Value.ToString()) : 0;
                        ldso.NGAY = this.dtgSearch.Rows[dtgSearch.CurrentRow.Index].Cells[6].Value != null ? DateTime.Parse(this.dtgSearch.Rows[dtgSearch.CurrentRow.Index].Cells[6].Value.ToString()) : DateTime.Now;
                        if (checkPrimaryKey(db, ldso.MAQUAN, ldso.MAPHUONG, ldso.KY, ldso.DOT) == true)
                        {
                            db.SubmitChanges();
                        }
                    }
                    MessageBox.Show(this, "Cập nhật thành công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Có Lỗi !!", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dtgSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //frmVisible(false);
            //if (e.RowIndex < 0) return;
            //else if (e.ColumnIndex == 3)
            //{
            //    editKy.Visible = true;
            //    editKy.Top = dtgSearch.Top + dtgSearch.GetRowDisplayRectangle(e.RowIndex, true).Top; ;
            //    editKy.Left = dtgSearch.Left + dtgSearch.GetColumnDisplayRectangle(e.ColumnIndex, true).Left; ;
            //    editKy.Width = dtgSearch.Columns[e.ColumnIndex].Width;
            //    editKy.Height = dtgSearch.Rows[e.RowIndex].Height;
            //    editKy.BringToFront();
            //}
            //else if (e.ColumnIndex == 4)
            //{
            //    editNam.Visible = true;
            //    editNam.Top = dtgSearch.Top + dtgSearch.GetRowDisplayRectangle(e.RowIndex, true).Top; ;
            //    editNam.Left = dtgSearch.Left + dtgSearch.GetColumnDisplayRectangle(e.ColumnIndex, true).Left; ;
            //    editNam.Width = dtgSearch.Columns[e.ColumnIndex].Width;
            //    editNam.Height = dtgSearch.Rows[e.RowIndex].Height;
            //    editNam.BringToFront();
            //}
            //else if (e.ColumnIndex == 5)
            //{
            //    editDot.Visible = true;
            //    editDot.Top = dtgSearch.Top + dtgSearch.GetRowDisplayRectangle(e.RowIndex, true).Top; ;
            //    editDot.Left = dtgSearch.Left + dtgSearch.GetColumnDisplayRectangle(e.ColumnIndex, true).Left; ;
            //    editDot.Width = dtgSearch.Columns[e.ColumnIndex].Width;
            //    editDot.Height = dtgSearch.Rows[e.RowIndex].Height;
            //    editDot.BringToFront();
            //}
            //else if (e.ColumnIndex == 6)
            //{
            //    editNgay.Visible = true;
            //    editNgay.Top = dtgSearch.Top + dtgSearch.GetRowDisplayRectangle(e.RowIndex, true).Top; ;
            //    editNgay.Left = dtgSearch.Left + dtgSearch.GetColumnDisplayRectangle(e.ColumnIndex, true).Left; ;
            //    editNgay.Width = dtgSearch.Columns[e.ColumnIndex].Width;
            //    editNgay.Height = dtgSearch.Rows[e.RowIndex].Height;
            //    editNgay.BringToFront();
            //}
        }
        private void cbKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
          
            //MessageBox.Show(editKy.Text);
            //dtgSearch.Rows[dtgSearch.CurrentRow.Index].Cells[3].Value = int.Parse(editKy.Text);
            ////}
            ////catch (Exception)
            //{
            //}

        }

        private void cbDot_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dtgSearch.Rows[dtgSearch.CurrentCell.RowIndex].Cells[5].Value = int.Parse(editDot.SelectedText);
            }
            catch (Exception)
            {

            }
        }
        private void cbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dtgSearch.Rows[dtgSearch.CurrentCell.RowIndex].Cells[4].Value = int.Parse(editNam.SelectedText);
            }
            catch (Exception)
            {


            }

        }

        private void calendar_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtgSearch.Rows[dtgSearch.CurrentCell.RowIndex].Cells[6].Value = editNgay.Value;
            }
            catch (Exception)
            {

            }

        }

        private void editKy_SelectedValueChanged(object sender, EventArgs e)
        {
           // //try
           // //{
           // this.dtgSearch.
           //// MessageBox.Show(editKy.Text);
           // MessageBox.Show(dtgSearch.Rows[dtgSearch.CurrentRow.Index].Cells[dtgSearch.CurrentCell.ColumnIndex].Value.ToString());
           // dtgSearch.Rows[dtgSearch.CurrentRow.Index].Cells[dtgSearch.CurrentCell.ColumnIndex].Value = int.Parse(editKy.Text);
           // MessageBox.Show(dtgSearch.Rows[dtgSearch.CurrentRow.Index].Cells[dtgSearch.CurrentCell.ColumnIndex].Value.ToString());
           // //}
           // //catch (Exception)
           // //{
           // //}
        }

        private void dtgSearch_AllowUserToOrderColumnsChanged(object sender, EventArgs e)
        {
            formatDataGird(this.dtgSearch);
        }

    }
}