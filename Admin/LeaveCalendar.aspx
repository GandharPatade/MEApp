<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="LeaveCalendar.aspx.cs" Inherits="MEApp.Admin.LeaveCalendar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="card shadow">
            <div class="card-header bg-primary text-white text-center">
                <h2 class="mb-0">Upcoming Events</h2>
            </div>
            <div class="card-body text-center">
                <asp:Calendar ID="Calendar1" runat="server" OnDayRender="Calendar1_DayRender" OnVisibleMonthChanged="Calendar1_VisibleMonthChanged" CssClass="table table-bordered bg-light" />
                <br />
                <asp:Label ID="lblInfo" runat="server" ForeColor="Blue" CssClass="font-weight-bold" />
            </div>
        </div>
    </div>
</asp:Content>
