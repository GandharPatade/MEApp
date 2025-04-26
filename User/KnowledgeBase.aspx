<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UserMasterPage.Master" AutoEventWireup="true" CodeBehind="KnowledgeBase.aspx.cs" Inherits="MEApp.User.KnowledgeBase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div style="padding:20px;">
        <h1>Knowledge Base</h1>
        <p>Access a knowledge base with FAQs and HR policies.</p>

        <asp:DropDownList 
            ID="ddlCategory" 
            runat="server" 
            AutoPostBack="true" 
            OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
            <asp:ListItem Text="Select Category" Value="" />
            <asp:ListItem Text="FAQs" Value="FAQs" />
            <asp:ListItem Text="HR Policies" Value="HR Policies" />
        </asp:DropDownList>

        <br /><br />

        <asp:Panel ID="pnlContent" runat="server" Visible="false">
            <asp:Label ID="lblHeader" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label>
            <br /><br />

            <asp:Label ID="lblQ1" runat="server" Font-Bold="true"></asp:Label><br />
            <asp:Label ID="lblA1" runat="server"></asp:Label><br /><br />

            <asp:Label ID="lblQ2" runat="server" Font-Bold="true"></asp:Label><br />
            <asp:Label ID="lblA2" runat="server"></asp:Label><br /><br />

            <asp:Label ID="lblQ3" runat="server" Font-Bold="true"></asp:Label><br />
            <asp:Label ID="lblA3" runat="server"></asp:Label><br /><br />
        </asp:Panel>
    </div>



</asp:Content>
