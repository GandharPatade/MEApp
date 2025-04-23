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

            SqlCommand cmd = new SqlCommand("exec sp_AddUserByAdmin @FullName, @Email, @Password, @Role", conn);
            cmd.Parameters.AddWithValue("@FullName", txtName.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@Role", ddlRole.SelectedValue);

            Session["Fullname"] = txtName.Text;
            Session["Email"] = txtEmail.Text;

            int result = cmd.ExecuteNonQuery();

            if (result > 0)
            {
                Response.Redirect("AddEmployee.aspx");
            }
            else
            {
                Response.Write("<script>alert('Error: User not registered.');</script>");
            }

            conn.Close();
        }
    }
}