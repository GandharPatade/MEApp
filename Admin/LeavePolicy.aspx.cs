using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MEApp.Admin
{
    public partial class LeavePolicy1 : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPolicies();
            }
        }

        private void LoadPolicies()
        {
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("sp_GetLeavePolicies", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvPolicies.DataSource = dt;
            gvPolicies.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd;
            string policyName = txtPolicyName.Text.Trim();
            string leaveType = txtLeaveType.Text.Trim();
            int totalLeaves = int.Parse(txtMaxLeaves.Text.Trim());
            string description = txtDescription.Text.Trim();
            int policyId = int.Parse(hfPolicyID.Value);

            try
            {
                if (string.IsNullOrEmpty(hfPolicyID.Value))
                {

                    cmd = new SqlCommand($"exec sp_InsertLeavePolicy '{policyName}', '{leaveType}', '{totalLeaves}', '{description}'", con);

                }
                else
                {
                    
                    cmd = new SqlCommand($"exec sp_UpdateLeavePolicy '{policyId}', '{policyName}', '{leaveType}', '{totalLeaves}', '{description}'", con);

                }

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                lblMessage.Text = "Policy saved successfully.";
                ClearFields();
                LoadPolicies();

            }
            catch (Exception ex) 
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }
        }

        protected void gvPolicies_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int policyId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditPolicy")
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("SELECT * FROM LeavePolicies WHERE PolicyID = @PolicyID", con);
                cmd.Parameters.AddWithValue("@PolicyID", policyId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    hfPolicyID.Value = dt.Rows[0]["PolicyID"].ToString();
                    txtPolicyName.Text = dt.Rows[0]["PolicyName"].ToString();
                    txtLeaveType.Text = dt.Rows[0]["LeaveType"].ToString();
                    txtMaxLeaves.Text = dt.Rows[0]["TotalLeaves"].ToString();
                    txtDescription.Text = dt.Rows[0]["Description"].ToString();
                }
            }
            else if (e.CommandName == "DeletePolicy")
            {
                try
                {
                    SqlConnection con = new SqlConnection(conStr);
                    SqlCommand cmd = new SqlCommand($"exec sp_DeleteLeavePolicy '{policyId}'", con);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    lblMessage.Text = "Policy deleted successfully.";
                    LoadPolicies();
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('{ex.Message}')</script>");
                }
            }
        }

        private void ClearFields()
        {
            txtPolicyName.Text = "";
            txtLeaveType.Text = "";
            txtMaxLeaves.Text = "";
            txtDescription.Text = "";
            hfPolicyID.Value = "";
        }
    }
}
