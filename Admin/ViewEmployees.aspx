<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewEmployees.aspx.cs" Inherits="MEApp.Admin.ViewEmployees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridViewEmployees" runat="server" AutoGenerateColumns="False"
        CssClass="table table-bordered display" DataKeyNames="EmployeeID"
        OnRowEditing="GridViewEmployees_RowEditing"
        OnRowUpdating="GridViewEmployees_RowUpdating"
        OnRowCancelingEdit="GridViewEmployees_RowCancelingEdit"
        OnRowDeleting="GridViewEmployees_RowDeleting"
        UseAccessibleHeader="true" HeaderStyle-CssClass="table-header">
        <Columns>
            <asp:BoundField DataField="EmployeeCode" HeaderText="Employee Code" ReadOnly="True" />
            <asp:BoundField DataField="FullName" HeaderText="Full Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="ContactNo" HeaderText="Contact No" />
            <asp:BoundField DataField="Department" HeaderText="Department" />
            <asp:BoundField DataField="Designation" HeaderText="Designation" />
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>

    <asp:Label ID="lblMessage" runat="server" CssClass="text-success mt-3 d-block"></asp:Label>

</asp:Content>
