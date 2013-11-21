//OurBookShop - Search.aspx.cs Programmed by Esa Salmikangas 24.2.2011
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class _Search : System.Web.UI.Page
{
    BookShopBL bl;
    protected void Page_Load(object sender, EventArgs e)
    {
      //let's fill the dropdown, but only once :-)
      if (!IsPostBack)
      {
        LoadDataToComponents();
      }
    }
    protected void LoadDataToComponents()
    {
      //use try catch always when reading data outside of your code
      try
      {
        bl = new BookShopBL(ConfigurationManager.ConnectionStrings["BookShop"].ConnectionString);
        ddlCountries.DataSource = bl.GetCountries();
        ddlCountries.DataBind();
      }
      catch (Exception ex)
      {
        errorMessage.InnerHtml = string.Format("We are sorry, an error is occured in {0}, the system is temporarily out of order.", ex.Source); 
        
      }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
      try
      {
        //Sanity test: Lets check that input is proper
        Regex regex = new Regex(@"^[a-ö]*$");
        if (regex.IsMatch(txtAuthor.Text))
        {
          bl = new BookShopBL(ConfigurationManager.ConnectionStrings["BookShop"].ConnectionString);
          GridView1.DataSource = bl.GetBooksFromAndBy(ddlCountries.SelectedItem.Value, txtAuthor.Text);
          GridView1.DataBind();
        }
        else
        {
          errorMessage.InnerHtml = " The given text was not proper";
        }
      }
      catch (Exception ex)
      {
        errorMessage.InnerHtml = ex.Message;
      }
    }
    protected void ddlCountries_SelectedIndexChanged(object sender, EventArgs e)
    {
      //let's filter books
      bl = new BookShopBL(ConfigurationManager.ConnectionStrings["BookShop"].ConnectionString);
      GridView1.DataSource = bl.GetBooksFrom(ddlCountries.SelectedItem.Value);
      GridView1.DataBind();
    }
}
