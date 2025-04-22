using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MEApp.Admin
{
    public partial class LeaveReport : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadLeaveReports();
            }
        }

        private void LoadLeaveReports()
        {
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("sp_GetLeaveReports", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvLeaveReport.DataSource = dt;
            gvLeaveReport.DataBind();
        }
    }
}
