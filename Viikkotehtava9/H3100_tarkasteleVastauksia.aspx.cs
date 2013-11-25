using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class H3100_tarkasteleVastauksia : System.Web.UI.Page
{
    private string url;
    protected void Page_Load(object sender, EventArgs e)
    {
        url = Request.QueryString["URL"];
        url = HttpUtility.UrlDecode(url);

        //lblDebug.Text = url;

        lblVastaustenLkm.Text = "Vastauksia yhteensä: " +laskeVastanneet().ToString();
        laskeProsentit();
    }

    private int laskeVastanneet()
    {
        List<int> vastaukset = (List<int>)Session[this.url.Trim()];
        int yhteensa = 0;
        yhteensa = (vastaukset[0] + vastaukset[1] + vastaukset[2] + vastaukset[3] 
                    + vastaukset[4] +vastaukset[5]);
        return yhteensa;
    }

    private void laskeProsentit()
    {
        List<int> vastaukset = (List<int>)Session[this.url.Trim()];
        int switchOn = vastaukset[6];
        switch (switchOn)
        {
            case 2: // lasketaan prosentit kahdelle vastaukselle
                int vastanneet = laskeVastanneet();
                double eka = vastaukset[0];
                double toka = vastaukset[1];

                double eka1 = vastaukset[0];
                double toka1 = vastaukset[1];

                eka = (eka / vastanneet)*100;
                toka = (toka / vastanneet)*100;
                lblProsenttiOsuudet1.Text = "Vaihtoehto 1: "+eka1.ToString()+" vastausta, joka on " + eka.ToString() +"%.";
                lblProsenttiOsuudet2.Text = "Vaihtoehto 2: " +toka1.ToString()+" vastausta, joka on "+ toka.ToString() + "%.";
                break;
            case 3: // lasketaan prosentit kolmelle vastaukselle
                vastanneet = laskeVastanneet();
                eka = vastaukset[0];
                toka = vastaukset[1];
                double kolmas = vastaukset[2];

                eka1 = vastaukset[0];
                toka1 = vastaukset[1];
                double kolmas1 = vastaukset[2];

                eka = (eka / vastanneet) * 100;
                toka = (toka / vastanneet) * 100;
                kolmas = (kolmas / vastanneet) * 100;
                lblProsenttiOsuudet1.Text = "Vaihtoehto 1: "+eka1.ToString()+" vastausta, joka on " + eka.ToString() +"%.";
                lblProsenttiOsuudet2.Text = "Vaihtoehto 2: " +toka1.ToString()+" vastausta, joka on "+ toka.ToString() + "%.";
                lblProsenttiOsuudet3.Text = "Vaihtoehto 3: " +kolmas1.ToString()+" vastausta, joka on "+ kolmas.ToString() + "%.";
                break;
            case 4: // lasketaan prosentit neljälle vastaukselle
                vastanneet = laskeVastanneet();
                eka = vastaukset[0];
                toka = vastaukset[1];
                kolmas = vastaukset[2];
                double neljas = vastaukset[3];

                eka1 = vastaukset[0];
                toka1 = vastaukset[1];
                kolmas1 = vastaukset[2];
                double neljas1 = vastaukset[3];

                eka = (eka / vastanneet) * 100;
                toka = (toka / vastanneet) * 100;
                kolmas = (kolmas / vastanneet) * 100;
                neljas = (neljas / vastanneet) * 100;
                lblProsenttiOsuudet1.Text = "Vaihtoehto 1: "+eka1.ToString()+" vastausta, joka on " + eka.ToString() +"%.";
                lblProsenttiOsuudet2.Text = "Vaihtoehto 2: " +toka1.ToString()+" vastausta, joka on "+ toka.ToString() + "%.";
                lblProsenttiOsuudet3.Text = "Vaihtoehto 3: " +kolmas1.ToString()+" vastausta, joka on "+ kolmas.ToString() + "%.";
                lblProsenttiOsuudet4.Text = "Vaihtoehto 4: "+neljas1.ToString()+" vastausta, joka on " + neljas.ToString() + "%.";
                break;
            case 5: // lasketaan prosentit viidelle vastaukselle
                vastanneet = laskeVastanneet();
                eka = vastaukset[0];
                toka = vastaukset[1];
                kolmas = vastaukset[2];
                neljas = vastaukset[3];
                double viides = vastaukset[4];

                eka1 = vastaukset[0];
                toka1 = vastaukset[1];
                kolmas1 = vastaukset[2];
                neljas1 = vastaukset[3];
                double viides1 = vastaukset[4];

                eka = (eka / vastanneet) * 100;
                toka = (toka / vastanneet) * 100;
                kolmas = (kolmas / vastanneet) * 100;
                neljas = (neljas / vastanneet) * 100;
                viides = (viides / vastanneet) * 100;

                lblProsenttiOsuudet1.Text = "Vaihtoehto 1: "+eka1.ToString()+" vastausta, joka on " + eka.ToString() +"%.";
                lblProsenttiOsuudet2.Text = "Vaihtoehto 2: " +toka1.ToString()+" vastausta, joka on "+ toka.ToString() + "%.";
                lblProsenttiOsuudet3.Text = "Vaihtoehto 3: " +kolmas1.ToString()+" vastausta, joka on "+ kolmas.ToString() + "%.";
                lblProsenttiOsuudet4.Text = "Vaihtoehto 4: "+neljas1.ToString()+" vastausta, joka on " + neljas.ToString() + "%.";
                lblProsenttiOsuudet5.Text = "Vaihtoehto 5: " +viides1.ToString()+" vastausta, joka on "+ viides.ToString() + "%.";
                break;
            case 6: // lasketaan prosentit kuudelle vastaukselle
                vastanneet = laskeVastanneet();
                eka = vastaukset[0];
                toka = vastaukset[1];
                kolmas = vastaukset[2];
                neljas = vastaukset[3];
                viides = vastaukset[4];
                double kuudes = vastaukset[5];

                eka1 = vastaukset[0];
                toka1 = vastaukset[1];
                kolmas1 = vastaukset[2];
                neljas1 = vastaukset[3];
                viides1 = vastaukset[4];
                double kuudes1 = vastaukset[5];

                eka = (eka / vastanneet) * 100;
                toka = (toka / vastanneet) * 100;
                kolmas = (kolmas / vastanneet) * 100;
                neljas = (neljas / vastanneet) * 100;
                viides = (viides / vastanneet) * 100;
                kuudes = (kuudes / vastanneet) * 100;

                lblProsenttiOsuudet1.Text = "Vaihtoehto 1: "+eka1.ToString()+" vastausta, joka on " + eka.ToString() +"%.";
                lblProsenttiOsuudet2.Text = "Vaihtoehto 2: " +toka1.ToString()+" vastausta, joka on "+ toka.ToString() + "%.";
                lblProsenttiOsuudet3.Text = "Vaihtoehto 3: " +kolmas1.ToString()+" vastausta, joka on "+ kolmas.ToString() + "%.";
                lblProsenttiOsuudet4.Text = "Vaihtoehto 4: "+neljas1.ToString()+" vastausta, joka on " + neljas.ToString() + "%.";
                lblProsenttiOsuudet5.Text = "Vaihtoehto 5: " +viides1.ToString()+" vastausta, joka on "+ viides.ToString() + "%.";
                lblProsenttiOsuudet6.Text = "Vaihtoehto 6: " +kuudes1.ToString() +" vastausta, joka on " + kuudes.ToString() + "%.";
                break;

            default:
                break;
        }
    }
}