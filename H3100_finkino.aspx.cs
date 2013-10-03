using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class H3100_finkino : System.Web.UI.Page
{
    string urlToTheatres;
    string urlToMovies;
    protected void Page_Load(object sender, EventArgs e)
    {
        urlToTheatres = ConfigurationManager.AppSettings["finnkinoteatterit"];
        urlToMovies = ConfigurationManager.AppSettings["finnkinoelokuvat"];
    }
    protected void myListbox_SelectedIndexChanged(object sender, EventArgs e)
    {
        string theatreShows = urlToMovies + myListbox.SelectedItem.Value;
        myDataSource.DataFile = theatreShows;
        myRepeater.DataBind();
    }
    protected void btnGetTheatres_Click(object sender, EventArgs e)
    {
        //haetaan FinnKinon teatterit listboxiin
        XmlDocument doc = new XmlDocument();
        doc.Load(urlToTheatres);
        XmlNodeList nodes = doc.DocumentElement.SelectNodes("TheatreArea");
        foreach (XmlNode node in nodes)
        {
            ListItem li = new ListItem(node["Name"].InnerText, node["ID"].InnerText);
            myListbox.Items.Add(li);
        }
    }
}