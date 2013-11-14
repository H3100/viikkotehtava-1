<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H3100_RouppiAloitus.aspx.cs" Inherits="H3100_RouppiAloitus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label3" runat="server" Text="Käyttäjätunnus: admin ja salasana admin, niin voit muokata autoja"></asp:Label>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Käyttäjätunnus: "></asp:Label>
    <asp:TextBox ID="txtKT" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Salasana: "></asp:Label>
    <asp:TextBox ID="txtSalasana" TextMode="Password" runat="server"></asp:TextBox>

    <br />
    <asp:Button ID="Button1" runat="server" Text="Kirjaudu" OnClick="Button1_Click" />
</asp:Content>

