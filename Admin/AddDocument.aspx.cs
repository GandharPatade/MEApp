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
    public partial class AddDocument : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEmployeeCodes();
            }

        }

        private void LoadEmployeeCodes()
        {
            //SqlConnection conn = new SqlConnection(conn);
            SqlDataAdapter da = new SqlDataAdapter("SELECT EmployeeCode FROM EmployeeProfiles", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ddlEmployeeCode.DataSource = dt;
            ddlEmployeeCode.DataTextField = "EmployeeCode";
            ddlEmployeeCode.DataValueField = "EmployeeCode";
            ddlEmployeeCode.DataBind();

            conn.Close();
        }

        protected void btnAddDocument_Click(object sender, EventArgs e)
        {
            if (fileUpload.HasFile)
            {
                string filePath = "~/Documents/" + fileUpload.FileName;
                fileUpload.SaveAs(Server.MapPath(filePath));

                string employeeCode = ddlEmployeeCode.SelectedValue;
                string documentType = txtDocumentType.Text;

                // Call Stored Procedure to Add Document
                //SqlConnection conn = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand("sp_AddDocument", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeCode", employeeCode);
                cmd.Parameters.AddWithValue("@DocumentType", documentType);
                cmd.Parameters.AddWithValue("@FilePath", filePath);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                // Optional: Display success message or redirect
                Response.Write("<script>alert('Document added successfully!');</script>");
            }
        }
    }
}