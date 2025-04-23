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
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
            con = new SqlConnection(cs);

            if (!IsPostBack)
            {
                Label1.Text= Session["EmpCode"].ToString();
                BindPayslips();
            }
        }

        private void BindPayslips()
        {
            SqlCommand cmd;

            
            string empCode = Session["EmpCode"].ToString();

            
                cmd = new SqlCommand("select * from Payslips where EmployeeCode='"+empCode+"'", con);
                
            

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            

            GridViewPayslips.DataSource = dt;
            GridViewPayslips.DataBind();
        }
    }
}