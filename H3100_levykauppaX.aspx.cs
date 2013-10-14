using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class H3100_levykauppaX : System.Web.UI.Page
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
        FillTableWithXmlDocument();
    }

    protected void FillTableWithXmlDocument()
    {
        string path = MappedApplicationPath + "App_Data/" + "LevykauppaX.xml";
        string imgPath = MappedApplicationPath + "images\\";
        //kesken
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        XmlNodeList nodes = doc.SelectNodes("/Records/genre/record");

        TableCell cell2 = new TableCell();
        TableCell cell3 = new TableCell();
        TableCell cell4 = new TableCell();
        TableCell cell5 = new TableCell();
        TableCell cell6 = new TableCell();

       // lblTesti.Text = nodes.Count.ToString();
        //lblTesti.Text = path;
        
        for (int i = 0; i < nodes.Count; i++)
        {
            if (nodes[i].InnerText.Length > 0 )
            {
                TableRow row = new TableRow();
                TableRow row2 = new TableRow();
                TableRow row3 = new TableRow();
                XmlNode node = nodes[i];

                //lblTesti.Text += " " + node["vm"].InnerText;
                //chldNode.Attributes["Name"].Value;
                Image img = new Image();
                img.ImageUrl = "./images/" + node.Attributes["ISBN"].Value +".jpg";

               
                cell2 = new TableCell();
                cell2.Controls.Add(img);
               // cell2.Text = node.Attributes["ISBN"].Value;
         
                
                cell3 = new TableCell();
                cell3.Text = "<h1>" +node.Attributes["Artist"].Value + " : " 
                    + node.Attributes["Title"].Value +"</h1>";



                HyperLink hl = new HyperLink();

                hl.Text = node.Attributes["ISBN"].Value;
                hl.NavigateUrl = "./H3100_Levyntiedot.aspx?ISBN=" + node.Attributes["ISBN"].Value;
              /*  Label txt = new Label();
                txt.Text = "<h1>ISBN: ";
                Label txt2 = new Label();
                txt2.Text = "</h1>";
                */
                cell5 = new TableCell();

                cell5.Controls.Add(new LiteralControl("<h1>ISBN: "));
                cell5.Controls.Add(hl);
                cell5.Controls.Add(new LiteralControl("</h1>"));

                cell4 = new TableCell();
                cell4.Text = "<h1>ISBN: </h1>";



                cell6 = new TableCell();
                cell6.Text = "<h1>Hinta: " + node.Attributes["Price"].Value + "</h1>";

                //cell2.Controls.Add();
                //lisätään solut riville ja rivi lisätään tauluun

                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                row.Cells[0].RowSpan = 3;

               // row2.Cells.Add(cell4);
                row2.Cells.Add(cell5);

                row3.Cells.Add(cell6);

                myTable.Rows.Add(row);
                myTable.Rows.Add(row2);
                myTable.Rows.Add(row3);

               // myTable.Rows[0].Cells[0].RowSpan = 3;
               /* myTable.Rows[1].Cells.RemoveAt(1);
                myTable.Rows[2].Cells.RemoveAt(1);
                * */
            }
        }
        //lblTesti.Text = string.Format("Haettu {0} autoa listattu 4", nodes.Count);
        /*
        lblTesti.Text += " " + numerot[0].ToString() + " " + numerot[1].ToString() 
                        + " " + numerot[2].ToString() + " " + numerot[3].ToString();
        */
    }
}