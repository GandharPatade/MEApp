<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="SalaryStructure.aspx.cs" Inherits="MEApp.Admin.SalaryStructure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Breadcrumb -->
<div class="d-md-flex d-block align-items-center justify-content-between page-breadcrumb mb-3">
				<div class="my-auto mb-2">
					<h2 class="mb-1">Salary</h2>
					<nav>
						<ol class="breadcrumb mb-0">
							<li class="breadcrumb-item">
								<a href="index.html"><i class="ti ti-smart-home"></i></a>
							</li>
							<li class="breadcrumb-item">
								Salary
							</li>
							<li class="breadcrumb-item active" aria-current="page">Salary Structure</li>
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


    <div class="mb-3">
        <asp:TextBox ID="txtRole" runat="server" CssClass="form-control" Placeholder="Role"></asp:TextBox>
        <asp:TextBox ID="txtBasic" runat="server" CssClass="form-control mt-2" Placeholder="Basic Salary"></asp:TextBox>
        <asp:TextBox ID="txtHRA" runat="server" CssClass="form-control mt-2" Placeholder="HRA"></asp:TextBox>
        <asp:TextBox ID="txtAllowances" runat="server" CssClass="form-control mt-2" Placeholder="Allowances"></asp:TextBox>
        <asp:TextBox ID="txtDeductions" runat="server" CssClass="form-control mt-2" Placeholder="Deductions"></asp:TextBox>
        <asp:HiddenField ID="hfStructureID" runat="server" />
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary mt-3" OnClick="btnSave_Click" />
    </div>

    <asp:GridView ID="gvStructure" runat="server" AutoGenerateColumns="false"
    DataKeyNames="StructureID" CssClass="table table-bordered" OnRowCommand="gvStructure_RowCommand">

        <columns>
            <asp:BoundField DataField="StructureID" HeaderText="ID" />
            <asp:BoundField DataField="Role" HeaderText="Role" />
            <asp:BoundField DataField="BasicSalary" HeaderText="Basic Salary" />
            <asp:BoundField DataField="HRA" HeaderText="HRA" />
            <asp:BoundField DataField="Allowances" HeaderText="Allowances" />
            <asp:BoundField DataField="Deductions" HeaderText="Deductions" />
            <asp:ButtonField CommandName="editRow" Text="Edit" ButtonType="Button" />
            <asp:ButtonField CommandName="deleteRow" Text="Delete" ButtonType="Button" />
        </columns>
    </asp:GridView>
</asp:Content>
