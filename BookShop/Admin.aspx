<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Button ID="btnGetAccounts" runat="server" Text="Hae accountit" OnClick="btnGetAccounts_Click" />
    <asp:GridView ID="myGridView" runat="server"></asp:GridView>
</asp:Content>

