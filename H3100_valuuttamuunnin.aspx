<%@ Page Title="IIO13200 viikkotehtävä 1" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H3100_valuuttamuunnin.aspx.cs" Inherits="H3100_valuuttamuunnin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Miten lukea URL -->
    Terve<asp:TextBox ID="TxtUser" runat="server"></asp:TextBox><br />
    Muunnan bitcoinit euroiksi, anna BitCoinien määrä
    <asp:TextBox ID="TxtBitcoins" runat="server"></asp:TextBox><br />
    <asp:Button ID="Button1" runat="server" Text="Muunna" OnClick="Button1_Click" /> <br />
    <asp:Label ID="lblCurrency" runat="server" Text="..."></asp:Label> <br />
    <asp:ListBox ID="lstOne" runat="server"></asp:ListBox>
    <asp:ListBox ID="lstTwo" runat="server" EnableViewState="False"></asp:ListBox>

</asp:Content>

