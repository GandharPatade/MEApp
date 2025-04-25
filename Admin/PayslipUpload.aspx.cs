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
            ddlEmpCode.Items.Insert(0, new ListItem("--Select--", ""));
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fuPayslip.HasFile)
            {
                string saveDir = Server.MapPath("~/Admin/Payslip/");
                if (!Directory.Exists(saveDir))
                {
                    Directory.CreateDirectory(saveDir);
                }

                string fileName = Path.GetFileName(fuPayslip.FileName);
                string savePath = Path.Combine(saveDir, fileName);
                fuPayslip.SaveAs(savePath);
                string empCode = ddlEmpCode.SelectedValue;
                string monthYear = txtMonthYear.Text;
                string salaryAmount = txtAmount.Text;

                SqlCommand cmd = new SqlCommand($"exec sp_InsertPayslip '{empCode}', '{monthYear}','{salaryAmount}', @PayslipFile", con);
                
                cmd.Parameters.AddWithValue("@PayslipFile", "Payslip/" + fileName);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                btnUpload.Text = "Payslip uploaded successfully.";
                btnUpload.Attributes["style"] = "color:black;";

                string to = "";
                SqlCommand emailCmd = new SqlCommand("SELECT Email FROM EmployeeProfiles WHERE EmployeeCode = @EmpCode", con);
                emailCmd.Parameters.AddWithValue("@EmpCode", ddlEmpCode.SelectedValue);

                con.Open();
                SqlDataReader reader = emailCmd.ExecuteReader();
                if (reader.Read())
                {
                    to = reader["Email"].ToString();
                }
                con.Close();

                if (!string.IsNullOrEmpty(to))
                {
                    string subject = "Your Monthly Payslip";
                    string body = "Dear Employee, your payslip for this month is attached.";

                    List<HttpPostedFile> files = new List<HttpPostedFile>();
                    if (fuPayslip.HasFiles)
                    {
                        foreach (HttpPostedFile file in fuPayslip.PostedFiles)
                        {
                            files.Add(file);
                        }
                    }

                    EmailHelper.SendEmail(to, subject, body, files);
                }
                else
                {
                    Response.Write("<script>alert('Employee email not found. Please check EmployeeProfiles table.');</script>");
                }
            }
            else
            {
                btnUpload.Text = "Please upload a file.";
                btnUpload.Attributes["style"] = "color:red;";
            }
        }

    }


}