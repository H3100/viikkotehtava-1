<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H3100_XMLDataAdapterKoodilla.aspx.cs" Inherits="H3100_XMLDataAdapterKoodilla" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Alennuslaari</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Tänään meiltä halvalla seuraavat levyt</h1>
    <asp:Button ID="btnGetCheapRecords" runat="server" Text="Näytä tarjouslevyt" OnClick="btnGetCheapRecords_Click" />
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
</asp:Content>

