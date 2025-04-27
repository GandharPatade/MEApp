<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UserMasterPage.Master" AutoEventWireup="true" CodeBehind="AppraisalParticipation.aspx.cs" Inherits="MEApp.User.Appraisal_Participation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container mt-5">
    <div class="card shadow">
        <div class="card-header bg-primary text-white text-center">
            <h2 class="mb-0">My Appraisal Forms</h2>
        </div>
        <div class="card-body">

            <asp:GridView ID="gvAppraisalForms" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-striped">
                <Columns>
                    <asp:BoundField DataField="AppraisalID" HeaderText="Appraisal ID" />
                    <asp:BoundField DataField="ReviewPeriod" HeaderText="Review Period" />
                    <asp:BoundField DataField="Punctuality" HeaderText="Punctuality" />
                    <asp:BoundField DataField="Communication" HeaderText="Communication" />
                    <asp:BoundField DataField="Teamwork" HeaderText="Teamwork" />
                    <asp:BoundField DataField="ReviewerComments" HeaderText="Reviewer Comments" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                    <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" DataFormatString="{0:dd-MM-yyyy}" />
                </Columns>
            </asp:GridView>

        </div>
    </div>
</div>


</asp:Content>
