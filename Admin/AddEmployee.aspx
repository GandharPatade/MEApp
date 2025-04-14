<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="MEApp.Admin.AddEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row mb-3">
        <div class="col-md-6">
            <label>Employee Code</label>
            <asp:TextBox ID="txtEmployeeCode" runat="server" CssClass="form-control" />
        </div>
        <div class="col-md-6">
            <label>Full Name</label>
            <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" />
        </div>
    </div>

    <div class="row mb-3">
        <div class="col-md-6">
            <label>Email</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
        </div>
        <div class="col-md-6">
            <label>Contact No</label>
            <asp:TextBox ID="txtContactNo" runat="server" CssClass="form-control" />
        </div>
    </div>

    <div class="row mb-3">
        <div class="col-md-6">
            <label>Department</label>
            <asp:TextBox ID="txtDepartment" runat="server" CssClass="form-control" />
        </div>
        <div class="col-md-6">
            <label>Designation</label>
            <asp:TextBox ID="txtDesignation" runat="server" CssClass="form-control" />
        </div>
    </div>

    <asp:Button ID="btnAddEmployee" runat="server" Text="Add Employee" CssClass="btn btn-primary" OnClick="btnAddEmployee_Click" />
    <asp:Label ID="lblMessage" runat="server" CssClass="text-success mt-3 d-block"></asp:Label>
    </div>

</asp:Content>
