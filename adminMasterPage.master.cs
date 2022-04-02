using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

public partial class admin_adminMasterPage : System.Web.UI.MasterPage
{
 SqlConnection con = new SqlConnection(
    WebConfigurationManager.ConnectionStrings["myconnections"].ConnectionString);
    
        
        string sUserName = "", suserid = "";

    protected void admin_load()
    {
        
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
    }
}
