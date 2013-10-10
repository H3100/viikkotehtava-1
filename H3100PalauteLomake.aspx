<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H3100PalauteLomake.aspx.cs" Inherits="H3100PalauteLomake" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Opintojakson palaute</h1>
    <h2>Anna palaute</h2>
    <p>
        <asp:Label ID="lblPVM" runat="server" Text="Pvm"></asp:Label>
        <asp:TextBox ID="txtPvm" runat="server"></asp:TextBox>
        <!-- <asp:RequiredFieldValidator runat="server" id="reqPvm" controltovalidate="txtPvm" errormessage="Please enter date" /> -->
        <asp:Label ID="lblNimi" runat="server" Text="Nimi"></asp:Label>
        <asp:TextBox ID="txtNimi" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Olen oppinut:"></asp:Label>
        <textarea id="txtAreaOlenOppinut" cols="20" name="S1" rows="2"></textarea></p>
    <p>
        <asp:Label ID="Label4" runat="server" Text="Haluan oppia"></asp:Label>
        <textarea id="txtAreaHaluanOppia" cols="20" name="S2" rows="2"></textarea></p>
    <p>
        <asp:Label ID="Label5" runat="server" Text="Muista tehdä sanity-test kaikille!"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label6" runat="server" Text="Hyvää:"></asp:Label>
        <textarea id="TextArea3" cols="20" name="S3" rows="2"></textarea></p>
    <p>
        <asp:Label ID="Label7" runat="server" Text="Parannettavaa:"></asp:Label>
        <textarea id="TextArea4" cols="20" name="S4" rows="2"></textarea></p>
    <p>
        <asp:Label ID="Label8" runat="server" Text="Muuta:"></asp:Label>
        <textarea id="TextArea5" cols="20" name="S5" rows="2"></textarea></p>
    <p>
        <asp:Label ID="Label9" runat="server" Text="Muista tehdä sanity-test (paitsi muulle)!"></asp:Label>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Lähetä palaute" OnClick="Button1_Click" />
    </p>
    <h2>Palautteet</h2>
    <p>
        <asp:Button ID="Button2" runat="server" Text="Näytä palautteet" />
    </p>
    <p>
        <asp:Table ID="Table1" runat="server">
        </asp:Table>
    </p>



</asp:Content>

