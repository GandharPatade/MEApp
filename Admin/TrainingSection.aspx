<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="TrainingSection.aspx.cs" Inherits="MEApp.Admin.TrainingSection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Add New Training</h2>

    <div>
        <!-- Title -->
        <label for="Title">Title:</label>
        <asp:TextBox ID="TitleTextBox" runat="server" Width="300px"></asp:TextBox><br /><br />

        <!-- Description -->
        <label for="Description">Description:</label><br />
        <asp:TextBox ID="DescriptionTextBox" runat="server" TextMode="MultiLine" Rows="5" Width="300px"></asp:TextBox><br /><br />

        <!-- Status -->
        <label for="Status">Status:</label>
        <asp:DropDownList ID="StatusDropDown" runat="server">
            <asp:ListItem Text="Active" Value="Active" />
            <asp:ListItem Text="Inactive" Value="Inactive" />
        </asp:DropDownList><br /><br />

        <!-- URL -->
        <label for="URL">URL:</label>
        <asp:TextBox ID="URLTextBox" runat="server" Width="300px"></asp:TextBox><br /><br />

        <!-- Submit Button -->
        <asp:Button ID="SaveTrainingButton" runat="server" Text="Save Training" OnClick="SaveTrainingButton_Click" />

        <!-- Grid -->
        <asp:GridView ID="TrainingGridView" runat="server" AutoGenerateColumns="False"
            OnRowEditing="TrainingGridView_RowEditing"
            OnRowUpdating="TrainingGridView_RowUpdating"
            OnRowDeleting="TrainingGridView_RowDeleting"
            OnRowCancelingEdit="TrainingGridView_RowCancelingEdit"
            OnRowDataBound="TrainingGridView_RowDataBound"
            DataKeyNames="TrainingID">
            <Columns>
                <asp:TemplateField HeaderText="TrainingID">
                    <ItemTemplate>
                        <%# Eval("TrainingID") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Title">
                    <ItemTemplate>
                        <%# Eval("Title") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="EditTitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Description">
                    <ItemTemplate>
                        <%# Eval("Description") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="EditDescriptionTextBox" runat="server" Text='<%# Bind("Description") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <%# Eval("Status") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="EditStatusDropDown" runat="server">
                            <asp:ListItem Text="Active" Value="Active" />
                            <asp:ListItem Text="Inactive" Value="Inactive" />
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="URL">
                    <ItemTemplate>
                        <%# Eval("URL") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="EditURLTextBox" runat="server" Text='<%# Bind("URL") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
