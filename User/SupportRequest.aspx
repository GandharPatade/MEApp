<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UserMasterPage.Master" AutoEventWireup="true" CodeBehind="SupportRequest.aspx.cs" Inherits="MEApp.User.SupportRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container mt-5">
    <div class="card shadow">
        <div class="card-header bg-primary text-white">
            <h2 class="mb-0">Raise a New Ticket</h2>
        </div>
        <div class="card-body">
            <div class="form-group">
                <asp:Label ID="lblTitle" runat="server" Text="Title:" CssClass="font-weight-bold"></asp:Label>
                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <asp:Label ID="lblDescription" runat="server" Text="Description:" CssClass="font-weight-bold"></asp:Label>
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="5" Columns="30" CssClass="form-control" />
            </div>

            <div class="form-group">
                <asp:Label ID="lblRaisedBy" runat="server" Text="Employee Code (Raised By):" CssClass="font-weight-bold"></asp:Label>
                <asp:TextBox ID="txtRaisedBy" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <asp:Label ID="lblAssignTo" runat="server" Text="Assign To:" CssClass="font-weight-bold"></asp:Label>
                <asp:DropDownList ID="ddlAssignTo" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <asp:Label ID="lblUpload" runat="server" Text="Upload Image:" CssClass="font-weight-bold"></asp:Label>
                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control-file" />
            </div>

            <div class="form-group text-center">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
            </div>

            <div class="form-group text-center">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" CssClass="font-weight-bold"></asp:Label>
            </div>
        </div>
    </div>
</div>
</asp:Content>
