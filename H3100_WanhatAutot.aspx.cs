using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

public partial class H3100_WanhatAutot : System.Web.UI.Page
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

        //myListbox.Items.Clear();
        /*
        int[] numero = palautaNeljaRandomNumeroa();
        lblTesti.Text = "numerot: " + numero[0].ToString() +" " + numero[1].ToString()
                            + " " + numero[2].ToString() + " " + numero[3].ToString();
        */
        FillTableWithXmlDocument();
        if(!IsPostBack)
        haeAutotListaan();
       // muokkaaHinnanMukaanLaskeva();

    }

    protected void FillTableWithXmlDocument()
    {
        string path = MappedApplicationPath + "App_Data/" + "WanhatAutot.xml";
        //kesken
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        XmlNodeList nodes = doc.SelectNodes("/Wanhatautot/Auto");
        //XmlNodeList nodes = doc.SelectNodes("/WanhatAutot");
        TableRow row = new TableRow();


        TableCell cell2 = new TableCell();
        cell2.Text = "<b>Merkki</b>";
        TableCell cell3 = new TableCell();
        cell3.Text = "<b>Malli</b>";
        TableCell cell4 = new TableCell();
        cell4.Text = "<b>Vuosimalli</b>";
        TableCell cell5 = new TableCell();
        cell5.Text = "<b>Myyntihinta</b>";

        //cell2.Controls.Add();
        //lisätään solut riville ja rivi lisätään tauluun

        row.Cells.Add(cell2);
        row.Cells.Add(cell3);
        row.Cells.Add(cell4);
        row.Cells.Add(cell5);

        myTable.Rows.Add(row);

        int[] numerot = palautaNeljaRandomNumeroa();
        for (int i = 0; i < nodes.Count; i++)
        {
            if (nodes[i].InnerText.Length > 0 &&
                (numerot[0] == i || numerot[1] == i || numerot[2] == i || numerot[3] == i))
            {
                TableRow row2 = new TableRow();
                XmlNode node = nodes[i];

                //lblTesti.Text += " " + node["vm"].InnerText;

                cell2 = new TableCell();
                cell2.Text = node["merkki"].InnerText;
                cell3 = new TableCell();
                cell3.Text = node["malli"].InnerText;
                cell4 = new TableCell();
                cell4.Text = node["vm"].InnerText;
                cell5 = new TableCell();
                cell5.Text = node["myyntiHinta"].InnerText;

                //cell2.Controls.Add();
                //lisätään solut riville ja rivi lisätään tauluun

                row2.Cells.Add(cell2);
                row2.Cells.Add(cell3);
                row2.Cells.Add(cell4);
                row2.Cells.Add(cell5);

                myTable.Rows.Add(row2);
            }
        }
        //lblTesti.Text = string.Format("Haettu {0} autoa listattu 4", nodes.Count);
        /*
        lblTesti.Text += " " + numerot[0].ToString() + " " + numerot[1].ToString() 
                        + " " + numerot[2].ToString() + " " + numerot[3].ToString();
        */
    }
    private bool tarkista(int[] a) 
    {
        if(a[0] == a[1]) return false;
        if(a[0] == a[2]) return false;
        if(a[0] == a[3]) return false;

        if(a[1] == a[2]) return false;
        if(a[1] == a[3]) return false;

        if(a[2] == a[3]) return false;

        return true;

    }
    private int[] palautaNeljaRandomNumeroa()
    {
        int[] b = new int[4];
        var r = new Random(DateTime.Now.Millisecond);
        do
	    {
            b[0] = r.Next(0, 12);
            b[1] = r.Next(0, 12);
            b[2] = r.Next(0, 12);
            b[3] = r.Next(0, 12);
	    } while (!tarkista(b));        

        return b;
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
            ListItem li = new ListItem(node["merkki"].InnerText, node["aid"].InnerText);
            myListbox.Items.Add(li);
        }
    }
    private void muokkaaHinnanMukaanNouseva()
    {
        string path = MappedApplicationPath + "App_Data/" + "WanhatAutot.xml";
        //haetaan autot listboxiin
        XElement xDoc = XElement.Load(path);
        var xmlJarjestyksessa = xDoc.Elements("Auto").OrderBy(xtab => (int)xtab.Element("myyntiHinta")).ToArray();

        xDoc.RemoveAll();
        foreach (XElement item in xmlJarjestyksessa)
        {
            xDoc.Add(item);
        }
        xDoc.Save(path);
    }
    private void muokkaaHinnanMukaanLaskeva()
    {
        string path = MappedApplicationPath + "App_Data/" + "WanhatAutot.xml";
        //haetaan autot listboxiin
        XElement xDoc = XElement.Load(path);
        var xmlJarjestyksessa = xDoc.Elements("Auto").OrderByDescending(xtab => (int)xtab.Element("myyntiHinta")).ToArray();

        xDoc.RemoveAll();
        foreach (XElement item in xmlJarjestyksessa)
        {
            xDoc.Add(item);
        }
        xDoc.Save(path);
    }

    protected void Nousevako_CheckedChanged(object sender, EventArgs e)
    {
       // muokkaaHinnanMukaanNouseva();
    }
    protected void btnListaaAutot_Click(object sender, EventArgs e)
    {
        if (Nousevako.Checked)
        {
            muokkaaHinnanMukaanNouseva();
        }
        else
        {
            muokkaaHinnanMukaanLaskeva();
        }
        myListbox.Items.Clear();
        haeAutotListaan();
    }
    protected void myListbox_SelectedIndexChanged(object sender, EventArgs e)
    {
        //lblTesti.Text = "Teksti";
       // lblTesti.Text = myListbox.Items.Count.ToString();
        //if (myListbox.SelectedItem == null) return;

        //lblTesti.Text = myListbox.SelectedItem.Text;
        string path = MappedApplicationPath + "App_Data/" + "WanhatAutot.xml";

        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        XmlNodeList nodes = doc.SelectNodes("/Wanhatautot/Auto");

        myListbox2.Items.Clear();
        for (int i = 0; i < nodes.Count; i++)
        {
            if (nodes[i].InnerText.Length > 0)
            {
                XmlNode node = nodes[i];
                if (node["merkki"].InnerText.Equals(myListbox.SelectedItem.Text))
                {
                    //
                    ListItem li = new ListItem(node["malli"].InnerText, node["aid"].InnerText);
                    myListbox2.Items.Add(li);
                }
            }
        }
        
    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void btnTesti_Click(object sender, EventArgs e)
    {
        myListbox.Items.Clear();
    }
    protected void btnEtsi_Click(object sender, EventArgs e)
    {
        string path = MappedApplicationPath + "App_Data/" + "WanhatAutot.xml";

        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        XmlNodeList nodes = doc.SelectNodes("/Wanhatautot/Auto");

        myListbox2.Items.Clear();
        myListbox3.Items.Clear();
        for (int i = 0; i < nodes.Count; i++)
        {
            if (nodes[i].InnerText.Length > 0)
            {
                XmlNode node = nodes[i];

                string merkki = node["merkki"].InnerText;
                string malli = node["malli"].InnerText;

                // B.
                // Test with IndexOf.
                if ((merkki.IndexOf(txtRegexp.Text) != -1) || (malli.IndexOf(txtRegexp.Text) != -1))
                {
                    //lblTesti.Text += " " +node["merkki"].InnerText + " " + node["malli"].InnerText;
                    ListItem li = new ListItem(node["merkki"].InnerText + " " 
                                    + node["malli"].InnerText, node["aid"].InnerText);
                    myListbox3.Items.Add(li);
                }
            }
        }
    }
}