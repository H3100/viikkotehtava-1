using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class H3100_lasnaolot : System.Web.UI.Page
{
    private string connString = "Data Source=eight.labranet.jamk.fi;Initial Catalog=DemoxOy;Persist Security Info=True;User ID=koodari;Password=koodari13";

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        populateDdlOpintojaksot();
        /*
         * Palvelin: eight.labranet.jamk.fi
         * tunnus: koodari
         * salasana: koodari13
         * tietokanta: DemoxOy
         * taulu: lasnaolot
         * 
        qry = "select * from customer"; 
        sds = new SqlDataSource(connection, qry); 
        GridView1.DataSource = sds; 
        GridView1.DataBind();
         * */
    }

    protected void populateDdlOpintojaksot()
    {
        //string connString = "Data Source=eight.labranet.jamk.fi;Initial Catalog=DemoxOy;Persist Security Info=True;User ID=koodari;Password=koodari13";

        using (SqlConnection con = new SqlConnection(this.connString))
        {

            con.Open();

            using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT course FROM lasnaolot", con))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            ddlOpintojaksonValinta.Items.Add(reader["course"].ToString());
                            //do something
                        }
                    }
                } // reader closed and disposed up here

            } // command disposed here

        } //connection closed and disposed here
    }
    protected void btnHae_Click(object sender, EventArgs e)
    {
        string likeString = "'%" + ddlOpintojaksonValinta.SelectedValue + "%'";
        string likeStringNimi = "'%" + txtSukunimi.Text + "%'";
        string qry = "SELECT asioid, lastname, firstname, date FROM lasnaolot WHERE lastname like " +likeStringNimi + " AND course like " +likeString +" ORDER BY asioid";
        lblTesti.Text = qry;
        SqlDataSource sds = new SqlDataSource(this.connString, qry);
        GridViewHaetut.DataSource = sds;
        GridViewHaetut.DataBind();
    }
}