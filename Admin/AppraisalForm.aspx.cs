using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace MEApp.Admin
{
    public partial class AppraisalForm : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEmployeeCodes();
                LoadAppraisals();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string empCode = ddlEmployeeCode.SelectedValue;
            string period = txtReviewPeriod.Text.Trim();
            string punctuality = txtPunctuality.Text.Trim();
            string communication = txtCommunication.Text.Trim();
            string teamwork = txtTeamwork.Text.Trim();
            string comments = txtComments.Text.Trim().Replace("'", "''");
            string status = ddlStatus.SelectedValue;

            string query = $"exec sp_InsertAppraisalForm '{empCode}', '{period}', {punctuality}, {communication}, {teamwork}, '{comments}', '{status}'";

            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            LoadAppraisals();
            con.Open();
            string to = "";
            SqlCommand emailCmd = new SqlCommand($"exec sp_GetEmail '{empCode}'", con);
            emailCmd.ExecuteNonQuery();

            //con.Open();
            SqlDataReader reader = emailCmd.ExecuteReader();
            if (reader.Read())
            {
                to = reader["Email"].ToString();
            }
            con.Close();

            if (!string.IsNullOrEmpty(to))
            {
                string subject = "Performance Appraisal Notification";
                string body = $"Dear Employee,Your performance appraisal for the review period {period} has been submitted. " +
                              $" Status: {status} " +
                              $" Comments: {comments} " +
                              $" Regards,HR Department ";

                EmailHelper.SendEmail(to, subject, body, null);
            }
            else
            {
                Response.Write("<script>alert('Email not found for this employee.');</script>");
            }
        }

        private void LoadEmployeeCodes()
        {
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("exec sp_GetEmpcode", con);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            ddlEmployeeCode.Items.Clear();
            ddlEmployeeCode.Items.Add(new ListItem("-- Select Employee Code --", ""));

            while (reader.Read())
            {
                ddlEmployeeCode.Items.Add(new ListItem(reader["EmployeeCode"].ToString(), reader["EmployeeCode"].ToString()));
            }

            con.Close();
        }

        private void LoadAppraisals()
        {
            SqlConnection con = new SqlConnection(conStr);
            string query = "exec sp_GetAppraisals";
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvAppraisals.DataSource = dt;
            gvAppraisals.DataBind();
        }
    }
}
