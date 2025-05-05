<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UserMasterPage.Master" AutoEventWireup="true" CodeBehind="UserUpdateProfile.aspx.cs" Inherits="MEApp.User.UserUpdateProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-label {
            font-weight: 600;
        }
        .card {
            max-width: 700px;
            margin: auto;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Breadcrumb -->
    <div class="d-md-flex d-block align-items-center justify-content-between page-breadcrumb mb-4">
        <div class="my-auto mb-2">
            <h2 class="mb-1">Employees</h2>
            <nav>
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item">
                        <a href="index.html"><i class="ti ti-smart-home"></i></a>
                    </li>
                    <li class="breadcrumb-item">Employees</li>
                    <li class="breadcrumb-item active" aria-current="page">Update Employee</li>
                </ol>
            </nav>
        </div>
        <div class="d-flex align-items-center flex-wrap">
            <div class="me-2 mb-2">
                <div class="dropdown">
                    <a href="#" class="dropdown-toggle btn btn-outline-primary" data-bs-toggle="dropdown">
                        <i class="ti ti-file-export me-1"></i> Export
                    </a>
                    <ul class="dropdown-menu dropdown-menu-end p-3">
                        <li><a href="#" class="dropdown-item"><i class="ti ti-file-type-pdf me-1"></i> Export as PDF</a></li>
                        <li><a href="#" class="dropdown-item"><i class="ti ti-file-type-xls me-1"></i> Export as Excel</a></li>
                    </ul>
                </div>
            </div>
            <div class="mb-2">
                <div class="input-icon w-120 position-relative">
                    <span class="input-icon-addon">
                        <i class="ti ti-calendar text-gray-9"></i>
                    </span>
                    <input type="text" class="form-control yearpicker" value="2025">
                </div>
            </div>
        </div>
    </div>
    <!-- /Breadcrumb -->

    <!-- Profile Form -->
    <div class="container">
        <div class="card border-primary shadow-sm">
            <div class="card-header bg-primary text-white">
                <h5 class="mb-0">Update Employee</h5>
            </div>
            <div class="card-body">
                <asp:Label ID="lblMessage" runat="server" CssClass="text-success mb-3 d-block"></asp:Label>

                <div class="mb-3">
                    <label for="txtEmployeeCode" class="form-label">Employee Code</label>
                    <asp:TextBox ID="txtEmployeeCode" runat="server" CssClass="form-control" ReadOnly="True" />
                </div>

                <div class="mb-3">
                    <label for="txtFullName" class="form-label">Full Name</label>
                    <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <label for="txtContactNo" class="form-label">Contact No</label>
                    <asp:TextBox ID="txtContactNo" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <label for="dropdowndepartment" class="form-label">Department</label>
                    <asp:DropDownList ID="dropdowndepartment" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>

                <div class="mb-3">
                    <label for="dropdowndesignation" class="form-label">Designation</label>
                    <asp:DropDownList ID="dropdowndesignation" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>

                <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary w-100" Text="Update" OnClick="btnUpdate_Click" />
            </div>
        </div>
    </div>
    <!-- /Profile Form -->

</asp:Content>
