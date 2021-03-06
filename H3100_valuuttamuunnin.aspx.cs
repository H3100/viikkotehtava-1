﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class H3100_valuuttamuunnin : System.Web.UI.Page
{
    private const float BitCoinRate = 94.71F;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["name"] != null)
            TxtUser.Text = Request["name"];

        if (Session["nimi"] != null)
            TxtUser.Text = (String)Session["nimi"];

        HttpCookie Cookie = Request.Cookies["UserName"];
        if (Cookie != null)
            TxtUser.Text = (String)Cookie.Value;
        if(Cookie == null) TxtUser.Text = "Cookie ei toimi";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            //Muunnetaan käyttäjän antamat BitCoinit Euroiksi
            lblCurrency.Text = string.Format("{0:0.0000} euroa", float.Parse(TxtBitcoins.Text) * BitCoinRate);

            //Näytetään suoritetut laskutoimitukset listboxissa
            lstOne.Items.Add(TxtBitcoins.Text + "-->" + lblCurrency.Text);
            lstTwo.Items.Add(TxtBitcoins.Text + "-->" + lblCurrency.Text);
        }
        catch (Exception ex)
        {
            lblCurrency.Text = ex.Message;
        }

    }
}