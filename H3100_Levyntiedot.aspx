<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H3100_Levyntiedot.aspx.cs" Inherits="H3100_Levyntiedot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Image ID="myImage" runat="server" />
    <br />
    <asp:Label ID="lblArtistiAlbumi" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="lblISBN" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="lblHinta" runat="server" Text="Label"></asp:Label>
    <p runat="server" id="myParagraph">

    </p>

    <asp:Label ID="lblTesti" runat="server" Text=""></asp:Label>
</asp:Content>

