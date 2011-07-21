using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using TanHoaWater.View.QLDHN;

namespace TanHoaWater
{
    public partial class frm_Main : Form
    {
        public void start()
        {
            Application.Run(new SplashScreen());
        }
        public frm_Main()
        {
            Thread th = new Thread(new ThreadStart(this.start));
            th.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            th.Abort();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dữLiệuKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // frm_DuLieuKH frm = new frm_DuLieuKH();
          //  frm.ShowDialog();
        }

        private void thôngTinKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frm_DanhSachKH frm = new frm_DanhSachKH();
            //frm.ShowDialog();
        }

    
        private void lichGhiDHN_Click(object sender, EventArgs e)
        {
            //frm_QLDongHoNuoc frm = new frm_QLDongHoNuoc();
            //frm.ShowDialog();
        }

       

        private void btDLDHNuoc_Click(object sender, EventArgs e)
        {
            frm_QLDHN frm = new frm_QLDHN();
            frm.ShowDialog();
        }
    }
}
