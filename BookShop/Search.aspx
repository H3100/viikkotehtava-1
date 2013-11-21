<%@ Page Title="Books Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Search.aspx.cs" Inherits="_Search" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Search Books
    </h2>
    <p>Here you can search some nice books from our bookstore.</p>
    Country:
    <asp:DropDownList ID="ddlCountries" runat="server" AutoPostBack="True" 
    onselectedindexchanged="ddlCountries_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    Author:
    <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" 
        Text="Search" />
    <br />
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    <div id="errorMessage" runat="server">...</div> 
    <p>End of the page</p>
</asp:Content>
