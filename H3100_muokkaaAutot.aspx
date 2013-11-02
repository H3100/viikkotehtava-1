<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H3100_muokkaaAutot.aspx.cs" Inherits="H3100_muokkaaAutot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="txtRekkari" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="ValidatorRekkari" runat="server" 
        ErrorMessage="Rekkari ei oikeata muotoa" ControlToValidate="txtRekkari"
        validationexpression="^[a-zA-Z]{1,3}[-][0-9]{1,3}$">
    </asp:RegularExpressionValidator>
    <br />
    <asp:TextBox ID="txtMerkki" runat="server"></asp:TextBox>
    <br />
    <asp:TextBox ID="txtMalli" runat="server"></asp:TextBox>
    <br />
    <asp:TextBox ID="txtVm" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="ValidatorVm" runat="server" 
        ErrorMessage="Vuosimalli ei ole oikeaa muotoa" ControlToValidate="txtVm"
        validationexpression="^[0-9]+$">
    </asp:RegularExpressionValidator>
    <br />
    <asp:TextBox ID="txtMyyntihinta" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="ValidatorMyyntihinta" runat="server" 
        ErrorMessage="Myyntihinta ei ole oikeaa muotoa" ControlToValidate="txtMyyntihinta"
        validationexpression="^[0-9]+$">
    </asp:RegularExpressionValidator>
    <br />
    <asp:TextBox ID="txtSisaanostohinta" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="ValidatorSisaanostohinta" runat="server" 
        ErrorMessage="Sisäänostohinta ei ole oikeaa muotoa" ControlToValidate="txtSisaanostohinta"
        validationexpression="^[0-9]+$">
    </asp:RegularExpressionValidator>
    <asp:Button ID="btnPaivita" runat="server" OnClick="btnPaivita_Click" Text="Päivitä" />
    <br />
    <asp:Label ID="lblTesti" runat="server" Text="Label"></asp:Label>
</asp:Content>

