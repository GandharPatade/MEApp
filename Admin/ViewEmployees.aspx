<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewEmployees.aspx.cs" Inherits="MEApp.Admin.ViewEmployees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
.dataTables_wrapper .dataTables_length,
.dataTables_wrapper .dataTables_filter,
.dataTables_wrapper .dataTables_paginate {
    display: block !important;
}
</style>

     <!-- ✅ Load jQuery FIRST -->
<script src="https://code.jquery.com/jquery-3.7.0.min.js"></script>

<!-- ✅ Then load DataTables core and Bootstrap5 integration -->
<link href="https://cdn.datatables.net/1.13.4/css/dataTables.bootstrap5.min.css" rel="stylesheet" />
<script src="https://cdn.datatables.net/1.13.4/js/jquery.dataTables.min.js"></script>
<script src="https://cdn.datatables.net/1.13.4/js/dataTables.bootstrap5.min.js"></script>

<!-- ✅ Then load Bootstrap Bundle -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>


    <script type="text/javascript">
        function initializeDataTable() {
            var table = $('#<%= GridViewEmployees.ClientID %>');
            console.log("Initializing table: " + table.length);

            if (!table.find('thead').length) {
                console.log("No <thead> found. Injecting...");
                var headerRow = table.find('tr').first().clone();
                var thead = $('<thead></thead>').append(headerRow);
                table.find('tr').first().remove();
                table.prepend(thead);
            }

            if (!$.fn.DataTable) {
                console.log("🚨 DataTable function is undefined! Check if JS is loaded.");
                return;
            }

            if (!$.fn.DataTable.isDataTable(table)) {
                console.log("✅ DataTable function exists, initializing...");
                table.DataTable({
                    paging: true,
                    searching: true,
                    lengthChange: true,
                    info: true,
                    language: {
                        lengthMenu: "Rows per page: _MENU_",
                        emptyTable: "No records found."
                    },
                    drawCallback: function () {
                        console.log("✅ DataTable draw callback hit!");
                    }
                });
            } else {
                console.log("🟡 Table already initialized.");
            }
        }

        $(document).ready(function () {
            initializeDataTable();
        });
    </script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Breadcrumb -->
<div class="d-md-flex d-block align-items-center justify-content-between page-breadcrumb mb-3">
				<div class="my-auto mb-2">
					<h2 class="mb-1">Employee</h2>
					<nav>
						<ol class="breadcrumb mb-0">
							<li class="breadcrumb-item">
								<a href="index.html"><i class="ti ti-smart-home"></i></a>
							</li>
							<li class="breadcrumb-item">
								Employee
							</li>
							<li class="breadcrumb-item active" aria-current="page">View Employee</li>
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


    <asp:GridView ID="GridViewEmployees" runat="server" AutoGenerateColumns="False"
        CssClass="table table-striped table-bordered" DataKeyNames="EmployeeID"
        OnRowEditing="GridViewEmployees_RowEditing" 		
        OnRowUpdating="GridViewEmployees_RowUpdating"
        OnRowCancelingEdit="GridViewEmployees_RowCancelingEdit"
        OnRowDeleting="GridViewEmployees_RowDeleting"
        UseAccessibleHeader="true" HeaderStyle-CssClass="table-header" GridLines="None">

		   <HeaderStyle CssClass="table-dark" />
    <RowStyle CssClass="table-body" />

        <Columns>
            <asp:BoundField DataField="EmployeeCode" HeaderText="Employee Code" ReadOnly="True" />
            <asp:BoundField DataField="FullName" HeaderText="Full Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="ContactNo" HeaderText="Contact No" />
            <asp:BoundField DataField="Department" HeaderText="Department" />
            <asp:BoundField DataField="Designation" HeaderText="Designation" />
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>

    <asp:Label ID="lblMessage" runat="server" CssClass="text-success mt-3 d-block"></asp:Label>

</asp:Content>