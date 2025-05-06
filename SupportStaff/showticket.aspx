<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/supportstaff.Master" AutoEventWireup="true" CodeBehind="showticket.aspx.cs" Inherits="MEApp.SupportStaff.showticket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Welcome Wrap -->
<div class="card border-0">
				<div class="card-body d-flex align-items-center justify-content-between flex-wrap pb-1">
					<div class="d-flex align-items-center mb-3">
						<span class="avatar avatar-xl flex-shrink-0">
							<img src="assets/img/profiles/avatar-31.jpg" class="rounded-circle" alt="img">
						</span>
						<div class="ms-3">
							<h3 class="mb-2">Welcome Back,<asp:Label ID="Label1" runat="server" Text=""></asp:Label>  <a href="javascript:void(0);" class="edit-icon"><i class="ti ti-edit fs-14"></i></a></h3>
							<p>You have <span class="text-primary text-decoration-underline">21</span> Pending Approvals & <span class="text-primary text-decoration-underline">14</span> Leave Requests</p>
						</div>
					</div>
					<div class="d-flex align-items-center flex-wrap mb-1">
						<a href="#" class="btn btn-secondary btn-md me-2 mb-2" data-bs-toggle="modal" data-bs-target="#add_project"><i class="ti ti-square-rounded-plus me-1"></i>Add Project</a>
						<a href="#" class="btn btn-primary btn-md mb-2" data-bs-toggle="modal" data-bs-target="#add_leaves"><i class="ti ti-square-rounded-plus me-1"></i>Add Requests</a>
					</div>
				</div>
</div>
<!-- /Welcome Wrap -->



        <div class="container mt-5">
    <div class="card shadow">
        <div class="card-header bg-primary text-white text-center">
            <h2 class="mb-0">All Employee Tickets</h2>
        </div>
        <div class="card-body">

            <asp:GridView ID="gvAllTickets" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-striped text-center" OnRowCommand="gvAllTickets_RowCommand">
                <Columns>
                    <asp:BoundField DataField="TicketID" HeaderText="Ticket ID" />
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="RaisedBy" HeaderText="Raised By" />
                    <asp:BoundField DataField="AssignedTo" HeaderText="Assigned To" />
                    <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" DataFormatString="{0:dd-MM-yyyy HH:mm}" />
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image ID="imgTicket" runat="server" ImageUrl='<%# Eval("ImagePath") %>' Width="100px" Height="100px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
    <ItemTemplate>
        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-sm"
            CommandName="DeleteTicket" CommandArgument='<%# Eval("TicketID") %>' 
            OnClientClick="return confirm('Are you sure you want to delete this ticket?');" />
    </ItemTemplate>
</asp:TemplateField>

                </Columns>
            </asp:GridView>

        </div>
    </div>
</div>
</asp:Content>
