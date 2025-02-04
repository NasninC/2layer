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
    public partial class UserProfile : System.Web.UI.Page
    {
        ConnectionCls objcls = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            string a = "select Name,Age,Address,Photo from T1 where Id=" + Session["uid"] + "";
            SqlDataReader dr = objcls.Fn_Reader(a);
            while(dr.Read())
            {
                TextBox1.Text = dr["Name"].ToString();
                TextBox2.Text = dr["Age"].ToString();
                TextBox3.Text = dr["Address"].ToString();
                Image1.ImageUrl = dr["Photo"].ToString();
            }

            string b = "select * from T1";
            DataSet ds = objcls.Fn_Dataset(b);
            GridView1.DataSource = ds;
            GridView1.DataBind();

            string c = "select Name,Age,Address,Photo from T1";
            DataTable dt = objcls.Fn_Datatable(c);
            DataList1.DataSource = ds;
            DataList1.DataBind();
        }
    }
}