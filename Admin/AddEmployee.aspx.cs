using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace MEApp.Admin
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)  
        {
            string fullname = Session["Fullname"].ToString();
            string email = Session["Email"].ToString();
            string role = Session["Role"].ToString();

            txtFullName.Text = fullname;
            txtEmail.Text = email;
            txtDesignation.Text = role;
            LoadEmployees();
            if (Session["UserID"] == null || Session["Role"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            string fullname = Session["Fullname"].ToString();
            string email = Session["Email"].ToString();
            string role = Session["Role"].ToString();
            try 
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString);
                SqlCommand cmd = new SqlCommand("exec sp_AddEmployee @EmployeeCode, @FullName, @Email, @ContactNo, @Department, @Designation", con);
                cmd.Parameters.AddWithValue("@EmployeeCode", txtEmployeeCode.Text);
                cmd.Parameters.AddWithValue("@FullName", fullname);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text);
                cmd.Parameters.AddWithValue("@Department", txtDepartment.Text);
                cmd.Parameters.AddWithValue("@Designation", role);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                lblMessage.Text = "Employee added successfully!";
                ClearFields();
                LoadEmployees();
            }
            catch(Exception ex)
            {
                lblMessage.Text = ex.Message;
            }

        }

        private void LoadEmployees()
        {
            SqlDataAdapter da = new SqlDataAdapter("EXEC sp_GetAllEmployeesDesc", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
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
