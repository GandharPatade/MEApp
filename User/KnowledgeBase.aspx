<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UserMasterPage.Master" AutoEventWireup="true" CodeBehind="KnowledgeBase.aspx.cs" Inherits="MEApp.User.KnowledgeBase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="padding:20px;">
    <h1>Knowledge Base</h1>
    <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
        <asp:ListItem Text="Select Category" Value="" />
        <asp:ListItem Text="FAQs" Value="FAQ" />
        <asp:ListItem Text="HR Policies" Value="HR" />
    </asp:DropDownList>

    <br /><br />
    <asp:Panel ID="pnlContent" runat="server" Visible="false">
        <asp:Literal ID="ltlContent" runat="server"></asp:Literal>
    </asp:Panel>
</div>
</asp:Content>

