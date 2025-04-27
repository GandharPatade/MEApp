<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UserMasterPage.Master" AutoEventWireup="true" CodeBehind="KnowledgeBase.aspx.cs" Inherits="MEApp.User.KnowledgeBase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


   <div style="padding:20px;">
            <h2>FAQs</h2>

            <asp:Label ID="lblFAQ1Question" runat="server" Font-Bold="True" />
            <br />
            <asp:Label ID="lblFAQ1Answer" runat="server" />
            <br /><br />

            <asp:Label ID="lblFAQ2Question" runat="server" Font-Bold="True" />
            <br />
            <asp:Label ID="lblFAQ2Answer" runat="server" />
            <br /><br />

            <h2>HR Policies</h2>

            <asp:Label ID="lblPolicy1Title" runat="server" Font-Bold="True" />
            <br />
            <asp:Label ID="lblPolicy1Content" runat="server" />
            <br /><br />

            <asp:Label ID="lblPolicy2Title" runat="server" Font-Bold="True" />
            <br />
            <asp:Label ID="lblPolicy2Content" runat="server" />
        </div>



</asp:Content>
