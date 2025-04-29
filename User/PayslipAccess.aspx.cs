using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MEApp.User
{
    public partial class PayslipAccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPayslips();
            }
        }

        private void LoadPayslips()
        {
            string empCode = Session["EmpCode"] as string;

            if (string.IsNullOrEmpty(empCode))
            {
                
                Response.Redirect("~/Account/LogIn.aspx"); 
                return;
            }

            string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = @"
                    SELECT 
                        PayslipID, 
                        EmployeeCode, 
                        FinancialYear, 
                        SalaryAmount AS Salary, 
                        PF, 
                        PayslipPath 
                    FROM Payslips 
                    WHERE EmployeeCode = @EmpCode
                    ORDER BY PayslipID DESC";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@EmpCode", empCode);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvPayslips.DataSource = dt;
                gvPayslips.DataBind();
            }
        }
    }
}