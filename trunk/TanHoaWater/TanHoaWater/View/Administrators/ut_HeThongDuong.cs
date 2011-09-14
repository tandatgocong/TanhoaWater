using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;

namespace TanHoaWater.View.Administrators
{
    public partial class ut_HeThongDuong : UserControl
    {
        int currentPageIndex = 1;
        int pageSize = 23;
        int pageNumber = 0;
        int FirstRow, LastRow;
        int rows;
        private static readonly ILog log = LogManager.GetLogger(typeof(ut_HeThongDuong).Name);
        public ut_HeThongDuong()
        {
            InitializeComponent();
            fromLoad();
         
            
        }
        private void PageTotal()
        {
            try
            {
                pageNumber = rows % pageSize != 0 ? rows / pageSize + 1 : rows / pageSize;
                lbPaing.Text = currentPageIndex + "/" + pageNumber;
            }
            catch (Exception ex)
            {
                log.Error(ex); ;
            }

        }
        private void next_Click(object sender, EventArgs e)
        {
            if (currentPageIndex < pageNumber)
            {
                currentPageIndex = currentPageIndex + 1;
                FirstRow = pageSize * (currentPageIndex - 1);
                LastRow = pageSize * (currentPageIndex);
                PageTotal();
                search();
            }

        }

        private void pre(object sender, EventArgs e)
        {
            try
            {
                if (currentPageIndex > 1)
                {
                    currentPageIndex = currentPageIndex - 1;
                    FirstRow = pageSize * (currentPageIndex - 1);
                    LastRow = pageSize * (currentPageIndex);
                    PageTotal();
                    search();
                }
            }
            catch (Exception)
            {

            }

        }
        public void fromLoad() {
            this.cbPhuong.DataSource = DAL.C_TenDuong.getPhuong();
            this.cbPhuong.DisplayMember = "Display";
            this.cbPhuong.ValueMember = "Display";
            this.cbQuan.DataSource = DAL.C_TenDuong.getQuan();
            this.cbQuan.DisplayMember = "Display";
            this.cbQuan.ValueMember = "Value";

            this.cbPhuong.DataSource = DAL.C_Phuong.getListPhuong();
            this.cbPhuong.DisplayMember = "TENPHUONG";
            this.cbPhuong.ValueMember = "MAPHUONG";
            this.cbQuan.DataSource = DAL.C_Quan.getList();
            this.cbQuan.DisplayMember = "TENQUAN";
            this.cbQuan.ValueMember = "MAQUAN";
            search();
            
        }
        public void search() {
            string phuong = this.cbPhuong.SelectedValue + "";
            if ("  Chọn Phường  ".Equals(this.cbPhuong.SelectedValue))
            {
                phuong = "";
            }
            try
            {
                rows = DAL.C_TenDuong.TotalListDuong(this.txtTenDuong.Text, phuong, this.cbQuan.SelectedValue + "");
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            PageTotal();
            this.dataGridViewX1.DataSource = DAL.C_TenDuong.getListDuong(this.txtTenDuong.Text, phuong,this.cbQuan.SelectedValue+"", FirstRow, pageSize);
             
        }
        private void btTimKiem_Click(object sender, EventArgs e)
        {
             currentPageIndex = 1;
             pageSize = 23;
             pageNumber = 0;
             FirstRow = 0;
             LastRow = 0;
            search();
        }

        private void ut_HeThongDuong_Load(object sender, EventArgs e)
        {

        }
             
    }
}
