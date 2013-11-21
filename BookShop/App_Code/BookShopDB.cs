//OurBookShop - BooksShopDB.cs Programmed by Esa Salmikangas 24.2.2011
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// BookShopDB contains db functionality for OurBookShop application
/// </summary>
public class BookShopDB
{
  private SqlConnection myConn;
  private string myConnStr;
  public BookShopDB(string connectionString)
  {
    // let's create a connection to our db
    myConnStr = connectionString;
    OpenConnection();
    //
  }
  private bool OpenConnection()
  {
    try
    {
      myConn = new SqlConnection(myConnStr);
      myConn.Open();
      return true;
    }
    catch (Exception)
    {
      throw;
    }
  }
  public DataTable GetBooksNotSafe(string countryFilter, string authorFilter)
  {
    try
    {
      using (myConn)
      {
        //this is unsafe way to make query to a database! Do not do like this in the real world!
        string sql = "SELECT name, author, year, country FROM books";
        //add filters if needed
        if ((countryFilter.Length > 0) && (authorFilter.Length > 0))
          sql += " WHERE country like '" + countryFilter + "%' AND author like '%" + authorFilter + "%'";
        else if (countryFilter.Length > 0)
          sql += " WHERE country like '" + countryFilter + "%'";
        else if (authorFilter.Length > 0)
          sql += " WHERE author like '%" + authorFilter + "%'";
        using (SqlCommand cmd = new SqlCommand(sql, myConn))
        using (SqlDataReader rdr = cmd.ExecuteReader())
        {
          DataTable dt = new DataTable();
          dt.Load(rdr);
          return dt;
        }
      }
    }
    catch
    {
      throw;
    }
  }
  public DataTable GetBooksSafeVE2(string countryFilter, string authorFilter)
  {
    try
    {
      //Demo:Preventing SQL Injection
      //-->use Parameters
      string sql = "SELECT name, author, year, country FROM books";
      //add filters if needed
      if ((countryFilter != "") && (authorFilter != ""))
        sql += " WHERE (country LIKE @CountryParam AND author LIKE @AuthorParam)";
      else if (countryFilter != "")
        sql += " WHERE country LIKE @CountryParam";
      else if (authorFilter != "")
        sql += " WHERE author LIKE @AuthorParam";
      System.Diagnostics.Debug.Write(sql);
      using (SqlCommand cmd = new SqlCommand(sql, myConn))
      {
        //Add Parameters
        if (countryFilter != "")
        {
          SqlParameter param = new SqlParameter("CountryParam", SqlDbType.VarChar);
          param.Value = "%" + countryFilter + "%";
          cmd.Parameters.Add(param);
        }
        if (authorFilter != "")
        {
          SqlParameter param2 = new SqlParameter("AuthorParam", SqlDbType.VarChar);
          param2.Value = "%" + authorFilter + "%";
          cmd.Parameters.Add(param2);
        }
        //execute reader
        using (SqlDataReader rdr = cmd.ExecuteReader())
        {
          DataTable dt = new DataTable();
          dt.Load(rdr);
          return dt;
        }
      }
    }
    catch
    {
      throw;
    }
  }
  public DataTable GetCountries()
  {
    try
    {
      using (myConn)
      {
        using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT country FROM books", myConn))
        using (SqlDataReader rdr = cmd.ExecuteReader())
        {
          DataTable dt = new DataTable();
          dt.Load(rdr);
          return dt;
        }
      }
    }
    catch
    {
      throw;
    }
  }
 
}