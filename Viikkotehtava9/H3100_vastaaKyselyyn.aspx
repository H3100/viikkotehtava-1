<%@ Page Language="C#" AutoEventWireup="true" CodeFile="H3100_vastaaKyselyyn.aspx.cs" Inherits="H3100_vastaaKyselyyn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblKysymys" runat="server" Text="Label"></asp:Label>
        <div id="kysymykset" runat="server">

        </div>
        <asp:Label ID="lblDebug" runat="server" Text="..."></asp:Label>
        <asp:Button ID="btnVastaa" runat="server" Text="Vastaa" OnClick="btnVastaa_Click" />
    </div>
    </form>
</body>
</html>
