using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class H3100_muokkaaAutot : System.Web.UI.Page
{
    BLAutot muokkaus;
    //private string aid;
    protected void Page_Init(object sender, System.EventArgs e)
    {
        // register css
        HtmlHead head = (HtmlHead)Page.Header;
        HtmlLink link = new HtmlLink();
        link.Attributes.Add("href", Page.ResolveClientUrl("~/omaRouppi.css"));
        link.Attributes.Add("type", "text/css");
        link.Attributes.Add("rel", "stylesheet");
        head.Controls.Add(link);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
            if (Request["aid"] != null)
            {
                Session["aid"] = Request["aid"];
                this.muokkaus = new BLAutot(Session["aid"].ToString());
                this.muokkaus.populateTxtBoxes(txtMalli, txtMerkki, txtMyyntihinta, txtRekkari,
                    txtSisaanostohinta,txtVm);
            }
            else
                lblTesti.Text = "Pitaa tulla sivun H3100_Jinta-Rouppi.aspx kautta, että toimii";
        if (IsPostBack)
        {
            this.muokkaus = new BLAutot(Session["aid"].ToString());
        }
        

    }
    protected void btnPaivita_Click(object sender, EventArgs e)
    {
        try
        {
            this.muokkaus.paivita(txtMalli.Text, txtMerkki.Text, txtMyyntihinta.Text,
               txtRekkari.Text, txtSisaanostohinta.Text, txtVm.Text);
        }
        catch (Exception ex)
        {

            lblTesti.Text = ex.Message;
        }
           

        Response.Redirect("~/H3100_Jinta-Rouppi.aspx");
    }
}