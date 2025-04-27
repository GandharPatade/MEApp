<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UserMasterPage.Master" AutoEventWireup="true" CodeBehind="FeedbackSubmission.aspx.cs" Inherits="MEApp.User.FeedbackSubmission" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5">
    <div class="card shadow">
        <div class="card-header bg-primary text-white text-center">
            <h2 class="mb-0">Submit Your Feedback</h2>
        </div>
        <div class="card-body">

            <asp:Label ID="lblFeedback" runat="server" Text="Your Feedback:" CssClass="font-weight-bold"></asp:Label>
            <asp:TextBox ID="txtFeedback" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" />

            <div class="form-group text-center mt-4">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit Feedback" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
            </div>

            <div class="text-center mt-3">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Bold="True"></asp:Label>
            </div>

        </div>
    </div>
</div>


</asp:Content>
