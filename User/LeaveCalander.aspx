<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UserMasterPage.Master" AutoEventWireup="true" CodeBehind="LeaveCalander.aspx.cs" Inherits="MEApp.User.LeaveCalander" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
    <h2>Add Event Type</h2>
    <p>Event Type Name</p>
    <p>&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </p>
    <p>Colour</p>
    <p>
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Color" Width="41px"></asp:TextBox>
    </p>
    <p>choose a colour for this event type</p>
    <p>
        <asp:Button ID="Button1" runat="server" BackColor="#FA971F" OnClick="Button1_Click" Text="Add Event" Height="51px" Width="229px" />
    </p>
</div>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />

        <asp:BoundField DataField="Color" HeaderText="Color" SortExpression="Color" />
    </Columns>
</asp:GridView>

</asp:Content>
