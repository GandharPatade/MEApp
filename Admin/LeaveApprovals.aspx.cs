using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace MEApp
{
    public partial class LeaveAprrovals : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadLeaveRequests();
            }
        }

        private void LoadLeaveRequests()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString);
                SqlCommand cmd = new SqlCommand("exec sp_GetAllLeaveRequests", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GvLeaveRequest.DataSource = dt;
                GvLeaveRequest.DataBind();
            }
            catch (Exception ex) 
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }
        }

        protected void GvLeaveRequests_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Approve" || e.CommandName == "Reject")
            {
                int requestId = Convert.ToInt32(e.CommandArgument);
                string newStatus = e.CommandName == "Approve" ? "Approved" : "Rejected";

                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString);
                    SqlCommand cmd = new SqlCommand($"exec sp_UpdateLeaveStatus '{requestId}', '{newStatus}'", con);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    lblMessage.Text = $"Leave request was {newStatus.ToLower()} successfully.";
                    LoadLeaveRequests();
                }
                catch(Exception ex)
                {
                    Response.Write($"<script>alert('{ex.Message}')</script>");
                }
            }
        }
    }
}