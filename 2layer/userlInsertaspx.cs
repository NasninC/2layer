using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace _2layer
{
    public partial class userlogin : System.Web.UI.Page
    {
        ConnectionCls objcls = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string p = "~/Photos/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));

            string str = "insert into T1 values('" + TextBox1.Text + "'," + TextBox2.Text + ",'" + TextBox3.Text + "','" + p + "','" + TextBox4.Text + "','" + TextBox5.Text + "')";

            int i = objcls.Fn_NonQuery(str);
            if(i==1)
            {
                Label7.Text = "Inserted";
            }
                

            
        }
    }
}