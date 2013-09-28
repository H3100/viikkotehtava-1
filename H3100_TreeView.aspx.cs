using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class H3100_TreeView : System.Web.UI.Page
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
    }

    private void AddNode(XmlNode inXmlNode, TreeNode inTreeNode)
    {
        XmlNode xNode;
        TreeNode tNode;
        XmlNodeList nodeList;
        int i = 0;
        if (inXmlNode.HasChildNodes)
        {
            nodeList = inXmlNode.ChildNodes;
            for (i = 0; i <= nodeList.Count - 1; i++)
            {
                xNode = inXmlNode.ChildNodes[i];
                inTreeNode.ChildNodes.Add(new TreeNode(xNode.Name));
                tNode = inTreeNode.ChildNodes[i];
                AddNode(xNode, tNode);
            }
        }
        else
        {
            inTreeNode.Text = inXmlNode.InnerText.ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        fu.SaveAs(Server.MapPath("Files") + "\\" + fu.FileName);
        lblTesti.Text = "File uploaded succesfully";

        String path = MappedApplicationPath +"Files/" +fu.FileName;
        XmlDataDocument xmldoc = new XmlDataDocument();
        XmlNode xmlnode;
        try
        {

        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
        xmldoc.Load(fs);
        xmlnode = xmldoc.ChildNodes[1];
        treeView.Nodes.Clear();
        treeView.Nodes.Add(new TreeNode(xmldoc.DocumentElement.Name));
        TreeNode tNode;
        tNode = treeView.Nodes[0];
        AddNode(xmlnode, tNode);

        }
        catch (Exception ex)
        {

            lblTesti.Text = ex.Message;
        }
    }


}