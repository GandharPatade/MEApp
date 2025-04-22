using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MEApp.Admin
{
    public partial class ViewPayslips : System.Web.UI.Page
    {
        SqlConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
            con = new SqlConnection(cs);

            if (!IsPostBack)
            {
                BindPayslips();
            }
        }

        private void BindPayslips()
        {
            SqlCommand cmd;

            // Check if Admin
            string role = Session["Role"]?.ToString();
            string empCode = Session["EmpCode"]?.ToString();

            if (role == "Admin")
            {
                cmd = new SqlCommand("exec sp_GetAllPayslips", con);
            }
            else
            {
                cmd = new SqlCommand("exec sp_GetPayslipsByEmp @EmployeeCode", con);
                cmd.Parameters.AddWithValue("@EmployeeCode", empCode);
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            GridViewPayslips.DataSource = dt;
            GridViewPayslips.DataBind();
        }
    }
}
