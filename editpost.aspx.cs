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

    string sPId = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = clsCon.con();
        if (Request.Cookies["login"] != null)
        {
            sPId = Request.QueryString["ID"].ToString();

            sUserName = Request.Cookies["login"]["username"].ToString();
            suserid = Request.Cookies["login"]["ID"].ToString();

        }
        else
        {
            Response.Write("<script language='javascript'>alert('your cookies has expired. please login to continue');</script>");
            Response.Redirect("../loginmain.aspx");

        }
        if (!IsPostBack)
        {
            load_post();
        }

    }

    protected void load_post()
    {

        string sql = "";

        {

            sql = "select * from Posts where ID = '" + sPId + "'";
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand com = new SqlCommand(sql, con);


            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int i = dt.Rows.Count;
            if (i > 0)
            {

                Image1.ImageUrl = dt.Rows[0]["Post"].ToString();
                txt_Caption.Text = dt.Rows[0]["Caption"].ToString();
                txt_Description.Text = Server.HtmlDecode(dt.Rows[0]["Description"].ToString());
            }

        }
    }


    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string sql = "", sField = "";
        try
        {
            var vPath = "../posts/" + suserid + "/";
            if (!Directory.Exists(vPath))
            {
                Directory.CreateDirectory(Server.MapPath(vPath));
            }

            sField = "Caption='" + txt_Caption.Text + "'";
            if (Pictures.HasFile)
            {
                Pictures.SaveAs(Server.MapPath(vPath) + Pictures.FileName);

                sField += ",Post='" + clsCon.getBaseurl + "posts/" + suserid + "/" + Pictures.FileName + "'";
            }
            sField += ",Description='" + Server.HtmlEncode(txt_Description.Text) + "'";


            sql = "update Posts set " + sField + " where ID = '" + sPId + "'";

            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand com = new SqlCommand(sql, con);
            int i = com.ExecuteNonQuery();
            if (i > 0)
            {
                divErr.InnerHtml = " <div style='padding:10px;color:red;background-color:ghostwhite;'>post Updated successfully. Continue adding more.....</div>";

                load_post();
            }
            else { divErr.InnerHtml = "can not register at the moment, please try after sometime...."; }

            com.Dispose(); con.Close();
        }
        catch (Exception ex) { divErr.InnerHtml = "<div style='padding:10px;color:red;background-color:ghostwhite;'> error: " + ex.Message + " <hr/> " + ex.GetBaseException() + "<hr>" + sql + "</div>"; }

        // 
    }







    protected void btndelete_Click(object sender, EventArgs e)
    {
        string sql = "";
        {
            sql = "delete from Posts where ID = '" + sPId + "'";
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand com = new SqlCommand(sql, con);

            int i = com.ExecuteNonQuery();
            if (i > 0)
            {
                Response.Redirect("manage.aspx");

            }
            else { divErr.InnerHtml = "Something Caused Error Please Report to The Admin"; }

            com.Dispose(); con.Close();

        }
    }

}