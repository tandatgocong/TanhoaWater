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
using TanHoaWater.Class;

namespace TanHoaWater.View.Administrators
{
    public partial class uct_Users : UserControl
    {
        public uct_Users()
        {
            InitializeComponent();
            LoadRole();
            LoadUsers();
            formatGirdView();
        }
        public void LoadRole()
        {
             #region Load Combobox Role         
             //this.cbRoles.DataSource =  Role.getList();
             //cbRoles.DisplayMember = "ROLENAME";
             //cbRoles.ValueMember = "ROLEID";
            this.cbRoles.DataSource = C_Role.comboxSearch();
            this.cbRoles.DisplayMember = "Display";
            this.cbRoles.ValueMember = "Value";
            #endregion        
        }
        public void LoadUsers(){
            DAL.C_USERS user = new DAL.C_USERS();
            userGridView.DataSource = null;
            userGridView.DataSource = user.getList(this.txtUserName.Text, this.txtName.Text, this.cbRoles.SelectedValue.ToString());            
        }

        public void formatGirdView() {           
            for (int i = 0; i < this.userGridView.ColumnCount; i++){
                this.userGridView.Columns[0].ReadOnly = true;
                this.userGridView.Columns[i].Width = 170;                         
            }
        }         
        private void btAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                string username = this.txtUserName.Text;
                bool flag = true;
                if (username == null || "".Equals(username))
                {
                    errorProvider1.SetError(this.txtUserName, "Tên đăng nhập không được trống!!");
                    flag = false;
                }
                string fullName = this.txtName.Text;
                if (fullName == null || "".Equals(fullName))
                {
                    errorProvider1.SetError(this.txtName, "Họ Và Tên không được trống!!");
                    flag = false;
                }
                string rolesId = this.cbRoles.SelectedValue.ToString();
                if (rolesId == null || "".Equals(rolesId))
                {
                    errorProvider1.SetError(this.cbRoles, "Chọn Quyền!!");
                    flag = false;
                }
                if (flag == true)
                {
                    errorProvider1.Clear();
                    USER user = new USER();
                    user.USERNAME = username;
                    user.FULLNAME = fullName;
                    user.PASSWORD = LogIn.Encrypt(this.txtPassword.Text);
                    user.ROLEID = rolesId;
                    user.CREATEBY = "";
                    user.ENABLED = true;
                    user.CREATEDATE = DateTime.Now;
                    DAL.C_USERS users = new DAL.C_USERS();
                    if (DAL.C_USERS.findByUserName(user.USERNAME) == null)
                    {
                        users.AddNew(user);
                    }
                    userGridView.DataSource = null;
                    userGridView.DataSource = users.getList(null, null, null);
                    formatGirdView();
                }
            }
            catch (Exception)
            {     }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            LoadUsers();
            formatGirdView();
        }
    }
}
