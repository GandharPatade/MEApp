<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewPayslips.aspx.cs" Inherits="MEApp.Admin.ViewPayslips" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">
        <h4 class="mb-3">View Payslips</h4>

        <asp:GridView ID="GridViewPayslips" runat="server" AutoGenerateColumns="false"
            CssClass="table table-bordered table-striped table-hover"
            HeaderStyle-CssClass="table-dark" GridLines="None">
            <Columns>
                <asp:BoundField DataField="MonthYear" HeaderText="Month" />
                <asp:BoundField DataField="SalaryAmount" HeaderText="Salary" />
                <asp:TemplateField HeaderText="Download">
                    <ItemTemplate>
                        <a class="btn btn-primary btn-sm" href='<%# ResolveUrl(Eval("PayslipFile").ToString()) %>' target="_blank">
                            <i class="bi bi-download"></i> Download
                        </a>

                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
