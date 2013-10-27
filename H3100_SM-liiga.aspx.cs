using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class H3100_SM_liiga : System.Web.UI.Page
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
        if(!IsPostBack) {
        populateDDLJoukkueet();
        populateDDLPelipaikka();
        }

        }

    private void testaa()
    {
        string path = MappedApplicationPath + "App_Data/" + "SMLiiga.accdb";
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path;
        string queryString = "SELECT * FROM Pisteet";
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            OleDbCommand command = new OleDbCommand(queryString, connection);

            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                lblTesti.Text += reader["sukunimi"].ToString();
            }

            connection.Close();
        }
    }

    private void listaaPelaajatAakkosjarjestyksessa()
    {
        string path = MappedApplicationPath + "App_Data/" + "SMLiiga.accdb";
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path;
        string queryString = "SELECT etunimi,sukunimi FROM Pisteet ORDER BY sukunimi, etunimi";
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            OleDbCommand command = new OleDbCommand(queryString, connection);

            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            TableCell cell1;
            TableCell cell2;
            TableRow row;
            while (reader.Read())
            {
                cell1 = new TableCell();
                cell2 = new TableCell();
                cell1.Text = reader["sukunimi"].ToString();
                cell2.Text = reader["etunimi"].ToString();

                row = new TableRow();
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);

                myTable.Rows.Add(row);
            }

            connection.Close();
        }
    }

    private void populateDDLJoukkueet()
    {
        string path = MappedApplicationPath + "App_Data/" + "SMLiiga.accdb";
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path;
        string queryString = "SELECT DISTINCT seura FROM Pisteet ORDER BY seura";
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            OleDbCommand command = new OleDbCommand(queryString, connection);

            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            //lblTesti.Text = "";
            while (reader.Read())
            {
                ddlJoukkueet.Items.Add(reader["seura"].ToString());
              //  lblTesti.Text += reader["seura"].ToString();
            }

            connection.Close();
        }
    }

    private void populateDDLPelipaikka()
    {
        string path = MappedApplicationPath + "App_Data/" + "SMLiiga.accdb";
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path;
        string queryString = "SELECT DISTINCT pelipaikka FROM Pisteet ORDER BY pelipaikka";
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            OleDbCommand command = new OleDbCommand(queryString, connection);

            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            //lblTesti.Text = "";
            while (reader.Read())
            {
                ddlPeliaikat.Items.Add(reader["pelipaikka"].ToString());
                //  lblTesti.Text += reader["seura"].ToString();
            }

            connection.Close();
        }
    }

    protected void btn1_Click(object sender, EventArgs e)
    {
        listaaPelaajatAakkosjarjestyksessa();
    }
    protected void btnListaaPelaajat_Click(object sender, EventArgs e)
    {
        string path = MappedApplicationPath + "App_Data/" + "SMLiiga.accdb";
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path;
        string seura = ddlJoukkueet.SelectedValue;
        string queryString = "SELECT etunimi,sukunimi FROM Pisteet WHERE seura = '"+seura+"' ORDER BY sukunimi, etunimi";
        lblTesti.Text = queryString;
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            OleDbCommand command = new OleDbCommand(queryString, connection);

            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            TableCell cell1;
            TableCell cell2;
            TableRow row;
            while (reader.Read())
            {
                cell1 = new TableCell();
                cell2 = new TableCell();
                cell1.Text = reader["sukunimi"].ToString();
                cell2.Text = reader["etunimi"].ToString();

                row = new TableRow();
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);

                myTable.Rows.Add(row);
            }

            connection.Close();
        }
    }
    protected void btnListaaPelaajatPistejarj_Click(object sender, EventArgs e)
    {
        string path = MappedApplicationPath + "App_Data/" + "SMLiiga.accdb";
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path;
        string seura = ddlJoukkueet.SelectedValue;
        string queryString = "SELECT etunimi,sukunimi FROM Pisteet WHERE seura = '" + seura + "' ORDER BY pisteet";
        lblTesti.Text = queryString;
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            OleDbCommand command = new OleDbCommand(queryString, connection);

            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            TableCell cell1;
            TableCell cell2;
            TableRow row;
            while (reader.Read())
            {
                cell1 = new TableCell();
                cell2 = new TableCell();
                cell1.Text = reader["sukunimi"].ToString();
                cell2.Text = reader["etunimi"].ToString();

                row = new TableRow();
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);

                myTable.Rows.Add(row);
            }

            connection.Close();
        }
    }
    protected void btnListaaPelipaikanPerusteella_Click(object sender, EventArgs e)
    {
        string path = MappedApplicationPath + "App_Data/" + "SMLiiga.accdb";
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path;
        string pelipaikka = ddlPeliaikat.SelectedValue;
        string queryString = "SELECT etunimi,sukunimi FROM Pisteet WHERE pelipaikka = '" + pelipaikka + "' ORDER BY pisteet";
       //lblTesti.Text = queryString;
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            OleDbCommand command = new OleDbCommand(queryString, connection);

            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            TableCell cell1;
            TableCell cell2;
            TableRow row;
            while (reader.Read())
            {
                cell1 = new TableCell();
                cell2 = new TableCell();
                cell1.Text = reader["sukunimi"].ToString();
                cell2.Text = reader["etunimi"].ToString();

                row = new TableRow();
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);

                myTable.Rows.Add(row);
            }

            connection.Close();
        }
    }
    protected void btnListaapelipaikanpAakkosj_Click(object sender, EventArgs e)
    {
        string path = MappedApplicationPath + "App_Data/" + "SMLiiga.accdb";
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path;
        string pelipaikka = ddlPeliaikat.SelectedValue;
        string queryString = "SELECT etunimi,sukunimi FROM Pisteet WHERE pelipaikka = '" + pelipaikka + "' ORDER BY sukunimi, etunimi";
        //lblTesti.Text = queryString;
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            OleDbCommand command = new OleDbCommand(queryString, connection);

            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            TableCell cell1;
            TableCell cell2;
            TableRow row;
            while (reader.Read())
            {
                cell1 = new TableCell();
                cell2 = new TableCell();
                cell1.Text = reader["sukunimi"].ToString();
                cell2.Text = reader["etunimi"].ToString();

                row = new TableRow();
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);

                myTable.Rows.Add(row);
            }

            connection.Close();
        }
    }
}