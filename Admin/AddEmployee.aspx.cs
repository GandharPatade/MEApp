using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MEApp.Admin
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)  
        {
            if (Session["UserID"] == null || Session["Role"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString);
            SqlCommand cmd = new SqlCommand("exec sp_AddEmployee @EmployeeCode, @FullName, @Email, @ContactNo, @Department, @Designation", con);
            cmd.Parameters.AddWithValue("@EmployeeCode", txtEmployeeCode.Text);
            cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text);
            cmd.Parameters.AddWithValue("@Department", txtDepartment.Text);
            cmd.Parameters.AddWithValue("@Designation", txtDesignation.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            lblMessage.Text = "Employee added successfully!";
            ClearFields();
        }

        private void ClearFields()
        {
            txtEmployeeCode.Text = "";
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtContactNo.Text = "";
            txtDepartment.Text = "";
            txtDesignation.Text = "";
        }
    }
}
