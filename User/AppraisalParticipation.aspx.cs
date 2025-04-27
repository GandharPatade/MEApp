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
    public partial class Appraisal_Participation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["EmpCode"] != null)
                {
                    string employeeCode = Session["EmpCode"].ToString();
                    LoadAppraisalForms(employeeCode);
                }
                else
                {
                    // Optionally redirect to login or show error if session expired
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        private void LoadAppraisalForms(string employeeCode)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT AppraisalID, ReviewPeriod, Punctuality, Communication, Teamwork, ReviewerComments, Status, CreatedDate " +
                               "FROM AppraisalForms WHERE EmployeeCode = @EmployeeCode";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@EmployeeCode", employeeCode);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvAppraisalForms.DataSource = dt;
                gvAppraisalForms.DataBind();
            }
        }
    }
}