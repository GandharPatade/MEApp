<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UserMasterPage.Master" AutoEventWireup="true" CodeBehind="Form16access.aspx.cs" Inherits="MEApp.User.Form16access" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <!-- Breadcrumb -->
<div class="d-md-flex d-block align-items-center justify-content-between page-breadcrumb mb-3">
    <div class="my-auto mb-2">
        <h2 class="mb-1">Payroll</h2>
        <nav>
            <ol class="breadcrumb mb-0">
                <li class="breadcrumb-item">
                    <a href="index.html"><i class="ti ti-smart-home"></i></a>
                </li>
                <li class="breadcrumb-item">Payroll
                </li>
                <li class="breadcrumb-item active" aria-current="page">Form 16 Access</li>
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


    <h2>View form16's</h2>
    <asp:GridView ID="GridViewForm16" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
    <Columns>
        <asp:BoundField DataField="FinancialYear" HeaderText="Financial Year" />
        <asp:BoundField DataField="Salary" HeaderText="Salary" DataFormatString="{0:C}" />
        <asp:BoundField DataField="PF" HeaderText="PF" DataFormatString="{0:C}" />
        <asp:BoundField DataField="CreatedAt" HeaderText="Created At" DataFormatString="{0:dd-MM-yyyy}" />
        <asp:TemplateField HeaderText="Download">
            <ItemTemplate>
                <asp:LinkButton 
                    ID="btnDownload" 
                    runat="server" 
                    Text="Download" 
                    CssClass="btn btn-primary btn-sm" 
                    CommandArgument='<%# Eval("Form16Path") %>' 
                    OnClick="btnDownload_Click" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

</asp:Content>
