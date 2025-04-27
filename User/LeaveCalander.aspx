<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UserMasterPage.Master" AutoEventWireup="true" CodeBehind="LeaveCalander.aspx.cs" Inherits="MEApp.User.LeaveCalander" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div style="padding:20px;">
            <h2>Upcoming Events</h2>
            <asp:Calendar ID="Calendar1" runat="server" OnDayRender="Calendar1_DayRender"></asp:Calendar>
            <br />
            <asp:Label ID="lblInfo" runat="server" ForeColor="Blue" />
        </div>

</asp:Content>
