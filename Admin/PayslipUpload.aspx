<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="PayslipUpload.aspx.cs" Inherits="MEApp.Admin.PayslipUpload_aspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h4 class="mb-4">Upload Payslip</h4>
        <div class="row">
            <div class="col-md-4 mb-3">
                <label for="ddlEmpCode" class="form-label">Employee Code</label>
                <asp:DropDownList ID="ddlEmpCode" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>

            <div class="col-md-4 mb-3">
                <label for="txtMonthYear" class="form-label">Month-Year</label>
                <asp:TextBox ID="txtMonthYear" runat="server" CssClass="form-control" placeholder="MM-YYYY"></asp:TextBox>
            </div>

            <div class="col-md-4 mb-3">
                <label for="txtAmount" class="form-label">Salary Amount</label>
                <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" placeholder="Salary Amount"></asp:TextBox>
            </div>

            <div class="col-md-6 mb-3">
                <label for="fuPayslip" class="form-label">Payslip File</label>
                <asp:FileUpload ID="fuPayslip" runat="server" CssClass="form-control" />
            </div>

            <div class="col-md-12 mt-3">
                <asp:Button ID="btnUpload" runat="server" Text="Upload Payslip" CssClass="btn btn-success" OnClick="btnUpload_Click" />
            </div>
        </div>
    </div>
</asp:Content>

