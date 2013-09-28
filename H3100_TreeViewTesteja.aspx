<%@ Page Title="" Language="C#" MasterPageFile="~/H3100_MasterPage.master" AutoEventWireup="true" CodeFile="H3100_TreeViewTesteja.aspx.cs" Inherits="H3100_TreeViewTesteja" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<h3>TreeView Declarative Syntax Example</h3>
      
     <asp:TreeView ID="TreeView1" runat="server" >
    <Nodes>
 
            <asp:TreeNode Text="Hi" Value="Hi">
                <asp:TreeNode Text="Hello" Value="Hello">
                    <asp:TreeNode Text="H r u" Value="H r u">
                </asp:TreeNode>
            </asp:TreeNode>
        </asp:TreeNode>
    </Nodes>
</asp:TreeView>

</asp:Content>

