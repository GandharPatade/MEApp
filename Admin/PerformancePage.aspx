<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="PerformancePage.aspx.cs" Inherits="MEApp.Admin.PerformancePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Performance Page</h1>

    <asp:GridView ID="PerformanceGridView" runat="server" AutoGenerateColumns="False"
        OnRowCommand="PerformanceGridView_RowCommand"
        DataKeyNames="UserID">
        
        <Columns>
            <asp:BoundField DataField="UserID" HeaderText="User ID" ReadOnly="True" />
            <asp:BoundField DataField="FullName" HeaderText="Full Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" />

            <asp:TemplateField HeaderText="Points (1-10)">
                <ItemTemplate>
                    <asp:DropDownList ID="PointsDropdown" runat="server">
                        <asp:ListItem Text="1" Value="1" />
                        <asp:ListItem Text="2" Value="2" />
                        <asp:ListItem Text="3" Value="3" />
                        <asp:ListItem Text="4" Value="4" />
                        <asp:ListItem Text="5" Value="5" />
                        <asp:ListItem Text="6" Value="6" />
                        <asp:ListItem Text="7" Value="7" />
                        <asp:ListItem Text="8" Value="8" />
                        <asp:ListItem Text="9" Value="9" />
                        <asp:ListItem Text="10" Value="10" />
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Remark">
                <ItemTemplate>
                    <asp:TextBox ID="RemarkTextBox" runat="server" Text='<%# Eval("Remark") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="SubmitPerformanceButton" runat="server" Text="Submit" CommandName="SubmitPerformance" CommandArgument='<%# Eval("UserID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>
