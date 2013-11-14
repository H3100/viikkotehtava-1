using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class H3100_RouppiAloitus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string toBeRedirected = "~/H3100_Jinta-Rouppi.aspx?user=" + txtKT.Text +
                                "&passwd=" + txtSalasana.Text;
        Response.Redirect(toBeRedirected);
    }
}