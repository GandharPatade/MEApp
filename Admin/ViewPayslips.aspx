<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewPayslips.aspx.cs" Inherits="MEApp.Admin.ViewPayslips" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Breadcrumb -->
    <div class="d-md-flex d-block align-items-center justify-content-between page-breadcrumb mb-3">
        <div class="my-auto mb-2">
            <h2 class="mb-1">Payslip</h2>
            <nav>
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item">
                        <a href="index.html"><i class="ti ti-smart-home"></i></a>
                    </li>
                    <li class="breadcrumb-item">Payslip
                    </li>
                    <li class="breadcrumb-item active" aria-current="page">View Payslip</li>
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



        <h2>View Payslips</h2>
    <asp:GridView ID="GridViewPayslips" runat="server" AutoGenerateColumns="false" CssClass="table table-striped">
    <Columns>
        <asp:BoundField DataField="EmployeeCode" HeaderText="Employee Code" />
        <asp:BoundField DataField="MonthYear" HeaderText="Month Year" />
        <asp:BoundField DataField="SalaryAmount" HeaderText="SalaryAmount" DataFormatString="{0:C}" />
        <asp:BoundField DataField="PayslipFile" HeaderText="PF" DataFormatString="{0:C}" />
        <asp:TemplateField HeaderText="Download Payslip">
            <ItemTemplate>
                <asp:LinkButton ID="btnDownload" 
                                runat="server" 
                                CommandArgument='<%# Eval("EmployeeCode") %>' 
                                OnClick="btnDownload_Click"
                                CssClass="btn btn-sm btn-primary">
                    Download
                </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

</asp:Content>
