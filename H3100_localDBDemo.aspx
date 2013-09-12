<%@ Page Language="C#" AutoEventWireup="true" CodeFile="H3100_localDBDemo.aspx.cs" Inherits="H3100_localDBDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Paikallista tietoa tietokannasta</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Tässä elokuvia (oliokokoelma)</h2>
    </div>
        <asp:Button ID="btnGetMovies" runat="server" Text="Hae elokuvat (oliokokoelma)" OnClick="btnGetMovies_Click" />
        <asp:DataList ID="myDataList" runat="server">
            <ItemTemplate>Elokuvan <%#Eval("Title") %> ohjannut <%#Eval("Director") %></ItemTemplate>
        </asp:DataList>
    </form>
</body>
</html>
