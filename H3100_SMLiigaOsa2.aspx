<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H3100_SMLiigaOsa2.aspx.cs" Inherits="H3100_SMLiigaOsa2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Etunimi:"></asp:Label>
    <asp:TextBox ID="txtEtunimi" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" id="reqEtunimi" controltovalidate="txtEtunimi" errormessage="Etunimi puuttuu" />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Sukunimi:"></asp:Label>
    <asp:TextBox ID="txtSukunimi" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" id="reqSukunimi" controltovalidate="txtSukunimi" errormessage="Sukunimi puuttuu" />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Seura"></asp:Label>
    <asp:DropDownList ID="ddlSeura" runat="server"></asp:DropDownList>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Pelipaikka"></asp:Label>
    <asp:DropDownList ID="ddlPelipaikka" runat="server"></asp:DropDownList>
    <br />
    <asp:Button ID="btnTallenna" runat="server" Text="Tallenna pelaaja tietokantaan" OnClick="btnTallenna_Click" />
    <asp:Label ID="lblTesti" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:GridView ID="myGridview" runat="server"></asp:GridView>
    <asp:Table ID="myTable" runat="server"></asp:Table>
    <br />
    <asp:Button ID="btntarkistamuutokset" runat="server" Text="Päivitä" />
</asp:Content>

