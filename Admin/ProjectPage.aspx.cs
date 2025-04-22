using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MEApp.Admin
{
    public partial class ProjectPage : System.Web.UI.Page
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

        protected void CreateProjectButton_Click(object sender, EventArgs e)
        {
            string projectName = ProjectName.Text;
            DateTime deadline = DeadlineCalendar.SelectedDate;
            string description = Description.Text;
            string technology = Technology.Text;
            string status = Status.SelectedValue;

            // Validation
            if (string.IsNullOrEmpty(projectName) || deadline == DateTime.MinValue ||
                string.IsNullOrEmpty(description) || string.IsNullOrEmpty(technology) || string.IsNullOrEmpty(status))
            {
                Response.Write("<script>alert('Please fill in all fields and select a deadline date.');</script>");
                return;
            }

            if (deadline < DateTime.Today)
            {
                Response.Write("<script>alert('Deadline cannot be in the past.');</script>");
                return;
            }

            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand("sp_insertProject", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ProjectName", projectName);
                    cmd.Parameters.AddWithValue("@Deadline", deadline);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Technology", technology);
                    cmd.Parameters.AddWithValue("@Status", status);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                Response.Write("<script>alert('Project created successfully!');</script>");

                // Clear form fields
                ProjectName.Text = "";
                Description.Text = "";
                Technology.Text = "";
                Status.SelectedIndex = 0;
                DeadlineCalendar.SelectedDate = DateTime.MinValue;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
            BindGrid();
        }

        protected void ProjectsGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ProjectsGridView.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void ProjectsGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ProjectsGridView.EditIndex = -1;
            BindGrid();
        }

        protected void ProjectsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && ProjectsGridView.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddlStatus = (DropDownList)e.Row.FindControl("EditStatusDropDown");
                if (ddlStatus != null)
                {
                    string currentStatus = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                    ddlStatus.SelectedValue = currentStatus;
                }
            }
        }
        protected void ProjectsGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = ProjectsGridView.Rows[e.RowIndex];
            int projectId = Convert.ToInt32(ProjectsGridView.DataKeys[e.RowIndex].Value);

            string projectName = ((TextBox)row.Cells[1].Controls[0]).Text;
            Calendar cal = (Calendar)row.FindControl("EditDeadlineCalendar");
            DateTime deadline = cal.SelectedDate;

            if (deadline < DateTime.Today)
            {
                Response.Write("<script>alert('Deadline cannot be in the past.');</script>");
                return;
            }

            string description = ((TextBox)row.Cells[3].Controls[0]).Text;
            string technology = ((TextBox)row.Cells[4].Controls[0]).Text;
            DropDownList statusDropdown = (DropDownList)row.FindControl("EditStatusDropDown");
            string status = statusDropdown.SelectedValue;

            string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            {
                SqlCommand cmd = new SqlCommand("sp_updateProjects", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectID", projectId);
                cmd.Parameters.AddWithValue("@ProjectName", projectName);
                cmd.Parameters.AddWithValue("@Deadline", deadline);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Technology", technology);
                cmd.Parameters.AddWithValue("@Status", status);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            Response.Write("<script>alert ('Update Successful')</script>");
            ProjectsGridView.EditIndex = -1;
            BindGrid();
        }

        protected void ProjectsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int projectId = Convert.ToInt32(ProjectsGridView.DataKeys[e.RowIndex].Value);

            string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            {
                SqlCommand cmd = new SqlCommand($"sp_deleteProject '{projectId}'", conn);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            Response.Write("<script>alert('Deleted project successfully!')</script>");
            BindGrid();
        }


        private void BindGrid()
        {
            string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            {
                SqlCommand cmd = new SqlCommand("sp_getProjects", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                ProjectsGridView.DataSource = rdr;
                ProjectsGridView.DataBind();
            }
        }

    }

}