using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MEApp.User
{
    public partial class PayslipAccess : System.Web.UI.Page
    {
        SqlConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
            con = new SqlConnection(cs);

            if (!IsPostBack)
            {
                BindPayslips();
            }
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
                cmd = new SqlCommand("exec sp_GetAllPayslips", con);
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

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string employeeCode = btn.CommandArgument;

            string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"exec sp_GetPayslipPath '{employeeCode}'", con);

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string filePath = result.ToString();
                    string fullFilePath = Server.MapPath(filePath);

                    if (System.IO.File.Exists(fullFilePath))
                    {
                        Response.ContentType = "application/pdf";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(fullFilePath));
                        Response.TransmitFile(fullFilePath);
                        Response.End();
                    }
                    else
                    {
                        Response.Write("<script>alert('File not found!');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('No file path available!');</script>");
                }
            }
        }
    }
}