using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MEApp.User
{
    public partial class checkincheckout : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ManageButtonVisibility();
                LoadAttendanceDates();
            }
        }

        private void ManageButtonVisibility()
        {
            int userId = Convert.ToInt32(Session["EmpCode"]);
            DateTime today = DateTime.Today;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT CheckInTime, CheckOutTime FROM AttendanceRecords WHERE UserID = @UserID AND Date = @Today";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@Today", today);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Already checked in
                    btnCheckIn.Enabled = false;

                    if (reader["CheckOutTime"] == DBNull.Value)
                    {
                        btnCheckOut.Enabled = true;
                    }
                    else
                    {
                        btnCheckOut.Enabled = false;
                    }
                }
                else
                {

                    DateTime now = DateTime.Now;
                    if (now.Hour >= 8 && now.Hour <= 12)
                    {
                        btnCheckIn.Enabled = true;
                        btnCheckOut.Enabled = false;
                    }
                    else
                    {
                        btnCheckIn.Enabled = false;
                        lblMessage.Text = "Check-in is only allowed between 8 AM and 12 PM.";
                    }
                }
                conn.Close();
            }
        }

        protected void btnCheckIn_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["EmpCode"]);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_CheckInUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userId);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    lblMessage.Text = "Checked in successfully!";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                catch (SqlException ex)
                {
                    lblMessage.Text = ex.Message;
                }
                finally
                {
                    conn.Close();
                }
            }

            ManageButtonVisibility();
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["EmpCode"]);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_CheckOutUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userId);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    lblMessage.Text = "Checked out successfully!";
                }
                catch (SqlException ex)
                {
                    lblMessage.Text = ex.Message;
                }
                finally
                {
                    conn.Close();
                }
            }

            ManageButtonVisibility();
        }



        HashSet<DateTime> presentDates = new HashSet<DateTime>();
        HashSet<DateTime> absentDates = new HashSet<DateTime>();

        private void LoadAttendanceDates()
        {
            string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
            int userId = Convert.ToInt32(Session["EmpCode"]);

            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "SELECT CAST(Date AS DATE) AS WorkDate, Status FROM AttendanceRecords WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime date = Convert.ToDateTime(reader["WorkDate"]);
                    string status = reader["Status"].ToString();

                    if (status == "Present") presentDates.Add(date);
                    else absentDates.Add(date);
                }
            }
        }

        protected void calAttendance_DayRender(object sender, DayRenderEventArgs e)
        {
            if (presentDates.Contains(e.Day.Date))
            {
                e.Cell.BackColor = System.Drawing.Color.LightGreen;
                e.Cell.ToolTip = "Present";
            }
            else if (absentDates.Contains(e.Day.Date))
            {
                e.Cell.BackColor = System.Drawing.Color.Red;
                e.Cell.ToolTip = "Absent";
            }
        }
    }
}