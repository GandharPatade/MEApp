using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MEApp.User
{
    public partial class SupportRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateSupportStaffDropdown();
            }

        }

        private void PopulateSupportStaffDropdown()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
            string query = "SELECT UserID, FullName FROM Users WHERE Role = 'Support'";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                ddlAssignTo.DataSource = reader;
                ddlAssignTo.DataTextField = "FullName";    // Show FullName in dropdown
                ddlAssignTo.DataValueField = "UserID";     // Save UserID internally
                ddlAssignTo.DataBind();
            }

            ddlAssignTo.Items.Insert(0, new ListItem("Select support staff", ""));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string description = txtDescription.Text.Trim();
            string raisedBy = txtRaisedBy.Text.Trim();   // EmployeeCode from textbox
            string selectedUserId = ddlAssignTo.SelectedValue;
            string assignedToName = null;
            string imagePath = null;

            if (string.IsNullOrEmpty(raisedBy))
            {
                lblMessage.Text = "Please enter your Employee Code.";
                return;
            }

            if (string.IsNullOrEmpty(selectedUserId))
            {
                lblMessage.Text = "Please select a Support Staff.";
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;

            // Fetch Support Staff FullName based on selected UserID
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string fetchNameQuery = "SELECT FullName FROM Users WHERE UserID = @UserID";
                SqlCommand cmdFetch = new SqlCommand(fetchNameQuery, conn);
                cmdFetch.Parameters.AddWithValue("@UserID", selectedUserId);
                conn.Open();
                object result = cmdFetch.ExecuteScalar();
                assignedToName = result != null ? result.ToString() : null;
            }

            if (FileUpload1.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUpload1.FileName);
                    string uploadFolder = Server.MapPath("~/Uploads/");

                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }

                    string fullPath = Path.Combine(uploadFolder, filename);
                    FileUpload1.SaveAs(fullPath);

                    imagePath = "~/Uploads/" + filename;
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "File upload failed: " + ex.Message;
                    return;
                }
            }

            // Insert Ticket
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string insertQuery = "INSERT INTO Tickets (Title, Description, RaisedBy, AssignedTo, CreatedDate, ImagePath) " +
                                     "VALUES (@Title, @Description, @RaisedBy, @AssignedTo, @CreatedDate, @ImagePath)";

                SqlCommand cmdInsert = new SqlCommand(insertQuery, conn);
                cmdInsert.Parameters.AddWithValue("@Title", title);
                cmdInsert.Parameters.AddWithValue("@Description", description);
                cmdInsert.Parameters.AddWithValue("@RaisedBy", raisedBy);
                cmdInsert.Parameters.AddWithValue("@AssignedTo", (object)assignedToName ?? DBNull.Value);   // Insert FullName
                cmdInsert.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                cmdInsert.Parameters.AddWithValue("@ImagePath", (object)imagePath ?? DBNull.Value);

                conn.Open();
                cmdInsert.ExecuteNonQuery();
            }

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Ticket raised successfully.";
            ClearForm();
        }

        private void ClearForm()
        {
            txtTitle.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtRaisedBy.Text = string.Empty;
            ddlAssignTo.SelectedIndex = 0;
        }
    }
}
