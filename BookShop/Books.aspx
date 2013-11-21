<%@ Page Title="Books Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Books.aspx.cs" Inherits="_Books" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>
        Our Books
    </h1>
    <p>Here you can find some nice books from all over the world.</p>
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    <div id="errorMessage" runat="server">...</div>
    <p>End of the page</p>
</asp:Content>
