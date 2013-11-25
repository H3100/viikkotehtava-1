<%@ Page Language="C#" AutoEventWireup="true" CodeFile="H3100_luoKysely.aspx.cs" Inherits="H3100_luoKysely" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <asp:Label ID="Label1" runat="server" Text="Kysymys: "></asp:Label>
    <asp:TextBox ID="txtKysymys" runat="server" Width="511px"></asp:TextBox>
    <br />

    <asp:Label ID="Label2" runat="server" Text="Vaihtoehdot (täytä järjestyksessä!):"></asp:Label>
    <br />
    <asp:TextBox ID="txtEka" runat="server"></asp:TextBox>
    <br />
    <asp:TextBox ID="txtToka" runat="server"></asp:TextBox>
    <br />
    <asp:TextBox ID="txtKolmas" runat="server"></asp:TextBox>
    <br />
    <asp:TextBox ID="txtNeljas" runat="server"></asp:TextBox>
    <br />
    <asp:TextBox ID="txtViides" runat="server"></asp:TextBox>
    <br />
    <asp:TextBox ID="txtKuudes" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Valitse vastausaika sekunteina: "></asp:Label>
        <asp:TextBox ID="txtVastausaika" runat="server" Width="63px"></asp:TextBox>
        <br />
    <asp:Button ID="btnKaynnista" runat="server" Text="Käynnistä kysely" OnClick="btnKaynnista_Click" />
    <br />
    <asp:Label ID="lblUrl" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Syötä tarkasteltavan kyselyn koko URL: "></asp:Label>
     <br />   <asp:TextBox ID="txtTarkasteltavanURL" runat="server" Width="583px"></asp:TextBox>
        <asp:Button ID="btnKatsoVastauksia" runat="server" Text="Katso vastauksia" OnClick="btnKatsoVastauksia_Click" />



    </div>
    </form>
</body>
</html>
