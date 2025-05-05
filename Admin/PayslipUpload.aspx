<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="PayslipUpload.aspx.cs" Inherits="MEApp.Admin.PayslipUpload_aspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Breadcrumb -->
    <div class="d-md-flex d-block align-items-center justify-content-between page-breadcrumb mb-3">
        <div class="my-auto mb-2">
            <h2 class="mb-1">Pasyslip</h2>
            <nav>
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item">
                        <a href="index.html"><i class="ti ti-smart-home"></i></a>
                    </li>
                    <li class="breadcrumb-item">Payslip
                    </li>
                    <li class="breadcrumb-item active" aria-current="page">Payslip Upload</li>
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


    <div class="row">
        <div class="col-md-4">
            <label>Employee Code</label>
            <asp:DropDownList ID="ddlEmpCode" runat="server" CssClass="form-select"></asp:DropDownList>
        </div>
        <div class="col-md-4">
            <label>Financial Year</label>
            <asp:TextBox ID="txtFinancialYear" runat="server" CssClass="form-control" placeholder="e.g., 2023-2024"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label>Salary</label>
            <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control" placeholder="Enter Salary"></asp:TextBox>
        </div>
    </div>

    <asp:Button
        ID="btnUpload"
        runat="server"
        CssClass="btn btn-primary mt-3"
        Text="Generate Payslip"
        OnClick="btnUpload_Click"
        OnClientClick="return confirm('Are you sure you want to generate Payslip?');" />

    <asp:GridView ID="GridViewPayslips" runat="server" CssClass="table table-bordered table-striped mt-4">
    </asp:GridView>
</asp:Content>

