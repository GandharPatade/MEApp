using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MEApp.Admin
{
    public partial class PerformancePage : System.Web.UI.Page
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

        protected void PerformanceGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SubmitPerformance")
            {
                int userId = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = ((Button)e.CommandSource).NamingContainer as GridViewRow;

                DropDownList ddlPoints = (DropDownList)row.FindControl("PointsDropdown");
                TextBox txtRemark = (TextBox)row.FindControl("RemarkTextBox");

                if (ddlPoints != null && txtRemark != null)
                {
                    int points = int.Parse(ddlPoints.SelectedValue);
                    string remark = txtRemark.Text;

                    SavePerformance(userId, points, remark);

                    Response.Write("<script>alert('Performance submitted!');</script>");
                }
            }
        }

        private void SavePerformance(int userId, int points, string remark)
        {
            string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand($"exec sp_savePerformance '{userId}', '{points}', '{remark}' ", conn);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void BindGrid()
        {
            string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            {
                SqlCommand cmd = new SqlCommand("sp_getUsersForPerformance", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                PerformanceGridView.DataSource = dt;
                PerformanceGridView.DataBind();
            }
        }
    }
}
