<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AddDepartment.aspx.cs" Inherits="MEApp.Admin.AddDepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Add Department</h2>
    <div>
        <asp:Label ID="lblDepartmentName" runat="server" Text="Department Name:"></asp:Label>
        <asp:TextBox ID="txtDepartmentName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvDepartmentName" runat="server" ControlToValidate="txtDepartmentName" ErrorMessage="Department Name is required." ForeColor="Red"></asp:RequiredFieldValidator>

        <div>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="Active">Active</asp:ListItem>
                <asp:ListItem Value="Inactive">Inactive</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    <div>
        <asp:Button ID="btnAddDepartment" runat="server" Text="Add Department" OnClick="btnAddDepartment_Click" />
    </div>

</asp:Content>
