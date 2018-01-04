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
        public static string _maphong = null;
        public static string _maquyen = null;
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
        public static string KHVTDuyet()
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var data = from user in db.USERs where user.DUYET == true && user.MAPHONG.Equals("KD") == true select user;
           return data.SingleOrDefault().USERNAME;     
        }
        static TanHoaDataContext db = new TanHoaDataContext();
        public static USER findByUserName(string username)
        {
            
            var data = from user in db.USERs where user.USERNAME == username select user;
            USER us = data.SingleOrDefault();     
            return us;
        }
        public static USER findByFullName(string fullName)
        {
            TanHoaDataContext db = new TanHoaDataContext();
            var data = from user in db.USERs where user.FULLNAME == fullName select user;
            USER us = data.SingleOrDefault();
            return us;
        }
        public static bool UpdateUser()
        {
            try
            {
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
            string sql = " SELECT  USERNAME ,FULLNAME ,TENPHONG,ROLENAME, CASE WHEN CAP='0' THEN N'Phó Phòng'  WHEN CAP='1' THEN N'Tổ Trưởng' ELSE N'Nhân Viên' END as 'CHUCVU',  CASE WHEN ENABLED='True' THEN N'Kích Hoạt' ELSE N'Chưa Kích Hoạt' END as 'TINHTRANG'  ";
            sql +="  FROM USERS u, ROLES  r, PHONGBANDOI p ";
            sql +=" WHERE u.ROLEID = r.ROLEID AND u.MAPHONG=p.MAPHONG ";
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
                _maphong = userlogin.MAPHONG;
                _maquyen = userlogin.ROLE;
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
        public static int ChangePass(string username, string passold, string passNew) {
            TanHoaDataContext db = new TanHoaDataContext();
            var data = from user in db.USERs where user.USERNAME == username  select user;
            USER u = data.SingleOrDefault();
            if(passold.Equals(Utilities.LogIn.Decrypt(u.PASSWORD))==true){
                try
                {
                    u.PASSWORD = Utilities.LogIn.Encrypt(passNew);
                    db.SubmitChanges();
                    return 1;
                }
                catch (Exception)
                {
                     
                }
                return 0;
            }
            return -1;

        }

    }
}
