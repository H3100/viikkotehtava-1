<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H3100_rssfeedsTuntiEsim.aspx.cs" Inherits="H3100_rssfeedsTuntiEsim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:XmlDataSource ID="myDataSource" runat="server"  XPath="rss/channel/item" />

    <asp:XmlDataSource ID="XmlDataSource2" DataFile="<%$ AppSettings:rssFeeditSF %>" 
        TransformFile="~/App_Data/rssfeeds.xsl" runat="server" XPath="rss/channel/item" />
    <asp:Button ID="btngetMicrosoft" runat="server" Text="Microsoft Feeds" OnClick="btngetMicrosoft_Click" />
    <asp:Button ID="btnGetLiiga" runat="server" OnClick="btnGetLiiga_Click" Text="Liiga" />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Iltasanomat Feeds" />
    <h1><asp:Label ID="lblHeader" runat="server" Text="..."></asp:Label></h1>
    <asp:Label ID="lblBody" runat="server" Text="..."></asp:Label>

    
    <asp:Table ID="myDataTable" runat="server" />

    <!-- RSS-feedien haku "ilman koodausta" -->
    <asp:GridView ID="myGridView" DataSourceID="XmlDataSource2" AutoGenerateColumns="true" runat="server">
    </asp:GridView>
</asp:Content>

