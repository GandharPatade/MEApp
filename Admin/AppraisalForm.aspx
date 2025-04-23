<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AppraisalForm.aspx.cs" Inherits="MEApp.Admin.AppraisalForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <!-- Breadcrumb -->
<div class="d-md-flex d-block align-items-center justify-content-between page-breadcrumb mb-3">
				<div class="my-auto mb-2">
					<h2 class="mb-1">Performance Management</h2>
					<nav>
						<ol class="breadcrumb mb-0">
							<li class="breadcrumb-item">
								<a href="index.html"><i class="ti ti-smart-home"></i></a>
							</li>
							<li class="breadcrumb-item">
								Performance Management
							</li>
							<li class="breadcrumb-item active" aria-current="page">Appraisal Form</li>
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
        <h2 class="mb-4">Appraisal Form</h2>

        <div class="card p-4 shadow-sm mb-4">
            <div class="row mb-3">
                <div class="col-md-6">
                    <asp:DropDownList ID="ddlEmployeeCode" runat="server" CssClass="form-control">
                        <asp:ListItem Text="-- Select Employee Code --" Value="" />
                    </asp:DropDownList>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtReviewPeriod" runat="server" CssClass="form-control" placeholder="Review Period (e.g., Q1 2025)"></asp:TextBox>
                </div>
            </div>

            <div class="row mb-3">
                <div class="col-md-4">
                    <asp:TextBox ID="txtPunctuality" runat="server" CssClass="form-control" placeholder="Punctuality (1-10)" TextMode="Number"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtCommunication" runat="server" CssClass="form-control" placeholder="Communication (1-10)" TextMode="Number"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtTeamwork" runat="server" CssClass="form-control" placeholder="Teamwork (1-10)" TextMode="Number"></asp:TextBox>
                </div>
            </div>

            <div class="mb-3">
                <asp:TextBox ID="txtComments" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" placeholder="Reviewer Comments"></asp:TextBox>
            </div>

            <div class="row mb-3">
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Pending" Value="Pending" />
                        <asp:ListItem Text="Approved" Value="Approved" />
                    </asp:DropDownList>
                </div>
            </div>

            <div>
                <asp:Button ID="btnSave" runat="server" Text="Save Appraisal" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                <asp:Label ID="lblMessage" runat="server" CssClass="text-success fw-bold ms-3"></asp:Label>
            </div>
        </div>

        <h4 class="mb-3">Appraisal Records</h4>
        <asp:GridView ID="gvAppraisals" runat="server" AutoGenerateColumns="true" CssClass="table table-bordered table-striped" />
    </div>
</asp:Content>
