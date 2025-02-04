using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace _2layer
{
    public class ConnectionCls
    {
        SqlConnection con;
        SqlCommand cmd;

        public ConnectionCls()
        {
            con = new SqlConnection(@"server=BLACK_PINK\SQLEXPRESS;database=P2;Integrated security=true");
        }
        public int Fn_NonQuery(string sqlquery)//insert,delete,update
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
                
        }
        public string Fn_Scalar(string sqlquery)//count,min,max...
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            string i = cmd.ExecuteScalar().ToString();
            con.Close();
            return i;

        }
        public SqlDataReader Fn_Reader(string sqlquery)//select
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public DataSet Fn_Dataset(string sqlquery)//select
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataTable Fn_Datatable(string sqlquery)//select
        {
          if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}