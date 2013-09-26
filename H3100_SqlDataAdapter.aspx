<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H3100_SqlDataAdapter.aspx.cs" Inherits="H3100_SqlDataAdapter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SqlDataSource ID="SqlDataSource" 
        ConnectionString="<%$ ConnectionStrings:MovieConnectionString2 %>"
        SelectCommand="SELECT title, director, year FROM Movies ORDER BY title"
        runat="server">
    </asp:SqlDataSource>
    <h2>Grid view</h2>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource">
        <Columns>
            <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
            <asp:BoundField DataField="director" HeaderText="director" SortExpression="director" />
            <asp:BoundField DataField="year" HeaderText="year" SortExpression="year" />
        </Columns>
    </asp:GridView>

    <h2>DataList kontrolli</h2>
    <p>Datalist esittää datan html-taulussa, määritetään esitettävä data ItemTemplatella.</p>
    <asp:DataList ID="DataList1" DataSourceID="SqlDataSource" runat="server">
        <ItemTemplate>
            Elokuvan <%#Eval("title") %> on ohjannut <%#Eval("director") %>
        </ItemTemplate>
    </asp:DataList>

    <h2>Repeate -kontrolli</h2>
    <p>Repeater käyttää datarivejä käyttäen templatea ei renderöi automaattisesti</p>
    <asp:Repeater ID="Repeater1" DataSourceID="SqlDataSource" runat="server">
        <ItemTemplate>
            Movie <%#Eval("title") %> directed by <b><%#Eval("director") %></b>
        </ItemTemplate>
    </asp:Repeater>

    <h2>ListView -kontrolli</h2>
    <p>Tämäkin näyttää datarivejä käyttäen templatea, tukee sorttausta, sivutusta ja datan editointia.</p>
    <asp:ListView ID="Listview1" DataSourceID="SqlDataSource" runat="server">
        <LayoutTemplate>
            <div id="itemPlaceholder" runat="server" />
            <asp:DataPager ID="Pager1" PageSize="4" runat="server">
                <Fields>
                    <asp:NumericPagerField />
                </Fields>
            </asp:DataPager>
        </LayoutTemplate>
        <ItemTemplate>
            <b>Movie <%#Eval("title") %> </b> directed by <%#Eval("director") %> </br>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>

