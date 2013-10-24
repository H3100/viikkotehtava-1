<%@ Page Title="Läsnäolot" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H3100_lasnaolot.aspx.cs" Inherits="H3100_lasnaolot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <asp:Label ID="Label1" runat="server" Text="Sukunimi:"></asp:Label>
    <asp:TextBox ID="txtSukunimi" runat="server"></asp:TextBox>
    <asp:Button ID="btnHae" runat="server" Text="Hae" />
    <br />
    <asp:Label ID="lblOpintojaksonvalinta" runat="server" Text="Opintojakson valinta:"></asp:Label>
    <asp:DropDownList ID="ddlOpintojaksonValinta" runat="server"></asp:DropDownList>
</asp:Content>

