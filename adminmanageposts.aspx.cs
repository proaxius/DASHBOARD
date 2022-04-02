using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class admin_Default : System.Web.UI.Page
{
    myConnections clsCon = new myConnections();
    SqlConnection con = new SqlConnection();

    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = clsCon.con();
        manageblogs();
    }
    protected void manageblogs()
    {
        string sql = "", sData = "";
        sql = "select * from tbl_Blog where blog_by ='" + Request.Cookies["Login"]["username"].ToString() + "'";
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


        divblog.InnerHtml = sData;
    }
}