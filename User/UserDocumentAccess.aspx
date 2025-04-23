<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UserMasterPage.Master" AutoEventWireup="true" CodeBehind="UserDocumentAccess.aspx.cs" Inherits="MEApp.User.UserDocumentAccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


                <!-- Breadcrumb -->
<div class="d-md-flex d-block align-items-center justify-content-between page-breadcrumb mb-3">
				<div class="my-auto mb-2">
					<h2 class="mb-1">Employees</h2>
					<nav>
						<ol class="breadcrumb mb-0">
							<li class="breadcrumb-item">
								<a href="index.html"><i class="ti ti-smart-home"></i></a>
							</li>
							<li class="breadcrumb-item">
								Employees
							</li>
							<li class="breadcrumb-item active" aria-current="page"> Document Access</li>
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



	<div class="container mt-5">
            <h3 class="text-primary mb-3">📄 Form 16 Documents</h3>
            <asp:GridView ID="gvForm16" runat="server" CssClass="table table-bordered"
                AutoGenerateColumns="False" OnRowCommand="gvForm16_RowCommand">
                <Columns>
                    <asp:BoundField DataField="EmployeeCode" HeaderText="Employee Code" />
                    <asp:BoundField DataField="FinancialYear" HeaderText="Financial Year" />
                    <asp:BoundField DataField="UploadedOn" HeaderText="Uploaded On" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="Form16Path" HeaderText="File Path" />

                    <asp:TemplateField HeaderText="Download">
                        <ItemTemplate>
                            <asp:Button ID="btnDownloadForm16" runat="server" Text="Download" CommandName="DownloadForm16"
                                CommandArgument='<%# Eval("Form16Path") %>' CssClass="btn btn-primary btn-sm" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <hr class="my-5"/>

            <h3 class="text-primary mb-3">🧾 Payslips</h3>
            <asp:GridView ID="gvPayslips" runat="server" CssClass="table table-bordered"
                AutoGenerateColumns="False" OnRowCommand="gvPayslips_RowCommand">
                <Columns>
                    <asp:BoundField DataField="EmployeeCode" HeaderText="Employee Code" />
                    <asp:BoundField DataField="MonthYear" HeaderText="Month-Year" />
                    <asp:BoundField DataField="SalaryAmount" HeaderText="Salary Amount" />
                    <asp:BoundField DataField="PayslipFile" HeaderText="File Path" />

                    <asp:TemplateField HeaderText="Download">
                        <ItemTemplate>
                            <asp:Button ID="btnDownloadPayslip" runat="server" Text="Download" CommandName="DownloadPayslip"
                                CommandArgument='<%# Eval("PayslipFile") %>' CssClass="btn btn-primary btn-sm" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>


</asp:Content>
