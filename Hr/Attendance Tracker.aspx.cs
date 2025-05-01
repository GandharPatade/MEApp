using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MEApp.Hr
{
    public partial class Attendance_Tracker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                calDate.SelectedDate = DateTime.Today;
                LoadEmployeeDropdown();
                LoadAttendance(calDate.SelectedDate);
            }
        }



        private void LoadEmployeeDropdown()
        {
            string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT EmployeeCode, FullName FROM EmployeeProfiles", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                ddlEmployeeSummary.Items.Clear();
                ddlEmployeeSummary.Items.Add(new ListItem("-- Select Employee --", "0"));
                while (reader.Read())
                {
                    ddlEmployeeSummary.Items.Add(new ListItem(reader["FullName"].ToString(), reader["EmployeeCode"].ToString()));
                }
            }
        }

        protected void ddlEmployeeSummary_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSummary();
        }


        //private void UpdateSummary()
        //{
        //    int userId = Convert.ToInt32(ddlEmployeeSummary.SelectedValue);
        //    if (userId == 0) return;

        //    DateTime selectedDate = calDate.SelectedDate == DateTime.MinValue ? DateTime.Today : calDate.SelectedDate;
        //    int month = selectedDate.Month;
        //    int year = selectedDate.Year;

        //    string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
        //    using (SqlConnection conn = new SqlConnection(cs))
        //    {
        //        SqlCommand cmd = new SqlCommand(@"SELECT Status FROM AttendanceRecords
        //                                  WHERE UserID = @UserID AND MONTH([Date]) = @Month AND YEAR([Date]) = @Year", conn);
        //        cmd.Parameters.AddWithValue("@UserID", userId);
        //        cmd.Parameters.AddWithValue("@Month", month);
        //        cmd.Parameters.AddWithValue("@Year", year);

        //        conn.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        int present = 0, absent = 0;
        //        while (reader.Read())
        //        {
        //            string status = reader["Status"].ToString();
        //            if (status == "Present") present++;
        //            else if (status == "Absent") absent++;
        //        }
        //        lblSummary.Text = $"Selected Employee Monthly Summary: Present: {present} | Absent: {absent}";
        //    }
        //}


        private void UpdateSummary()
        {
            lblSummary.Visible = false; // Hide label by default when changing month

            int userId = Convert.ToInt32(ddlEmployeeSummary.SelectedValue);
            if (userId == 0) return;

            DateTime selectedDate = calDate.SelectedDate == DateTime.MinValue ? DateTime.Today : calDate.SelectedDate;
            int month = selectedDate.Month;
            int year = selectedDate.Year;

            string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_GetMonthlyAttendanceSummary", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@Month", month);
                cmd.Parameters.AddWithValue("@Year", year);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Handle DBNull and set default to 0 if needed
                    int present = reader["PresentCount"] != DBNull.Value ? Convert.ToInt32(reader["PresentCount"]) : 0;
                    int absent = reader["AbsentCount"] != DBNull.Value ? Convert.ToInt32(reader["AbsentCount"]) : 0;

                    if (present == 0 && absent == 0)
                    {
                        lblSummary.Visible = false; // No data — hide label
                    }
                    else
                    {
                        lblSummary.Text = $"Selected Employee Monthly Summary: Present: {present} | Absent: {absent}";
                        lblSummary.Visible = true; // Data exists — show label
                    }
                }
                else
                {
                    lblSummary.Visible = false; // In case there is no data at all for the selected month
                }
            }
        }











        protected void calDate_SelectionChanged(object sender, EventArgs e)
        {
            LoadAttendance(calDate.SelectedDate);

            // Only update summary if an employee is selected
            if (ddlEmployeeSummary.SelectedValue != "0")
            {
                UpdateSummary();
            }
        }




        private void LoadAttendance(DateTime date)
        {
            string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("sp_GetSimpleAttendanceReport", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Date", date);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);


                dt.Columns.Add("WorkedHoursFormatted", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    if (row["TotalMinutes"] != DBNull.Value)
                    {
                        int totalMin = Convert.ToInt32(row["TotalMinutes"]);
                        int hr = totalMin / 60;
                        int min = totalMin % 60;
                        row["WorkedHoursFormatted"] = $"{hr} hr {min} min";

                        string status;
                        if (totalMin < 480)
                        {
                            status = "Absent";
                            row["Status"] = status;
                            row["WorkStatus"] = $"Pending: {480 - totalMin} mins";
                        }
                        else
                        {
                            status = "Present";
                            row["Status"] = status;
                            row["WorkStatus"] = $"Overtime: {totalMin - 480} mins";
                        }


                        SqlCommand updateCmd = new SqlCommand("UPDATE AttendanceRecords SET Status = @Status WHERE UserID = @UserID AND Date = @Date", conn);
                        updateCmd.Parameters.AddWithValue("@Status", status);
                        updateCmd.Parameters.AddWithValue("@UserID", row["UserID"]);
                        updateCmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(row["Date"]));

                        updateCmd.ExecuteNonQuery();
                    }
                    else
                    {
                        row["WorkedHoursFormatted"] = "-";
                        row["Status"] = "Absent";
                        row["WorkStatus"] = "No data";
                    }
                }


                gvAttendance.DataSource = dt;
                gvAttendance.DataBind();
                ViewState["AttendanceData"] = dt;


                conn.Close();
            }
        }




        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dt = ViewState["AttendanceData"] as DataTable;
            if (dt == null) return;

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=AttendanceReport.xlsx");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";

            using (System.IO.StringWriter sw = new System.IO.StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    GridView exportGrid = new GridView();
                    exportGrid.DataSource = dt;
                    exportGrid.DataBind();
                    exportGrid.RenderControl(hw);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            // Needed for export
        }

        protected void gvAttendance_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAttendance.PageIndex = e.NewPageIndex;
            LoadAttendance(calDate.SelectedDate);
        }

    }
}