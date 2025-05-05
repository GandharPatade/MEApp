<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/HrMasterPage.Master" AutoEventWireup="true" CodeBehind="Attendance Tracker.aspx.cs" Inherits="MEApp.Hr.Attendance_Tracker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container py-5">
        <div class="card shadow border-primary">
            <div class="card-header bg-primary text-white">
                <h4 class="mb-0">Employee Attendance Report</h4>
            </div>
            <div class="card-body">

                <div class="row mb-4">
                    <div class="col-md-6">
                        <label class="form-label fw-bold">Select Date:</label><br />
                        <asp:Calendar ID="calDate" runat="server" CssClass="border rounded" OnSelectionChanged="calDate_SelectionChanged" />
                    </div>
                    <div class="col-md-6 d-flex align-items-end">
                        <asp:Button ID="btnExport" runat="server" Text="Export to Excel" CssClass="btn btn-primary w-100" OnClick="btnExport_Click" />
                    </div>
                </div>

                <asp:GridView ID="gvAttendance" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped text-center">
                    <Columns>
                        <asp:BoundField DataField="UserID" HeaderText="User ID" />
                        <asp:BoundField DataField="CheckInTime" HeaderText="Check-In" DataFormatString="{0:hh:mm tt}" />
                        <asp:BoundField DataField="CheckOutTime" HeaderText="Check-Out" DataFormatString="{0:hh:mm tt}" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:BoundField DataField="TotalMinutes" HeaderText="Worked (mins)" />
                        <asp:BoundField DataField="WorkedHoursFormatted" HeaderText="Worked (hrs)" />
                        <asp:BoundField DataField="WorkStatus" HeaderText="Time Balance" />
                    </Columns>
                </asp:GridView>


                <asp:ScriptManager 
                    ID="ScriptManager1" 
                    runat="server" 
                    EnableCdn="true" 
                    EnableScriptGlobalization="false" 
                    EnableScriptLocalization="false" 
                    ScriptMode="Release" 
                    LoadScriptsBeforeUI="false" />
                
                <asp:UpdatePanel ID="upSummary" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="row mb-4">
                            <div class="col-md-6">
                                <label class="form-label fw-bold">Select Employee to View Monthly Summary:</label>
                                <asp:DropDownList ID="ddlEmployeeSummary" runat="server" CssClass="form-control"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlEmployeeSummary_SelectedIndexChanged" />
                            </div>
                            <div class="col-md-6 d-flex align-items-end">
                                <asp:Label ID="lblSummary" runat="server" CssClass="fw-bold text-success" Visible="false"></asp:Label>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
        </div>
    </div>

</asp:Content>
