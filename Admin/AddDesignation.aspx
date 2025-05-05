<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AddDesignation.aspx.cs" Inherits="MEApp.Admin.AddDesignation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card {
            max-width: 600px;
            margin: auto;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="card border-primary shadow">
            <div class="card-header bg-primary text-white">
                <h4 class="mb-0">Add Designation</h4>
            </div>
            <div class="card-body">
                <div class="mb-3">
                    <label for="txtDesignation" class="form-label">Designation</label>
                    <asp:TextBox ID="txtDesignation" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="rfvDesignation" runat="server" ControlToValidate="txtDesignation"
                        ErrorMessage="Designation is required." CssClass="text-danger" Display="Dynamic" />
                </div>

                <div class="mb-3">
                    <label for="DropDownList2" class="form-label">Status</label>
                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-select">
                        <asp:ListItem Value="Active">Active</asp:ListItem>
                        <asp:ListItem Value="Inactive">Inactive</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="text-end">
                    <asp:Button ID="btnAddDesignation" runat="server" Text="Add Designation" CssClass="btn btn-primary" OnClick="btnAddDesignation_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
