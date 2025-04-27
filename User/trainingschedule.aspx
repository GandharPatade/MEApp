<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UserMasterPage.Master" AutoEventWireup="true" CodeBehind="trainingschedule.aspx.cs" Inherits="MEApp.User.trainingschedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                    <!-- Breadcrumb -->
<div class="d-md-flex d-block align-items-center justify-content-between page-breadcrumb mb-3">
				<div class="my-auto mb-2">
					<h2 class="mb-1">Training And Development</h2>
					<nav>
						<ol class="breadcrumb mb-0">
							<li class="breadcrumb-item">
								<a href="index.html"><i class="ti ti-smart-home"></i></a>
							</li>
							<li class="breadcrumb-item">
								Training And Development
							</li>
							<li class="breadcrumb-item active" aria-current="page">Training List</li>
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

	<div class="card shadow p-4">
    <h3 class="text-primary mb-3">Training List</h3>

    <asp:GridView ID="TrainingGridView" runat="server" AutoGenerateColumns="False"
        OnRowEditing="TrainingGridView_RowEditing"
        OnRowUpdating="TrainingGridView_RowUpdating"
        OnRowDeleting="TrainingGridView_RowDeleting"
        OnRowCancelingEdit="TrainingGridView_RowCancelingEdit"
        OnRowDataBound="TrainingGridView_RowDataBound"
        DataKeyNames="TrainingID"
        CssClass="table table-bordered table-hover">

        <Columns>
            <asp:TemplateField HeaderText="TrainingID">
                <ItemTemplate>
                    <%# Eval("TrainingID") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Title">
                <ItemTemplate>
                    <%# Eval("Title") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="EditTitleTextBox" runat="server" Text='<%# Bind("Title") %>' CssClass="form-control" />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Description">
                <ItemTemplate>
                    <%# Eval("Description") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="EditDescriptionTextBox" runat="server" Text='<%# Bind("Description") %>' CssClass="form-control" />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <%# Eval("Status") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="EditStatusDropDown" runat="server" CssClass="form-select">
                        <asp:ListItem Text="Active" Value="Active" />
                        <asp:ListItem Text="Inactive" Value="Inactive" />
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="URL">
                <ItemTemplate>
                    <%# Eval("URL") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="EditURLTextBox" runat="server" Text='<%# Bind("URL") %>' CssClass="form-control" />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
        </Columns>

    </asp:GridView>
</div>
</asp:Content>
