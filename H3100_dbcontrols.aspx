<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H3100_dbcontrols.aspx.cs" Inherits="H3100_dbcontrols" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:SqlDataSource ID="SqlDataSource" 
        ConnectionString="<%$ ConnectionStrings:MovieConnectionString2 %>"
        SelectCommand="SELECT title, director, year FROM Movies ORDER BY title"
        runat="server">
    </asp:SqlDataSource>

    <h1>DataControls to display a single data item</h1>
    <h2>DetailsView -control</h2>
    <p>Näyttää data HTML-taulussa, tarvittaessa mahdollistaa lisäämisen ja muokkaamisen</p>
    <asp:DetailsView ID="DetailsView1" DataSourceID="SqlDataSource" runat="server" AllowPaging="true" />

    <h2>FormView -control</h2>
    <p>Näyttää datan ItemTemplaten avulla</p>
    <asp:FormView ID="FormView1" DataSourceID="SqlDataSource" runat="server" AllowPaging="true">
        <ItemTemplate>
            <h3><%#Eval("title") %></h3> directed by <%#Eval("director") %> at year <%#Eval("year") %>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>

