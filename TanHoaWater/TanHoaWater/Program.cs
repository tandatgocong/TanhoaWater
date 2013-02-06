using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TanHoaWater.View.Users;
using TanHoaWater.View.Users.TinhDuToan.BGDieuChinh;
using System.Threading;
using System.Globalization;

namespace TanHoaWater
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_Main());
            // Application.Run(new frm_VatTuDieuChinh());
        }
    }
}
