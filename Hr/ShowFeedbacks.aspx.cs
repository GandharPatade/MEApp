using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MEApp.Hr
{
    public partial class ShowFeedbacks : System.Web.UI.Page
    {
        
            protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllFeedbacks();
            }
        }

        private void LoadAllFeedbacks()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllEmployeeFeedbacks", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvAllFeedbacks.DataSource = dt;
                gvAllFeedbacks.DataBind();
            }
        }
    }
    
}