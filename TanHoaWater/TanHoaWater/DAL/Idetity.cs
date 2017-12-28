using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;
using System.Data.SqlClient;
using System.Data;

namespace TanHoaWater.DAL
{

    class Idetity
    {
        //public static DataTable getListbyDot(string dot, int FirstRow, int pageSize)
        //{
        //    TanHoaDataContext db = new TanHoaDataContext();
        //    db.Connection.Open();
        //    string sql = " SELECT MAX(SHS) as 'SHS',SOHO FROM BIENNHANDON WHERE LOAIDON='GM' GROUP BY SOHO ORDER BY SHS DESC";
        //    SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
        //    DataTable table = new DataTable();
        //    adapter.Fill(table);
        //    db.Connection.Close();
        //    return dataset.Tables[0];

        //}

        public static string IdentityBienNhan(string loaihs)
        {
            string year = DateTime.Now.Year.ToString().Substring(2);            
            string kytumacdinh = year + loaihs;
            if ("DD".Equals(loaihs)) {
                kytumacdinh = year + "D0";
            }
            string id = kytumacdinh + "999";
            try
            {

                String_Indentity.String_Indentity obj = new String_Indentity.String_Indentity();
                TanHoaDataContext db = new TanHoaDataContext();
                db.Connection.Open();
                if ("GM".Equals(loaihs))
                {
                    string sql = " SELECT MAX(SHS) as 'SHS',SOHO FROM BIENNHANDON WHERE LOAIDON='GM' GROUP BY SOHO ORDER BY SHS DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        if (table.Rows[0][0].ToString().Trim().Substring(0, 2).Equals(year))
                        {
                            int number = 1;
                            if (int.Parse(table.Rows[0][1] + "") > 1)
                                number = int.Parse(table.Rows[0][1] + "");

                            id = obj.ID(year, table.Rows[0][0].ToString().Trim(), "000000", number) + "";
                        }
                        else
                        {
                            id = obj.ID(year, year + "000000", "000000") + "";
                        }
                    }
                    else
                    {
                        id = obj.ID(year, year + "000000", "000000") + "";
                    }

                    db.Connection.Close();
                }
                else
                {
                    string sql = " SELECT MAX(SHS) as 'SHS',SOHO FROM BIENNHANDON WHERE LOAIDON='" + loaihs + "' GROUP BY SOHO ORDER BY SHS DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        if (table.Rows[0][0].ToString().Trim().Substring(0, 2).Equals(year))
                        {
                            int number = 1;
                            if (int.Parse(table.Rows[0][1] + "") > 1)
                                number = int.Parse(table.Rows[0][1] + "");

                            id = obj.ID(kytumacdinh, table.Rows[0][0].ToString().Trim(), "0000", number) + "";
                        }
                        else
                        {
                            id = obj.ID(year + loaihs, year + loaihs + "0000", "0000") + "";
                        }                       
                    }
                    else
                    {
                        id = obj.ID(kytumacdinh, table.Rows[0][0].ToString().Trim(), "0000") + "";
                    }

                    db.Connection.Close();

                    /*
                    string sql = "SELECT MAX(SHS) FROM BIENNHANDON WHERE LOAIDON='" + loaihs + "'";
                    SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader dr1 = cmd.ExecuteReader();
                    while (dr1.Read())
                    {

                        if (dr1[0].ToString().Trim().Substring(0, 2).Equals(year))
                        {
                            id = obj.ID(kytumacdinh, dr1[0].ToString().Trim(), "0000") + "";
                        }
                        else
                        {
                            id = obj.ID(year + loaihs, year + loaihs + "0000", "0000") + "";
                        }
                    }
                    dr1.Close();
                    db.Connection.Close();
                     * */
                }
            }
            catch (Exception)
            {

            }

            return id;

        }


        public static string IdentityDUAN(string loaihs)
        {
            loaihs = "DA";
            string year = DateTime.Now.Year.ToString().Substring(2);
            string kytumacdinh = year + loaihs;
          
           
            string id = kytumacdinh + "001";
            try
            {

                String_Indentity.String_Indentity obj = new String_Indentity.String_Indentity();
                TanHoaDataContext db = new TanHoaDataContext();
                db.Connection.Open();
                string sql = " SELECT MAX(MADOT) as 'SHS' FROM KH_XINPHEPDAODUONG WHERE CREATEBY='" + DAL.C_USERS._userName + "'  ORDER BY SHS DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        if (table.Rows[0][0].ToString().Trim().Substring(0, 2).Equals(year))
                        {
                            int number = 1;
                            //if (int.Parse(table.Rows[0][1] + "") > 1)
                            //    number = int.Parse(table.Rows[0][1] + "");

                            id = obj.ID(kytumacdinh, table.Rows[0][0].ToString().Trim(), "0000", number) + "";
                        }
                        else
                        {
                            id = obj.ID(year + loaihs, year + loaihs + "0000", "0000") + "";
                        }
                    }
                    else
                    {
                        id = obj.ID(kytumacdinh, table.Rows[0][0].ToString().Trim(), "0000") + "";
                    }

                    db.Connection.Close();

            }
            catch (Exception)
            {

            }

            return id;

        }


        public static string IdentityAMSAU()
        {
            string loaihs = "A";
            string year = DateTime.Now.Year.ToString().Substring(2);
            string kytumacdinh = year + loaihs;


            string id = kytumacdinh + "0001";
            try
            {

                String_Indentity.String_Indentity obj = new String_Indentity.String_Indentity();
                TanHoaDataContext db = new TanHoaDataContext();
                db.Connection.Open();
                string sql = " SELECT MAX(SHS) as 'SHS' FROM AS_KHACHHANG  ORDER BY SHS DESC";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                DataTable table = new DataTable();
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    if (table.Rows[0][0].ToString().Trim().Substring(0, 2).Equals(year))
                    {
                        int number = 1;
                        //if (int.Parse(table.Rows[0][1] + "") > 1)
                        //    number = int.Parse(table.Rows[0][1] + "");

                        id = obj.ID(kytumacdinh, table.Rows[0][0].ToString().Trim(), "0000", number) + "";
                    }
                    else
                    {
                        id = obj.ID(year + loaihs, year + loaihs + "0000", "0000") + "";
                    }
                }
                else
                {
                    id = obj.ID(kytumacdinh, table.Rows[0][0].ToString().Trim(), "0000") + "";
                }

                db.Connection.Close();

            }
            catch (Exception)
            {

            }

            return id;

        }


        public static string IdentitySoHopDong(string sohodong)
        {
            try
            {
                String_Indentity.String_Indentity obj = new String_Indentity.String_Indentity();
                sohodong = obj.ID(sohodong.Substring(0, 2), sohodong, "00000") + "";
            }
            catch (Exception)
            {
            }
            return sohodong;
        }

        public static string IdentityDutChi()
        {
            string loaihs = "BC";
            string year = DateTime.Now.Year.ToString().Substring(2);
            string kytumacdinh = year + loaihs;


            string id = kytumacdinh + "0001";
            try
            {

                String_Indentity.String_Indentity obj = new String_Indentity.String_Indentity();
                TanHoaDataContext db = new TanHoaDataContext();
                db.Connection.Open();
                string sql = " SELECT MAX(SoBangKe)   FROM KH_HOSOBAMCHIGOC ";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                DataTable table = new DataTable();
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    if (table.Rows[0][0].ToString().Trim().Substring(0, 2).Equals(year))
                    {
                        int number = 1;
                        //if (int.Parse(table.Rows[0][1] + "") > 1)
                        //    number = int.Parse(table.Rows[0][1] + "");

                        id = obj.ID(kytumacdinh, table.Rows[0][0].ToString().Trim(), "0000", number) + "";
                    }
                    else
                    {
                        id = obj.ID(year + loaihs, year + loaihs + "0000", "0000") + "";
                    }
                }
                else
                {
                    id = obj.ID(kytumacdinh, table.Rows[0][0].ToString().Trim(), "0000") + "";
                }

                db.Connection.Close();

            }
            catch (Exception)
            {

            }

            return id;

        }

        public static string IdentityToMangLuoi()
        {
            string loaihs = "ML";
            string year = DateTime.Now.Year.ToString().Substring(2);
            string kytumacdinh = year + loaihs;


            string id = kytumacdinh + "0001";
            try
            {

                String_Indentity.String_Indentity obj = new String_Indentity.String_Indentity();
                TanHoaDataContext db = new TanHoaDataContext();
                db.Connection.Open();
                string sql = " SELECT MAX(SOHOSO)   FROM TOQLMANGLUOI ";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                DataTable table = new DataTable();
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    if (table.Rows[0][0].ToString().Trim().Substring(0, 2).Equals(year))
                    {
                        int number = 1;
                        //if (int.Parse(table.Rows[0][1] + "") > 1)
                        //    number = int.Parse(table.Rows[0][1] + "");

                        id = obj.ID(kytumacdinh, table.Rows[0][0].ToString().Trim(), "0000", number) + "";
                    }
                    else
                    {
                        id = obj.ID(year + loaihs, year + loaihs + "0000", "0000") + "";
                    }
                }
                else
                {
                    id = obj.ID(kytumacdinh, table.Rows[0][0].ToString().Trim(), "0000") + "";
                }

                db.Connection.Close();

            }
            catch (Exception)
            {

            }

            return id;

        }


    }
}