<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H3100XMLDataAdapter.aspx.cs" Inherits="H3100XMLDataAdapter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:XmlDataSource ID="XmlDataSource" runat="server" DataFile="~/App_data/Records.xml" TransformFile="~/App_Data/Records.xsl" ></asp:XmlDataSource>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="XmlDataSource" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="nimi" HeaderText="nimi" SortExpression="nimi" />
            <asp:BoundField DataField="artisti" HeaderText="artisti" SortExpression="artisti" />
            <asp:BoundField DataField="maa" HeaderText="maa" SortExpression="maa" />
            <asp:BoundField DataField="vuosi" HeaderText="vuosi" SortExpression="vuosi" />
        </Columns>
    </asp:GridView>
</asp:Content>

