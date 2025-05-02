<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AddDesignation.aspx.cs" Inherits="MEApp.Admin.AddDesignation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Add Designation</h2>
    <div>
    <asp:Label ID="lblDesignation" runat="server" Text="Designation"></asp:Label>
    <asp:TextBox ID="txtDesignation" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvDesignation" runat="server" ControlToValidate="txtDesignation" ErrorMessage="Designation is required." ForeColor="Red"></asp:RequiredFieldValidator>

    <div>
        <asp:DropDownList ID="DropDownList2" runat="server">
            <asp:ListItem Value="Active">Active</asp:ListItem>
            <asp:ListItem Value="Inactive">Inactive</asp:ListItem>
        </asp:DropDownList>
    </div>
</div>

    <div>
        <asp:Button ID="btnAddDesignation" runat="server" Text="Add Designation" OnClick="btnAddDesignation_Click" />
    </div>
</asp:Content>
