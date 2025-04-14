<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="SalaryStructure.aspx.cs" Inherits="MEApp.Admin.SalaryStructure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mb-3">
        <asp:TextBox ID="txtRole" runat="server" CssClass="form-control" Placeholder="Role"></asp:TextBox>
        <asp:TextBox ID="txtBasic" runat="server" CssClass="form-control mt-2" Placeholder="Basic Salary"></asp:TextBox>
        <asp:TextBox ID="txtHRA" runat="server" CssClass="form-control mt-2" Placeholder="HRA"></asp:TextBox>
        <asp:TextBox ID="txtAllowances" runat="server" CssClass="form-control mt-2" Placeholder="Allowances"></asp:TextBox>
        <asp:TextBox ID="txtDeductions" runat="server" CssClass="form-control mt-2" Placeholder="Deductions"></asp:TextBox>
        <asp:HiddenField ID="hfStructureID" runat="server" />
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary mt-3" OnClick="btnSave_Click" />
    </div>

    <asp:GridView ID="gvStructure" runat="server" AutoGenerateColumns="false"
    DataKeyNames="StructureID" CssClass="table table-bordered" OnRowCommand="gvStructure_RowCommand">

        <columns>
            <asp:BoundField DataField="StructureID" HeaderText="ID" />
            <asp:BoundField DataField="Role" HeaderText="Role" />
            <asp:BoundField DataField="BasicSalary" HeaderText="Basic Salary" />
            <asp:BoundField DataField="HRA" HeaderText="HRA" />
            <asp:BoundField DataField="Allowances" HeaderText="Allowances" />
            <asp:BoundField DataField="Deductions" HeaderText="Deductions" />
            <asp:ButtonField CommandName="editRow" Text="Edit" ButtonType="Button" />
            <asp:ButtonField CommandName="deleteRow" Text="Delete" ButtonType="Button" />
        </columns>
    </asp:GridView>
</asp:Content>
