using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing.Printing;
using System.IO;
using System.Xml.Linq;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text;

namespace MEApp.Admin
{
    public partial class UserList : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null || Session["Role"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadUsers();
            }
        }

        private void LoadUsers()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec sp_GetAllUsers", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvUsers.DataSource = dt;
            gvUsers.DataBind();
            conn.Close();
        }

        protected void gvUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUsers.EditIndex = e.NewEditIndex;
            LoadUsers();
        }

        protected void gvUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUsers.EditIndex = -1;
            LoadUsers();
        }

        protected void gvUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int userID = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value);

            GridViewRow row = gvUsers.Rows[e.RowIndex];
            string fullName = ((TextBox)row.Cells[1].Controls[0]).Text;
            string email = ((TextBox)row.Cells[2].Controls[0]).Text;
            string role = ((DropDownList)row.FindControl("ddlRole")).SelectedValue;

            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand($"exec sp_UpdateUserByAdmin '{userID}', '{fullName}', '{email}', '{role}'", conn);

                cmd.ExecuteNonQuery();
                conn.Close();

                gvUsers.EditIndex = -1;
                LoadUsers();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }
        }

        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userID = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value);

            conn.Open();
            SqlCommand cmd = new SqlCommand($"exec sp_DeleteUser '{userID}'", conn);

            cmd.ExecuteNonQuery();
            conn.Close();

            LoadUsers();
        }


        protected void btnExportPdf_Click(object sender, EventArgs e)
        {
            GridView gvExport = new GridView();
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec sp_GetAllUsers", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            gvExport.DataSource = dt;
            gvExport.DataBind();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=UserList.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gvExport.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());

            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
            pdfDoc.Close();
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            // Confirms that an ASP.NET server control is rendered for the HtmlForm control at run time.
        }


    }
}