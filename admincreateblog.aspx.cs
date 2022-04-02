using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;



public partial class admin_Default : System.Web.UI.Page
{
   
    myConnections clsCon = new myConnections();
    SqlConnection con = new SqlConnection();
    string sUserName = "", suserid = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = clsCon.con();
        if (Request.Cookies["login"] != null)
        {
            sUserName = Request.Cookies["login"]["username"].ToString();
            suserid = Request.Cookies["login"]["ID"].ToString();
        }
        else
        {
            Response.Write("<script language='javascript'>alert('your cookies has expired. please login to continue');</script>");
            Response.Redirect("../loginmain.aspx");

        }

        var vPath = "../Blogs/" + suserid + "/";
        if (!Directory.Exists(vPath))
        {
            Directory.CreateDirectory(Server.MapPath(vPath));
        }

    }

    protected void Btnupload_Click(object sender, EventArgs e)
    {
        string sql = "", sField = "", sValues = "";
        try
        {
            var vPath = "../Blogs/" + suserid + "/";
            if (!Directory.Exists(vPath))
            {
                Directory.CreateDirectory(Server.MapPath(vPath));
            }


            sField = "cDate"; sValues = "'" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
            sField += ",cTime"; sValues += ",'" + DateTime.Now.ToString("T") + "'";
            sField += ",Title"; sValues += ",'" + txt_title.Text + "'";
            if (Blogpic.HasFile)
            {
                Blogpic.SaveAs(Server.MapPath(vPath) + Blogpic.FileName);

                sField += ",Blogpic"; sValues += ",'" + vPath + Blogpic.FileName + "'";
            }
            sField += ",Descriptionblog"; sValues += ",'" + txt_Descriptionblog.Text + "'";

            sField += ",blog_by"; sValues += ",'" + sUserName + "'";

            sql = "insert into tbl_Blog  (" + sField + ") values(" + sValues + ")";

            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand com = new SqlCommand(sql, con);
            int i = com.ExecuteNonQuery();
            if (i > 0)
            {
                divErr.InnerHtml = " <div style='padding:10px;color:red;background-color:ghostwhite;'>New Blog added successfully. Continue adding more..... </div>";

                txt_Descriptionblog.Text = "";
                txt_title.Text = "";

            }
            else { divErr.InnerHtml = "can not register at the moment, please try after sometime...."; }

            com.Dispose(); con.Close();
        }
        catch (Exception ex) { divErr.InnerHtml = "<div style='padding:10px;color:red;background-color:ghostwhite;'> error: " + ex.Message + " <hr/> " + ex.GetBaseException() + "<hr>" + sql + "</div>"; }

    }




}