using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace MEApp.Admin
{
    public partial class UploadForm16 : System.Web.UI.Page
    {
        SqlConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEmployees();
            }
        }

        private void LoadEmployees()
        {
            string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            {
                SqlCommand cmd = new SqlCommand("SELECT EmployeeCode FROM EmployeeProfiles", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlEmpCode.DataSource = dt;
                ddlEmpCode.DataTextField = "EmployeeCode";
                ddlEmpCode.DataValueField = "EmployeeCode";
                ddlEmpCode.DataBind();
                ddlEmpCode.Items.Insert(0, new ListItem("--Select--", ""));


            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            Session["EmpCode"]= ddlEmpCode;
            if (fuForm16.HasFile)
            {
                string folderPath = Server.MapPath("~/Form16/");
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                string fileName = Path.GetFileName(fuForm16.FileName);
                string filePath = folderPath + fileName;
                fuForm16.SaveAs(filePath);

                string relativePath = "~/Form16/" + fileName;

                string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("exec sp_InsertForm16 @EmployeeCode, @FinancialYear, @Form16Path", con);
                    cmd.Parameters.AddWithValue("@EmployeeCode", ddlEmpCode.SelectedValue);
                    cmd.Parameters.AddWithValue("@FinancialYear", txtFinancialYear.Text);
                    cmd.Parameters.AddWithValue("@Form16Path", relativePath);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                //lblMessage.Text = "Form 16 uploaded successfully.";
                //lblMessage.ForeColor = System.Drawing.Color.Green;
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessAlert", "alert('Form 16 uploaded successfully!');", true);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "FileError", "alert('Please select a PDF to upload.');", true);

                //    lblMessage.Text = "Please select a file to upload.";
                //    lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

    }
}