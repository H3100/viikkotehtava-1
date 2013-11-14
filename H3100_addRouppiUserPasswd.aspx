<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H3100_addRouppiUserPasswd.aspx.cs" Inherits="H3100_addRouppiUserPasswd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Käyttäjätunnus: "></asp:Label>
    <asp:TextBox ID="txtKT" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Salasana: "></asp:Label>
    <asp:TextBox ID="txtSalasana" TextMode="Password" runat="server"></asp:TextBox>

    <br />
    <asp:Button ID="Button1" runat="server" Text="Tallenna" OnClick="Button1_Click" />
    <br />
    <asp:Label ID="lblTesti" runat="server" Text=""></asp:Label>
</asp:Content>

