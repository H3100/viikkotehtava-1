using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Web.HttpContext.Current.Session;

public partial class H3100_indexMP : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String parametri = "?name=" + txtName.Text;
        Response.Redirect("H3100_valuuttamuunnin.aspx"+parametri);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Session["nimi"] = txtName.Text;
        Response.Redirect("H3100_valuuttamuunnin.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {       
        HttpCookie keksi = new HttpCookie("UserName");
        keksi.Value = txtName.Text;
        keksi.Expires = DateTime.Now.AddDays(1d);
        Response.Cookies.Add(keksi);

        Response.Redirect("H3100_valuuttamuunnin.aspx");
    }
}