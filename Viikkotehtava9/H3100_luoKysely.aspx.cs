using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class H3100_luoKysely : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtEka.Text = "Kyllä";
        txtToka.Text = "Ei";
    }
    protected void btnKaynnista_Click(object sender, EventArgs e)
    {
        String strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
        String strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/");
        

        string toBeRedirected = "H3100_vastaaKyselyyn.aspx?eka=" + txtEka.Text
                                    + "&toka=" + txtToka.Text + "&kolmas=" + txtKolmas.Text
                                    + "&neljas=" + txtNeljas.Text + "&viides=" + txtViides.Text
                                    + "&kuudes=" + txtKuudes.Text + "&kysymys=" + txtKysymys.Text;
        lblUrl.Text = strUrl+toBeRedirected;

        List<int> vastaukset = new List<int>(); // { 0, 0, 0, 0, 0, 0 };
        vastaukset.Add(0);
        vastaukset.Add(0);
        vastaukset.Add(0);
        vastaukset.Add(0);
        vastaukset.Add(0);
        vastaukset.Add(0);
        //URL:ää käytetään session tunnisteena, jotta siitä tulee aina yksilöllinen jokaiselle 
        // kyselylle.
        Session[lblUrl.Text] = vastaukset;

        double vastausaika = 60;
        if (!txtVastausaika.Text.Equals(""))
        {
            try
            {
                vastausaika = Convert.ToDouble(txtVastausaika.Text);
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
        // Tällä toteutetaan timeout
        Cache.Insert("vastaus", "testi",
        null, DateTime.Now.AddSeconds(vastausaika),       //AddMinutes(1d),
        System.Web.Caching.Cache.NoSlidingExpiration);


        //Session.Timeout = 20;
        
        //Console.WriteLine(response.ResponseUri);
        //Response.Redirect(toBeRedirected); //?param1=data1&param2=data2
    }
    protected void btnKatsoVastauksia_Click(object sender, EventArgs e)
    {
        string urlToRedirect = HttpUtility.UrlEncode(txtTarkasteltavanURL.Text);
        string toBeRedirected = "~/H3100_tarkasteleVastauksia.aspx?URL="+urlToRedirect;
        
        //lblUrl.Text = testi;
        Response.Redirect(toBeRedirected);
    }
}