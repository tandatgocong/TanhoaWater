using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TanHoaWater.View.Users.To_ThietKe
{
    public partial class tab_HoanTatTK : UserControl
    {
        public tab_HoanTatTK()
        {
            InitializeComponent();
            this.cbDotNhanDon.DataSource = DAL.C_ToThietKe.DANHSACHDOTNHANDON();
            this.cbDotNhanDon.ValueMember = "MADOT";
            this.cbDotNhanDon.DisplayMember = "MADOT";

        }
    }
}
