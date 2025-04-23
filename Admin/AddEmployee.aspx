<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="MEApp.Admin.AddEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Breadcrumb -->
<div class="d-md-flex d-block align-items-center justify-content-between page-breadcrumb mb-3">
				<div class="my-auto mb-2">
					<h2 class="mb-1">Employee</h2>
					<nav>
						<ol class="breadcrumb mb-0">
							<li class="breadcrumb-item">
								<a href="index.html"><i class="ti ti-smart-home"></i></a>
							</li>
							<li class="breadcrumb-item">
								Employee
							</li>
							<li class="breadcrumb-item active" aria-current="page">Add Employee</li>
						</ol>
					</nav>
				</div>
				<div class="d-flex my-xl-auto right-content align-items-center flex-wrap ">
					<div class="me-2 mb-2">
						<div class="dropdown">
							<a href="javascript:void(0);" class="dropdown-toggle btn btn-white d-inline-flex align-items-center" data-bs-toggle="dropdown">
								<i class="ti ti-file-export me-1"></i>Export
							</a>
							<ul class="dropdown-menu  dropdown-menu-end p-3">
								<li>
									<a href="javascript:void(0);" class="dropdown-item rounded-1"><i class="ti ti-file-type-pdf me-1"></i>Export as PDF</a>
								</li>
								<li>
									<a href="javascript:void(0);" class="dropdown-item rounded-1"><i class="ti ti-file-type-xls me-1"></i>Export as Excel </a>
								</li>
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
					<div class="ms-2 head-icons">
						<a href="javascript:void(0);" class="" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-original-title="Collapse" id="collapse-header">
							<i class="ti ti-chevrons-up"></i>
						</a>
					</div>
				</div>
</div>
<!-- /Breadcrumb -->

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
