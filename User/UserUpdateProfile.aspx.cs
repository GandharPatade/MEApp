//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//namespace MEApp.User
//{
//    public partial class UserUpdateProfile : System.Web.UI.Page
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                string email = Session["Email12"].ToString();
//                lblMessage.Text = "Email received: " + email; // Debug output
//                if (!string.IsNullOrEmpty(email))
//                {
//                    LoadEmployee(email);
//                }
//            }
//        }

//        public void LoadEmployee(string email)
//        {
//            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString);
//            {
//                string query = "SELECT * FROM EmployeeProfiles WHERE Email = @Email";
//                SqlCommand cmd = new SqlCommand(query, con);
//                cmd.Parameters.AddWithValue("@Email", email);
//                con.Open();
//                SqlDataReader reader = cmd.ExecuteReader();
//                if (reader.Read())
//                {
//                    txtEmployeeCode.Text = reader["EmployeeCode"].ToString();
//                    txtFullName.Text = reader["FullName"].ToString();
//                    txtContactNo.Text = reader["ContactNo"].ToString();
//                    //txtDepartment.Text = reader["Department"].ToString();
//                    //txtDesignation.Text = reader["Designation"].ToString();
//                    dropdowndepartment.SelectedValue = reader["Department"].ToString();
//                    dropdowndesignation.SelectedValue = reader["Designation"].ToString();
//                }
//                con.Close();
//            }
//        }


//        protected void btnUpdate_Click(object sender, EventArgs e)
//        {
//            string email = Session["Email12"].ToString();
//            if (!string.IsNullOrEmpty(email))
//            {
//                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString))
//                {
//                    string updateQuery = @"UPDATE EmployeeProfiles SET 
//                    EmployeeCode = @EmployeeCode,
//                    FullName = @FullName,
//                    ContactNo = @ContactNo,
//                    Department = @Department,
//                    Designation = @Designation
//                    WHERE Email = @Email";

//                    SqlCommand cmd = new SqlCommand(updateQuery, con);
//                    cmd.Parameters.AddWithValue("@EmployeeCode", txtEmployeeCode.Text);
//                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
//                    cmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text);
//                    cmd.Parameters.AddWithValue("@Department", txtDepartment.Text);
//                    cmd.Parameters.AddWithValue("@Designation", txtDesignation.Text);
//                    cmd.Parameters.AddWithValue("@Email", email);

//                    con.Open();
//                    int rowsAffected = cmd.ExecuteNonQuery();
//                    con.Close();

//                    if (rowsAffected > 0)
//                        lblMessage.Text = "Employee data updated successfully!";
//                    else
//                        lblMessage.Text = "No records were updated.";
//                }
//            }
//        }
//    }
//}



using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace MEApp.User
{
    public partial class UserUpdateProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDepartments();
                LoadDesignations();

                string email = Session["Email12"]?.ToString();
                lblMessage.Text = "Email received: " + email; // Debug output

                if (!string.IsNullOrEmpty(email))
                {
                    LoadEmployee(email);
                }
            }
        }

        private void LoadDepartments()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString))
            {
                string query = "SELECT DepartmentID, DepartmentName FROM Department WHERE Status = 'Active'";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                dropdowndepartment.DataSource = reader;
                dropdowndepartment.DataTextField = "DepartmentName";
                dropdowndepartment.DataValueField = "DepartmentName"; // or "DepartmentID" if preferred
                dropdowndepartment.DataBind();
                con.Close();
            }

            dropdowndepartment.Items.Insert(0, new ListItem("-- Select Department --", ""));
        }

        private void LoadDesignations()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString))
            {
                string query = "SELECT DesignationID, DesignationName FROM Designation WHERE Status = 'Active'";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                dropdowndesignation.DataSource = reader;
                dropdowndesignation.DataTextField = "DesignationName";
                dropdowndesignation.DataValueField = "DesignationName"; // or "DesignationID" if preferred
                dropdowndesignation.DataBind();
                con.Close();
            }

            dropdowndesignation.Items.Insert(0, new ListItem("-- Select Designation --", ""));
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

                    // Set dropdown values
                    string department = reader["Department"].ToString();
                    string designation = reader["Designation"].ToString();

                    if (dropdowndepartment.Items.FindByValue(department) != null)
                        dropdowndepartment.SelectedValue = department;

                    if (dropdowndesignation.Items.FindByValue(designation) != null)
                        dropdowndesignation.SelectedValue = designation;
                }
                con.Close();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string email = Session["Email12"]?.ToString();
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
                    cmd.Parameters.AddWithValue("@Department", dropdowndepartment.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@Designation", dropdowndesignation.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@Email", email);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();

                    lblMessage.Text = rowsAffected > 0
                        ? "Employee data updated successfully!"
                        : "No records were updated.";
                }
            }
        }
    }
}
