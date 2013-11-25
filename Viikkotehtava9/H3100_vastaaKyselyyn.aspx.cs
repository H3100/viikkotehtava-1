using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class H3100_vastaaKyselyyn : System.Web.UI.Page
{
    private bool voimassako = true;
    protected void Page_Load(object sender, EventArgs e)
    {
        string cachedString;
        cachedString = (string)Cache["vastaus"];
        if (cachedString == null)
        {
            voimassako = false;
            lblKysymys.Text = "Kysely ei ole enää voimassa!";            
        }
        else
        {
          //  lblDebug.Text = Request.Url.ToString();
            lblKysymys.Text = Request.QueryString["kysymys"]; 
            string eka = Request.QueryString["eka"];
            string toka = Request.QueryString["toka"];
            string kolmas = Request.QueryString["kolmas"];
            string neljas = Request.QueryString["neljas"];
            string viides = Request.QueryString["viides"];
            string kuudes = Request.QueryString["kuudes"];

            RadioButtonList rbl = new RadioButtonList();
            rbl.ID = "rblID";
            rbl.AutoPostBack = true;

            
            // vain kaksi ensimmäistä kysymystä on määritelty
            if (kuudes.Equals("") && viides.Equals("") && neljas.Equals("") && kolmas.Equals("") &&
                !toka.Equals("") && !eka.Equals(""))
            {
                rbl.Items.Add(new ListItem(eka, "1"));
                rbl.Items.Add(new ListItem(toka, "2"));
                string url = Request.Url.ToString();
                List<int> vastaukset = (List<int>)Session[HttpUtility.UrlDecode(Request.Url.ToString())];
                // Merkitään, että kysymyksiä oli kaksi.
                vastaukset.Add(2);
                Session[Request.Url.ToString()] = vastaukset;
                /*
                RadioButton radio = new RadioButton();
                radio.Text = eka;
                radio.ID = "eka";
                radio.GroupName = "answers";
                this.kysymykset.Controls.Add(radio);

                kysymykset.Controls.Add(new LiteralControl("<br />"));

                radio = new RadioButton();
                radio.Text = toka;
                radio.ID = "toka";
                radio.GroupName = "answers";
                this.kysymykset.Controls.Add(radio);
                 * */
            }
            else if (kuudes.Equals("") && viides.Equals("") && neljas.Equals("") && !kolmas.Equals("") &&
              !toka.Equals("") && !eka.Equals(""))
            {
                rbl.Items.Add(new ListItem(eka, "1"));
                rbl.Items.Add(new ListItem(toka, "2"));
                rbl.Items.Add(new ListItem(kolmas, "3"));

                List<int> vastaukset = (List<int>)Session[HttpUtility.UrlDecode(Request.Url.ToString())];
                vastaukset.Add(3);
                Session[Request.Url.ToString()] = vastaukset;

            }
            else if (kuudes.Equals("") && viides.Equals("") && !neljas.Equals("") && !kolmas.Equals("") &&
            !toka.Equals("") && !eka.Equals(""))
            {
                rbl.Items.Add(new ListItem(eka, "1"));
                rbl.Items.Add(new ListItem(toka, "2"));
                rbl.Items.Add(new ListItem(kolmas, "3"));
                rbl.Items.Add(new ListItem(neljas, "4"));

                List<int> vastaukset = (List<int>)Session[HttpUtility.UrlDecode(Request.Url.ToString())];
                vastaukset.Add(4);
                Session[Request.Url.ToString()] = vastaukset;
                
            }
            else if (kuudes.Equals("") && !viides.Equals("") && !neljas.Equals("") && !kolmas.Equals("") &&
          !toka.Equals("") && !eka.Equals(""))
            {
                rbl.Items.Add(new ListItem(eka, "1"));
                rbl.Items.Add(new ListItem(toka, "2"));
                rbl.Items.Add(new ListItem(kolmas, "3"));
                rbl.Items.Add(new ListItem(neljas, "4"));
                rbl.Items.Add(new ListItem(viides, "5"));

                List<int> vastaukset = (List<int>)Session[HttpUtility.UrlDecode(Request.Url.ToString())];
                vastaukset.Add(5);
                Session[Request.Url.ToString()] = vastaukset;
                
            }
            else if (!kuudes.Equals("") && !viides.Equals("") && !neljas.Equals("") && !kolmas.Equals("") &&
        !toka.Equals("") && !eka.Equals(""))
            {
                rbl.Items.Add(new ListItem(eka, "1"));
                rbl.Items.Add(new ListItem(toka, "2"));
                rbl.Items.Add(new ListItem(kolmas, "3"));
                rbl.Items.Add(new ListItem(neljas, "4"));
                rbl.Items.Add(new ListItem(viides, "5"));
                rbl.Items.Add(new ListItem(kuudes, "6"));

                List<int> vastaukset = (List<int>)Session[HttpUtility.UrlDecode(Request.Url.ToString())];
                vastaukset.Add(6);
                Session[Request.Url.ToString()] = vastaukset;
              
            }

            rbl.DataBind();
            kysymykset.Controls.Add(rbl);
            /*
            RadioButton radio = new RadioButton();
            radio.Text = "testi";
            this.kysymykset.Controls.Add(radio);
             * */
        }

    }
    protected void btnVastaa_Click(object sender, EventArgs e)
    {
        if (voimassako)
        {
            RadioButtonList rb = (RadioButtonList)FindControl("rblID");
            lblDebug.Text = rb.SelectedValue;
            int caseValue = Int32.Parse(rb.SelectedValue);
            switch (caseValue)
            {
                case 1:
                    List<int> vastaukset = (List<int>)Session[HttpUtility.UrlDecode(Request.Url.ToString())];
                    vastaukset[0]++;
                    Session[Request.Url.ToString()] = vastaukset;
                    break;
                case 2:
                    vastaukset = (List<int>)Session[Request.Url.ToString()];
                    vastaukset[1]++;
                    Session[Request.Url.ToString()] = vastaukset;
                    break;
                case 3:
                    vastaukset = (List<int>)Session[Request.Url.ToString()];
                    vastaukset[2]++;
                    Session[Request.Url.ToString()] = vastaukset;
                    break;
                case 4:
                    vastaukset = (List<int>)Session[Request.Url.ToString()];
                    vastaukset[3]++;
                    Session[Request.Url.ToString()] = vastaukset;
                    break;
                case 5:
                    vastaukset = (List<int>)Session[Request.Url.ToString()];
                    vastaukset[4]++;
                    Session[Request.Url.ToString()] = vastaukset;
                    break;
                case 6:
                    vastaukset = (List<int>)Session[Request.Url.ToString()];
                    vastaukset[5]++;
                    Session[Request.Url.ToString()] = vastaukset;
                    break;
                default:
                    break;
            }
        }
        /*
       List<int> vastaukset2 = (List<int>)Session[Request.Url.ToString()];
       lblDebug.Text = vastaukset2[0].ToString();
          */   
       
    }
}