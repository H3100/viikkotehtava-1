<%@ Page Title="RegularExpressionTesti" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RegularExpressioni.aspx.cs" 
    Inherits="RegularExpressioni" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Reqular Expression testi</h1>
    <h2>Kirjoita oheiseen textboxiin testattava teksti:</h2>
    <br />
    <asp:TextBox ID="txtNimi" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Validate" />
    <br />
    <asp:Label ID="lblNimiValidator" runat="server" Text="[Tähän kelpaako vai ei]"></asp:Label>
   <!-- <asp:RequiredFieldValidator runat="server" id="validatorNimi" controltovalidate="txtNimi" ValidateEmptyText="true" /> -->
         <asp:RegularExpressionValidator id="validatorRegexpNimi" runat="SERVER" ControlToValidate="txtNimi" 
       ValidationExpression="^[A-Öa-ö]*$" />

    <asp:Label ID="lblTesti" runat="server" Text="...."></asp:Label>

    <h2>Sivun teeman vaihto</h2>
    <asp:Image ID="Image1" SkinID="CompanyLogo" runat="server" />
    <asp:HyperLink ID="hyperlink1" runat="server" NavigateUrl="~/RegularExpressioni.aspx?theme=Kaunis">Kaunis-teema</asp:HyperLink>
    <asp:HyperLink ID="hyperlink2" runat="server" NavigateUrl="~/RegularExpressioni.aspx?theme=Ruma">Ruma-teema</asp:HyperLink>

</asp:Content>

