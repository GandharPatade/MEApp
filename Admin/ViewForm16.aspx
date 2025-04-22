<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewForm16.aspx.cs" Inherits="MEApp.Admin.ViewForm16" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>View form page</h2>
    <asp:GridView ID="GridViewForm16" runat="server" AutoGenerateColumns="false" CssClass="table table-striped">
    <Columns>
        <asp:BoundField DataField="EmployeeCode" HeaderText="Employee Code" />
        <asp:BoundField DataField="FinancialYear" HeaderText="Financial Year" />
        <asp:TemplateField HeaderText="Download Form 16">
            <ItemTemplate>
                <a href='<%# ResolveUrl(Eval("Form16Path").ToString()) %>' 
                   class="btn btn-sm btn-primary" 
                   target="_blank">
                   Download

                </a>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>


</asp:Content>
