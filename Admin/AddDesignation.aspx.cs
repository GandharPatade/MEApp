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
    public partial class AddDesignation : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null || Session["Role"] == null || Session["Role"].ToString() != "Admin")
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void btnAddDesignation_Click(object sender, EventArgs e)
        {
            string designationName= txtDesignation.Text.Trim();

            string status = DropDownList2.SelectedValue;

            if (string.IsNullOrEmpty(designationName))
                return;


            SqlConnection conn = new SqlConnection(cs);
            {
                string query = "INSERT INTO Designation (DesignationName, Status) VALUES (@DesignationName, @Status)";

                SqlCommand cmd = new SqlCommand(query, conn);
                {
                    cmd.Parameters.AddWithValue("@DesignationName", designationName);
                    cmd.Parameters.AddWithValue("@Status", status);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            txtDesignation.Text = "";
                            Response.Write("<script>alert('Designation added successfully.');</script>");
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