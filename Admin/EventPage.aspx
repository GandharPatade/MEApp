<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="EventPage.aspx.cs" Inherits="MEApp.Admin.EventPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <!-- Breadcrumb -->
<div class="d-md-flex d-block align-items-center justify-content-between page-breadcrumb mb-3">
				<div class="my-auto mb-2">
					<h2 class="mb-1">Events</h2>
					<nav>
						<ol class="breadcrumb mb-0">
							<li class="breadcrumb-item">
								<a href="index.html"><i class="ti ti-smart-home"></i></a>
							</li>
							<li class="breadcrumb-item">
								Events
							</li>
							<li class="breadcrumb-item active" aria-current="page">Event Management</li>
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
            <h3 class="text-primary mb-3">Create Event</h3>

            <div class="mb-3">
                <label for="EventName" class="form-label">Event Name:</label>
                <asp:TextBox ID="EventName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="EventDateCalendar" class="form-label">Event Date:</label><br/>
                <asp:Calendar ID="EventDateCalendar" runat="server" CssClass="border rounded" OnSelectionChanged="EventDateCalendar_SelectionChanged"></asp:Calendar>
            </div>

            <div class="mb-3">
                <asp:Label ID="SelectedDateLabel" runat="server" CssClass="form-text text-muted"></asp:Label>
            </div>

            <div class="mb-3">
                <label for="EventDescription" class="form-label">Event Description:</label>
                <asp:TextBox ID="EventDescription" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
            </div>

            <asp:Button ID="CreateEventButton" runat="server" Text="Create Event" CssClass="btn btn-primary" OnClick="CreateEventButton_Click" />
        </div>

        <div class="card shadow p-4">
            <h3 class="text-primary mb-3">All Events</h3>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                DataKeyNames="EventID"
                OnRowEditing="GridView1_RowEditing"
                OnRowUpdating="GridView1_RowUpdating"
                OnRowCancelingEdit="GridView1_RowCancelingEdit"
                OnRowDeleting="GridView1_RowDeleting"
                CssClass="table table-bordered table-hover">

                <Columns>
                    <asp:BoundField DataField="EventName" HeaderText="Event Name" SortExpression="EventName" ReadOnly="False" />

                    <asp:TemplateField HeaderText="Event Date" SortExpression="EventDate">
                        <EditItemTemplate>
                            <asp:Calendar ID="EditEventDateCalendar" runat="server" 
                                SelectedDate='<%# Bind("EventDate") %>' 
                                CssClass="border rounded"
                                OnSelectionChanged="EditEventDateCalendar_SelectionChanged"></asp:Calendar>
                            <asp:Label ID="SelectedDateLabel" runat="server" Text=""></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="EventDateLabel" runat="server" Text='<%# Bind("EventDate", "{0:MM/dd/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="EventDescription" HeaderText="Description" SortExpression="EventDescription" ReadOnly="False" />

                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>

            </asp:GridView>
        </div>

    </div>

</asp:Content>
