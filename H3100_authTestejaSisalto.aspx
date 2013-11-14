<%@ Page Language="C#" AutoEventWireup="true" CodeFile="H3100_authTestejaSisalto.aspx.cs" Inherits="H3100_authTestejaSisalto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
        <asp:Menu ID="Menu1" runat="server">
        <Items>
            <asp:MenuItem NavigateUrl="~/AuthNeeded/H3100_authTestejaMembersOnly.aspx" Text="Members only" Value="Members only"></asp:MenuItem>
        </Items>
    </asp:Menu>
    <div>
    
    </div>
    </form>
</body>
</html>
