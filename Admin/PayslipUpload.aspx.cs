using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MEApp.Admin
{
    public partial class PayslipUpload_aspx : System.Web.UI.Page
    {
        SqlConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
            con = new SqlConnection(cs);

            BindPayslips();
            if (!IsPostBack)
            {
                LoadEmployees();
            }
        }

        private void LoadEmployees()
        {
            SqlCommand cmd = new SqlCommand("SELECT EmployeeCode FROM EmployeeProfiles", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            ddlEmpCode.DataSource = dt;
            ddlEmpCode.DataTextField = "EmployeeCode";
            ddlEmpCode.DataValueField = "EmployeeCode";
            ddlEmpCode.DataBind();
            ddlEmpCode.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", ""));
        }

        private void BindPayslips()
        {
            //if (Session["Role"] == null || Session["empCode"] == null)
            //{
            //    Response.Redirect("~/Login.aspx"); 
            //    return;
            //}
            SqlCommand cmd;

            string role = Session["Role"].ToString();
            //string empCode = Session["empCode"].ToString();

            if (role == "Admin")
            {
                cmd = new SqlCommand("select EmployeeCode, FullName, Email, Department, Designation, ContactNo from EmployeeProfiles", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();

                GridViewPayslips.DataSource = dt;
                GridViewPayslips.DataBind();
            }
            //else
            //{
            //    cmd = new SqlCommand($"exec sp_GetPayslipsByEmp '{empCode}'", con);
            //}
        }

        private int GetPresentDays(string empCode, int month, int year)
        {
            int presentDays = 0;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetMonthlyAttendanceSummaryByEmpCode", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeCode", empCode);
                cmd.Parameters.AddWithValue("@Month", month);
                cmd.Parameters.AddWithValue("@Year", year);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    presentDays = reader["PresentCount"] != DBNull.Value ? Convert.ToInt32(reader["PresentCount"]) : 0;
                }
            }
            return presentDays;
        }


        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //try
            //{
            string empCode = ddlEmpCode.SelectedValue;
            string financialYear = txtFinancialYear.Text;
            decimal salary;
            if (!decimal.TryParse(txtSalary.Text, out salary))
            {
                throw new Exception("Invalid salary format. Please enter a valid number.");
            }

            DateTime today = DateTime.Today;
            int month = today.Month;
            int year = today.Year;
            int workingDays = 26;
            int presentDays = GetPresentDays(empCode, month, year);

            decimal perDaySalary = salary / workingDays;
            decimal earnedSalary = perDaySalary * presentDays;
            decimal pf = earnedSalary * 0.12m;


            string htmlContent = $@"
            <h1>Payslip</h1>
            <p>Employee Code: {empCode}</p>
            <p>Financial Year: {financialYear}</p>
            <p>Total Salary (for full month): ₹{salary:N2}</p>
            <p>Days Present: {presentDays} / {workingDays}</p>
            <p>Salary Earned: ₹{earnedSalary:N2}</p>
            <p>Provident Fund (12%): ₹{pf:N2}</p>
            <p>Date Generated: {DateTime.Now.ToShortDateString()}</p>
        ";

            byte[] pdfBytes = GeneratePdfFromHtml(htmlContent);

            string fileName = $"Payslip_{empCode}_{financialYear}.pdf";
            string folderPath = Server.MapPath("~/Payslip/");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, fileName);
            File.WriteAllBytes(filePath, pdfBytes);

            string relativePath = "~/Payslip/" + fileName;

            // Database and email operations
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString);
            con.Open();

            // Insert data into database
            SqlCommand cmd = new SqlCommand($"exec sp_InsertPayslip '{empCode}', '{financialYear}', '{salary}', '{pf}', '{relativePath}'", con);
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
                        EmailHelper.SendEmail(email, "Payslip Generated", "Please find the Payslip attached.", filePath);
                    }
                    else
                    {
                        throw new Exception("Payslip not found at " + filePath);
                    }
                }
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessAlert", "alert('Payslip generated and uploaded successfully!');", true);
            //}
            //catch (Exception ex)
            //{
            //    Response.Write($"<script>alert('{ex.Message}')</script>");
            //}
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