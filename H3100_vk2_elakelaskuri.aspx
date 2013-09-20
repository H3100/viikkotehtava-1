<%@ Page Language="C#" AutoEventWireup="true" CodeFile="H3100_vk2_elakelaskuri.aspx.cs" Inherits="H3100_vk2_elakelaskuri" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="eLaskuri.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
    <body id="body" runat="server">
    <form id="form1" runat="server">
    <div>    
        <h1>Tänään on paras päivä aloittaa eläkesäästäminen.</h1>
        <div id="margin">
        <h2>1. Tiedätkö kuinka paljon saat aikanaan eläkettä? 
            <asp:HyperLink ID="laskeTasta" runat="server" NavigateUrl="http://www.google.com">Laske tästä!
            </asp:HyperLink></h2>
                <div id="vasen">
                    <asp:Label ID="lblIka" runat="server" Text="Ikä"></asp:Label>
                        <div class="clearLeft">
                        <asp:Button ID="btnIka1" runat="server" Text="-" OnClick="btnIka1_Click" />
                        <asp:TextBox ID="TxtIka" runat="server" OnDisposed="txtIkaDisposed" OnTextChanged="txtIkaChanged"></asp:TextBox>
                        <asp:Button ID="btnIka2" runat="server" Text="+" OnClick="btnIka2_Click" />
                        </div>

                    <asp:Label ID="lblPalkka" runat="server" Text="Palkka"></asp:Label>
                        <div class="clearLeft">
                        <asp:Button ID="btnPalkka1" runat="server" Text="-" OnClick="btnPalkka1_Click" />
                        <asp:TextBox ID="TxtPalkka" runat="server"></asp:TextBox>
                        <asp:Button ID="btnPalkka2" runat="server" Text="+" OnClick="btnPalkka2_Click" />
                        </div>
                </div>
                
                <div id="oikea">
                    <div id="lakisaa">
                    <asp:Label ID="lblLakisaa" runat="server" Text="Lakisääteinen eläke"></asp:Label>
                    <asp:Label ID="lblLakisaaNbr" runat="server" Text="....."></asp:Label>
                    </div>

                    <div id="elinaikana">
                    <asp:Label ID="lblElinaikak" runat="server" Text="Elinaikakertoimen vaikutus"></asp:Label>
                    <asp:Label ID="lblElinaikakNbr" runat="server" Text="...."></asp:Label>
                    </div>

                    <asp:Label ID="lblArvio" runat="server" Text="Arvio lakisääteisestä eläkkeestä"></asp:Label>                  
                    <p><asp:TextBox ID="txtArvio" runat="server"></asp:TextBox>€</p>
                </div>

        </div>
        <h2 id="riittaako">Riittääkö se sinulle? Paranna toimeentuloasi säästämällä.</h2>
        <div class="buttonHolder">
        <asp:Button ID="btnLuel" runat="server" Text="Lue lisää" />             
            </div>
    </div>
        <div id="Virheet">
        <asp:Label ID="lblVirheet" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
