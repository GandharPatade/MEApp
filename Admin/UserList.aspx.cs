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
            SqlCommand cmd = new SqlCommand("exec sp_UpdateUserByAdmin @UserID, @FullName, @Email, @Role", conn);
            cmd.Parameters.AddWithValue("@UserID", userID);
            cmd.Parameters.AddWithValue("@FullName", fullName);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Role", role);
            cmd.ExecuteNonQuery();
            conn.Close();

            gvUsers.EditIndex = -1;
            LoadUsers();
        }

        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userID = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value);

            conn.Open();
            SqlCommand cmd = new SqlCommand("exec sp_DeleteUser @UserID", conn);
            cmd.Parameters.AddWithValue("@UserID", userID);
            cmd.ExecuteNonQuery();
            conn.Close();

            LoadUsers();
        }

       
        

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=FileList.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);


            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gvUsers.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());


            iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10f, 10f, 10f, 10f);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
            pdfDoc.Close();


            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            // Required for Export to work
        }
    }
}