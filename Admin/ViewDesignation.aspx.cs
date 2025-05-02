using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MEApp.Admin
{
    public partial class ViewDesignation : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
            if (Session["UserID"] == null || Session["Role"] == null || Session["Role"].ToString() != "Admin")
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && GridView1.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddlStatus = (DropDownList)e.Row.FindControl("ddlStatus");
                string currentStatus = DataBinder.Eval(e.Row.DataItem, "Status").ToString();

                if (ddlStatus != null)
                {
                    ddlStatus.SelectedValue = currentStatus;
                }
            }
        }


        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string desigName = GridView1.DataKeys[e.RowIndex].Value.ToString();
            GridViewRow row = GridView1.Rows[e.RowIndex];

            DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
            string newStatus = ddlStatus.SelectedValue;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "UPDATE Designation SET Status = @Status WHERE DesignationName = @DesignationName";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Status", newStatus);
                cmd.Parameters.AddWithValue("@DesignationName", desigName);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string desigName = GridView1.DataKeys[e.RowIndex].Value.ToString();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "DELETE FROM Designation WHERE DesignationName = @DesignationName";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DesignationName", desigName);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            BindGrid();
        }

        private void BindGrid()
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("select DesignationName, Status from Designation", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            conn.Close();
        }
    }
}