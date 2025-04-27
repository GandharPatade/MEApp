<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/HrMasterPage.Master" AutoEventWireup="true" CodeBehind="AddEvents.aspx.cs" Inherits="MEApp.Hr.AddEvents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container mt-5">
    <div class="card shadow">
        <div class="card-header bg-primary text-white text-center">
            <h2 class="mb-0">Add New Event</h2>
        </div>
        <div class="card-body">
            <div class="form-group">
                <asp:Label ID="lblTitle" runat="server" Text="Event Title:" CssClass="font-weight-bold"></asp:Label>
                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <asp:Label ID="lblDate" runat="server" Text="Event Date:" CssClass="font-weight-bold"></asp:Label>
                <asp:TextBox ID="txtDate" runat="server" TextMode="Date" CssClass="form-control" />
            </div>

            <div class="form-group">
                <asp:Label ID="lblStatus" runat="server" Text="Status:" CssClass="font-weight-bold"></asp:Label>
                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Active" Value="Active" />
                    <asp:ListItem Text="Inactive" Value="Inactive" />
                </asp:DropDownList>
            </div>

            <div class="form-group text-center">
                <asp:Button ID="btnAdd" runat="server" Text="Add Event" OnClick="btnAdd_Click" CssClass="btn btn-primary" />
            </div>

            <div class="form-group text-center">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Green" CssClass="font-weight-bold"></asp:Label>
            </div>
        </div>
    </div>
</div>
</asp:Content>
