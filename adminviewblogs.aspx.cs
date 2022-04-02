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
        view_blogs();
    }

    protected void view_blogs()
    {
        string sql = "";
        sql = "select * from tbl_Blog where blog_by ='" + Request.Cookies["login"]["username"].ToString() + "'";
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
            string sData = "", sCaption = "", sDisc = "", sAddedBy = "", sImage = "";

            for (int j = 0; j < i; j++)
            {
                sImage = dt.Rows[j]["blogpic"].ToString();
                sCaption = dt.Rows[j]["Title"].ToString();
                sDisc = dt.Rows[j]["Descriptionblog"].ToString();
                sAddedBy = fxnUser(dt.Rows[j]["blog_by"].ToString());


                sData += " <div class='col-lg-6' style=' height:50%,width:50%;'>";
                if ((j + 1) % 2 != 0)
                {
                    sData += "   <div class='rectangle'>";
                }
                else
                {
                    sData += "   <div class='rectangle2'>";
                }
                sData += "<div class='containerbox'>";
                sData += "    <label class='headcaption'>" + sAddedBy + "</label>";
                sData += "     <image class='imagestyle' src='" + sImage + "' />";
                sData += "   <p>" + sCaption + "</p>";
                sData += "   <p>" + Server.HtmlDecode(sDisc) + "</p></div>";
                sData += "   </div>";
                sData += "<br>";
                sData += "</div>";
            }
            viewblogs.InnerHtml = sData;


        }

    }


    private string fxnUser(string sID)
    {
        string sql = "", sFullName = "";
        sql = "select * from tbl_User where Username='" + sID + "'";
        if (con.State == ConnectionState.Closed) { con.Open(); }
        SqlCommand com = new SqlCommand(sql, con);
        SqlDataReader sdr = com.ExecuteReader();

        if (sdr.HasRows)
        {
            sdr.Read();
            sFullName = sdr["First_name"].ToString() + " " + sdr["Last_name"].ToString();
        }

        sdr.Close();
        com.Dispose(); con.Close();


        return sFullName;
    }

}