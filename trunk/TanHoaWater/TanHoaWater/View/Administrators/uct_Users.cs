using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoaWater.Database;
using TanHoaWater.DAL;
using TanHoaWater.Utilities;

namespace TanHoaWater.View.Administrators
{
    public partial class uct_Users : UserControl
    {
        public uct_Users()
        {
            InitializeComponent();
            fromload();
            LoadUsers();
            //formatGirdView();
           
        }
        public void fromload()
        {
            #region Load Combobox Role
            this.u_Quyen.DataSource = C_Role.getList();
            u_Quyen.DisplayMember = "ROLENAME";
            u_Quyen.ValueMember = "ROLEID";
            //this.u_Quyen.DataSource = C_Role.comboxSearch();
            //this.u_Quyen.DisplayMember = "Display";
            //this.u_Quyen.ValueMember = "Value";
            #endregion
            #region Phong Ban
            this.u_BoPhan.DataSource = C_PhongBan.getList();
            u_BoPhan.DisplayMember = "TENPHONG";
            u_BoPhan.ValueMember = "MAPHONG";
            #endregion
        }
        public void LoadUsers(){
            DAL.C_USERS user = new DAL.C_USERS();
            userGridView.DataSource = user.getList(this.txtUserName.Text, this.txtName.Text, "");
            Utilities.DataGridV.formatRows(userGridView);
        }

        //public void formatGirdView() {           
        //    for (int i = 0; i < this.userGridView.ColumnCount; i++){
        //        this.userGridView.Columns[0].ReadOnly = true;
        //        this.userGridView.Columns[i].Width = 170;                         
        //    }
        //}         
        //private void btAddNew_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string username = this.txtUserName.Text;
        //        bool flag = true;
        //        if (username == null || "".Equals(username))
        //        {
        //            errorProvider1.SetError(this.txtUserName, "Tên đăng nhập không được trống!!");
        //            flag = false;
        //        }
        //        string fullName = this.txtName.Text;
        //        if (fullName == null || "".Equals(fullName))
        //        {
        //            errorProvider1.SetError(this.txtName, "Họ Và Tên không được trống!!");
        //            flag = false;
        //        }
        //        string rolesId = this.cbRoles.SelectedValue.ToString();
        //        if (rolesId == null || "".Equals(rolesId))
        //        {
        //            errorProvider1.SetError(this.cbRoles, "Chọn Quyền!!");
        //            flag = false;
        //        }
        //        if (flag == true)
        //        {
        //            errorProvider1.Clear();
        //            USER user = new USER();
        //            user.USERNAME = username;
        //            user.FULLNAME = fullName;
        //            user.PASSWORD = LogIn.Encrypt(this.txtPassword.Text);
        //            user.ROLEID = rolesId;
        //            user.CREATEBY = "";
        //            user.ENABLED = true;
        //            user.CREATEDATE = DateTime.Now;
        //            DAL.C_USERS users = new DAL.C_USERS();
        //            if (DAL.C_USERS.findByUserName(user.USERNAME) == null)
        //            {
        //                users.AddNew(user);
        //            }
        //            userGridView.DataSource = null;
        //            userGridView.DataSource = users.getList(null, null, null);
        //            formatGirdView();
        //        }
        //    }
        //    catch (Exception)
        //    {     }
        //}

        private void btSearch_Click(object sender, EventArgs e)
        {
            LoadUsers();
            //formatGirdView();
            Utilities.DataGridV.formatRows(userGridView);
        }

        private void userGridView_Click(object sender, EventArgs e)
        {
            Utilities.DataGridV.formatRows(userGridView);
        }

        private void userGridView_Sorted(object sender, EventArgs e)
        {
            Utilities.DataGridV.formatRows(userGridView);
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            try
            {
                string username = this.u_tendangnhap.Text;
                string fullName = this.u_hoten.Text;
                string chucvu = this.u_chucvu.Text;
                
                if (username == null || "".Equals(username))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(this.u_tendangnhap, "Tên đăng nhập không được trống !");
                    u_tendangnhap.Focus();
                     
                }else  if (fullName == null || "".Equals(fullName))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(this.u_hoten, "Họ Và Tên không được trống !");
                    u_hoten.Focus();
                     
                }else if (chucvu == null || "".Equals(chucvu))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(this.u_chucvu, "Chọn Chức Vụ !");
                    u_chucvu.Focus();
                    
                }else
                
                {
                    errorProvider1.Clear();
                    USER user = new USER();
                    user.USERNAME = username;
                    user.FULLNAME = fullName;
                    user.PASSWORD = LogIn.Encrypt(this.u_matkhau.Text);
                    user.ROLEID = this.u_Quyen.SelectedValue+"";
                    user.MAPHONG = this.u_BoPhan.SelectedValue + "";
                    user.CREATEBY = C_USERS._userName;
                    user.CAP = this.u_chucvu.SelectedIndex;
                    if (u_kichhoat.Checked)
                    {
                        user.ENABLED = true;
                    }
                    else
                    {
                        user.ENABLED = false;
                    }
                    user.CREATEDATE = DateTime.Now;
                    DAL.C_USERS users = new DAL.C_USERS();
                    if (DAL.C_USERS.findByUserName(user.USERNAME) == null)
                    {
                        users.AddNew(user);
                    }
                    else {
                        MessageBox.Show(this, "Người dùng đã tồn tại.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadUsers();
                }
            }
            catch (Exception)
            { }
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {

        }
        public void refesh() {
            this.u_hoten.Text = "";
            this.u_tendangnhap.Text = "";
            this.u_matkhau.Text = "";
            this.u_kichhoat.Checked = true;
            this.u_hoten.Focus();

        }
        private void btmLamLai_Click(object sender, EventArgs e)
        {
            refesh();
        } 
    }
}
