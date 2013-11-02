using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

/// <summary>
/// Summary description for BLAutot
/// </summary>
public class BLAutot
{

    private string aid;
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

    public BLAutot(string aid)
    {
        this.aid = aid;
    }


    public void muokkaaAuto()
    {

    }

    public void poistaAuto()
    {

    }
    public void lisaaAuto(string rekkari, string merkki, string malli, int vm,
                        int myyntihinta, int sisaanOstohinta)
    {

    }

    public void paivita(string txtMalli, string txtMerkki, string txtMyyntihinta, string txtRekkari,
        string txtSisaanostohinta, string txtVm)
    {
        // Validoidaan syötettä
        if (Convert.ToInt32(txtMyyntihinta) < 0) return;
        if (Convert.ToInt32(txtSisaanostohinta) < 0) return;

        string path = MappedApplicationPath + "App_Data/" + "WanhatAutot.xml";

        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        XmlNodeList nodes = doc.SelectNodes("/Wanhatautot/Auto");

        for (int i = 0; i < nodes.Count; i++)
        {
            if (nodes[i].InnerText.Length > 0)
            {
                XmlNode node = nodes[i];
                if (node["aid"].InnerText.Equals(this.aid))
                {

                    node["malli"].InnerText = txtMalli;
                    node["merkki"].InnerText = txtMerkki;
                    node["myyntiHinta"].InnerText = txtMyyntihinta;
                    node["rekkari"].InnerText = txtRekkari;
                    node["sisaanOstoHinta"].InnerText = txtSisaanostohinta;
                    node["vm"].InnerText = txtVm;
                    break;
                }
            }
        }
        doc.Save(path);
    }

    public void populateTxtBoxes(System.Web.UI.WebControls.TextBox txtMalli,
        System.Web.UI.WebControls.TextBox txtMerkki,
        System.Web.UI.WebControls.TextBox txtMyyntihinta, System.Web.UI.WebControls.TextBox txtRekkari,
        System.Web.UI.WebControls.TextBox txtSisaanostohinta, System.Web.UI.WebControls.TextBox txtVm)
    {
        string path = MappedApplicationPath + "App_Data/" + "WanhatAutot.xml";

        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        XmlNodeList nodes = doc.SelectNodes("/Wanhatautot/Auto");

        for (int i = 0; i < nodes.Count; i++)
        {
            if (nodes[i].InnerText.Length > 0)
            {
                XmlNode node = nodes[i];
                if (node["aid"].InnerText.Equals(this.aid))
                {
                    //
                    txtMalli.Text = node["malli"].InnerText;
                    txtMerkki.Text = node["merkki"].InnerText;
                    txtMyyntihinta.Text = node["myyntiHinta"].InnerText;
                    txtRekkari.Text = node["rekkari"].InnerText;
                    txtSisaanostohinta.Text = node["sisaanOstoHinta"].InnerText;
                    txtVm.Text = node["vm"].InnerText;
                    break;
                }
            }
        }
    }
}