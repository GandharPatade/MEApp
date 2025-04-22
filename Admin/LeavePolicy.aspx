<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="LeavePolicy.aspx.cs" Inherits="MEApp.Admin.LeavePolicy1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h2 class="mb-4">Leave Policy Setup</h2>

        <div class="row mb-3">
            <div class="col-md-6">
                <asp:TextBox ID="txtPolicyName" runat="server" CssClass="form-control" placeholder="Policy Name"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtLeaveType" runat="server" CssClass="form-control" placeholder="Leave Type"></asp:TextBox>
            </div>
        </div>

        <div class="row mb-3">
            <div class="col-md-6">
                <asp:TextBox ID="txtMaxLeaves" runat="server" CssClass="form-control" placeholder="Max Leaves" TextMode="Number"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" placeholder="Description" TextMode="MultiLine" Rows="2"></asp:TextBox>
            </div>
        </div>

        <div class="mb-3">
            <asp:Button ID="btnSave" runat="server" Text="Save Policy" CssClass="btn btn-primary" OnClick="btnSave_Click" />
            <asp:HiddenField ID="hfPolicyID" runat="server" />
        </div>

        <div class="mb-3">
            <asp:Label ID="lblMessage" runat="server" CssClass="text-success fw-bold"></asp:Label>
        </div>

        <asp:GridView ID="gvPolicies" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
            OnRowCommand="gvPolicies_RowCommand">
            <Columns>
                <asp:BoundField DataField="PolicyID" HeaderText="Policy ID" />
                <asp:BoundField DataField="PolicyName" HeaderText="Policy Name" />
                <asp:BoundField DataField="LeaveType" HeaderText="Leave Type" />
                <asp:BoundField DataField="TotalLeaves" HeaderText="Max Leaves" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="EditPolicy"
                            CommandArgument='<%#Eval("PolicyID") %>' CssClass="btn btn-warning btn-sm me-2" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="DeletePolicy"
                            CommandArgument='<%#Eval("PolicyID") %>' CssClass="btn btn-danger btn-sm" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
