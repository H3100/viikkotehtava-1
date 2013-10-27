<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H3100_SM-liiga.aspx.cs" Inherits="H3100_SM_liiga" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Table ID="myTable" runat="server">
    </asp:Table>
    <asp:Button ID="btn1" runat="server" Text="Listaa kaikki pelaajat" OnClick="btn1_Click" />
    <br />
    <asp:DropDownList ID="ddlJoukkueet" runat="server"></asp:DropDownList>
    <asp:Button ID="btnListaaPelaajat" runat="server" Text="Listaa akkosjärjestykseen" OnClick="btnListaaPelaajat_Click" />
    <asp:Button ID="btnListaaPelaajatPistejarj" runat="server" Text="listaa pistejärjestykseen" OnClick="btnListaaPelaajatPistejarj_Click" />
    <br />
    <br />
    <asp:DropDownList ID="ddlPeliaikat" runat="server"></asp:DropDownList>
    <asp:Button ID="btnListaaPelipaikanPerusteella" runat="server" Text="Listaa pelipaikan perusteella pistejärjestyksessä" OnClick="btnListaaPelipaikanPerusteella_Click" />
    <asp:Button ID="btnListaapelipaikanpAakkosj" runat="server" Text="Listaa pelipaikan perusteella aakkosjärjestyksessä" OnClick="btnListaapelipaikanpAakkosj_Click" />
    <asp:Label ID="lblTesti" runat="server" Text="Label"></asp:Label>
</asp:Content>

