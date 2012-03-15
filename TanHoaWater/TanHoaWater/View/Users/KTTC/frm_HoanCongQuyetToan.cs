using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;
using log4net;
using ExcelCOM = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Excel;

namespace TanHoaWater.View.Users.KTTC
{

    public partial class frm_HoanCongQuyetToan : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_HoanCongQuyetToan).Name);
        double hs_nhancong = 0.0;
        double hs_maythicong = 0.0;
        double hs_chiphichung = 0.0;
        double hs_tnchuithue = 0.0;
        double hs_thue = 0.0;
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        public frm_HoanCongQuyetToan()
        {
            InitializeComponent();

            KTTC_HESOQUYETTOAN hsqt = DAL.C_KTTC_HeSoQT.hsquyettoan();
            if (hsqt != null)
            {
                hs_nhancong = hsqt.NHANCONG.Value;
                hs_maythicong = hsqt.MAYTC.Value;
                hs_chiphichung = hsqt.CHIPHICUNG.Value;
                hs_tnchuithue = hsqt.TNCHUITHUE.Value;
                hs_thue = hsqt.THUE.Value;

            }
            List<KH_DONVITHICONG> list = DAL.C_KH_DonViTC.getDonViThiCong(); ;
            foreach (var item in list)
            {
                namesCollection.Add(item.TENCONGTY);
            }
            txtNhaThau.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtNhaThau.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtNhaThau.AutoCompleteCustomSource = namesCollection;
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

        private void dataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            dataGridView.Rows[e.Row.Index - 1].Cells["STT"].Value = e.Row.Index;
        }

        private void dataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                txtKeypress = e.Control;
                if (dataGridView.CurrentCell.OwningColumn.Name == "SODHN"
                    | dataGridView.CurrentCell.OwningColumn.Name == "CATDA"
                    | dataGridView.CurrentCell.OwningColumn.Name == "NHANCONG"
                    | dataGridView.CurrentCell.OwningColumn.Name == "CP_NHANCONG"
                    | dataGridView.CurrentCell.OwningColumn.Name == "MAYTC"
                    | dataGridView.CurrentCell.OwningColumn.Name == "CPNC"
                    | dataGridView.CurrentCell.OwningColumn.Name == "CP_MAYTC"
                    | dataGridView.CurrentCell.OwningColumn.Name == "CPCHUNG"
                    | dataGridView.CurrentCell.OwningColumn.Name == "CPC"
                    | dataGridView.CurrentCell.OwningColumn.Name == "THUNHAPCHUITHUE"
                    | dataGridView.CurrentCell.OwningColumn.Name == "TNCTTT"
                    | dataGridView.CurrentCell.OwningColumn.Name == "GTXLTT"
                    | dataGridView.CurrentCell.OwningColumn.Name == "MAYTHICONG"
                    | dataGridView.CurrentCell.OwningColumn.Name == "THUE"
                    | dataGridView.CurrentCell.OwningColumn.Name == "GIATRISAUTHUE")
                {
                    txtKeypress.KeyPress -= KeyPressHandle;
                    txtKeypress.KeyPress += KeyPressHandle;
                }
                else
                {
                    txtKeypress.KeyPress -= KeyPressHandle;
                }
            }
            catch (Exception)
            {
            }
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            /*
             Tim Ho so
            */
            if (dataGridView.CurrentCell.OwningColumn.Name == "MABANGGIA" && dataGridView.Rows[e.RowIndex].Cells["MABANGGIA"].Value != null && !"".Equals(dataGridView.Rows[e.RowIndex].Cells["MABANGGIA"].Value + ""))
            {
                KTTC_HOSOKHACHHANG hskh = DAL.C_KTTC_HoanCongQuyetToan.findBySHS(dataGridView.Rows[e.RowIndex].Cells["MABANGGIA"].Value + "");
                if (hskh != null)
                {
                    dataGridView.Rows[e.RowIndex].Cells["TENKHACHHANG"].Value = hskh.HOTEN;
                    dataGridView.Rows[e.RowIndex].Cells["SONHA"].Value = hskh.SONHA;
                    dataGridView.Rows[e.RowIndex].Cells["TENDUONG"].Value = hskh.DUONG;
                    dataGridView.Rows[e.RowIndex].Cells["PHUONG"].Value = hskh.TENPHUONG;
                    dataGridView.Rows[e.RowIndex].Cells["QUAN"].Value = hskh.TENQUAN;
                    dataGridView.Rows[e.RowIndex].Cells["SODHN"].Value = hskh.SOHO;
                }

            }
            /*
           * Tính Toán
           */
            try
            {
                if ((dataGridView.CurrentCell.OwningColumn.Name == "NHANCONG" && dataGridView.Rows[e.RowIndex].Cells["NHANCONG"].Value != null && !"".Equals(dataGridView.Rows[e.RowIndex].Cells["NHANCONG"].Value + ""))
                    || (dataGridView.CurrentCell.OwningColumn.Name == "MAYTC" && dataGridView.Rows[e.RowIndex].Cells["MAYTC"].Value != null && !"".Equals(dataGridView.Rows[e.RowIndex].Cells["MAYTC"].Value + ""))
                    || (dataGridView.CurrentCell.OwningColumn.Name == "CATDA" && dataGridView.Rows[e.RowIndex].Cells["CATDA"].Value != null && !"".Equals(dataGridView.Rows[e.RowIndex].Cells["CATDA"].Value + "")))
                {
                    double cp_nhancong = (hs_nhancong * double.Parse(dataGridView.Rows[e.RowIndex].Cells["NHANCONG"].Value + ""));
                    dataGridView.Rows[e.RowIndex].Cells["CPNC"].Value = cp_nhancong;
                    dataGridView.Rows[e.RowIndex].Cells["CP_NHANCONG"].Value = Math.Round(cp_nhancong, 2);

                    double cp_MAYTC = (hs_maythicong * double.Parse(dataGridView.Rows[e.RowIndex].Cells["MAYTC"].Value + ""));
                    dataGridView.Rows[e.RowIndex].Cells["MAYTHICONG"].Value = cp_MAYTC;
                    dataGridView.Rows[e.RowIndex].Cells["CP_MAYTC"].Value = Math.Round(cp_MAYTC, 2);

                    //double cp_MAYTC = double.Parse(dataGridView.Rows[e.RowIndex].Cells["CP_MAYTC"].Value + "");
                    //double cp_nhancong = double.Parse(dataGridView.Rows[e.RowIndex].Cells["CP_NHANCONG"].Value + "");
                    double cp_chung = hs_chiphichung * (cp_MAYTC + cp_nhancong);
                    dataGridView.Rows[e.RowIndex].Cells["CPCHUNG"].Value = cp_chung;
                    dataGridView.Rows[e.RowIndex].Cells["CPC"].Value = Math.Round(cp_chung, 2);
                    double cp_chuithue = hs_tnchuithue * (cp_nhancong + cp_MAYTC + cp_chung);
                    dataGridView.Rows[e.RowIndex].Cells["THUNHAPCHUITHUE"].Value = cp_chuithue;
                    dataGridView.Rows[e.RowIndex].Cells["TNCTTT"].Value = Math.Round(cp_chuithue, 2);
                    // double catda = double.Parse(dataGridView.Rows[e.RowIndex].Cells["CATDA"].Value + "");

                    //double cp_GTXLTT = double.Parse(dataGridView.Rows[e.RowIndex].Cells["CATDA"].Value + "")
                    //                    + double.Parse(dataGridView.Rows[e.RowIndex].Cells["CP_NHANCONG"].Value + "")
                    //                    + double.Parse(dataGridView.Rows[e.RowIndex].Cells["CP_MAYTC"].Value + "")
                    //                    + double.Parse(dataGridView.Rows[e.RowIndex].Cells["CPC"].Value + "")
                    //                    + double.Parse(dataGridView.Rows[e.RowIndex].Cells["TNCTTT"].Value + "");
                    //dataGridView.Rows[e.RowIndex].Cells["GTXLTT"].Value = cp_GTXLTT;
                    //double cp_thue = double.Parse(dataGridView.Rows[e.RowIndex].Cells["GTXLTT"].Value + "") * hs_thue;
                    //dataGridView.Rows[e.RowIndex].Cells["THUE"].Value = cp_thue;
                    //double giatrisauthue = double.Parse(dataGridView.Rows[e.RowIndex].Cells["GTXLTT"].Value + "") + double.Parse(dataGridView.Rows[e.RowIndex].Cells["THUE"].Value + "");
                    //dataGridView.Rows[e.RowIndex].Cells["GIATRISAUTHUE"].Value = giatrisauthue;
                }

                double cp_GTXLTT = Math.Round(double.Parse(dataGridView.Rows[e.RowIndex].Cells["CATDA"].Value + ""))
                                        + Math.Round(double.Parse(dataGridView.Rows[e.RowIndex].Cells["CP_NHANCONG"].Value + ""))
                                        + Math.Round(double.Parse(dataGridView.Rows[e.RowIndex].Cells["CP_MAYTC"].Value + ""))
                                        + Math.Round(double.Parse(dataGridView.Rows[e.RowIndex].Cells["CPC"].Value + ""))
                                        + Math.Round(double.Parse(dataGridView.Rows[e.RowIndex].Cells["TNCTTT"].Value + ""));
                dataGridView.Rows[e.RowIndex].Cells["GTXLTT"].Value = Math.Round(cp_GTXLTT, 0); ;
                double cp_thue = double.Parse(dataGridView.Rows[e.RowIndex].Cells["GTXLTT"].Value + "") * hs_thue;
                dataGridView.Rows[e.RowIndex].Cells["THUE"].Value = Math.Round(cp_thue, 0);
                double giatrisauthue = double.Parse(dataGridView.Rows[e.RowIndex].Cells["GTXLTT"].Value + "") + double.Parse(dataGridView.Rows[e.RowIndex].Cells["THUE"].Value + "");
                dataGridView.Rows[e.RowIndex].Cells["GIATRISAUTHUE"].Value = Math.Round(giatrisauthue, 0);
            }
            catch (Exception)
            { }

            /*
                format so
             */
            if (dataGridView.CurrentCell.OwningColumn.Name == "CP_NHANCONG"
                | dataGridView.CurrentCell.OwningColumn.Name == "CP_MAYTC"
                | dataGridView.CurrentCell.OwningColumn.Name == "CPC"
                | dataGridView.CurrentCell.OwningColumn.Name == "TNCTTT")
            {

            }

            // | dataGridView.CurrentCell.OwningColumn.Name == "THUE"
            //        | dataGridView.CurrentCell.OwningColumn.Name == "GIATRISAUTHUE")

            //| dataGridView.CurrentCell.OwningColumn.Name == "GTXLTT"
            try
            {
                dataGridView.Rows[e.RowIndex].Cells["CATDA"].Value = String.Format("{0:0,0}", double.Parse(dataGridView.Rows[e.RowIndex].Cells["CATDA"].Value + ""));
                dataGridView.Rows[e.RowIndex].Cells["NHANCONG"].Value = String.Format("{0:0,0}", double.Parse(dataGridView.Rows[e.RowIndex].Cells["NHANCONG"].Value + ""));
                dataGridView.Rows[e.RowIndex].Cells["CP_NHANCONG"].Value = String.Format("{0:0,0}", double.Parse(dataGridView.Rows[e.RowIndex].Cells["CP_NHANCONG"].Value + ""));
                dataGridView.Rows[e.RowIndex].Cells["CPNC"].Value = String.Format("{0:0,0.00}", double.Parse(dataGridView.Rows[e.RowIndex].Cells["CPNC"].Value + ""));
                dataGridView.Rows[e.RowIndex].Cells["MAYTC"].Value = String.Format("{0:0,0}", double.Parse(dataGridView.Rows[e.RowIndex].Cells["MAYTC"].Value + ""));
                dataGridView.Rows[e.RowIndex].Cells["CP_MAYTC"].Value = String.Format("{0:0,0}", double.Parse(dataGridView.Rows[e.RowIndex].Cells["CP_MAYTC"].Value + ""));
                dataGridView.Rows[e.RowIndex].Cells["CPCHUNG"].Value = String.Format("{0:0,0.00}", double.Parse(dataGridView.Rows[e.RowIndex].Cells["CPCHUNG"].Value + ""));
                dataGridView.Rows[e.RowIndex].Cells["CPC"].Value = String.Format("{0:0,0}", double.Parse(dataGridView.Rows[e.RowIndex].Cells["CPC"].Value + ""));
                dataGridView.Rows[e.RowIndex].Cells["TNCTTT"].Value = String.Format("{0:0,0}", double.Parse(dataGridView.Rows[e.RowIndex].Cells["TNCTTT"].Value + ""));
                dataGridView.Rows[e.RowIndex].Cells["GTXLTT"].Value = String.Format("{0:0,0}", double.Parse(dataGridView.Rows[e.RowIndex].Cells["GTXLTT"].Value + ""));
                dataGridView.Rows[e.RowIndex].Cells["THUNHAPCHUITHUE"].Value = String.Format("{0:0,0.00}", double.Parse(dataGridView.Rows[e.RowIndex].Cells["THUNHAPCHUITHUE"].Value + ""));
                dataGridView.Rows[e.RowIndex].Cells["MAYTHICONG"].Value = String.Format("{0:0,0.00}", double.Parse(dataGridView.Rows[e.RowIndex].Cells["MAYTHICONG"].Value + ""));
                dataGridView.Rows[e.RowIndex].Cells["THUE"].Value = String.Format("{0:0,0}", double.Parse(dataGridView.Rows[e.RowIndex].Cells["THUE"].Value + ""));
                dataGridView.Rows[e.RowIndex].Cells["GIATRISAUTHUE"].Value = String.Format("{0:0,0}", double.Parse(dataGridView.Rows[e.RowIndex].Cells["GIATRISAUTHUE"].Value + ""));
            }
            catch (Exception)
            { }

        }
        public void format()
        {

            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                try
                {
                    dataGridView.Rows[i].Cells["CATDA"].Value = String.Format("{0:0,0}", double.Parse(dataGridView.Rows[i].Cells["CATDA"].Value + ""));
                    dataGridView.Rows[i].Cells["NHANCONG"].Value = String.Format("{0:0,0}", double.Parse(dataGridView.Rows[i].Cells["NHANCONG"].Value + ""));
                    dataGridView.Rows[i].Cells["CP_NHANCONG"].Value = String.Format("{0:0,0}", double.Parse(dataGridView.Rows[i].Cells["CP_NHANCONG"].Value + ""));
                    dataGridView.Rows[i].Cells["CPNC"].Value = String.Format("{0:0,0.00}", double.Parse(dataGridView.Rows[i].Cells["CPNC"].Value + ""));
                    dataGridView.Rows[i].Cells["MAYTC"].Value = String.Format("{0:0,0}", double.Parse(dataGridView.Rows[i].Cells["MAYTC"].Value + ""));
                    dataGridView.Rows[i].Cells["CP_MAYTC"].Value = String.Format("{0:0,0}", double.Parse(dataGridView.Rows[i].Cells["CP_MAYTC"].Value + ""));
                    dataGridView.Rows[i].Cells["CPCHUNG"].Value = String.Format("{0:0,0.00}", double.Parse(dataGridView.Rows[i].Cells["CPCHUNG"].Value + ""));
                    dataGridView.Rows[i].Cells["CPC"].Value = String.Format("{0:0,0}", double.Parse(dataGridView.Rows[i].Cells["CPC"].Value + ""));
                    dataGridView.Rows[i].Cells["TNCTTT"].Value = String.Format("{0:0,0}", double.Parse(dataGridView.Rows[i].Cells["TNCTTT"].Value + ""));
                    dataGridView.Rows[i].Cells["GTXLTT"].Value = String.Format("{0:0,0}", double.Parse(dataGridView.Rows[i].Cells["GTXLTT"].Value + ""));
                    dataGridView.Rows[i].Cells["THUNHAPCHUITHUE"].Value = String.Format("{0:0,0.00}", double.Parse(dataGridView.Rows[i].Cells["THUNHAPCHUITHUE"].Value + ""));
                    dataGridView.Rows[i].Cells["MAYTHICONG"].Value = String.Format("{0:0,0.00}", double.Parse(dataGridView.Rows[i].Cells["MAYTHICONG"].Value + ""));
                    dataGridView.Rows[i].Cells["THUE"].Value = String.Format("{0:0,0}", double.Parse(dataGridView.Rows[i].Cells["THUE"].Value + ""));
                    dataGridView.Rows[i].Cells["GIATRISAUTHUE"].Value = String.Format("{0:0,0}", double.Parse(dataGridView.Rows[i].Cells["GIATRISAUTHUE"].Value + ""));
                }
                catch (Exception)
                { }
            }
        }


        private void btHeSo_Click(object sender, EventArgs e)
        {
            //  MessageBox.Show(this, hs_nhancong + "--" + hs_maythicong + "--" + hs_chiphichung + "--" + hs_tnchuithue + "--" + hs_thue + "--");
            frm_HeSoQT frm = new frm_HeSoQT();
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                hs_nhancong = frm.hs_nhancong;
                hs_maythicong = frm.hs_maythicong;
                hs_chiphichung = frm.hs_chiphichung;
                hs_tnchuithue = frm.hs_tnchuithue;
                hs_thue = frm.hs_thue;
                ///  MessageBox.Show(this, hs_nhancong + "--" + hs_maythicong + "--" + hs_chiphichung + "--" + hs_tnchuithue + "--" + hs_thue + "--");
            }
        }

        private void btTongKet_Click(object sender, EventArgs e)
        {
            ///MessageBox.Show(this, dataGridView.Rows.Count + "--");

            int SODHN = 0;
            double CATDA = 0;
            double NHANCONG = 0;
            double CP_NHANCONG = 0;
            double MAYTC = 0;
            double CP_MAYTC = 0;
            double CPCHUNG = 0;
            double CPC = 0;
            double CPNC = 0;
            double THUNHAPCHUITHUE = 0;
            double TNCTTT = 0;
            double GTXLTT = 0;
            double THUE = 0;
            double MAYTHICONG = 0;
            double GIATRISAUTHUE = 0;
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                SODHN += int.Parse(dataGridView.Rows[i].Cells["SODHN"].Value != null ? dataGridView.Rows[i].Cells["SODHN"].Value + "" : "0");
                CATDA += double.Parse(dataGridView.Rows[i].Cells["CATDA"].Value != null ? dataGridView.Rows[i].Cells["CATDA"].Value + "" : "0");
                NHANCONG += double.Parse(dataGridView.Rows[i].Cells["NHANCONG"].Value != null ? dataGridView.Rows[i].Cells["NHANCONG"].Value + "" : "0");
                CP_NHANCONG += double.Parse(dataGridView.Rows[i].Cells["CP_NHANCONG"].Value != null ? dataGridView.Rows[i].Cells["CP_NHANCONG"].Value + "" : "0");
                CPNC += double.Parse(dataGridView.Rows[i].Cells["CPNC"].Value != null ? dataGridView.Rows[i].Cells["CPNC"].Value + "" : "0");
                MAYTC += double.Parse(dataGridView.Rows[i].Cells["MAYTC"].Value != null ? dataGridView.Rows[i].Cells["MAYTC"].Value + "" : "0");
                CP_MAYTC += double.Parse(dataGridView.Rows[i].Cells["CP_MAYTC"].Value != null ? dataGridView.Rows[i].Cells["CP_MAYTC"].Value + "" : "0");
                CPCHUNG += double.Parse(dataGridView.Rows[i].Cells["CPCHUNG"].Value != null ? dataGridView.Rows[i].Cells["CPCHUNG"].Value + "" : "0");
                CPC += double.Parse(dataGridView.Rows[i].Cells["CPC"].Value != null ? dataGridView.Rows[i].Cells["CPC"].Value + "" : "0");
                TNCTTT += double.Parse(dataGridView.Rows[i].Cells["TNCTTT"].Value != null ? dataGridView.Rows[i].Cells["TNCTTT"].Value + "" : "0");
                GTXLTT += double.Parse(dataGridView.Rows[i].Cells["GTXLTT"].Value != null ? dataGridView.Rows[i].Cells["GTXLTT"].Value + "" : "0");
                THUNHAPCHUITHUE += double.Parse(dataGridView.Rows[i].Cells["THUNHAPCHUITHUE"].Value != null ? dataGridView.Rows[i].Cells["THUNHAPCHUITHUE"].Value + "" : "0");
                MAYTHICONG += double.Parse(dataGridView.Rows[i].Cells["MAYTHICONG"].Value != null ? dataGridView.Rows[i].Cells["MAYTHICONG"].Value + "" : "0");
                THUE += double.Parse(dataGridView.Rows[i].Cells["THUE"].Value != null ? dataGridView.Rows[i].Cells["THUE"].Value + "" : "0");
                GIATRISAUTHUE += double.Parse(dataGridView.Rows[i].Cells["GIATRISAUTHUE"].Value != null ? dataGridView.Rows[i].Cells["GIATRISAUTHUE"].Value + "" : "0");
            }

            int index = dataGridView.Rows.Count - 1;
            dataGridView.Rows[index].Cells["SODHN"].Value = SODHN;
            dataGridView.Rows[index].Cells["CATDA"].Value = String.Format("{0:0,0}", CATDA);
            dataGridView.Rows[index].Cells["NHANCONG"].Value = String.Format("{0:0,0}", NHANCONG);
            dataGridView.Rows[index].Cells["CP_NHANCONG"].Value = String.Format("{0:0,0}", CP_NHANCONG);
            dataGridView.Rows[index].Cells["CPNC"].Value = String.Format("{0:0,0.00}", CPNC);
            dataGridView.Rows[index].Cells["MAYTC"].Value = String.Format("{0:0,0}", MAYTC);
            dataGridView.Rows[index].Cells["CP_MAYTC"].Value = String.Format("{0:0,0}", CP_MAYTC);
            dataGridView.Rows[index].Cells["CPCHUNG"].Value = String.Format("{0:0,0.00}", CPCHUNG);
            dataGridView.Rows[index].Cells["CPC"].Value = String.Format("{0:0,0}", CPC);
            dataGridView.Rows[index].Cells["TNCTTT"].Value = String.Format("{0:0,0}", TNCTTT);
            dataGridView.Rows[index].Cells["GTXLTT"].Value = String.Format("{0:0,0}", GTXLTT);
            dataGridView.Rows[index].Cells["THUNHAPCHUITHUE"].Value = String.Format("{0:0,0.00}", THUNHAPCHUITHUE);
            dataGridView.Rows[index].Cells["MAYTHICONG"].Value = String.Format("{0:0,0.00}", MAYTHICONG);
            dataGridView.Rows[index].Cells["THUE"].Value = String.Format("{0:0,0}", THUE);
            dataGridView.Rows[index].Cells["GIATRISAUTHUE"].Value = String.Format("{0:0,0}", GIATRISAUTHUE);

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new System.Drawing.Font(dataGridView.Font, FontStyle.Bold);
            dataGridView.Rows[index].DefaultCellStyle = style;

            dataGridView.Rows[index].DefaultCellStyle.BackColor = Color.YellowGreen;
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string DOTQT = this.txtDotQuyetToan.Text;
                string NHATHAU = this.txtNhaThau.Text;
                int TONGSODHN = this.numberDongHo.Value;
                DateTime QUYETTOAN = dateQuyetToan.Value;
                DateTime THANHTOAN = dateThanhToan.Value;
                for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                {
                    int stt = int.Parse(dataGridView.Rows[i].Cells["STT"].Value != null ? dataGridView.Rows[i].Cells["STT"].Value.ToString().Trim() + "" : "0");
                    string SOHOSO = dataGridView.Rows[i].Cells["MABANGGIA"].Value + "";
                    string TENKH = dataGridView.Rows[i].Cells["TENKHACHHANG"].Value + "";
                    string SONHA = dataGridView.Rows[i].Cells["SONHA"].Value + "";
                    string TENDUONG = dataGridView.Rows[i].Cells["TENDUONG"].Value + "";
                    string PHUONG = dataGridView.Rows[i].Cells["PHUONG"].Value + "";
                    string QUAN = dataGridView.Rows[i].Cells["QUAN"].Value + "";
                    int SODHN = int.Parse(dataGridView.Rows[i].Cells["SODHN"].Value != null ? dataGridView.Rows[i].Cells["SODHN"].Value + "" : "0");
                    double CATDA = double.Parse(dataGridView.Rows[i].Cells["CATDA"].Value != null ? dataGridView.Rows[i].Cells["CATDA"].Value + "" : "0");
                    double NHANCONG = double.Parse(dataGridView.Rows[i].Cells["NHANCONG"].Value != null ? dataGridView.Rows[i].Cells["NHANCONG"].Value + "" : "0");
                    double CP_NHANCONG = double.Parse(dataGridView.Rows[i].Cells["CP_NHANCONG"].Value != null ? dataGridView.Rows[i].Cells["CP_NHANCONG"].Value + "" : "0");
                    double CPNC = double.Parse(dataGridView.Rows[i].Cells["CPNC"].Value != null ? dataGridView.Rows[i].Cells["CPNC"].Value + "" : "0");
                    double MAYTHICONG = double.Parse(dataGridView.Rows[i].Cells["MAYTC"].Value != null ? dataGridView.Rows[i].Cells["MAYTC"].Value + "" : "0");
                    double CP_MAYTC = double.Parse(dataGridView.Rows[i].Cells["CP_MAYTC"].Value != null ? dataGridView.Rows[i].Cells["CP_MAYTC"].Value + "" : "0");
                    double MAYTC = double.Parse(dataGridView.Rows[i].Cells["MAYTHICONG"].Value != null ? dataGridView.Rows[i].Cells["MAYTHICONG"].Value + "" : "0");
                    double CHIPHICHUNG = double.Parse(dataGridView.Rows[i].Cells["CPCHUNG"].Value != null ? dataGridView.Rows[i].Cells["CPCHUNG"].Value + "" : "0");
                    double CP_CHUNG = double.Parse(dataGridView.Rows[i].Cells["CPC"].Value != null ? dataGridView.Rows[i].Cells["CPC"].Value + "" : "0");
                    double TNCTTT = double.Parse(dataGridView.Rows[i].Cells["TNCTTT"].Value != null ? dataGridView.Rows[i].Cells["TNCTTT"].Value + "" : "0");
                    double GTXLTT = double.Parse(dataGridView.Rows[i].Cells["GTXLTT"].Value != null ? dataGridView.Rows[i].Cells["GTXLTT"].Value + "" : "0");
                    double THUNHAPCHUITHUE = double.Parse(dataGridView.Rows[i].Cells["THUNHAPCHUITHUE"].Value != null ? dataGridView.Rows[i].Cells["THUNHAPCHUITHUE"].Value + "" : "0");
                    double THUE = double.Parse(dataGridView.Rows[i].Cells["THUE"].Value != null ? dataGridView.Rows[i].Cells["THUE"].Value + "" : "0");
                    double GIATRISAUTHUE = double.Parse(dataGridView.Rows[i].Cells["GIATRISAUTHUE"].Value != null ? dataGridView.Rows[i].Cells["GIATRISAUTHUE"].Value + "" : "0");
                    string GHICHU = dataGridView.Rows[i].Cells["GHICHU"].Value + "";
                    string id = dataGridView.Rows[i].Cells["ID"].Value + "";
                    if ("".Equals(id))
                    {
                        KTTC_QUYETTOAN_GANDHN qt = new KTTC_QUYETTOAN_GANDHN();
                        qt.STT = stt;
                        qt.DOTQT = DOTQT;
                        qt.NHATHAU = NHATHAU;
                        qt.TONGSODHN = TONGSODHN;
                        qt.QUYETTOAN = QUYETTOAN;
                        qt.THANHTOAN = THANHTOAN;
                        qt.SOHOSO = SOHOSO;
                        qt.TENKH = TENKH;
                        qt.SONHA = SONHA;
                        qt.TENDUONG = TENDUONG;
                        qt.PHUONG = PHUONG;
                        qt.QUAN = QUAN;
                        qt.SODHN = SODHN;
                        qt.CATDA = CATDA;
                        qt.NHANCONG = NHANCONG;
                        qt.CPNC = CPNC;
                        qt.CP_NHANCONG = CP_NHANCONG;
                        qt.MAYTC = MAYTC;
                        qt.MAYTHICONG = MAYTHICONG;
                        qt.CP_MAYTC = CP_MAYTC;
                        qt.CHIPHICHUNG = CHIPHICHUNG;
                        qt.CP_CHUNG = CP_CHUNG;
                        qt.THUNHAPCHUITHUE = THUNHAPCHUITHUE;
                        qt.CP_TNCTTT = TNCTTT;
                        qt.GXLTT = GTXLTT;
                        qt.THUE = THUE;
                        qt.SAUTHUE = GIATRISAUTHUE;
                        qt.GHICHU = GHICHU;
                        qt.CREATEBY = DAL.C_USERS._userName;
                        qt.CREATEDATE = DateTime.Now;
                        DAL.C_KTTC_HoanCongQuyetToan.Insert(qt);
                    }
                    else
                    {
                        KTTC_QUYETTOAN_GANDHN qt = DAL.C_KTTC_HoanCongQuyetToan.findByQuyetToan(int.Parse(id));
                        if (qt != null)
                        {
                            qt.STT = stt;
                            qt.DOTQT = DOTQT;
                            qt.NHATHAU = NHATHAU;
                            qt.TONGSODHN = TONGSODHN;
                            qt.QUYETTOAN = QUYETTOAN;
                            qt.THANHTOAN = THANHTOAN;
                            qt.SOHOSO = SOHOSO;
                            qt.TENKH = TENKH;
                            qt.SONHA = SONHA;
                            qt.TENDUONG = TENDUONG;
                            qt.PHUONG = PHUONG;
                            qt.QUAN = QUAN;
                            qt.SODHN = SODHN;
                            qt.CATDA = CATDA;
                            qt.NHANCONG = NHANCONG;
                            qt.CPNC = CPNC;
                            qt.CP_NHANCONG = CP_NHANCONG;
                            qt.MAYTC = MAYTC;
                            qt.MAYTHICONG = MAYTHICONG;
                            qt.CP_MAYTC = CP_MAYTC;
                            qt.CHIPHICHUNG = CHIPHICHUNG;
                            qt.CP_CHUNG = CP_CHUNG;
                            qt.THUNHAPCHUITHUE = THUNHAPCHUITHUE;
                            qt.CP_TNCTTT = TNCTTT;
                            qt.GXLTT = GTXLTT;
                            qt.THUE = THUE;
                            qt.SAUTHUE = GIATRISAUTHUE;
                            qt.GHICHU = GHICHU;
                            qt.CREATEBY = DAL.C_USERS._userName;
                            qt.CREATEDATE = DateTime.Now;
                            DAL.C_KTTC_HoanCongQuyetToan.Update();
                        }
                    }
                }
                MessageBox.Show(this, "Cập Nhật Thông Tin Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                log.Error("Loi Cap Nhat Thong Tin Hoan Cong Quyet Toan." + ex.Message);
                MessageBox.Show(this, "Cập Nhật Thông Tin Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDotQuyetToan_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            if (e.KeyChar == 13)
            {
                System.Data.DataTable table = DAL.C_KTTC_HoanCongQuyetToan.getList(this.txtDotQuyetToan.Text);
                if (table != null)
                {
                    this.txtNhaThau.Text = table.Rows[0]["NHATHAU"] + "";
                    this.numberDongHo.Value = int.Parse(table.Rows[0]["TONGSODHN"] + "");
                    dateQuyetToan.Value = DateTime.Parse(table.Rows[0]["QUYETTOAN"] + "");
                    dateThanhToan.Value = DateTime.Parse(table.Rows[0]["THANHTOAN"] + "");
                    dataGridView.DataSource = table;
                    format();
                }
            }
            //}
            //catch (Exception)
            //{

            //}

        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //  MessageBox.Show(this, e.Exception.Message);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            //    Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            //    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            //    app.Visible = true;
            //    worksheet = workbook.Sheets["Sheet1"];
            //    worksheet = workbook.ActiveSheet;
            //    worksheet.Name = "Danh Sach";
            //    for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            //    {
            //        worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            //    }

            //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //    {
            //        for (int j = 0; j < dataGridView1.Columns.Count; j++)
            //        {
            //            worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
            //        }
            //    }
            //    workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            //}
            //catch (Exception ex)
            //{
               
            //}

            try
            {
              //  string[] arrFile = Utilities.Files.getFileOnServer();//get file onserver

                ExcelCOM.Application exApp = new ExcelCOM.Application();
                string workbookPath = AppDomain.CurrentDomain.BaseDirectory + @"\QuyetToanGanDHN.xls";
                ExcelCOM.Workbook exBook = exApp.Workbooks.Open(workbookPath,
            0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                ExcelCOM.Worksheet exSheet = (ExcelCOM.Worksheet)exBook.Worksheets[1];

                exSheet.Name = DateTime.Now.Year + ""; ;
                exSheet.Cells[2, 1] = "BẢNG KIỂM TRA QUYẾT TOÁN GẮN ĐHN NĂM  " + DateTime.Now.Year + " " + this.txtNhaThau.Text.ToUpper() +" ( " + this.numberDongHo.Value+"TLK )";
                int rows = 6; 
                int SODHN = 0;
                double CATDA = 0;
                double NHANCONG = 0;
                double CP_NHANCONG = 0;
                double MAYTC = 0;
                double CP_MAYTC = 0;
                double CPCHUNG = 0;
                double CPC = 0;
                double CPNC = 0;
                double THUNHAPCHUITHUE = 0;
                double TNCTTT = 0;
                double GTXLTT = 0;
                double THUE = 0;
                double MAYTHICONG = 0;
                double GIATRISAUTHUE = 0;
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    exSheet.Cells[rows, 1] = dataGridView.Rows[i].Cells["STT"].Value + "";
                    exSheet.Cells[rows, 2] = this.txtDotQuyetToan.Text;
                    exSheet.Cells[rows, 3] = dataGridView.Rows[i].Cells["MABANGGIA"].Value + "";
                    exSheet.Cells[rows, 4] = dataGridView.Rows[i].Cells["TENKHACHHANG"].Value + "";
                    exSheet.Cells[rows, 5] = dataGridView.Rows[i].Cells["SONHA"].Value + "";
                    exSheet.Cells[rows, 6] = dataGridView.Rows[i].Cells["TENDUONG"].Value + "";
                    exSheet.Cells[rows, 7] = dataGridView.Rows[i].Cells["PHUONG"].Value + "";
                    exSheet.Cells[rows, 8] = dataGridView.Rows[i].Cells["QUAN"].Value + "";
                    exSheet.Cells[rows, 9] = dataGridView.Rows[i].Cells["SODHN"].Value + "";
                    exSheet.Cells[rows, 10] = dataGridView.Rows[i].Cells["CATDA"].Value + "";
                    exSheet.Cells[rows, 11] = dataGridView.Rows[i].Cells["NHANCONG"].Value + "";
                    exSheet.Cells[rows, 12] = dataGridView.Rows[i].Cells["CP_NHANCONG"].Value + "";
                    exSheet.Cells[rows, 13] = dataGridView.Rows[i].Cells["CPNC"].Value + "";
                    exSheet.Cells[rows, 14] = dataGridView.Rows[i].Cells["MAYTC"].Value + "";
                    exSheet.Cells[rows, 15] = dataGridView.Rows[i].Cells["CP_MAYTC"].Value + "";
                    exSheet.Cells[rows, 16] = dataGridView.Rows[i].Cells["CPCHUNG"].Value + "";
                    exSheet.Cells[rows, 17] = dataGridView.Rows[i].Cells["CPC"].Value + "";
                    exSheet.Cells[rows, 18] = dataGridView.Rows[i].Cells["TNCTTT"].Value + "";
                    exSheet.Cells[rows, 19] = dataGridView.Rows[i].Cells["GTXLTT"].Value + "";
                    exSheet.Cells[rows, 20] = dataGridView.Rows[i].Cells["THUNHAPCHUITHUE"].Value + "";
                    exSheet.Cells[rows, 21] = dataGridView.Rows[i].Cells["MAYTHICONG"].Value + "";
                    exSheet.Cells[rows, 22] = dataGridView.Rows[i].Cells["THUE"].Value + "";
                    exSheet.Cells[rows, 23] = dataGridView.Rows[i].Cells["GIATRISAUTHUE"].Value + "";
                    exSheet.Cells[rows, 24] = dataGridView.Rows[i].Cells["GHICHU"].Value + "";

                    SODHN += int.Parse(dataGridView.Rows[i].Cells["SODHN"].Value != null ? dataGridView.Rows[i].Cells["SODHN"].Value + "" : "0");
                    CATDA += double.Parse(dataGridView.Rows[i].Cells["CATDA"].Value != null ? dataGridView.Rows[i].Cells["CATDA"].Value + "" : "0");
                    NHANCONG += double.Parse(dataGridView.Rows[i].Cells["NHANCONG"].Value != null ? dataGridView.Rows[i].Cells["NHANCONG"].Value + "" : "0");
                    CP_NHANCONG += double.Parse(dataGridView.Rows[i].Cells["CP_NHANCONG"].Value != null ? dataGridView.Rows[i].Cells["CP_NHANCONG"].Value + "" : "0");
                    CPNC += double.Parse(dataGridView.Rows[i].Cells["CPNC"].Value != null ? dataGridView.Rows[i].Cells["CPNC"].Value + "" : "0");
                    MAYTC += double.Parse(dataGridView.Rows[i].Cells["MAYTC"].Value != null ? dataGridView.Rows[i].Cells["MAYTC"].Value + "" : "0");
                    CP_MAYTC += double.Parse(dataGridView.Rows[i].Cells["CP_MAYTC"].Value != null ? dataGridView.Rows[i].Cells["CP_MAYTC"].Value + "" : "0");
                    CPCHUNG += double.Parse(dataGridView.Rows[i].Cells["CPCHUNG"].Value != null ? dataGridView.Rows[i].Cells["CPCHUNG"].Value + "" : "0");
                    CPC += double.Parse(dataGridView.Rows[i].Cells["CPC"].Value != null ? dataGridView.Rows[i].Cells["CPC"].Value + "" : "0");
                    TNCTTT += double.Parse(dataGridView.Rows[i].Cells["TNCTTT"].Value != null ? dataGridView.Rows[i].Cells["TNCTTT"].Value + "" : "0");
                    GTXLTT += double.Parse(dataGridView.Rows[i].Cells["GTXLTT"].Value != null ? dataGridView.Rows[i].Cells["GTXLTT"].Value + "" : "0");
                    THUNHAPCHUITHUE += double.Parse(dataGridView.Rows[i].Cells["THUNHAPCHUITHUE"].Value != null ? dataGridView.Rows[i].Cells["THUNHAPCHUITHUE"].Value + "" : "0");
                    MAYTHICONG += double.Parse(dataGridView.Rows[i].Cells["MAYTHICONG"].Value != null ? dataGridView.Rows[i].Cells["MAYTHICONG"].Value + "" : "0");
                    THUE += double.Parse(dataGridView.Rows[i].Cells["THUE"].Value != null ? dataGridView.Rows[i].Cells["THUE"].Value + "" : "0");
                    GIATRISAUTHUE += double.Parse(dataGridView.Rows[i].Cells["GIATRISAUTHUE"].Value != null ? dataGridView.Rows[i].Cells["GIATRISAUTHUE"].Value + "" : "0");
                    rows++;
                }

                exSheet.Cells[rows+ 2, 19] = "NGÀY" + DateTime.Now.Day + " THÁNG " + DateTime.Now.Month + " NĂM " + DateTime.Now.Year;
                exSheet.Cells[rows + 3, 19] = "NGƯỜI KIỂM TRA";
                exSheet.Cells[rows + 8, 19] = DAL.C_USERS._fullName.ToUpper();
                //ExcelCOM.Range tR;
                //tR = exSheet.get_Range("T" + rows, "V" + (rows));
                //tR.VerticalAlignment = ExcelCOM.XlVAlign.xlVAlignCenter;
                //tR.ShrinkToFit = false;
                //tR.MergeCells = true;
                //tR.Value2 = "NGƯỜI KIỂM TRA";


                exApp.Visible = false;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = @"C:\";
                saveFileDialog1.Title = "Save text Files";
                saveFileDialog1.DefaultExt = ".xls";
                saveFileDialog1.Filter = "All files (*.*)|*.*";    
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string path = saveFileDialog1.FileName;;
                    exBook.SaveAs(path, ExcelCOM.XlFileFormat.xlWorkbookNormal,
                        null, null, false, false,
                        ExcelCOM.XlSaveAsAccessMode.xlExclusive,
                        false, false, false, false, false);
                }
               
                exBook.Close(false, false, false);
                exApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(exBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(exApp);

            }
            catch (Exception ex)
            {
                log.Error("Export File Loi" + ex.Message);
                MessageBox.Show(this, "Xuất File Lỗi. ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}