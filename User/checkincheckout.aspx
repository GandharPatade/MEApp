<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UserMasterPage.Master" AutoEventWireup="true" CodeBehind="checkincheckout.aspx.cs" Inherits="MEApp.User.checkincheckout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="container py-5">
        <div class="row justify-content-center">
            <div class="col-md-6">

                <div class="card shadow border-primary">
                    <div class="card-header bg-primary text-white text-center">
                        <h4>Employee Attendance</h4>
                    </div>
                    <div class="card-body text-center">

                        <asp:Button ID="btnCheckIn" runat="server" Text="Check In" CssClass="btn btn-primary btn-lg mb-3 w-100" OnClick="btnCheckIn_Click" />
                        <asp:Button ID="btnCheckOut" runat="server" Text="Check Out" CssClass="btn btn-outline-primary btn-lg mb-3 w-100" OnClick="btnCheckOut_Click" />

                        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger fw-bold d-block mt-3" />
                        <br />
                        <br />
                        <asp:Calendar ID="calAttendance" runat="server" OnDayRender="calAttendance_DayRender" CssClass="border mt-4" />


                    </div>
                </div>

            </div>
        </div>
    </div>



</asp:Content>
