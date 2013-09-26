<%@ Page Title="IIO13200 kotisivu" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H3100_indexMP.aspx.cs" Inherits="H3100_indexMP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    
    <h2>Viikon 37 tuntiharkat</h2>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Tehtävä1">HyperLink</asp:HyperLink>
    
        <br />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/H3100_localDBDemo.aspx">HyperLink</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Tehtävä1">HyperLink</asp:HyperLink>
    
        <br />
        <h2>Viikon 38 tuntiharkat</h2>
        <asp:HyperLink ID="HyperLink4" runat="server">Iän laskenta Calendar komponentilla</asp:HyperLink>

        <h2>Viikkotehtävät 1 ja 2</h2>

        <asp:TextBox ID="txtName" runat="server" Text="Tähän nimesi" ></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Välitä parametrina" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Tallenna sessioon" OnClick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" Text="Tallenna Cookiehin" OnClick="Button3_Click" />

        <h2>Viikon 39 tuntiharkat</h2>
        <asp:HyperLink ID="HyperLink5" runat="server">Iän laskenta Calendar komponentilla</asp:HyperLink>
    </div>
</asp:Content>

