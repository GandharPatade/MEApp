using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
            if (!IsPostBack)
            {
                string name = Session["fullname"].ToString();
                string email = Session["email"].ToString();

                txtEmail.Text = email;
                txtFullName.Text = name;

                LoadUsers();

                //string naam = Request.QueryString["name"];
                //string email12 = Request.QueryString["email"];

                //txtEmail.Text = email12;
                //txtFullName.Text = naam;
            }
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
