using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MEApp.Admin
{
    public partial class ViewForm16 : System.Web.UI.Page
    {
        SqlConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
                con = new SqlConnection(cs);
                LoadForm16Documents();
            }
        }

        private void LoadForm16Documents()
        {
            string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
             SqlConnection con = new SqlConnection(cs);
            {
                SqlCommand cmd = new SqlCommand("SELECT EmployeeCode, FinancialYear, Form16Path FROM Form16Documents", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridViewForm16.DataSource = dt;
                GridViewForm16.DataBind();
            }
        }
    }
}
