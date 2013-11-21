<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MyAccount.aspx.cs" Inherits="Account_MyAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Account details for <%  Response.Write(User.Identity.Name);%></h1>
    <div id="info">
        <p>Account: <asp:Label ID="myName" runat="server"></asp:Label></p>
        <p>Email: <asp:Label ID="myEmail" runat="server"></asp:Label></p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Account/ChangePassword.aspx">Vaihda salasana</asp:HyperLink>
    </div>
</asp:Content>

