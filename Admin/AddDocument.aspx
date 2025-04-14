<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AddDocument.aspx.cs" Inherits="MEApp.Admin.AddDocument" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group">
        <label for="ddlEmployeeCode">Employee Code:</label>
        <asp:DropDownList ID="ddlEmployeeCode" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlEmployeeCode_SelectedIndexChanged">
            <asp:ListItem Text="Select Employee" Value="0" />
        </asp:DropDownList>
    </div>

    <div class="form-group">
        <label for="txtDocumentType">Document Type:</label>
        <asp:TextBox ID="txtDocumentType" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="fileUpload">Upload Document:</label>
        <asp:FileUpload ID="fileUpload" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <asp:Button ID="btnAddDocument" runat="server" Text="Add Document" CssClass="btn btn-primary" OnClick="btnAddDocument_Click" />
    </div>
</asp:Content>
