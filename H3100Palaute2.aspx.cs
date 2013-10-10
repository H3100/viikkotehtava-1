using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

public partial class H3100Palaute2 : System.Web.UI.Page
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

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string path = MappedApplicationPath + "App_Data/" + "Palautteet.xml";
        XDocument doc = XDocument.Load(path);


                    XElement srcTree = new XElement("palaute",
                    new XElement("pvm", txtPvm.Text),
                    new XElement("tekija", txtNimi.Text),
                    new XElement("opittu", txtOlenoppinut.Text),
                    new XElement("haluanoppia", txtHaluanOppia.Text),
                    new XElement("hyvaa", txtHyvaa.Text),
                    new XElement("parannettavaa", txtParannettavaa.Text),
                    new XElement("muuta", txtMuuta.Text)
                );
                        doc.Element("palautteet").Add(srcTree);
                        doc.Save(path);
        /*
                        xmlDoc.Element("Microsoft").Add(new XElement("DOTNet", new XElement("Name", "Nisar"),
                      new XElement("Forum", "dotnetobject"), new XElement("Position", "Member")));
                        xmlDoc.Save("yourfile.xml");
                        readXml();
                     //   doc.Element("palaute").Add(srcTree);
        */
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string path = MappedApplicationPath + "App_Data/" + "Palautteet.xml";
        //XDocument doc = XDocument.Load(path);

        
        TableRow row = new TableRow();

        TableCell cell22 = new TableCell();
        cell22.Text = "<b>Pvm</b>";
        TableCell cell33 = new TableCell();
        cell33.Text = "<b>Tekijä</b>";
        TableCell cell44 = new TableCell();
        cell44.Text = "<b>Opittu</b>";
        TableCell cell55 = new TableCell();
        cell55.Text = "<b>Haluan_oppia</b>";
        TableCell cell66 = new TableCell();
        cell66.Text = "<b>Hyvää</b>";
        TableCell cell77 = new TableCell();
        cell77.Text = "<b>Parannettavaa</b>";
        TableCell cell88 = new TableCell();
        cell88.Text = "<b>Muuta</b>";
        //cell2.Controls.Add();
        //lisätään solut riville ja rivi lisätään tauluun
        row.Cells.Add(cell22);
        row.Cells.Add(cell33);
        row.Cells.Add(cell44);
        row.Cells.Add(cell55);
        row.Cells.Add(cell66);
        row.Cells.Add(cell77);
        row.Cells.Add(cell88);
        myTable.Rows.Add(row);        
        
        

        foreach (XElement level1Element in XElement.Load(path).Elements("palaute"))
        {
            /*
                <tekija>Juice Läskinen</tekija>
    <opittu>paljon hyvää ja törkeän tärkeää</opittu>
    <haluanoppia>tietoturvasta tsäbää</haluanoppia>
    <hyvaa>demot</hyvaa>
    <parannettavaa>enemmän omaa tekemistä</parannettavaa>
    <muuta>GitHub ok </muuta>
            */

            //uusi rivi Tableen
            TableRow row2 = new TableRow();
 

            TableCell cell2 = new TableCell();  
            cell2.Text = level1Element.Element("pvm").Value.ToString();
                        TableCell cell3 = new TableCell();  
            cell3.Text = level1Element.Element("tekija").Value.ToString();
                        TableCell cell4 = new TableCell();  
            cell4.Text = level1Element.Element("opittu").Value.ToString();
                        TableCell cell5 = new TableCell();  
            cell5.Text = level1Element.Element("haluanoppia").Value.ToString();
                        TableCell cell6 = new TableCell();  
            cell6.Text = level1Element.Element("hyvaa").Value.ToString();
                        TableCell cell7 = new TableCell();  
            cell7.Text = level1Element.Element("parannettavaa").Value.ToString();
                        TableCell cell8 = new TableCell();  
            cell8.Text = level1Element.Element("muuta").Value.ToString();
            //cell2.Controls.Add();
            //lisätään solut riville ja rivi lisätään tauluun
            row2.Cells.Add(cell2);
            row2.Cells.Add(cell3);
            row2.Cells.Add(cell4);
            row2.Cells.Add(cell5);
            row2.Cells.Add(cell6);
            row2.Cells.Add(cell7);
            row2.Cells.Add(cell8);
            myTable.Rows.Add(row2);
        }
    


    }
}