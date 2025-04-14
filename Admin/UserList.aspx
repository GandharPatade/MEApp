<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="MEApp.Admin.UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False"
        CssClass="table table-bordered"
        DataKeyNames="UserID"
        OnRowEditing="gvUsers_RowEditing"
        OnRowCancelingEdit="gvUsers_RowCancelingEdit"
        OnRowUpdating="gvUsers_RowUpdating"
        OnRowDeleting="gvUsers_RowDeleting">
        <Columns>
            <asp:BoundField DataField="UserID" HeaderText="ID" ReadOnly="true" />
            <asp:BoundField DataField="FullName" HeaderText="Full Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:TemplateField HeaderText="Role">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlRole" runat="server">
                        <asp:ListItem Text="Admin" Value="Admin" />
                        <asp:ListItem Text="User" Value="User" />
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <%# Eval("Role") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
