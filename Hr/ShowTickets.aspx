<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/HrMasterPage.Master" AutoEventWireup="true" CodeBehind="ShowTickets.aspx.cs" Inherits="MEApp.Hr.ShowTickets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
