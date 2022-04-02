using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.Cookies["login"] != null)  //logout
            {
                Response.Cookies["login"].Expires = DateTime.Now.AddDays(-1);

                Response.Redirect("../Default.aspx");
            }

        }
        catch (Exception ex) { err.InnerHtml = ex.Message + "<hr/>" + ex.GetBaseException(); }
    }
}