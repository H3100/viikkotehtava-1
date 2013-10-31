<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H3100_haeIlmot.aspx.cs" Inherits="H3100_haeIlmot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SqlDataSource ID="srcIlmot" 
        ConnectionString="Data Source=eight.labranet.jamk.fi;Initial Catalog=DemoxOy;Persist Security Info=True;User ID=koodari;Password=koodari13"
        SelectCommand="SELECT asioid, lastname, firstname, date FROM lasnaolot WHERE course like 'IIO13200%' ORDER BY asioid" runat="server">
    </asp:SqlDataSource>

        <h2>Syksyn läsnäolot</h2>
        <asp:GridView runat="server" DataSourceID="srcIlmot"></asp:GridView>

</asp:Content>

