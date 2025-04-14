<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AccountMasterPage.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="MEApp.Account.LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group">
        <label>Email</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
    </div>
    <div class="form-group">
        <label>Password</label>
        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
    </div>
    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
</asp:Content>
