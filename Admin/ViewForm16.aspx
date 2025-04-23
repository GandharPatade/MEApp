<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewForm16.aspx.cs" Inherits="MEApp.Admin.ViewForm16" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <!-- Breadcrumb -->
<div class="d-md-flex d-block align-items-center justify-content-between page-breadcrumb mb-3">
				<div class="my-auto mb-2">
					<h2 class="mb-1">Documents</h2>
					<nav>
						<ol class="breadcrumb mb-0">
							<li class="breadcrumb-item">
								<a href="index.html"><i class="ti ti-smart-home"></i></a>
							</li>
							<li class="breadcrumb-item">
								Documents
							</li>
							<li class="breadcrumb-item active" aria-current="page">View Form 16</li>
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


    <h2>View form page</h2>
    <asp:GridView ID="GridViewForm16" runat="server" AutoGenerateColumns="false" CssClass="table table-striped">
    <Columns>
        <asp:BoundField DataField="EmployeeCode" HeaderText="Employee Code" />
        <asp:BoundField DataField="FinancialYear" HeaderText="Financial Year" />
        <asp:TemplateField HeaderText="Download Form 16">
            <ItemTemplate>
                <a href='<%# ResolveUrl(Eval("Form16Path").ToString()) %>' 
                   class="btn btn-sm btn-primary" 
                   target="_blank">
                   Download
                </a>
				<br />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>


</asp:Content>
