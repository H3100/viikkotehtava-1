<%@ Page Language="C#" AutoEventWireup="true" CodeFile="H3100_index.aspx.cs" Inherits="H3100_index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Antin viikkotehtävä</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Tehtävä1">HyperLink</asp:HyperLink>
    
        <br />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/H3100_localDBDemo.aspx">HyperLink</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Tehtävä1">HyperLink</asp:HyperLink>
    
    </div>
    </form>
</body>
</html>
