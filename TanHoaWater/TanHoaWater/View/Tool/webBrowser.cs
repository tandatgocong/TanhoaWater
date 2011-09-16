using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TanHoaWater.View.Tool
{
    public partial class webBrowser : UserControl
    {
        void ClickButton(string attribute, string attName)
        {
            HtmlElementCollection col = webBrowser1.Document.GetElementsByTagName("type");

            foreach (HtmlElement element in col)
            {
                if (element.GetAttribute(attribute).Equals(attName))
                {

                 
                    element.InvokeMember("click");
                }
            }
        }
        public webBrowser()
        {
            InitializeComponent();
            webBrowser1.Navigate("http://office.capnuoctanhoa.com.vn/security/login.aspx?action=expired");           

        }
    }
}
