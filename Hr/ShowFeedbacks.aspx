<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/HrMasterPage.Master" AutoEventWireup="true" CodeBehind="ShowFeedbacks.aspx.cs" Inherits="MEApp.Hr.ShowFeedbacks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5">
    <div class="card shadow">
        <div class="card-header bg-primary text-white text-center">
            <h2 class="mb-0">All Employee Feedbacks</h2>
        </div>
        <div class="card-body">

            <asp:GridView ID="gvAllFeedbacks" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-striped text-center">
                <Columns>
                    <asp:BoundField DataField="FeedbackID" HeaderText="Feedback ID" />
                    <asp:BoundField DataField="EmployeeCode" HeaderText="Employee Code" />
                    <asp:BoundField DataField="Feedback" HeaderText="Feedback" />
                    <asp:BoundField DataField="CreatedDate" HeaderText="Submitted On" DataFormatString="{0:dd-MM-yyyy HH:mm}" />
                </Columns>
            </asp:GridView>

        </div>
    </div>
</div>

</asp:Content>
