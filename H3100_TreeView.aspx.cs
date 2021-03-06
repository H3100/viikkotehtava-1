﻿using System;
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
                //tästä lisätään
                xNode = inXmlNode.ChildNodes[i];
                //lisäys
                inTreeNode.ChildNodes.Add(new TreeNode(xNode.Name));

                //tähän lisätään
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

        XmlDocument xmldoc;
        //XDocument xRoot = XDocument.Load(nodeReader, LoadOptions.SetLineInfo);
        XmlNode xmlnode;

        try
        {

        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
        //XmlReader xmlr = XmlReader.Create(fs);
        xmldoc = new XmlDocument();
        xmldoc.Load(fs);

        //tästä lisätään
        xmlnode = xmldoc.ChildNodes[1];
        //lblTesti.Text = xmlnode.InnerXml;
        treeView.Nodes.Clear();
        treeView.Nodes.Add(new TreeNode(xmldoc.DocumentElement.Name));
        //lblTesti.Text = xmldoc.DocumentElement.Name;
        TreeNode tNode;
        // tähän lisätään
        tNode = treeView.Nodes[0];
        AddNode(xmlnode, tNode);

        }
        catch (Exception ex)
        {

            lblTesti.Text = ex.Message;
        }
    }


}