using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class H3100_AuthTesteja : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session.Clear();
        //Session.Abandon();
        FormsAuthentication.SignOut();
        //FormsAuthentication.RedirectToLoginPage();
    }
    protected void LoggedIn(object sender, EventArgs e)
    {
        string toBeRedirected = "~/H3100_Jinta-Rouppi.aspx?user=" + Login1.UserName;
        Response.Redirect(toBeRedirected);
    }
}