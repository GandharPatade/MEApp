<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UserMasterPage.Master" AutoEventWireup="true" CodeBehind="LeaveApplication.aspx.cs" Inherits="MEApp.User.LeaveApplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Container for Leave Request Form -->
    <div class="container mt-5 p-4 shadow-sm rounded bg-light">
        <h2 class="text-primary mb-4">Leave Request Form</h2>

        <form>
            <!-- Employee Code -->
            <div class="mb-3">
                <label for="txtEmpCode" class="form-label">Employee Code:</label>
                <asp:TextBox ID="txtEmpCode" runat="server" CssClass="form-control" Width="200px" ReadOnly="true"></asp:TextBox>
            </div>

            <!-- Leave Type -->
            <div class="mb-3">
                <label for="DropDownList1" class="form-label">Leave Type:</label>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-select" Width="150px">
                    <asp:ListItem Value="PL">PL</asp:ListItem>
                    <asp:ListItem Value="CL">CL</asp:ListItem>
                    <asp:ListItem Value="SL">SL</asp:ListItem>
                </asp:DropDownList>
            </div>

            <!-- Start Date -->
            <div class="mb-3">
                <label for="TextBox1" class="form-label">Start Date:</label>
                <asp:TextBox ID="TextBox1" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>

            <!-- End Date -->
            <div class="mb-3">
                <label for="TextBox2" class="form-label">End Date:</label>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>

            <!-- Reason -->
            <div class="mb-3">
                <label for="TextBox3" class="form-label">Reason:</label>
                <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Rows="4" Columns="50" CssClass="form-control"></asp:TextBox>
            </div>

            <!-- Submit Button -->
            <div class="mb-3">
                <asp:Button ID="Button1" runat="server" Text="Submit Request" OnClick="Button1_Click" CssClass="btn btn-primary" />
            </div>

            <!-- Success/Message Label -->
            <div class="mb-3">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Green" CssClass="form-text"></asp:Label>
            </div>
        </form>
    </div>

    <!-- Leave Applications Grid -->
    <div class="container mt-5">
        <h4 class="text-primary mb-3">Submitted Leave Requests</h4>
        <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-striped table-hover">
        </asp:GridView>
    </div>

</asp:Content>
