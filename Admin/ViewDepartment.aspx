<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewDepartment.aspx.cs" Inherits="MEApp.Admin.ViewDepartment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>View Department</h2>
   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
    DataKeyNames="DepartmentName"
    OnRowEditing="GridView1_RowEditing"
    OnRowUpdating="GridView1_RowUpdating"
    OnRowCancelingEdit="GridView1_RowCancelingEdit"
    OnRowDeleting="GridView1_RowDeleting"
    OnRowDataBound="GridView1_RowDataBound">


    <Columns>
        <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" ReadOnly="True" />

        <asp:TemplateField HeaderText="Status">
            <EditItemTemplate>
                <asp:DropDownList ID="ddlStatus" runat="server">
                    <asp:ListItem Text="Active" Value="Active" />
                    <asp:ListItem Text="Inactive" Value="Inactive" />
                </asp:DropDownList>
            </EditItemTemplate>
            <ItemTemplate>
                <%# Eval("Status") %>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
    </Columns>
</asp:GridView>
</asp:Content>
