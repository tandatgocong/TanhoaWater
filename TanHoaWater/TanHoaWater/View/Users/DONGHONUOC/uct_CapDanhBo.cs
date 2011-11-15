using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TanHoaWater.View.Users.DONGHONUOC
{
    public partial class UCT_CapDanhBo : UserControl
    {
        public UCT_CapDanhBo()
        {
            InitializeComponent();
            cbDotHoanCong.DataSource = DAL.C_KH_DotThiCong.getListDTC();
            cbDotHoanCong.DisplayMember = "MADOTTC";
            cbDotHoanCong.ValueMember = "MADOTTC";
            try
            {
                gridHoanCong.DataSource = DAL.C_DHN_ChoDanhBo.getListHoanCong(cbDotHoanCong.Text,0);
            }
            catch (Exception)
            {

            }
            
        }

        private void checkChuaHoanCong_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                gridHoanCong.DataSource = DAL.C_DHN_ChoDanhBo.getListHoanCong(this.cbDotHoanCong.Text, -1);
            }
            catch (Exception)
            {

            }
        }

        private void chekDaHoanCong_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                gridHoanCong.DataSource = DAL.C_DHN_ChoDanhBo.getListHoanCong(this.cbDotHoanCong.Text, 1);
            }
            catch (Exception)
            {

            }
        }

        private void checkALl_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                gridHoanCong.DataSource = DAL.C_DHN_ChoDanhBo.getListHoanCong(this.cbDotHoanCong.Text, 0);
            }
            catch (Exception)
            {

            }
        }

        private void cbDotHoanCong_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkALl.Checked)
                    gridHoanCong.DataSource = DAL.C_DHN_ChoDanhBo.getListHoanCong(this.cbDotHoanCong.Text, 0);
                else if (checkChuaHoanCong.Checked)
                    gridHoanCong.DataSource = DAL.C_DHN_ChoDanhBo.getListHoanCong(this.cbDotHoanCong.Text, -1);
                else if (chekDaHoanCong.Checked)
                    gridHoanCong.DataSource = DAL.C_DHN_ChoDanhBo.getListHoanCong(this.cbDotHoanCong.Text, 1);

            }
            catch (Exception)
            {

            }
        }
        private Control txtKeypress;
        private void KeyPressHandle(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
            {
                if ((e.KeyChar) != 8 && (e.KeyChar) != 46 && (e.KeyChar) != 37 && (e.KeyChar) != 39 && (e.KeyChar) != 188)
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
        }

        string _sohopdong = "";
        string _sodanhbo = "";

        string formatDanhBo(string db) {
            db = db.Insert(4, ".");
            db = db.Insert(8, ".");
            return db;
        }
        private void gridHoanCong_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_hopdong")
            {
                if ("".Equals(_sodanhbo))
                {
                    gridHoanCong.Rows[e.RowIndex].Cells["hc_SoDanhBo"].Value = gridHoanCong.Rows[e.RowIndex].Cells["hc_Ma_QP"].Value;
                }
                else {
                    gridHoanCong.Rows[e.RowIndex].Cells["hc_SoDanhBo"].Value = _sodanhbo.Substring(0, 7);
                }
            }

            if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_MaDMA")
            {
                
                _sodanhbo = gridHoanCong.Rows[e.RowIndex].Cells["hc_SoDanhBo"].Value.ToString().Replace(".", "");
                gridHoanCong.Rows[e.RowIndex].Cells["hc_SoDanhBo"].Value = formatDanhBo(_sodanhbo);
            }

            if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_hieuLuc")
            {
                    _sohopdong = gridHoanCong.Rows[e.RowIndex].Cells["hc_hopdong"].Value + ""; 
            }
            if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_sotlk")
            {
                if (!"".Equals(_sohopdong))
                {
                    gridHoanCong.Rows[e.RowIndex].Cells["hc_hopdong"].Value = DAL.Idetity.IdentitySoHopDong(_sohopdong);
                }
            }
            //if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_DMucGoc")
            //{
            //    if (gridHoanCong.Rows[e.RowIndex].Cells["hc_ngaythicong"].Value!=null && !"".Equals(gridHoanCong.Rows[e.RowIndex].Cells["hc_ngaythicong"].Value+"") && gridHoanCong.Rows[e.RowIndex].Cells["hc_hieuLuc"].Value!=null && !"".Equals(gridHoanCong.Rows[e.RowIndex].Cells["hc_hieuLuc"].Value+"") )
            //    {
            //        string[] ngaytc = Regex.Split(gridHoanCong.Rows[e.RowIndex].Cells["hc_ngaythicong"].Value + "","\\/");
            //        string[] ngayhl = Regex.Split(gridHoanCong.Rows[e.RowIndex].Cells["hc_hieuLuc"].Value  + "","\\/");
            //        int dmcapnu = int.Parse(gridHoanCong.Rows[e.RowIndex].Cells["hc_DMucGoc"].Value + "") * ( int.Parse(ngayhl[0])-int.Parse(ngaytc[1]));
            //        gridHoanCong.Rows[e.RowIndex].Cells["hc_DMCapBu"].Value = dmcapnu;
            //    }
            //}

            
            
        }

        private void gridHoanCong_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
           
        }

        private void gridHoanCong_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            if (gridHoanCong.CurrentCell.OwningColumn.Name == "hc_DMucGoc")
            {
                if (gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_ngaythicong"].Value != null && !"".Equals(gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_ngaythicong"].Value + "") && gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_hieuLuc"].Value != null && !"".Equals(gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_hieuLuc"].Value + ""))
                {
                    string[] ngaytc = Regex.Split(gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_ngaythicong"].Value + "", "\\/");
                    string[] ngayhl = Regex.Split(gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_hieuLuc"].Value + "", "\\/");
                    int dmcapnu = int.Parse(gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_DMucGoc"].Value + "") * (int.Parse(ngayhl[0]) - int.Parse(ngaytc[1]));
                    gridHoanCong.Rows[gridHoanCong.CurrentCell.RowIndex].Cells["hc_DMCapBu"].Value = dmcapnu;
                }
            }
        }

    }
}
