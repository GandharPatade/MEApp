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
                try
                {
                    string filePath = "~/Documents/" + fileUpload.FileName;
                    fileUpload.SaveAs(Server.MapPath(filePath));

                    string employeeCode = ddlEmployeeCode.SelectedValue;
                    string documentType = txtDocumentType.Text;

                    SqlCommand cmd = new SqlCommand($"exec sp_AddDocument '{employeeCode}', '{documentType}', '{filePath}'", conn);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Response.Write("<script>alert('Document added successfully!');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('{ex.Message}');</script>");
                }
            }
        }
    }
}