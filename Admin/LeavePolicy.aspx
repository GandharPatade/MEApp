<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="LeavePolicy.aspx.cs" Inherits="MEApp.Admin.LeavePolicy1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



        <!-- Breadcrumb -->
<div class="d-md-flex d-block align-items-center justify-content-between page-breadcrumb mb-3">
				<div class="my-auto mb-2">
					<h2 class="mb-1">Leaves</h2>
					<nav>
						<ol class="breadcrumb mb-0">
							<li class="breadcrumb-item">
								<a href="index.html"><i class="ti ti-smart-home"></i></a>
							</li>
							<li class="breadcrumb-item">
								Leaves
							</li>
							<li class="breadcrumb-item active" aria-current="page">Add Leave Policy</li>
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
        <h2 class="mb-4">Leave Policy Setup</h2>

        <div class="row mb-3">
            <div class="col-md-6">
                <asp:TextBox ID="txtPolicyName" runat="server" CssClass="form-control" placeholder="Policy Name"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtLeaveType" runat="server" CssClass="form-control" placeholder="Leave Type"></asp:TextBox>
            </div>
        </div>

        <div class="row mb-3">
            <div class="col-md-6">
                <asp:TextBox ID="txtMaxLeaves" runat="server" CssClass="form-control" placeholder="Max Leaves" TextMode="Number"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" placeholder="Description" TextMode="MultiLine" Rows="2"></asp:TextBox>
            </div>
        </div>

        <div class="mb-3">
            <asp:Button ID="btnSave" runat="server" Text="Save Policy" CssClass="btn btn-primary" OnClick="btnSave_Click" />
            <asp:HiddenField ID="hfPolicyID" runat="server" />
        </div>

        <div class="mb-3">
            <asp:Label ID="lblMessage" runat="server" CssClass="text-success fw-bold"></asp:Label>
        </div>

        <asp:GridView ID="gvPolicies" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
            OnRowCommand="gvPolicies_RowCommand">
            <Columns>
                <asp:BoundField DataField="PolicyID" HeaderText="Policy ID" />
                <asp:BoundField DataField="PolicyName" HeaderText="Policy Name" />
                <asp:BoundField DataField="LeaveType" HeaderText="Leave Type" />
                <asp:BoundField DataField="TotalLeaves" HeaderText="Max Leaves" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="EditPolicy"
                            CommandArgument='<%#Eval("PolicyID") %>' CssClass="btn btn-warning btn-sm me-2" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="DeletePolicy"
                            CommandArgument='<%#Eval("PolicyID") %>' CssClass="btn btn-danger btn-sm" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
