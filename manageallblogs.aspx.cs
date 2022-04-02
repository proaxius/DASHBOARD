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
    string suser = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = clsCon.con();
        suser = Request.Cookies["Login"]["username"].ToString();
        if (!IsPostBack)
        {
            manageblogs(suser);
            user_listload();

        }
        
    }
    protected void user_listload()
    {
        user_list.Items.Clear();
        string sql = "";
        sql = " select [Username] , [First_name] , [Last_name] , [user_Id] From tbl_User where username in ( Select distinct blog_by from tbl_Blog )";
        if (con.State == ConnectionState.Closed) { con.Open(); }
        SqlCommand cmd = new SqlCommand(sql, con);

        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        int i = dt.Rows.Count;
        if (i > 0)
        {
            var sname = ""; var svalue = "";
            for (int j = 0; j < i; j++)
            {
                sname = dt.Rows[j]["First_name"].ToString() + " " + dt.Rows[j]["Last_name"].ToString();

                svalue = dt.Rows[j]["Username"].ToString();
                 user_list.Items.Insert(0, new ListItem(sname,svalue ));

            }
            
        }

        sda.Dispose();
        cmd.Dispose();
        con.Close();

        
        
        
    }
    protected void manageblogs(string sid)
    {
        string sql = "", sData = "";
        //   sql = "select * from tbl_Blog where blog_by ='" + Request.Cookies["Login"]["username"].ToString() + "'";
        sql = "select * from tbl_Blog where blog_by ='" + sid + "'";
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
            string stitle = "", sblogs = "", sAddedBy = "", sImage = "";
            var vId = ""; var vCount = 0;
            sAddedBy = Request.Cookies["Login"]["fullname"].ToString();
            for (int j = 0; j < i; j++)
            {
                vId = dt.Rows[j]["ID"].ToString();
                sImage = dt.Rows[j]["blogpic"].ToString();
                stitle = dt.Rows[j]["Title"].ToString();
                sblogs = Server.HtmlDecode(dt.Rows[j]["Descriptionblog"].ToString());
                sAddedBy = dt.Rows[j]["blog_by"].ToString();
                vCount = j + 1;
                sData += "<tr>";
                sData += "<td>" + vCount + "</td>";
                sData += "<td><img class='notchedimage' src='" + sImage + "'/></td>";
                sData += "<td>" + stitle + "</td>";
                sData += "<td>" + sblogs + "</td>";
                sData += "<td><a href='editblog.aspx?id=" + vId + "'>EDIT</a></td>";
                sData += "</tr>";

            }
        }
        else
        {
            diverr.InnerHtml = "No records found";
           sData = "No records found";
        }


        divblog.InnerHtml = sData;
    }

    protected void user_list_SelectedIndexChanged(object sender, EventArgs e)
    {
        var vuser = user_list.SelectedValue.ToString();
        if (!string.IsNullOrEmpty(vuser)) {
            manageblogs(vuser);
        }
    }
}