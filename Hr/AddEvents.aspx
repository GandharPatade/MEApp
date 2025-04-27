<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/HrMasterPage.Master" AutoEventWireup="true" CodeBehind="AddEvents.aspx.cs" Inherits="MEApp.Hr.AddEvents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


      <div style="padding:20px;">
            <h2>Add New Event</h2>
            <p>Event Title: <asp:TextBox ID="txtTitle" runat="server" /></p>
            <p>Event Date: <asp:TextBox ID="txtDate" runat="server" TextMode="Date" /></p>
            <p>Status:
                <asp:DropDownList ID="ddlStatus" runat="server">
                    <asp:ListItem Text="Active" Value="Active" />
                    <asp:ListItem Text="Inactive" Value="Inactive" />
                </asp:DropDownList>
            </p>
            <p>
                <asp:Button ID="btnAdd" runat="server" Text="Add Event" OnClick="btnAdd_Click" BackColor="#FA971F" />
            </p>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
        </div>


</asp:Content>
