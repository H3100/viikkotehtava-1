using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class H3100_rssfeedsTuntiEsim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGetLiiga_Click(object sender, EventArgs e)
    {
        GetFeedsFrom("Liiga");
    }
    protected void GetFeedsFrom(string FeedSource)
    {
        string url = "";
        switch (FeedSource)
        {
            case "Liiga":
                url = ConfigurationManager.AppSettings["rssfeeditSF"];
                break;
            case "Microsoft":
                url = ConfigurationManager.AppSettings["rssfeeditMS"];
                break;
            case "Iltasanomat":
                url = ConfigurationManager.AppSettings["rssfeeditIS"];
                break;
            default:
                break;
        }
        //Kokeillaan, tuleeko oikeasta osoitteesta
        lblBody.Text = url;
        XmlDocument doc = new XmlDocument();
        myDataSource.DataFile = url;
        doc = myDataSource.GetXmlDocument();
        //1. vaihe: luetaan channel-elementin title-elementti
        XmlNode node = doc.SelectSingleNode("/rss/channel");
        string otsikko = node["title"].InnerText;
        lblHeader.Text = otsikko;
        
        //2. vaihe looptietaan item-noodit läpi
        XmlNodeList nodes = doc.SelectNodes("/rss/channel/item");
        int i = 0;
        string rsstitle;
        string rsslink;

        foreach (XmlNode item in nodes)
        {
            i++;
            //uusi rivi Tableen
            TableRow row = new TableRow();
            //rivillä kaksi solua, ensimmäiseen numero ja toiseen hyperlinkki
            TableCell cell = new TableCell();
            cell.Text = i.ToString();
            //toinen solu
            TableCell cell2 = new TableCell();
            rsstitle = item["title"].InnerText;
            rsslink = item["link"].InnerText;
            HyperLink hl = new HyperLink();
            
            hl.Text = rsstitle;
            hl.NavigateUrl = rsslink;
            cell2.Controls.Add(hl);

            //lisätään solut riville ja rivi lisätään tauluun
            row.Cells.Add(cell);
            row.Cells.Add(cell2);
            myDataTable.Rows.Add(row);
        }
    }
    protected void btngetMicrosoft_Click(object sender, EventArgs e)
    {
        GetFeedsFrom("Microsoft");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GetFeedsFrom("Iltasanomat");
    }
}