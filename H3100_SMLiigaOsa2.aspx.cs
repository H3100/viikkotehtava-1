using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class H3100_SMLiigaOsa2 : System.Web.UI.Page
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
        populateddlSeura();
        populateddlPelipaikka();
        listaaPelaajatAakkosjarjestyksessa();
        //populateMyGridview();
    }

    protected void populateddlSeura()
    {
        string path = MappedApplicationPath + "App_Data/" + "SMLiiga.accdb";
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path;
        string queryString = "SELECT DISTINCT seura FROM Pisteet ORDER BY seura";
        //lblTesti.Text = queryString;
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            OleDbCommand command = new OleDbCommand(queryString, connection);

            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ddlSeura.Items.Add(reader["seura"].ToString());
            }

            connection.Close();
        }
    }
    protected void populateddlPelipaikka()
    {
        string path = MappedApplicationPath + "App_Data/" + "SMLiiga.accdb";
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path;
        string queryString = "SELECT DISTINCT pelipaikka FROM Pisteet ORDER BY pelipaikka";
        //lblTesti.Text = queryString;
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            OleDbCommand command = new OleDbCommand(queryString, connection);

            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ddlPelipaikka.Items.Add(reader["pelipaikka"].ToString());
            }

            connection.Close();
        }
    }
    protected void populateMyGridview()
    {
                string path = MappedApplicationPath + "App_Data/" + "SMLiiga.accdb";
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path;
        string queryString = "SELECT * FROM Pisteet";
        //lblTesti.Text = queryString;
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            OleDbCommand command = new OleDbCommand(queryString, connection);
            OleDbDataAdapter adp = new OleDbDataAdapter(command);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            myGridview.DataSource = ds;
            myGridview.DataBind();
        }
    }
    private void listaaPelaajatAakkosjarjestyksessa()
    {
        string path = MappedApplicationPath + "App_Data/" + "SMLiiga.accdb";
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path;
        string queryString = "SELECT * FROM Pisteet ORDER BY sukunimi, etunimi";
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            OleDbCommand command = new OleDbCommand(queryString, connection);

            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            TableCell cell1;
            TableCell cell2;
            /*
            TableCell cell3;
            TableCell cell4;
            TableCell cell5;
            TableCell cell6;
            TableCell cell7;
            TableCell cell8;
            TableCell cell9;
            TableCell cell10;
            TableCell cell11;
            TableCell cell12;
            TableCell cell13;
            TableCell cell14;
             */
            TableRow row;
            TextBox txt;
            TextBox txt2;
            int i = 1;
            while (reader.Read())
            {
                txt = new TextBox();
                txt.ID = "sukunimi"+i;
                txt.Text = reader["sukunimi"].ToString();

                txt2 = new TextBox();
                txt2.ID = "etunimi" + i;
                txt2.Text = reader["etunimi"].ToString();

                cell1 = new TableCell();
                cell2 = new TableCell();

                cell1.Controls.Add(txt);
                cell2.Controls.Add(txt2);

                row = new TableRow();
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);

                myTable.Rows.Add(row);
                i++;
            }

            connection.Close();
        }
    }
    protected void btnTallenna_Click(object sender, EventArgs e)
    {
        string path = MappedApplicationPath + "App_Data/" + "SMLiiga.accdb";
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path;
        string maxvalue = null;
  
        
        string queryString = "SELECT MAX(id) as maksimi FROM Pisteet";
        //lblTesti.Text = queryString;
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            OleDbCommand command = new OleDbCommand(queryString, connection);

            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                maxvalue = reader["maksimi"].ToString();
                    
            }


            connection.Close();

           // lblTesti.Text = maxValue.ToString();
            
        }
        queryString = "INSERT INTO Pisteet(id, etunimi, sukunimi, seura, pelipaikka) VALUES (?,?,?,?,?)";
       // string queryString = "INSERT INTO Pisteet(etunimi, sukunimi, seura, pelipaikka) VALUES (" +txtEtunimi.Text.ToString() +","+txtSukunimi.Text.ToString()+","+ddlSeura.SelectedValue.ToString()+"," +ddlPelipaikka.SelectedValue.ToString()+")";
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            OleDbCommand command = new OleDbCommand(queryString, connection);
            connection.Open();
            command.Parameters.AddWithValue("@0", Convert.ToInt32(maxvalue)+1);
            command.Parameters.AddWithValue("@1", txtEtunimi.Text.ToString());
            command.Parameters.AddWithValue("@2", txtSukunimi.Text.ToString());
            command.Parameters.AddWithValue("@3", ddlSeura.SelectedValue.ToString());
            command.Parameters.AddWithValue("@4", ddlPelipaikka.SelectedValue.ToString());
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    protected void btntarkistamuutokset_Click(object sender, EventArgs e)
    {

    }
}