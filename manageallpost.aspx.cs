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
            ldposts(suser);
            user_listload();

        }

    }
    protected void user_listload()
    {
        user_list.Items.Clear();
        string sql = "";
        sql = " select [Username] , [First_name] , [Last_name] , [user_Id] From tbl_User where username in ( Select distinct Post_by from Posts )";
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
                user_list.Items.Insert(j, new ListItem(sname, svalue));

            }

        }

        sda.Dispose();
        cmd.Dispose();
        con.Close();


        user_list.Items.Insert(0, new ListItem("select", "select"));

    }
    protected void ldposts(string sid)
    {
        string sql = "", sData = "";
       
        sql = "select * from Posts where  Post_By='" + sid + "'";
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
            string sCaption = "", sDis = "", sAddedBy = "", sImage = "";
            var vId = ""; var vCount = 0;
            sAddedBy = Request.Cookies["Login"]["fullname"].ToString();
            for (int j = 0; j < i; j++)
            {
                vId = dt.Rows[j]["Id"].ToString();
                sImage = dt.Rows[j]["Post"].ToString();
                sCaption = dt.Rows[j]["Caption"].ToString();
                sDis = Server.HtmlDecode(dt.Rows[j]["Description"].ToString());
                sAddedBy = dt.Rows[j]["Post_by"].ToString();
                vCount = j + 1;
                sData += "<tr>";
                sData += "<td>" + vCount + "</td>";
                sData += "<td><img class='notchedimage' src='" + sImage + "'/></td>";
                sData += "<td>" + sCaption + "</td>";
                sData += "<td>" + sDis  + "</td>";
                sData += "<td><a href='editpost.aspx?id=" + vId + "'>EDIT</a></td>";
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
        if (!string.IsNullOrEmpty(vuser))
        {
            ldposts(vuser);
        }
    }
}
