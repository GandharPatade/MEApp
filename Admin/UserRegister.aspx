<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="UserRegister.aspx.cs" Inherits="MEApp.Admin.UserRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="form-group">
            <label>Full Name</label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label>Email</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" />
        </div>
        <div class="form-group">
            <label>Password</label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
        </div>
        <div class="form-group">
            <label>Role</label>
            <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Role" Value="" />
                <asp:ListItem Text="Admin" Value="Admin" />
                <asp:ListItem Text="User" Value="User" />
            </asp:DropDownList>
        </div>
        <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-success" Text="Add User" OnClick="btnRegister_Click"  />
</asp:Content>
