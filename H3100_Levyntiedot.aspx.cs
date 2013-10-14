using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class H3100_Levyntiedot : System.Web.UI.Page
{
    public string MappedApplicationPath
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

    private string ISBN;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["ISBN"] != null)
            this.ISBN = Request["ISBN"];

        FillTableWithXmlDocument();
    }

    protected void FillTableWithXmlDocument()
    {
        string path = MappedApplicationPath + "App_Data/" + "LevykauppaX.xml";
        myImage.ImageUrl = "./images/" + this.ISBN +".jpg";

        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        string xPath = "/Records/genre/record[@ISBN='" + this.ISBN + "']";
        //lblTesti.Text = xPath;
        XmlNodeList nodes = doc.SelectNodes(xPath);
        if (nodes[0].InnerText.Length > 0)
        {
            lblArtistiAlbumi.Text = "<h1>" +nodes[0].Attributes["Artist"].Value + " "
                                + nodes[0].Attributes["Title"].Value +"</h1>";

            lblISBN.Text = "<b>ISBN:</b> " +this.ISBN +"";

            lblHinta.Text = "<b>Hinta:</b> " + nodes[0].Attributes["Price"].Value;
           // lblBiisit.Text = "<b>Levyn biisit</b>";
        }


        string xPathBiisit = "/Records/genre/record[@ISBN='" + this.ISBN + "']/song";
        //lblTesti.Text = xPathBiisit;
        XmlNodeList nodesBiisit = doc.SelectNodes(xPathBiisit);
        //lblTesti.Text += " " +nodesBiisit.Count.ToString();
        myParagraph.Controls.Add(new LiteralControl("<b>Levyn biisit:</b><br />"));
        for (int i = 0; i < nodesBiisit.Count; i++)
        {
            if (nodesBiisit[i].InnerText.Length > 0)
            {
   
                XmlNode node = nodesBiisit[i];
               // myParagraph.InnerText = "testi <br /> testi <br /> testi <br />";
            
                Label label = new Label();
                label.Text = nodesBiisit[i].Attributes["name"].Value;
                myParagraph.Controls.Add(label);
                myParagraph.Controls.Add(new LiteralControl("<br />"));

                //lblTesti.Text += " " + node["vm"].InnerText;
                //chldNode.Attributes["Name"].Value;
                
                

                // cell2.Text = node.Attributes["ISBN"].Value;

            }
        }


    }
}