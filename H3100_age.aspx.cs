using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class H3100_age : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // Calendar1.SelectedDate = Calendar1.TodaysDate.ToUniversalTime();
        Label1.Text = "Tänään on: " + Calendar1.TodaysDate.ToShortDateString();
        Label2.Text = "Valitse haluamasi päivä.";
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {        
        Label2.Text = "Valittu: " + Calendar1.SelectedDate.ToShortDateString() + " vuosi: " + Calendar1.SelectedDate.Year;
        System.TimeSpan paivat;
        paivat = Calendar1.TodaysDate.Subtract(Calendar1.SelectedDate);
        Label3.Text = "Valitun päivän ja tämän päivän erotus: " +paivat.TotalDays;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        // Vastaus
        Calendar1.SelectedDate = Calendar1.SelectedDate.Date.AddYears(-1);
        Calendar1.VisibleDate = Calendar1.SelectedDate;
        

        //Calendar1.
        //date.text
      //  Calendar1.VisibleDate = Convert.ToDateTime(Calendar1.SelectedDate.);
     // Calendar1.VisibleDate = Calendar1.VisibleDate.Date.AddYears(1); // (Calendar1.SelectedDate.AddYears(1));
     //   Calendar1.VisibleDate = Calendar1.VisibleDate.AddYears(-1);
     //Tämä oli // Label1.Text = Calendar1.SelectedDate.AddYears(1).ToString();
        // pitäisi näyttää näytettävän kuukauden kohta
      //Tämä oli Label1.Text = Calendar1.VisibleDate.AddYears(-1).ToString();
       // Calendar1.VisibleDate.Date.AddYears(1);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        // Vastaus
        Calendar1.SelectedDate = Calendar1.SelectedDate.Date.AddYears(1);
        Calendar1.VisibleDate = Calendar1.SelectedDate;
       // Calendar1.VisibleDate = Calendar1.VisibleDate.Date.AddYears(1);
    }
}