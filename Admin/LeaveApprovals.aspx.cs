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
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString);
            SqlCommand cmd = new SqlCommand("sp_GetAllLeaveRequests", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GvLeaveRequest.DataSource = dt;
            GvLeaveRequest.DataBind();
        }

        protected void GvLeaveRequests_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Approve" || e.CommandName == "Reject")
            {
                int requestId = Convert.ToInt32(e.CommandArgument);
                string newStatus = e.CommandName == "Approve" ? "Approved" : "Rejected";

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString);
                SqlCommand cmd = new SqlCommand("sp_UpdateLeaveStatus", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RequestID", requestId);
                cmd.Parameters.AddWithValue("@Status", newStatus);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                lblMessage.Text = $"Leave request was {newStatus.ToLower()} successfully.";
                LoadLeaveRequests();
            }
        }
    }
}