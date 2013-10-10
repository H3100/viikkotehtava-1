<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H3100Palaute2.aspx.cs" Inherits="H3100Palaute2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <h1>Opintojakson palaute</h1>
    <h2>Anna palaute</h2>
    <p>
        <asp:Label ID="lblPVM" runat="server" Text="Pvm"></asp:Label>
        <asp:TextBox ID="txtPvm" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" id="reqPvm" controltovalidate="txtPvm" errormessage="Syötä päivämäärä" />

        <asp:Label ID="lblNimi" runat="server" Text="Nimi"></asp:Label>
        <asp:TextBox ID="txtNimi" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" controltovalidate="txtNimi" errormessage="Syötä nimi" />
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Olen oppinut:"></asp:Label>
        &nbsp;<asp:TextBox ID="txtOlenoppinut" runat="server" Height="51px" Width="136px"></asp:TextBox>

    </p>
     
    <p>
        <asp:Label ID="Label4" runat="server" Text="Haluan oppia"></asp:Label>
        <asp:TextBox ID="txtHaluanOppia" runat="server" Height="44px" Width="137px"></asp:TextBox>
        </p>
    <p>
        <asp:Label ID="Label5" runat="server" Text="Muista tehdä sanity-test kaikille!"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label6" runat="server" Text="Hyvää:"></asp:Label>
        <asp:TextBox ID="txtHyvaa" runat="server" Height="48px" Width="138px"></asp:TextBox>
        </p>
    <p>
        <asp:Label ID="Label7" runat="server" Text="Parannettavaa:"></asp:Label>
        <asp:TextBox ID="txtParannettavaa" runat="server" Height="53px" Width="139px"></asp:TextBox>
        </p>
    <p>
        <asp:Label ID="Label8" runat="server" Text="Muuta:"></asp:Label>
        <asp:TextBox ID="txtMuuta" runat="server" Height="57px" Width="146px"></asp:TextBox>
        </p>
    <p>
        <asp:Label ID="Label9" runat="server" Text="Muista tehdä sanity-test (paitsi muulle)!"></asp:Label>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Lähetä palaute" OnClick="Button1_Click" />
    </p>
    <h2>Palautteet</h2>
    <p>
        <asp:Button ID="Button2" runat="server" Text="Näytä palautteet" CausesValidation="False" OnClick="Button2_Click" />
    </p>
    <p>
        <asp:Table ID="myTable" runat="server">
        </asp:Table>
        <asp:Label ID="lblTesti" runat="server" Text="Label"></asp:Label>
    </p>
</asp:Content>

