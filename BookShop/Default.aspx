<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>Welcome to Our BookShop!</h2>
    <p>Here you can find some nice <a href="Books.aspx" >books</a> from all over the world.</p>
    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/bookshop13.jpg" />
    <p>To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">www.asp.net</a>.</p>
</asp:Content>
