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
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;


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
                ddlEmpCode.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", ""));


            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                string empCode = ddlEmpCode.SelectedValue;
                string financialYear = txtFinancialYear.Text;
                decimal salary;
                if (!decimal.TryParse(txtSalary.Text, out salary))
                {
                    throw new Exception("Invalid salary format. Please enter a valid number.");
                }

                decimal pf = salary * 0.12m;

                string htmlContent = $@"
            <h1>Form 16</h1>
            <p>Employee Code: {empCode}</p>
            <p>Financial Year: {financialYear}</p>
            <p>Salary: ₹{salary:N2}</p>
            <p>Provident Fund (12%): ₹{pf:N2}</p>
            <p>Date Generated: {DateTime.Now.ToShortDateString()}</p>
        ";

                byte[] pdfBytes = GeneratePdfFromHtml(htmlContent);

                string fileName = $"Form16_{empCode}_{financialYear}.pdf";
                string folderPath = Server.MapPath("~/Form16/");
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                string filePath = Path.Combine(folderPath, fileName);
                File.WriteAllBytes(filePath, pdfBytes);

                string relativePath = "~/Form16/" + fileName;

                // Database and email operations
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString);
                con.Open();

                // Insert data into database
                SqlCommand cmd = new SqlCommand($"exec sp_InsertForm16 '{empCode}', '{financialYear}', '{salary}', '{pf}', '{relativePath}'", con);
                cmd.ExecuteNonQuery();

                // Fetch email and send the email
                SqlCommand emailCmd = new SqlCommand("SELECT Email FROM EmployeeProfiles WHERE EmployeeCode = @EmployeeCode", con);
                emailCmd.Parameters.AddWithValue("@EmployeeCode", empCode);
                SqlDataReader rdr = emailCmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        string email = rdr["Email"].ToString();
                        if (File.Exists(filePath))
                        {
                            EmailHelper.SendEmail(email, "Form 16 Generated", "Please find the Form 16 attached.", filePath);
                        }
                        else
                        {
                            throw new Exception("Form 16 PDF not found at " + filePath);
                        }
                    }
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessAlert", "alert('Form 16 generated and uploaded successfully!');", true);
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }
        }


        private byte[] GeneratePdfFromHtml(string htmlContent)
        {
            MemoryStream memoryStream = new MemoryStream();
            {
                Document document = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                StringReader stringReader = new StringReader(htmlContent);
                {
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, stringReader);
                }

                document.Close();
                return memoryStream.ToArray();
            }
        }

    }
}