<%@ Page Title="" Language="C#" MasterPageFile="~/H3100_MasterPage.master" AutoEventWireup="true" CodeFile="H3100_TreeView.aspx.cs" Inherits="H3100_TreeView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:XmlDataSource ID="XmlDataSource" runat="server" 
        DataFile="~/App_data/nodet.xml">
    </asp:XmlDataSource>
    
      <h3>TreeView XML Data Binding Example</h3>
        <asp:TreeView id="treeView" runat="server" 
            ImageSet="Simple2"
            DataSourceID="XMLDataSource">

        </asp:TreeView>

    <asp:FileUpload  runat="server" ID="fu" />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Lataa" />

    <asp:Label ID="lblTesti" runat="server" Text=""></asp:Label>

</asp:Content>

