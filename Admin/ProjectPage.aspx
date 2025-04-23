<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ProjectPage.aspx.cs" Inherits="MEApp.Admin.ProjectPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <!-- Breadcrumb -->
<div class="d-md-flex d-block align-items-center justify-content-between page-breadcrumb mb-3">
				<div class="my-auto mb-2">
					<h2 class="mb-1">Projects</h2>
					<nav>
						<ol class="breadcrumb mb-0">
							<li class="breadcrumb-item">
								<a href="index.html"><i class="ti ti-smart-home"></i></a>
							</li>
							<li class="breadcrumb-item">
								Projects
							</li>
							<li class="breadcrumb-item active" aria-current="page">Project Management</li>
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

    <div class="container mt-4">

        

        <div class="card shadow p-4 mb-4">
            <h3 class="text-primary mb-3">Create Project</h3>

            <div class="mb-3">
                <label for="ProjectName" class="form-label">Project Name:</label>
                <asp:TextBox ID="ProjectName" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="DeadlineCalendar" class="form-label">Deadline:</label><br />
                <asp:Calendar ID="DeadlineCalendar" runat="server" CssClass="border rounded" />
            </div>

            <div class="mb-3">
                <label for="Description" class="form-label">Description:</label>
                <asp:TextBox ID="Description" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="Technology" class="form-label">Technology:</label>
                <asp:TextBox ID="Technology" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="Status" class="form-label">Status:</label>
                <asp:DropDownList ID="Status" runat="server" CssClass="form-select">
                    <asp:ListItem Text="Active" Value="Active" />
                    <asp:ListItem Text="Completed" Value="Completed" />
                    <asp:ListItem Text="On Hold" Value="On Hold" />
                </asp:DropDownList>
            </div>

            <asp:Button ID="CreateProjectButton" runat="server" Text="Create Project" CssClass="btn btn-primary" OnClick="CreateProjectButton_Click" />
        </div>

        <div class="card shadow p-4">
            <h3 class="text-primary mb-3">All Projects</h3>

            <asp:GridView ID="ProjectsGridView" runat="server" AutoGenerateColumns="False"
                OnRowEditing="ProjectsGridView_RowEditing"
                OnRowUpdating="ProjectsGridView_RowUpdating"
                OnRowCancelingEdit="ProjectsGridView_RowCancelingEdit"
                OnRowDataBound="ProjectsGridView_RowDataBound"
                OnRowDeleting="ProjectsGridView_RowDeleting"
                DataKeyNames="ProjectID"
                CssClass="table table-bordered table-hover">

                <Columns>
                    <asp:BoundField DataField="ProjectID" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="ProjectName" HeaderText="Project Name" />

                    <asp:TemplateField HeaderText="Deadline">
                        <EditItemTemplate>
                            <asp:Calendar ID="EditDeadlineCalendar" runat="server" SelectedDate='<%# Bind("Deadline") %>' CssClass="border rounded" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <%# Eval("Deadline", "{0:yyyy-MM-dd}") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Technology" HeaderText="Technology" />

                    <asp:TemplateField HeaderText="Status">
                        <EditItemTemplate>
                            <asp:DropDownList ID="EditStatusDropDown" runat="server" CssClass="form-select">
                                <asp:ListItem Text="Active" Value="Active" />
                                <asp:ListItem Text="Completed" Value="Completed" />
                                <asp:ListItem Text="On Hold" Value="On Hold" />
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <%# Eval("Status") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>

            </asp:GridView>
        </div>

    </div>

</asp:Content>
