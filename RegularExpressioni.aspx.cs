using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegularExpressioni : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        //Teeman vaihtaminen koodissa täytyy tehdä, jokoa Pre_Init-tapahtuman käsittelijässä tai ennen sitä
        switch (Request.QueryString["theme"])
        {
            case "Kaunis":
                Page.Theme="Kaunis";
                break;
            case "Ruma":
                Page.Theme = "Ruma";
                break;
            default:
                break;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
        if (this.IsPostBack)
        {
           // lblTesti.Text = "is Post Back";
            validatorNimi.Validate();
            if (validatorNimi.IsValid)
            {
                lblNimiValidator.Text = "Kelpaa";
            }
            else
            {
                lblNimiValidator.Text = "There are one or more invalid entries.";
            }
        }
        */
        if (this.IsPostBack)
        {
            // lblTesti.Text = "is Post Back";
            validatorRegexpNimi.Validate();
            if (validatorRegexpNimi.IsValid)
            {
                lblNimiValidator.Text = "Kelpaa";
            }
            else
            {
                lblNimiValidator.Text = "Ei kelpaa";
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}