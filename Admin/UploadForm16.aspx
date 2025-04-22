<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="UploadForm16.aspx.cs" Inherits="MEApp.Admin.UploadForm16" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
    <div class="col-md-4">
        <label>Employee Code</label>
        <asp:DropDownList ID="ddlEmpCode" runat="server" CssClass="form-select"></asp:DropDownList>
    </div>
    <div class="col-md-4">
        <label>Financial Year</label>
        <asp:TextBox ID="txtFinancialYear" runat="server" CssClass="form-control" placeholder="e.g., 2023-2024"></asp:TextBox>
    </div>
    <div class="col-md-4">
        <label>Form 16 PDF</label>
        <asp:FileUpload ID="fuForm16" runat="server" CssClass="form-control" />
    </div>
</div>
<%--<asp:Button ID="btnUpload" runat="server" CssClass="btn btn-success mt-3" Text="Upload" OnClick="btnUpload_Click" />
<asp:Label ID="lblMessage" runat="server" CssClass="mt-2 d-block"></asp:Label>--%>
    <asp:Button 
    ID="Button1" 
    runat="server" 
    CssClass="btn btn-success mt-3" 
    Text="Upload" 
    OnClick="btnUpload_Click" 
    OnClientClick="return confirm('Are you sure you want to upload this Form 16?');" />


</asp:Content>
