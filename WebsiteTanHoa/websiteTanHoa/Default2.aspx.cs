using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebReference;
using System.Collections;
using System.Data;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    //    hd();
        //Service.HoaDon hd = Service.HoaDon();

    }
    
    public void hd()
    {
        //try
        //{
        //    GridView1.DataSource = null;
        //    WebReference.banhang bh = new WebReference.banhang();
        //    HoaDon[] item = bh.getBill(this.TextBox1.Text, int.Parse(this.TextBox2.Text));
        //    ArrayList list = new ArrayList();
        //    for (int i = 0; i < item.Length; i++)
        //    {
        //        HoaDon hod = item[i];
        //        list.Add(hod);
        //    }
        //    GridView1.DataSource = list;
        //    GridView1.DataBind();
        //}
        //catch (Exception)
        //{
            
           
        //}
 
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        hd();
    }
}