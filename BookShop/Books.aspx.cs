//OurBookShop - Books.aspx.cs Programmed by Esa Salmikangas 24.2.2011
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class _Books : System.Web.UI.Page
{
  BookShopBL bl;
  string connStr;
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack)
      LoadDataToControl();
  }
  private void LoadDataToControl()
  {
    try
    {
      //get connection string to database
      connStr = ConfigurationManager.ConnectionStrings["BookShop"].ConnectionString;
      //let's fill the gridview with books
      bl = new BookShopBL(connStr);
      GridView1.DataSource = bl.GetAllBooks();
      GridView1.DataBind();
    }
    catch (Exception ex)
    {
      errorMessage.InnerHtml = ex.Message;//bad error message
      errorMessage.InnerHtml = string.Format("We are sorry, an error is occured in {0}, the system is temporarily out of order.", ex.Source); 
    }
  }
}
