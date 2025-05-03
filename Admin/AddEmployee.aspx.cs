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

namespace MEApp.Admin
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUsers();
                LoadDepartments();
                LoadDesignations();
                //string naam = Request.QueryString["name"];
                //string email12 = Request.QueryString["email"];

                //txtEmail.Text = email12;
                //txtFullName.Text = naam;
            }
            if (Session["UserID"] == null || Session["Role"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
            string name = Session["fullname"].ToString();
            string email = Session["email"].ToString();
            txtEmail.Text = email;
            txtFullName.Text = name;
        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            string empcode = txtEmployeeCode.Text;
            string name = txtFullName.Text;
            string email = txtEmail.Text;
            string contact = txtContactNo.Text;

            string departmentName = ddlDepartment.SelectedItem.Text;  
            string designationName = ddlDesignation.SelectedItem.Text;

            string departmentID = ddlDepartment.SelectedValue;
            string designationID = ddlDesignation.SelectedValue;

            string insertQuery = "INSERT INTO EmployeeProfiles (EmployeeCode, FullName, Email, ContactNo, Department, Designation, DepartmentID, DesignationID) " +
                                 "VALUES (@EmployeeCode, @FullName, @Email, @ContactNo, @Department, @Designation, @DepartmentID, @DesignationID)";

            SqlCommand cmd = new SqlCommand(insertQuery, conn);
            cmd.Parameters.AddWithValue("@EmployeeCode", empcode);
            cmd.Parameters.AddWithValue("@FullName", name);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@ContactNo", contact);
            cmd.Parameters.AddWithValue("@Department", departmentName);
            cmd.Parameters.AddWithValue("@Designation", designationName);
            cmd.Parameters.AddWithValue("@DepartmentID", departmentID);
            cmd.Parameters.AddWithValue("@DesignationID", designationID);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            LoadUsers();
        }



        private void LoadUsers()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec sp_GetAllEmployeesDesc", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            conn.Close();
        }

        private void LoadDepartments()
        {
            string query = "SELECT DepartmentID, DepartmentName FROM Department WHERE Status = 'Active'";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlDepartment.DataSource = dt;
            ddlDepartment.DataTextField = "DepartmentName";
            ddlDepartment.DataValueField = "DepartmentID";
            ddlDepartment.DataBind();
        }

        private void LoadDesignations()
        {
            string query = "SELECT DesignationID, DesignationName FROM Designation WHERE Status = 'Active'";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlDesignation.DataSource = dt;
            ddlDesignation.DataTextField = "DesignationName";
            ddlDesignation.DataValueField = "DesignationID";
            ddlDesignation.DataBind();
        }


        private void ClearFields()
        {
            txtEmployeeCode.Text = "";
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtContactNo.Text = "";
        }
    }
}
