using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;

namespace TanHoaWater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();



            Column1.DataSource = DAL.C_DanhMucTaiLapMD.getListDanhMucTLMD();
            Column1.DisplayMember = "TENKETCAU";
            Column1.ValueMember = "MADANHMUC";
            Column1.DropDownWidth = 400;
           
            
        }

        private void dataGridViewX1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 || e.KeyChar == 9) {
               
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewX1.Rows.Count; i++) {
                MessageBox.Show(dataGridViewX1.Rows[i].Cells[0].Value+"");
            }
        }
    }
}
