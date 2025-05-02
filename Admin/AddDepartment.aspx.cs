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
    public partial class AddDepartment : System.Web.UI.Page
    {
        string cs =ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null || Session["Role"] == null || Session["Role"].ToString() != "Admin")
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void btnAddDepartment_Click(object sender, EventArgs e)
        {
            string departmentName = txtDepartmentName.Text.Trim();
            string status = DropDownList1.SelectedValue;
            if (string.IsNullOrEmpty(departmentName))
                return;


            SqlConnection conn = new SqlConnection(cs);
            {
                string query = "INSERT INTO Department (DepartmentName, Status) VALUES (@DepartmentName, @Status)";

                SqlCommand cmd = new SqlCommand(query, conn);
                {
                    cmd.Parameters.AddWithValue("@DepartmentName", departmentName);
                    cmd.Parameters.AddWithValue("@Status", status);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            txtDepartmentName.Text = "";
                            Response.Write("<script>alert('Department added successfully.');</script>");
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                    }
                }
            }
        }

    }
}