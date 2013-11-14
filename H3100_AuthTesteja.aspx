<%@ Page Language="C#" AutoEventWireup="true" CodeFile="H3100_AuthTesteja.aspx.cs" Inherits="H3100_AuthTesteja" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Login ID="Login1" runat="server" OnLoggedIn="LoggedIn">
        </asp:Login>
    <div>
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Logout" />
        <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" 
            NavigateUrl="~/AuthNeeded/H3100_authTestejaMembersOnly.aspx"
            >To members page</asp:HyperLink>
    
    </div>
    </form>
</body>
</html>
