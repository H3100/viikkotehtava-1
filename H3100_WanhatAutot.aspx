<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H3100_WanhatAutot.aspx.cs" Inherits="H3100_WanhatAutot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Table ID="myTable" runat="server">
    </asp:Table>

    <asp:ListBox ID="myListbox" runat="server" AutoPostBack="True" Height="144px" 
        OnSelectedIndexChanged="myListbox_SelectedIndexChanged"/>


    <asp:ListBox ID="myListbox2" runat="server" Height="144px" style="margin-top: 0px"></asp:ListBox>
    <asp:ListBox ID="myListbox3" runat="server" Height="143px"></asp:ListBox>
    <asp:Label ID="lblTesti" runat="server"></asp:Label>
    <asp:Label ID="Label1" runat="server" Text="Nousevaan järjestykseen:"></asp:Label>
    <asp:CheckBox ID="Nousevako" runat="server" OnCheckedChanged="Nousevako_CheckedChanged" />
    <asp:Button ID="btnListaaAutot" runat="server" OnClick="btnListaaAutot_Click" Text="Listaa autot" />
    <asp:Button ID="btnTesti" runat="server" OnClick="btnTesti_Click" Text="Testinappi" />
    <br />
    <asp:TextBox ID="txtRegexp" runat="server"></asp:TextBox>
    <asp:Button ID="btnEtsi" runat="server" OnClick="btnEtsi_Click" Text="Etsi autoista" />
</asp:Content>

