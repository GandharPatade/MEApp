<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="LeaveReport.aspx.cs" Inherits="MEApp.Admin.LeaveReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" />
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h2 class="mb-4">Leave Reports</h2>

        <asp:GridView ID="gvLeaveReport" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
            <Columns>
                <asp:BoundField DataField="EmployeeCode" HeaderText="Employee Code" />
                <asp:BoundField DataField="LeaveType" HeaderText="Leave Type" />
                <asp:BoundField DataField="TotalLeaves" HeaderText="Total Leaves" />
                <asp:BoundField DataField="UsedLeaves" HeaderText="Used Leaves" />
                <asp:BoundField DataField="RemainingLeaves" HeaderText="Remaining Leaves" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
