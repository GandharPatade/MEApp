<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="EventPage.aspx.cs" Inherits="MEApp.Admin.EventPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3>Create Event</h3>

        <label for="EventName">Event Name:</label>
        <asp:TextBox ID="EventName" runat="server"></asp:TextBox><br/>

        <label for="EventDate">Event Date:</label>
        <asp:Calendar ID="EventDateCalendar" runat="server" OnSelectionChanged="EventDateCalendar_SelectionChanged"></asp:Calendar><br/>

        <asp:Label ID="SelectedDateLabel" runat="server"></asp:Label><br/>

        <label for="EventDescription">Event Description:</label>
        <asp:TextBox ID="EventDescription" runat="server" TextMode="MultiLine"></asp:TextBox><br/>

        <asp:Button ID="CreateEventButton" runat="server" Text="Create Event" OnClick="CreateEventButton_Click" /><br/><br/>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
            DataKeyNames="EventID"
            OnRowEditing="GridView1_RowEditing"
            OnRowUpdating="GridView1_RowUpdating"
            OnRowCancelingEdit="GridView1_RowCancelingEdit"
            OnRowDeleting="GridView1_RowDeleting">

            <Columns>
                <asp:BoundField DataField="EventName" HeaderText="Event Name" SortExpression="EventName" ReadOnly="False" />
                <asp:TemplateField HeaderText="Event Date" SortExpression="EventDate">
                    <EditItemTemplate>
                        <asp:Calendar ID="EditEventDateCalendar" runat="server" 
                            SelectedDate='<%# Bind("EventDate") %>' 
                            OnSelectionChanged="EditEventDateCalendar_SelectionChanged"></asp:Calendar>
                        <asp:Label ID="SelectedDateLabel" runat="server" Text=""></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="EventDateLabel" runat="server" Text='<%# Bind("EventDate", "{0:MM/dd/yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="EventDescription" HeaderText="Description" SortExpression="EventDescription" ReadOnly="False" />

                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>




    </div>
</asp:Content>
