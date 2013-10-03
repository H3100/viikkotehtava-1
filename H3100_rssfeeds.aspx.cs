using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class H3100_rssfeeds : System.Web.UI.Page
{
    // http://www.techrepublic.com/article/how-do-i-use-the-net-framework-to-consume-rss-feeds/
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
         * 
         * 
    <!-- <asp:Repeater ID="ulRepeater" runat="server" OnItemDataBound="unorderedList_ItemDataBound"> 
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
            <ItemTemplate>
                <li><asp:Literal ID="li" runat="server" /></li>
            </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
         * 
        -->
         * 
         * private void Page_Init(object sender, EventArgs e)
{
    string[] array = { "Apple", "Banana", "Cherry" };
    unorderedList.DataSource = array;
    unorderedList.DataBind();
}

protected void unorderedList_ItemDataBound(object sender,  RepeaterItemEventArgs e)
{
    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
    {
        string itemValue = (string)e.Item.DataItem;
        Literal myItem = (Literal)e.Item.FindControl("myItem");
        myItem.Text = itemValue;
    }
}
         * 
         * 
        XmlDocument xmldoc;
        try
        {        
            //Create a WebRequest object
            WebRequest myRequest = WebRequest.Create(ConfigurationManager.AppSettings["rssfeeditSF"]);

            //Get the response from the WebRequest
            WebResponse myResponse = myRequest.GetResponse();

            //Get the response's stream
            Stream fs = myResponse.GetResponseStream();

        
            xmldoc = new XmlDocument();
            xmldoc.Load(fs);

        }
        catch (Exception)
        {

            throw;
        }
        /*
        XmlNamespaceManager manager = new XmlNamespaceManager(xmldoc.NameTable);

        //Add the RSS namespace to the manager
        manager.AddNamespace("rss", "http://purl.org/rss/1.0/");

        XmlNode MainNode = xmldoc.SelectSingleNode("/rss/channel/item", manager);

        List<String> linkit = new List<String>();
        foreach (XmlNode node in MainNode)
        {
           //linkit.Add
        }

        */

    }
}