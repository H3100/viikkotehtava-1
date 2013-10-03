<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H3100_finkino.aspx.cs" Inherits="H3100_finkino" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Button ID="btnGetTheatres" runat="server" Text="Hae teatterit" OnClick="btnGetTheatres_Click" />
    <asp:ListBox ID="myListbox" runat="server" DataTextField="ID"
        rows="18" OnSelectedIndexChanged="myListbox_SelectedIndexChanged"
        AutoPostBack="true" />

    <asp:XmlDataSource ID="myDataSource" runat="server" />
    <asp:Repeater ID="myRepeater" runat="server" DataSourceID="myDataSource">
        <ItemTemplate>
            <!-- esitetään elokuvan kuva -->
            <asp:Image ID="image1" runat="server"
                ImageUrl='<%#XPath("Images/EventSmallImagePortrait") %>' />
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>

