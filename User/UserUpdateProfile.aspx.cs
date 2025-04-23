using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MEApp.User
{
    public partial class UserUpdateProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string email = Session["Email12"].ToString();
                lblMessage.Text = "Email received: " + email; // Debug output
                if (!string.IsNullOrEmpty(email))
                {
                    LoadEmployee(email);
                }
            }
        }

        public void LoadEmployee(string email)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString))
            {
                string query = "SELECT * FROM EmployeeProfiles WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", email);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtEmployeeCode.Text = reader["EmployeeCode"].ToString();
                    txtFullName.Text = reader["FullName"].ToString();
                    txtContactNo.Text = reader["ContactNo"].ToString();
                    txtDepartment.Text = reader["Department"].ToString();
                    txtDesignation.Text = reader["Designation"].ToString();
                }
                con.Close();
            }
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string email = Session["Email12"].ToString();
            if (!string.IsNullOrEmpty(email))
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString))
                {
                    string updateQuery = @"UPDATE EmployeeProfiles SET 
                    EmployeeCode = @EmployeeCode,
                    FullName = @FullName,
                    ContactNo = @ContactNo,
                    Department = @Department,
                    Designation = @Designation
                    WHERE Email = @Email";

                    SqlCommand cmd = new SqlCommand(updateQuery, con);
                    cmd.Parameters.AddWithValue("@EmployeeCode", txtEmployeeCode.Text);
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text);
                    cmd.Parameters.AddWithValue("@Department", txtDepartment.Text);
                    cmd.Parameters.AddWithValue("@Designation", txtDesignation.Text);
                    cmd.Parameters.AddWithValue("@Email", email);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();

                    if (rowsAffected > 0)
                        lblMessage.Text = "Employee data updated successfully!";
                    else
                        lblMessage.Text = "No records were updated.";
                }
            }
        }
    }
}