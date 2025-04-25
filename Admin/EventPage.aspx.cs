using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MEApp.Admin
{
    public partial class EventPage : Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null || Session["Role"] == null || Session["Role"].ToString() != "Admin")
            {
                Response.Redirect("~/Account/Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    BindGrid();
                }
            }
        }

        protected void EventDateCalendar_SelectionChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = EventDateCalendar.SelectedDate;

            if (selectedDate < DateTime.Today)
            {
                Response.Write("<script>alert('You cannot select a past date.');</script>");
                EventDateCalendar.SelectedDate = DateTime.Today; 
            }
            else
            {
                SelectedDateLabel.Text = "Selected Date: " + selectedDate.ToString("MM/dd/yyyy");
            }
        }


        protected void CreateEventButton_Click(object sender, EventArgs e)
        {
            string eventName = EventName.Text;
            DateTime eventDateTime;

            if (EventDateCalendar.SelectedDate == DateTime.MinValue)
            {
                Response.Write("<script>alert('Please select a valid event date.');</script>");
                return;
            }
            eventDateTime = EventDateCalendar.SelectedDate;

            string eventDescription = EventDescription.Text;

            if (string.IsNullOrEmpty(eventName) || string.IsNullOrEmpty(eventDescription))
            {
                Response.Write("<script>alert('Please fill all the fields.');</script>");
                return;
            }

            try
            {
                InsertEventIntoDatabase(eventName, eventDateTime, eventDescription);
                Response.Write("<script>alert('Event Created Successfully!');</script>");

                EventName.Text = "";
                EventDescription.Text = "";
                SelectedDateLabel.Text = "";
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }

            BindGrid();
        }


        private void InsertEventIntoDatabase(string eventName, DateTime eventDate, string eventDescription)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);
            {
                try
                {
                    SqlCommand cmd = new SqlCommand($"exec sp_insertEvent '{eventName}', '{eventDate}', '{eventDescription}'", conn);
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                catch (Exception ex) 
                {
                    Response.Write($"<script>alert('{ex.Message}');</script>");
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int eventId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

                string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
                SqlConnection conn = new SqlConnection(cs);
                {
                    SqlCommand cmd = new SqlCommand($"exec sp_deleteEvent '{eventId}'", conn);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                BindGrid();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error deleting event: " + ex.Message + "');</script>");
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int eventId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
                GridViewRow row = GridView1.Rows[e.RowIndex];

                string updatedEventName = ((TextBox)row.Cells[0].Controls[0]).Text;

                Calendar editCalendar = (Calendar)row.FindControl("EditEventDateCalendar");
                DateTime updatedEventDate = editCalendar.SelectedDate;

                string updatedEventDescription = ((TextBox)row.Cells[2].Controls[0]).Text;

                string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
                SqlConnection conn = new SqlConnection(cs);
                {
                    SqlCommand cmd = new SqlCommand($"exec sp_updateEvent '{eventId}', '{updatedEventName}', '{updatedEventDate}', '{updatedEventDescription}'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                GridView1.EditIndex = -1;
                BindGrid();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error updating event: " + ex.Message + "');</script>");
            }
        }

        protected void EditEventDateCalendar_SelectionChanged(object sender, EventArgs e)
        {
            Calendar calendar = sender as Calendar;
            DateTime selectedDate = calendar.SelectedDate;

            if (selectedDate < DateTime.Today)
            {
                Response.Write("<script>alert('You cannot select a past date.');</script>");
                calendar.SelectedDate = DateTime.Today;
            }
        }


        private void BindGrid()
        {
            string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
            conn = new SqlConnection(cs);
            {
                SqlCommand cmd = new SqlCommand("exec sp_getEvents", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                 
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
}