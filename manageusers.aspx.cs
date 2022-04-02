using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;


public partial class admin_Default : System.Web.UI.Page
{
    myConnections clsCon = new myConnections();
    SqlConnection con = new SqlConnection();

    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = clsCon.con();
        users_load();
    }

    protected void users_load()
    {
        string sql = "", sData = "";
        sql = " select [Username] , [First_name] , [Last_name] , [user_Id] , [suspend] From tbl_User ";
        if (con.State == ConnectionState.Closed) { con.Open(); }
        SqlCommand cmd = new SqlCommand(sql, con);

        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        sda.Dispose();
        cmd.Dispose();
        con.Close();

        int i = dt.Rows.Count;
        if (i > 0)
        {


            string sDate = "", ssuspend = "", sname = "", sID = "";
            var vCount = 0;

            for (int j = 0; j < i; j++)
            {
                sID = dt.Rows[j]["user_Id"].ToString();
                sname = dt.Rows[j]["First_name"].ToString() + "" + dt.Rows[j]["Last_name"].ToString();
                //sDate = dt.Rows[j]["cDate"].ToString();
                ssuspend = dt.Rows[j]["suspend"].ToString();
                vCount = j + 1;
                sData += "<tr>";
                sData += "<td>" + vCount + "</td>";
                sData += "<td>" + sID + "</td>";
                sData += "<td>" + sname + "</td>";
                sData += "<td>" + sDate + "</td>";
                sData += "<td>" + ssuspend + "</td>";
                sData += "<td><a href='editaccount.aspx?id=" + sID + "'>EDIT</a></td>";
                sData += "</tr>";


            }
        }
        else
        {
           
            sData = "No records found";
        }
        divtable.InnerHtml = sData;
        
    }

            

        

}