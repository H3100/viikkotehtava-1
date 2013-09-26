using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class H3100_XMLDataAdapterKoodilla : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGetCheapRecords_Click(object sender, EventArgs e)
    {
        //haetaan levytiedot DataTableen vai DataSettiin
        // Tämä onnistuu heittämällä vain DataSetillä
        DataSet ds = new DataSet();
        ds.ReadXml(MapPath("~/App_data/Records.xml"));

        /*
        DataTable dt = new DataTable();
        dt.ReadXml(MapPath("~/App_data/Records2.xml"));
        */
        //kytketään kontrolliin
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
}