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

        SqlConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
                con = new SqlConnection(cs);
                LoadForm16Documents();
            }
        }

        private void LoadForm16Documents()
        {
            string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            {
                SqlCommand cmd = new SqlCommand("exec sp_GetForm16Details", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridViewForm16.DataSource = dt;
                GridViewForm16.DataBind();
            }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string employeeCode = btn.CommandArgument;

            string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"exec sp_GetForm16Path '{employeeCode}'", con);

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