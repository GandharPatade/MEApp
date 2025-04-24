using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MEApp.User
{
    public partial class UserDocumentAccess : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadForm16();
                LoadPayslips();
            }
        }



        public void LoadForm16()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM Form16Documents where EmployeeCode='"+ Session["EmpCode"].ToString()+ "'";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvForm16.DataSource = dt;
                gvForm16.DataBind();
            }
        }

        public void LoadPayslips()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM Payslips where EmployeeCode='"+ Session["EmpCode"].ToString()+ "'";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvPayslips.DataSource = dt;
                gvPayslips.DataBind();
            }
        }


        protected void gvForm16_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DownloadForm16")
            {
                string filePath = Server.MapPath(e.CommandArgument.ToString());
                DownloadFile(filePath);
            }
        }

        protected void gvPayslips_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DownloadPayslip")
            {
                string filePath = Server.MapPath(e.CommandArgument.ToString());
                DownloadFile(filePath);
            }
        }

        public void DownloadFile(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                string fileName = System.IO.Path.GetFileName(filePath);
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.TransmitFile(filePath);
                Response.End();
            }
            else
            {
                Response.Write("<script>alert('File not found.');</script>");
            }

        }
    }
}