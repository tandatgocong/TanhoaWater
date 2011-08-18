using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using System.Collections;

namespace TanHoaWater.View.Users.HSKHACHHANG
{
    public partial class tab_TimKiemDonKH : UserControl
    {
        int currentPageIndex = 1;
        int pageSize = 16;
        int pageNumber = 0;
        int FirstRow, LastRow;
        int rows;
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_TimKiemDonKH).Name);
        public tab_TimKiemDonKH()
        {
            InitializeComponent();
           
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
         
        public void search() {
            try
            {
                rows = DAL.C_DONKHACHHANG.TotalPageSearch(SearchDotNhanDon.Text, this.SearchMaHoSo.Text, this.searchHoTenKH.Text, this.searchSoNha.Text, this.searchDiaChi.Text);
                PageTotal();
                this.dataSearCh.DataSource = DAL.C_DONKHACHHANG.search(SearchDotNhanDon.Text, this.SearchMaHoSo.Text, this.searchHoTenKH.Text, this.searchSoNha.Text, this.searchDiaChi.Text, FirstRow, pageSize);
                Utilities.DataGridV.formatRows(dataSearCh);

            }
            catch (Exception){
                 
            }

        }
        private void searchTimKiem_Click(object sender, EventArgs e)
        {
            search();
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

        private void txtDotNhanDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { search(); }
        }

        private void SearchMaHoSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { search(); }
        }

        private void searchHoTenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { search(); }
        }

        private void searchSoNha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { search(); }
        }

        private void searchDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { search(); }
        }

        private void searchLamLai_Click(object sender, EventArgs e)
        {
            this.searchDiaChi.Text = null;
            this.searchHoTenKH.Text = null;
            this.SearchMaHoSo.Text = null;
            this.searchSoNha.Text = null;
            this.SearchDotNhanDon.Text = null;
        }
    }
}
