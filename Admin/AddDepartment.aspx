<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AddDepartment.aspx.cs" Inherits="MEApp.Admin.AddDepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card {
            max-width: 600px;
            margin: auto;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="card border-primary shadow">
            <div class="card-header bg-primary text-white">
                <h4 class="mb-0">Add Department</h4>
            </div>
            <div class="card-body">
                <div class="mb-3">
                    <label for="txtDepartmentName" class="form-label">Department Name</label>
                    <asp:TextBox ID="txtDepartmentName" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="rfvDepartmentName" runat="server" ControlToValidate="txtDepartmentName"
                        ErrorMessage="Department Name is required." CssClass="text-danger" Display="Dynamic" />
                </div>

                <div class="mb-3">
                    <label for="DropDownList1" class="form-label">Status</label>
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-select">
                        <asp:ListItem Value="Active">Active</asp:ListItem>
                        <asp:ListItem Value="Inactive">Inactive</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="text-end">
                    <asp:Button ID="btnAddDepartment" runat="server" Text="Add Department" CssClass="btn btn-primary" OnClick="btnAddDepartment_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
