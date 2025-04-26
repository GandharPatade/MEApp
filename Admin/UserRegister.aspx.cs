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
    public partial class UserRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null || Session["Role"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString);
            conn.Open();

            Session["fullname"] = txtName.Text;
            Session["email"] = txtEmail.Text;

            string fullname = txtName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string role = ddlRole.SelectedValue;

            try
            {
                SqlCommand cmd = new SqlCommand($"exec sp_AddUserByAdmin '{fullname}', '{email}', '{password}', '{role}'", conn);

                int result = cmd.ExecuteNonQuery();

                if (result > 0 && role == "User" || role == "HR")
                { 
                    Response.Redirect($"../Admin/AddEmployee.aspx?name={txtName.Text.Trim()}&email={txtEmail.Text.Trim()}");
                }
                else if(result > 0 && role == "Admin")
                {
                    Response.Redirect("AdminDashboard.aspx");
                }
                else 
                {
                    Response.Write("<script>alert('Error: User not registered.');</script>");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }
        }
    }
}