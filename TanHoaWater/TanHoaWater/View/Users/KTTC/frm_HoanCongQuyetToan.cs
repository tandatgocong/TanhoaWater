using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;

namespace TanHoaWater.View.Users.KTTC
{
    public partial class frm_HoanCongQuyetToan : Form
    {

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
                    | dataGridView.CurrentCell.OwningColumn.Name == "CPNC"
                    | dataGridView.CurrentCell.OwningColumn.Name == "MAYTC"
                    | dataGridView.CurrentCell.OwningColumn.Name == "CPNHANCONG_G" 
                    | dataGridView.CurrentCell.OwningColumn.Name == "CPMTC"
                    | dataGridView.CurrentCell.OwningColumn.Name == "CPCHUNG"
                    | dataGridView.CurrentCell.OwningColumn.Name == "CPC"
                    | dataGridView.CurrentCell.OwningColumn.Name == "THUNHAPCHUITHUE"                    
                    | dataGridView.CurrentCell.OwningColumn.Name == "TNCTTT"
                    | dataGridView.CurrentCell.OwningColumn.Name == "GTXLTT"
                    | dataGridView.CurrentCell.OwningColumn.Name == "MAYTHICONG_C"                    
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
                if (hskh != null) {
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
                    dataGridView.Rows[e.RowIndex].Cells["CPNHANCONG_G"].Value = cp_nhancong;
                    dataGridView.Rows[e.RowIndex].Cells["CPNC"].Value = Math.Round(cp_nhancong, 2);

                    double cp_MAYTC = (hs_maythicong * double.Parse(dataGridView.Rows[e.RowIndex].Cells["MAYTC"].Value + ""));
                    dataGridView.Rows[e.RowIndex].Cells["MAYTHICONG_C"].Value = cp_MAYTC;
                    dataGridView.Rows[e.RowIndex].Cells["CPMTC"].Value = Math.Round(cp_MAYTC, 2);

                    //double cp_MAYTC = double.Parse(dataGridView.Rows[e.RowIndex].Cells["CPMTC"].Value + "");
                    //double cp_nhancong = double.Parse(dataGridView.Rows[e.RowIndex].Cells["CPNC"].Value + "");
                    double cp_chung = hs_chiphichung * (cp_MAYTC + cp_nhancong);
                    dataGridView.Rows[e.RowIndex].Cells["CPCHUNG"].Value = cp_chung;
                    dataGridView.Rows[e.RowIndex].Cells["CPC"].Value = Math.Round(cp_chung, 2);
                    double cp_chuithue = hs_tnchuithue * (cp_nhancong + cp_MAYTC + cp_chung);
                    dataGridView.Rows[e.RowIndex].Cells["THUNHAPCHUITHUE"].Value = cp_chuithue;
                    dataGridView.Rows[e.RowIndex].Cells["TNCTTT"].Value = Math.Round(cp_chuithue, 2);
                   // double catda = double.Parse(dataGridView.Rows[e.RowIndex].Cells["CATDA"].Value + "");

                    //double cp_GTXLTT = double.Parse(dataGridView.Rows[e.RowIndex].Cells["CATDA"].Value + "")
                    //                    + double.Parse(dataGridView.Rows[e.RowIndex].Cells["CPNC"].Value + "")
                    //                    + double.Parse(dataGridView.Rows[e.RowIndex].Cells["CPMTC"].Value + "")
                    //                    + double.Parse(dataGridView.Rows[e.RowIndex].Cells["CPC"].Value + "")
                    //                    + double.Parse(dataGridView.Rows[e.RowIndex].Cells["TNCTTT"].Value + "");
                    //dataGridView.Rows[e.RowIndex].Cells["GTXLTT"].Value = cp_GTXLTT;
                    //double cp_thue = double.Parse(dataGridView.Rows[e.RowIndex].Cells["GTXLTT"].Value + "") * hs_thue;
                    //dataGridView.Rows[e.RowIndex].Cells["THUE"].Value = cp_thue;
                    //double giatrisauthue = double.Parse(dataGridView.Rows[e.RowIndex].Cells["GTXLTT"].Value + "") + double.Parse(dataGridView.Rows[e.RowIndex].Cells["THUE"].Value + "");
                    //dataGridView.Rows[e.RowIndex].Cells["GIATRISAUTHUE"].Value = giatrisauthue;
                }

                double cp_GTXLTT = Math.Round(double.Parse(dataGridView.Rows[e.RowIndex].Cells["CATDA"].Value + ""))
                                        + Math.Round(double.Parse(dataGridView.Rows[e.RowIndex].Cells["CPNC"].Value + ""))
                                        + Math.Round(double.Parse(dataGridView.Rows[e.RowIndex].Cells["CPMTC"].Value + ""))
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
            if (dataGridView.CurrentCell.OwningColumn.Name == "CPNC"
                | dataGridView.CurrentCell.OwningColumn.Name == "CPMTC"
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
                dataGridView.Rows[e.RowIndex].Cells["CPNC"].Value = String.Format("{0:0,0}", double.Parse(dataGridView.Rows[e.RowIndex].Cells["CPNC"].Value + ""));
                dataGridView.Rows[e.RowIndex].Cells["CPNHANCONG_G"].Value = String.Format("{0:0,0.00}", double.Parse(dataGridView.Rows[e.RowIndex].Cells["CPNHANCONG_G"].Value + ""));
                dataGridView.Rows[e.RowIndex].Cells["MAYTC"].Value = String.Format("{0:0,0}", double.Parse(dataGridView.Rows[e.RowIndex].Cells["MAYTC"].Value + ""));
                dataGridView.Rows[e.RowIndex].Cells["CPMTC"].Value = String.Format("{0:0,0}", double.Parse(dataGridView.Rows[e.RowIndex].Cells["CPMTC"].Value + ""));
                dataGridView.Rows[e.RowIndex].Cells["CPCHUNG"].Value = String.Format("{0:0,0.00}", double.Parse(dataGridView.Rows[e.RowIndex].Cells["CPCHUNG"].Value + ""));
                dataGridView.Rows[e.RowIndex].Cells["CPC"].Value = String.Format("{0:0,0}", double.Parse(dataGridView.Rows[e.RowIndex].Cells["CPC"].Value + ""));
                dataGridView.Rows[e.RowIndex].Cells["TNCTTT"].Value = String.Format("{0:0,0}", double.Parse(dataGridView.Rows[e.RowIndex].Cells["TNCTTT"].Value + ""));
                dataGridView.Rows[e.RowIndex].Cells["GTXLTT"].Value = String.Format("{0:0,0}", double.Parse(dataGridView.Rows[e.RowIndex].Cells["GTXLTT"].Value + ""));
                dataGridView.Rows[e.RowIndex].Cells["THUNHAPCHUITHUE"].Value = String.Format("{0:0,0.00}", double.Parse(dataGridView.Rows[e.RowIndex].Cells["THUNHAPCHUITHUE"].Value + ""));
                dataGridView.Rows[e.RowIndex].Cells["MAYTHICONG_C"].Value = String.Format("{0:0,0.00}", double.Parse(dataGridView.Rows[e.RowIndex].Cells["MAYTHICONG_C"].Value + ""));
                dataGridView.Rows[e.RowIndex].Cells["THUE"].Value = String.Format("{0:0,0}", double.Parse(dataGridView.Rows[e.RowIndex].Cells["THUE"].Value + ""));
                dataGridView.Rows[e.RowIndex].Cells["GIATRISAUTHUE"].Value = String.Format("{0:0,0}", double.Parse(dataGridView.Rows[e.RowIndex].Cells["GIATRISAUTHUE"].Value + ""));
            }
            catch (Exception)
            { }



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
            double CPNC = 0;
            double MAYTC = 0;
            double CPMTC = 0;
            double CPCHUNG = 0;
            double CPC = 0;
            double CPNHANCONG_G = 0;
            double THUNHAPCHUITHUE = 0;
            double TNCTTT = 0;
            double GTXLTT = 0;
            double THUE = 0;
            double MAYTHICONG_C = 0;
            double GIATRISAUTHUE = 0;
            for (int i = 0; i < dataGridView.Rows.Count; i++) {
                SODHN += int.Parse(dataGridView.Rows[i].Cells["SODHN"].Value != null ? dataGridView.Rows[i].Cells["SODHN"].Value + "" : "0");
                CATDA += double.Parse(dataGridView.Rows[i].Cells["CATDA"].Value != null ? dataGridView.Rows[i].Cells["CATDA"].Value + "" : "0");
                NHANCONG += double.Parse(dataGridView.Rows[i].Cells["NHANCONG"].Value != null ? dataGridView.Rows[i].Cells["NHANCONG"].Value + "" : "0");
                CPNC += double.Parse(dataGridView.Rows[i].Cells["CPNC"].Value != null ? dataGridView.Rows[i].Cells["CPNC"].Value + "" : "0");
                CPNHANCONG_G += double.Parse(dataGridView.Rows[i].Cells["CPNHANCONG_G"].Value != null ? dataGridView.Rows[i].Cells["CPNHANCONG_G"].Value + "" : "0");
                MAYTC += double.Parse(dataGridView.Rows[i].Cells["MAYTC"].Value != null ? dataGridView.Rows[i].Cells["MAYTC"].Value + "" : "0");
                CPMTC += double.Parse(dataGridView.Rows[i].Cells["CPMTC"].Value != null ? dataGridView.Rows[i].Cells["CPMTC"].Value + "" : "0");
                CPCHUNG += double.Parse(dataGridView.Rows[i].Cells["CPCHUNG"].Value != null ? dataGridView.Rows[i].Cells["CPCHUNG"].Value + "" : "0");
                CPC += double.Parse(dataGridView.Rows[i].Cells["CPC"].Value != null ? dataGridView.Rows[i].Cells["CPC"].Value + "" : "0");
                TNCTTT += double.Parse(dataGridView.Rows[i].Cells["TNCTTT"].Value != null ? dataGridView.Rows[i].Cells["TNCTTT"].Value + "" : "0");
                GTXLTT += double.Parse(dataGridView.Rows[i].Cells["GTXLTT"].Value != null ? dataGridView.Rows[i].Cells["GTXLTT"].Value + "" : "0");
                THUNHAPCHUITHUE += double.Parse(dataGridView.Rows[i].Cells["THUNHAPCHUITHUE"].Value != null ? dataGridView.Rows[i].Cells["THUNHAPCHUITHUE"].Value + "" : "0");
                MAYTHICONG_C += double.Parse(dataGridView.Rows[i].Cells["MAYTHICONG_C"].Value != null ? dataGridView.Rows[i].Cells["MAYTHICONG_C"].Value + "" : "0");
                THUE += double.Parse(dataGridView.Rows[i].Cells["THUE"].Value != null ? dataGridView.Rows[i].Cells["THUE"].Value + "" : "0");
                GIATRISAUTHUE += double.Parse(dataGridView.Rows[i].Cells["GIATRISAUTHUE"].Value != null ? dataGridView.Rows[i].Cells["GIATRISAUTHUE"].Value + "" : "0");
            }
          
            int index=dataGridView.Rows.Count-1;
            dataGridView.Rows[index].Cells["SODHN"].Value = SODHN;
            dataGridView.Rows[index].Cells["CATDA"].Value = String.Format("{0:0,0}", CATDA);
            dataGridView.Rows[index].Cells["NHANCONG"].Value = String.Format("{0:0,0}", NHANCONG);
            dataGridView.Rows[index].Cells["CPNC"].Value = String.Format("{0:0,0}", CPNC);
            dataGridView.Rows[index].Cells["CPNHANCONG_G"].Value = String.Format("{0:0,0.00}", CPNHANCONG_G);
            dataGridView.Rows[index].Cells["MAYTC"].Value = String.Format("{0:0,0}", MAYTC);
            dataGridView.Rows[index].Cells["CPMTC"].Value = String.Format("{0:0,0}", CPMTC);
            dataGridView.Rows[index].Cells["CPCHUNG"].Value = String.Format("{0:0,0.00}", CPCHUNG);
            dataGridView.Rows[index].Cells["CPC"].Value = String.Format("{0:0,0}", CPC);
            dataGridView.Rows[index].Cells["TNCTTT"].Value = String.Format("{0:0,0}", TNCTTT);
            dataGridView.Rows[index].Cells["GTXLTT"].Value = String.Format("{0:0,0}", GTXLTT);
            dataGridView.Rows[index].Cells["THUNHAPCHUITHUE"].Value = String.Format("{0:0,0.00}", THUNHAPCHUITHUE);
            dataGridView.Rows[index].Cells["MAYTHICONG_C"].Value = String.Format("{0:0,0.00}", MAYTHICONG_C);
            dataGridView.Rows[index].Cells["THUE"].Value = String.Format("{0:0,0}", THUE);
            dataGridView.Rows[index].Cells["GIATRISAUTHUE"].Value = String.Format("{0:0,0}", GIATRISAUTHUE);
            
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font(dataGridView.Font, FontStyle.Bold);
            dataGridView.Rows[index].DefaultCellStyle = style;

            dataGridView.Rows[index].DefaultCellStyle.BackColor = Color.YellowGreen;
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            string dotquyettoan = this.txtDotQuyetToan.Text;
            string nhathau = this.txtNhaThau.Text;
            int sodh = this.numberDongHo.Value;
            DateTime quyettoan = dateQuyetToan.Value;
            DateTime thanhtoan = dateThanhToan.Value;             
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                string stt = dataGridView.Rows[i].Cells["STT"].Value+"";
                string mabanggia = dataGridView.Rows[i].Cells["MABANGGIA"].Value+"";
                string tenkh = dataGridView.Rows[i].Cells["TENKHACHHANG"].Value+"";
                string sonha = dataGridView.Rows[i].Cells["SONHA"].Value+"";
                string tenduong = dataGridView.Rows[i].Cells["TENDUONG"].Value+"";
                string phuong = dataGridView.Rows[i].Cells["PHUONG"].Value+"";
                string quan = dataGridView.Rows[i].Cells["QUAN"].Value+"";
                int SODHN = int.Parse(dataGridView.Rows[i].Cells["SODHN"].Value != null ? dataGridView.Rows[i].Cells["SODHN"].Value + "" : "0");
                double CATDA = double.Parse(dataGridView.Rows[i].Cells["CATDA"].Value != null ? dataGridView.Rows[i].Cells["CATDA"].Value + "" : "0");
                double NHANCONG = double.Parse(dataGridView.Rows[i].Cells["NHANCONG"].Value != null ? dataGridView.Rows[i].Cells["NHANCONG"].Value + "" : "0");
                double CPNC = double.Parse(dataGridView.Rows[i].Cells["CPNC"].Value != null ? dataGridView.Rows[i].Cells["CPNC"].Value + "" : "0");
                double CPNHANCONG_G = double.Parse(dataGridView.Rows[i].Cells["CPNHANCONG_G"].Value != null ? dataGridView.Rows[i].Cells["CPNHANCONG_G"].Value + "" : "0");
                double MAYTC = double.Parse(dataGridView.Rows[i].Cells["MAYTC"].Value != null ? dataGridView.Rows[i].Cells["MAYTC"].Value + "" : "0");
                double CPMTC = double.Parse(dataGridView.Rows[i].Cells["CPMTC"].Value != null ? dataGridView.Rows[i].Cells["CPMTC"].Value + "" : "0");
                double CPCHUNG = double.Parse(dataGridView.Rows[i].Cells["CPCHUNG"].Value != null ? dataGridView.Rows[i].Cells["CPCHUNG"].Value + "" : "0");
                double CPC = double.Parse(dataGridView.Rows[i].Cells["CPC"].Value != null ? dataGridView.Rows[i].Cells["CPC"].Value + "" : "0");
                double TNCTTT = double.Parse(dataGridView.Rows[i].Cells["TNCTTT"].Value != null ? dataGridView.Rows[i].Cells["TNCTTT"].Value + "" : "0");
                double GTXLTT = double.Parse(dataGridView.Rows[i].Cells["GTXLTT"].Value != null ? dataGridView.Rows[i].Cells["GTXLTT"].Value + "" : "0");
                double THUNHAPCHUITHUE = double.Parse(dataGridView.Rows[i].Cells["THUNHAPCHUITHUE"].Value != null ? dataGridView.Rows[i].Cells["THUNHAPCHUITHUE"].Value + "" : "0");
                double MAYTHICONG_C = double.Parse(dataGridView.Rows[i].Cells["MAYTHICONG_C"].Value != null ? dataGridView.Rows[i].Cells["MAYTHICONG_C"].Value + "" : "0");
                double  THUE = double.Parse(dataGridView.Rows[i].Cells["THUE"].Value != null ? dataGridView.Rows[i].Cells["THUE"].Value + "" : "0");
                double GIATRISAUTHUE = double.Parse(dataGridView.Rows[i].Cells["GIATRISAUTHUE"].Value != null ? dataGridView.Rows[i].Cells["GIATRISAUTHUE"].Value + "" : "0");
                string ghichu = dataGridView.Rows[i].Cells["GHICHU"].Value + "";
            }
        }
    }
}
