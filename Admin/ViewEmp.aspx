<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewEmp.aspx.cs" Inherits="MEApp.Admin.ViewEmp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="filter-section">
        <asp:DropDownList ID="ddlStatusFilter" runat="server" AutoPostBack="false">
            <asp:ListItem Text="All" Value="All"></asp:ListItem>
            <asp:ListItem Text="Active" Value="Active"></asp:ListItem>
            <asp:ListItem Text="Inactive" Value="Inactive"></asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnFilter" runat="server" Text="Apply Filter" OnClick="btnFilter_Click" />
    </div>

    <asp:GridView ID="GridViewEmployees" runat="server" AutoGenerateColumns="False"
    DataKeyNames="EmployeeCode"
    OnRowEditing="GridViewEmployees_RowEditing"
    OnRowUpdating="GridViewEmployees_RowUpdating"
    OnRowCancelingEdit="GridViewEmployees_RowCancelingEdit"
    OnRowDeleting="GridViewEmployees_RowDeleting"
    OnRowDataBound="GridViewEmployees_RowDataBound">
    <Columns>
        <asp:BoundField DataField="EmployeeCode" HeaderText="Employee Code" ReadOnly="True" />
        <asp:TemplateField HeaderText="Full Name">
            <ItemTemplate><%# Eval("FullName") %></ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtFullName" runat="server" Text='<%# Bind("FullName") %>' />
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Email">
            <ItemTemplate><%# Eval("Email") %></ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("Email") %>' />
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Contact No">
            <ItemTemplate><%# Eval("ContactNo") %></ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtContactNo" runat="server" Text='<%# Bind("ContactNo") %>' />
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Department">
            <ItemTemplate>
                <%# Eval("DepartmentName") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:DropDownList ID="ddlDepartment" runat="server" />
                <asp:HiddenField ID="hfDepartmentID" runat="server" Value='<%# Bind("DepartmentID") %>' />
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Designation">
            <ItemTemplate>
                <%# Eval("DesignationName") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:DropDownList ID="ddlDesignation" runat="server" />
                <asp:HiddenField ID="hfDesignationID" runat="server" Value='<%# Bind("DesignationID") %>' />
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
    </Columns>
</asp:GridView>

</asp:Content>
