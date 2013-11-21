//OurBookShop - BooksShopBL.cs Programmed by Esa Salmikangas 24.2.2011
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Collections;
using System.Configuration;

/// <summary>
/// BookShopBL contains all needed BusinessLogic functionality for OurBookShop application
/// </summary>
public class BookShopBL
{
  private bool useDB;
  private BookShopDB db;
  //private List<Book> books; //a hint http://www.dotnetperls.com/
	public BookShopBL()
	{
    useDB = false;
	}
  public BookShopBL(string connectionString)
  {
    useDB = true;
    try
    {
      db = new BookShopDB(connectionString);
    }
    catch
    {
      throw;
    }
  }
  public List<String> GetCountries()
  {
    List<string> countries;
    if (useDB)
    {
      DataTable dt = db.GetCountries();
      countries = new List<string>();
      countries.Add("Select");
      foreach (DataRow dr in dt.Rows)
      {
        countries.Add(dr[0].ToString());
      }
    }
    else
    {
      string[] c = { "Select", "England", "Finland", "Germany" };
      countries = new List<string>(c);
    }
    //return
    return countries;
  }
  public List<Book> GetBooksWrittenBy(string author)
  {
    if (useDB)
      return GetBooksFromDb("", author);
    else
      return GetBooksFromCode();
  }
  public List<Book> GetBooksFrom(string country)
  {
    if (useDB)
      return GetBooksFromDb(country, "");
    else
      return GetBooksFromCode();
  }
  public List<Book> GetBooksFromAndBy(string country, string author)
  {
    //Get rid off from extra spaces
    country = country.Trim();
    author = author.Trim();
    if (useDB)
      return GetBooksFromDb(country, author);
    else
      return GetBooksFromCode();

  }
  public List<Book> GetAllBooks()
  {
    if (!useDB)
      return GetBooksFromCode(); //just for testing
    else
      return GetBooksFromDb("", "");
  }
  private List<Book> GetBooksFromCode()
  {
    //create a book
    Book b = new Book();
    b.Author = "Esa Salmikangas";
    b.Name = "ASP.NET Security (coming)";
    b.Year = 2011;
    b.Country = "Finland";
    //create a list of books
    List<Book> books = new List<Book>();
    books.Add(b);
    //and let's return it
    return books;
  }
  private List<Book> GetBooksFromDb(string countryFilter, string authorFilter)
  {
    //create a book
    Book b;
    //get books from db
    //Note: we have to remove select
    if (countryFilter.Contains("Select"))
      countryFilter = "";
    //Demo: Preventing SQL Injection
    DataTable dt = db.GetBooksSafeVE2(countryFilter,authorFilter);
    //create a list of books
    List<Book> books = new List<Book>();
    foreach (DataRow dr in dt.Rows)
    {
      //note you have to know columns of query (here name, author, year, country)
      b = new Book();
      b.Name = dr[0].ToString();
      b.Author = dr[1].ToString();
      b.Year = (int)dr[2];
      b.Country = dr[3].ToString();
      books.Add(b);  
    }
    //and let's return it
    return books;
  }
}
[Serializable]
public class Book
{
  private string name;
  public string Name
  {
    get { return name; }
    set { name = value; }
  }
  private string author;
  public string Author
  {
    get { return author; }
    set { author = value; }
  }
  private int year;
  public int Year
  {
    get { return year; }
    set { year = value; }
  }
  private string country;

  public string Country
  {
    get { return country; }
    set { country = value; }
  }
}
