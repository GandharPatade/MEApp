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
    public partial class FeedbackSubmission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmpCode"] == null)
            {
                // Session expired or user not logged in
                Response.Redirect("~/Account/LogIn.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string employeeCode = Session["EmpCode"].ToString();
            string feedback = txtFeedback.Text.Trim();
            DateTime createdDate = DateTime.Now;

            if (!string.IsNullOrEmpty(feedback))
            {
                SaveFeedback(employeeCode, feedback, createdDate);
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please enter your feedback before submitting.";
            }
        }

        private void SaveFeedback(string employeeCode, string feedback, DateTime createdDate)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertEmployeeFeedback", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeCode", employeeCode);
                cmd.Parameters.AddWithValue("@Feedback", feedback);
                cmd.Parameters.AddWithValue("@CreatedDate", createdDate);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Feedback submitted successfully!";

                    txtFeedback.Text = ""; // Clear textbox after submission
                }
                catch (Exception ex)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
        }
    }
}