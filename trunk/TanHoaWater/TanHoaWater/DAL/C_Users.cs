using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;
using System.Data;
using System.Data.SqlClient;

namespace TanHoaWater.DAL
{
    public class C_USERS
    {
        public static string _fullName = null;
        public static string _userName = null;
        public static string _roles = null;        
        public bool AddNew(USER user)
        {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.USERs.InsertOnSubmit(user);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {

            }
            return false;
        }
        public static USER findByUserName(string username)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var data = from user in db.USERs where user.USERNAME == username select user;
            USER us = data.SingleOrDefault();     
            return us;
        }
        public  bool UpdateUser(USER user)
        {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.SubmitChanges();
            }
            catch (Exception)
            { }
            return false;
        }
        public  bool DeleteUser(USER user)
        {
            try
            {
                TanHoaDataContext db = new TanHoaDataContext();
                db.USERs.DeleteOnSubmit(user);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {}
            return false;
        }
        public  DataTable getList(string username, string fullName, string rolesId)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            db.Connection.Open();
            string sql = "SELECT  USERNAME AS 'Tên Đăng Nhập',FULLNAME as 'Tên Đầy Đủ',ROLENAME as 'Quyền' ";
            sql +=" FROM USERS, ROLES ";
            sql +=" WHERE USERS.ROLEID = ROLES.ROLEID  ";
           
            if(username!= null && !"".Equals(username)){
                sql += " AND USERNAME LIKE '%"+ username +"%'";
            }
            
            if (fullName != null && !"".Equals(fullName))
            {
                sql += " AND FULLNAME LIKE '%" + fullName + "%'";
            }

            if (rolesId != null && !"".Equals(rolesId))
            {
                sql += " AND USERS.ROLEID = '" + rolesId + "'";
            }
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            db.Connection.Close();
           return table;
        }
        public bool UserLogin(string userName, string passWord) {
            TanHoaDataContext db = new TanHoaDataContext();
            var data = from user in db.USERs where user.USERNAME == userName && user.PASSWORD == passWord && user.ENABLED ==true select user;
            USER userLogin = data.SingleOrDefault();
            if (userLogin != null)
            {
                USER userlogin = (USER)data.SingleOrDefault();
                _userName = userlogin.USERNAME;
                _fullName = userlogin.FULLNAME;
                _roles = userlogin.ROLEID;
                return true;
            }
            return false;
        }

        //public static List<USER> getAll() {
        //    TanHoaDataContext db = new TanHoaDataContext();
        //    var data = from user in db.USERs   select user;       
        //    return data.ToList();
        //}
        public static List<USER> getUserByMaPhongAndLevel(string maphong, int cap) {

            TanHoaDataContext db = new TanHoaDataContext();
            var data = from user in db.USERs where user.MAPHONG == maphong && user.CAP == cap select user;
            return data.ToList();

        }

    }
}
