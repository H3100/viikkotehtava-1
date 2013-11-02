using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

public partial class H3100_Jinta_Rouppi : System.Web.UI.Page
{
    private string MappedApplicationPath
    {
        get
        {
            string APP_PATH = System.Web.HttpContext.Current.Request.ApplicationPath.ToLower();
            if (APP_PATH == "/")      //a site
                APP_PATH = "/";
            else if (!APP_PATH.EndsWith(@"/")) //a virtual
                APP_PATH += @"/";

            string it = System.Web.HttpContext.Current.Server.MapPath(APP_PATH);
            if (!it.EndsWith(@"\"))
                it += @"\";
            return it;
        }
    }
    
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
        haeAutotListaan();
    }
    private void haeAutotListaan()
    {
        //Tyhjentää listboxin
        //myListbox.Items.Clear();
        /*
        for (int i = 0; i < myListbox.Items.Count; i++)
        {
            lblTesti.Text += " " +myListbox.Items[i].Value;
            myListbox.Items.RemoveAt(i);
        }
        */

        string path = MappedApplicationPath + "App_Data/" + "WanhatAutot.xml";
        //haetaan autot listboxiin
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        XmlNodeList nodes = doc.DocumentElement.SelectNodes("Auto");
        foreach (XmlNode node in nodes)
        {
            ListItem li = new ListItem(node["merkki"].InnerText + " " +node["malli"].InnerText, node["aid"].InnerText);
            myListbox.Items.Add(li);
        }
    }
    protected void btnMuokkaa_Click(object sender, EventArgs e)
    {
        try
        {
            string toBeRedirected = "./H3100_muokkaaAutot.aspx?aid=" +myListbox.SelectedItem.Value;
            Response.Redirect(toBeRedirected);
        }
        catch (Exception)
        {
            // Pitäisi ilmoittaak äyttäjälle, että on syytä valita jokin vaihtoehto ennen klikkausta
            throw;
        }
        
    }
}