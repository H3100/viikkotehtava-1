using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
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
    private string GetMD5Hash(string input)
    {
        System.Security.Cryptography.MD5CryptoServiceProvider x =
            new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
        bs = x.ComputeHash(bs);
        System.Text.StringBuilder s = new System.Text.StringBuilder();
        foreach (byte b in bs)
        {
            s.Append(b.ToString("x2").ToLower());
        }
        string password = s.ToString();
        return password;
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
        /* // Ensimmäinen versio!
        string user = WebConfigurationManager.AppSettings["username"].ToString();
        string passwd = WebConfigurationManager.AppSettings["passwd"].ToString();
        string user2 = Request["user"];
        string passwd2 = Request["passwd"];
        //lblIlmoitus.Text = Request["user"] + " " + Request["passwd"];
        if (user2.Equals(user) && passwd2.Equals(passwd))
        {
            try
            {
                string toBeRedirected = "~/H3100_muokkaaAutot.aspx?aid=" + myListbox.SelectedItem.Value;
                Response.Redirect(toBeRedirected);
            }
            catch (Exception)
            {
                // Pitäisi ilmoittaak äyttäjälle, että on syytä valita jokin vaihtoehto ennen klikkausta
                lblIlmoitus.Text = "Valitse jokin auto!";
                throw;
            }
        }
        else
            lblIlmoitus.Text = "Ei käyttäjäoikeuksia muokkaukseen!"; 
         */
        string user2 = Request["user"];
        string passwd2 = Request["passwd"];

        string path = MappedApplicationPath + "App_Data/" + "kayttajaJaSalasana.xml";
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        XmlNodeList nodes = doc.SelectNodes("kayttajat/kayttaja");
        //lblIlmoitus.Text = nodes.Item(0).SelectNodes("/kayttaja").Count.ToString();
        for (int i = 0; i < nodes.Count; i++)
        {
            //lblIlmoitus.Text += " " + i.ToString();
            if (nodes[i].InnerText.Length > 0)
            {
                XmlNode node = nodes[i];
                if (node["kayttajatunnus"].InnerText.Equals(user2) 
                    && node["salasana"].InnerText.Equals(GetMD5Hash(passwd2+user2)))
                {
                    string toBeRedirected = "~/H3100_muokkaaAutot.aspx?aid=" 
                                                + myListbox.SelectedItem.Value;
                    Response.Redirect(toBeRedirected);
                }
            }
        }
        lblIlmoitus.Text += "Ei muokkausoikeuksia.";
      }
         
        
}