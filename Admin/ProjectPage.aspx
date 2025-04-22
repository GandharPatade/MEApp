<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ProjectPage.aspx.cs" Inherits="MEApp.Admin.ProjectPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Projects Page</h2>
    <hr />

    <h3>Create Project</h3>

    <label for="ProjectName">Project Name:</label><br />
    <asp:TextBox ID="ProjectName" runat="server" /><br />

    <label for="DeadlineCalendar">Deadline:</label><br />
    <asp:Calendar ID="DeadlineCalendar" runat="server" /><br />

    <label for="Description">Description:</label><br />
    <asp:TextBox ID="Description" runat="server" TextMode="MultiLine" Rows="4" Columns="40" /><br />

    <label for="Technology">Technology:</label><br />
    <asp:TextBox ID="Technology" runat="server" /><br />

    <label for="Status">Status:</label><br />
    <asp:DropDownList ID="Status" runat="server">
        <asp:ListItem Text="Active" Value="Active" />
        <asp:ListItem Text="Completed" Value="Completed" />
        <asp:ListItem Text="On Hold" Value="On Hold" />
    </asp:DropDownList><br />

    <asp:Button ID="CreateProjectButton" runat="server" Text="Create Project" OnClick="CreateProjectButton_Click" />

    <asp:GridView ID="ProjectsGridView" runat="server" AutoGenerateColumns="False"
        OnRowEditing="ProjectsGridView_RowEditing"
        OnRowUpdating="ProjectsGridView_RowUpdating"
        OnRowCancelingEdit="ProjectsGridView_RowCancelingEdit"
        OnRowDataBound="ProjectsGridView_RowDataBound"
        OnRowDeleting="ProjectsGridView_RowDeleting"
        DataKeyNames="ProjectID"
        CssClass="table table-bordered">
    
        <Columns>
            <asp:BoundField DataField="ProjectID" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="ProjectName" HeaderText="Project Name" />
        
            <asp:TemplateField HeaderText="Deadline">
                <EditItemTemplate>
                    <asp:Calendar ID="EditDeadlineCalendar" runat="server" SelectedDate='<%# Bind("Deadline") %>'></asp:Calendar>
                </EditItemTemplate>
                <ItemTemplate>
                    <%# Eval("Deadline", "{0:yyyy-MM-dd}") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:BoundField DataField="Technology" HeaderText="Technology" />
            <asp:TemplateField HeaderText="Status">
                <EditItemTemplate>
                    <asp:DropDownList ID="EditStatusDropDown" runat="server">
                        <asp:ListItem Text="Active" Value="Active" />
                        <asp:ListItem Text="Completed" Value="Completed" />
                        <asp:ListItem Text="On Hold" Value="On Hold" />
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
