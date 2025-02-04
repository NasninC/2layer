using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace _2layer
{
    public partial class UserLogin : System.Web.UI.Page
    {
        ConnectionCls objcls = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "select count(Id) from T1 where Username='" + TextBox1.Text + "'and Password='" + TextBox2.Text + "'";
            string i = objcls.Fn_Scalar(sel);
            if(i=="1")
            {
                string selid= "select Id from T1 where Username='" + TextBox1.Text + "'and Password='" + TextBox2.Text + "'";
                int id = 0;
                SqlDataReader dr = objcls.Fn_Reader(selid);
                while(dr.Read())
                {
                    id = Convert.ToInt32(dr["Id"].ToString());
                }
                Session["uid"] = id;
                Response.Redirect("UserProfile.aspx");
            }
            else
            {
                Label1.Text = "Invalid username and password";
            }
        }
    }
}