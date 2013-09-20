using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class H3100_vk2_elakelaskuri : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String bg = ConfigurationManager.AppSettings["background"];
        form1.Style.Add("background-color", bg);

        if(TxtIka.Text.Equals(""))
        TxtIka.Text = ConfigurationManager.AppSettings["ika"];
        if(TxtPalkka.Text.Equals(""))
        TxtPalkka.Text = ConfigurationManager.AppSettings["palkka"];

        // ei voi olla, kuin lukuarvoja, kun ladataan sivu default arvoilla

        this.teeLaskelmat();

        
        //lblVirheet.Text = laskeElake(35, 3000).ToString();
    }

    private float laskeElake(int ika, int palkka)
    {
        float elake = (float)((0.5 * palkka) - ((63 - ika) * 5.5));
        return elake;
    }

    private float laskeLakisaateinenElake(int palkka)
    {
        return (float)(0.5 * palkka);
    }

    private float laskeIkakerroin(int ika)
    {
        return -(float)((63 - ika) * 5.5);
    }
    private void teeLaskelmat()
    {
        try
        {
            int lakisaa = Convert.ToInt32(TxtPalkka.Text);
            lblLakisaaNbr.Text = laskeLakisaateinenElake(lakisaa).ToString();
        }
        catch (Exception ex)
        {
            lblVirheet.Text += ex.Message;
        }

        try
        {
            int ika = Convert.ToInt32(TxtIka.Text);
            lblElinaikakNbr.Text = laskeIkakerroin(ika).ToString();
        }
        catch (Exception ex)
        {
            lblVirheet.Text += ex.Message;
        }

        try
        {
            int ika = Convert.ToInt32(TxtIka.Text);
            int lakisaa = Convert.ToInt32(TxtPalkka.Text);
            txtArvio.Text = laskeElake(ika, lakisaa).ToString();
        }
        catch (Exception ex)
        {
            lblVirheet.Text += ex.Message;
        }
    }
    protected void btnIka2_Click(object sender, EventArgs e)
    {
        int arvo;
        try
        {
            arvo = Convert.ToInt32(TxtIka.Text);
            arvo++;
            TxtIka.Text = arvo.ToString();
            this.teeLaskelmat();
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void btnIka1_Click(object sender, EventArgs e)
    {
        int arvo;
        try
        {
            arvo = Convert.ToInt32(TxtIka.Text);
            arvo--;
            TxtIka.Text = arvo.ToString();
            this.teeLaskelmat();
        }
        catch (Exception)
        {

            throw;
        }

    }
    protected void btnPalkka1_Click(object sender, EventArgs e)
    {
        int arvo;
        try
        {
            arvo = Convert.ToInt32(TxtPalkka.Text);
            arvo = arvo - 50;
            TxtPalkka.Text = arvo.ToString();
            this.teeLaskelmat();
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void btnPalkka2_Click(object sender, EventArgs e)
    {
        int arvo;
        try
        {
            arvo = Convert.ToInt32(TxtPalkka.Text);
            arvo = arvo + 50;
            TxtPalkka.Text = arvo.ToString();
            this.teeLaskelmat();
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void txtIkaChanged(object sender, EventArgs e)
    {
       //lblVirheet.Text = TxtIka.Text;
    }
    protected void txtIkaDisposed(object sender, EventArgs e)
    {
        //lblVirheet.Text = TxtIka.Text;
    }



}