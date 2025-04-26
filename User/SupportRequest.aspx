<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UserMasterPage.Master" AutoEventWireup="true" CodeBehind="SupportRequest.aspx.cs" Inherits="MEApp.User.SupportRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div>
<h2>Raise a New Ticket</h2>

<asp:Label ID="lblTitle" runat="server" Text="Title:"></asp:Label>
&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
<br /><br />

<asp:Label ID="lblDescription" runat="server" Text="Description:"></asp:Label>
&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="5" Columns="30"></asp:TextBox>
<br /><br />

<asp:Label ID="lblRaisedBy" runat="server" Text="Employee Code (Raised By):"></asp:Label>
&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="txtRaisedBy" runat="server"></asp:TextBox>
<br /><br />

<asp:Label ID="lblAssignTo" runat="server" Text="Assign To:"></asp:Label>
&nbsp;&nbsp;&nbsp;
<asp:DropDownList ID="ddlAssignTo" runat="server"></asp:DropDownList>
<br /><br />

<asp:Label ID="lblUpload" runat="server" Text="Upload Image:"></asp:Label>
&nbsp;&nbsp;&nbsp;
<asp:FileUpload ID="FileUpload1" runat="server" />
<br /><br />

<asp:Button ID="btnSubmit" runat="server" Text="Submit" BackColor="#00CC00" OnClick="btnSubmit_Click" />
<br /><br />

<asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </div>
</asp:Content>
