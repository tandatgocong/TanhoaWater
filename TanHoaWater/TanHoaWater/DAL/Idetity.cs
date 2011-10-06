using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TanHoaWater.Database;
using System.Data.SqlClient;

namespace TanHoaWater.DAL
{
    class Idetity
    {
        public static string IdentityBienNhan(string loaihs)
        {
            string year = DateTime.Now.Year.ToString().Substring(2);
            string kytumacdinh = year + loaihs;
            string id = kytumacdinh+"999";
            try
            {

                String_Indentity.String_Indentity obj = new String_Indentity.String_Indentity();
                TanHoaDataContext db = new TanHoaDataContext();
                SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
                conn.Open();
                if ("GM".Equals(loaihs))
                {
                    string sql = "SELECT MAX(SHS) FROM BIENNHANDON WHERE LOAIDON='GM'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader dr1 = cmd.ExecuteReader();
                    while (dr1.Read())
                    {
                        if (dr1[0].ToString().Trim().Substring(0, 2).Equals(year))
                        {
                            id = obj.ID(year, dr1[0].ToString().Trim(), "00000");
                        }
                        else {
                            id = obj.ID(year, year+"00000", "00000");
                        }
                        
                    }
                    dr1.Close();
                    db.Connection.Close();
                }
                else
                {
                    string sql = "SELECT MAX(SHS) FROM BIENNHANDON WHERE LOAIDON='" + loaihs + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader dr1 = cmd.ExecuteReader();
                    while (dr1.Read())
                    {
                        
                        if (dr1[0].ToString().Trim().Substring(0, 2).Equals(year))
                        {
                            id = obj.ID(kytumacdinh, dr1[0].ToString().Trim(), "000");
                        }
                        else
                        {
                            id = obj.ID(year + loaihs, year +loaihs+ "000", "000");
                        }
                    }
                    dr1.Close();
                    db.Connection.Close();
                }
            }
            catch (Exception)
            {
                 
            }
            

            return id;

        }
    }
}
