using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;

namespace MEApp.User
{
    public partial class Form16access : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadForm16Documents();
            }
        }

        private void LoadForm16Documents()
        {
            string empCode = Session["EmpCode"] as string;

            if (string.IsNullOrEmpty(empCode))
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = @"SELECT Form16ID, EmployeeCode, FinancialYear, Salary, PF, Form16Path, CreatedAt 
                                 FROM Form16 
                                 WHERE EmployeeCode = @EmployeeCode 
                                 ORDER BY CreatedAt DESC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@EmployeeCode", empCode);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridViewForm16.DataSource = dt;
                    GridViewForm16.DataBind();
                }
            }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string filePath = btn.CommandArgument;
            string fullPath = Server.MapPath(filePath);

            if (System.IO.File.Exists(fullPath))
            {
                Response.ContentType = "application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(fullPath));
                Response.TransmitFile(fullPath);
                Response.End();
            }
            else
            {
                Response.Write("<script>alert('File not found!');</script>");
            }
        }

    }
}