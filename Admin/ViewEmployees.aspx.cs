using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MEApp.Admin
{
    public partial class ViewEmployees : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEmployees();
            }
        }

        private void LoadEmployees()
        {
            SqlDataAdapter da = new SqlDataAdapter("EXEC sp_GetAllEmployees", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridViewEmployees.DataSource = dt;
            GridViewEmployees.DataBind();
        }


        protected void GridViewEmployees_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewEmployees.EditIndex = e.NewEditIndex; 
            LoadEmployees();
        }

        protected void GridViewEmployees_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewEmployees.EditIndex = -1;
            LoadEmployees();
        }

        protected void GridViewEmployees_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int empID = Convert.ToInt32(GridViewEmployees.DataKeys[e.RowIndex].Value);
            GridViewRow row = GridViewEmployees.Rows[e.RowIndex];

            string fullName = ((TextBox)row.Cells[1].Controls[0]).Text;
            string email = ((TextBox)row.Cells[2].Controls[0]).Text;
            string contact = ((TextBox)row.Cells[3].Controls[0]).Text;
            string dept = ((TextBox)row.Cells[4].Controls[0]).Text;
            string desig = ((TextBox)row.Cells[5].Controls[0]).Text;

            try
            {
                string query = $"exec sp_UpdateEmployee '{empID}', '{fullName}', '{email}', '{contact}', '{dept}', '{desig}'";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                lblMessage.Text = "Employee updated successfully.";
                GridViewEmployees.EditIndex = -1;
                LoadEmployees();
            }
            catch (Exception ex) 
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }

        }

        protected void GridViewEmployees_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int empID = Convert.ToInt32(GridViewEmployees.DataKeys[e.RowIndex].Value);
                SqlCommand cmd = new SqlCommand($"EXEC sp_DeleteEmployee '{empID}'", con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                lblMessage.Text = "Employee deleted.";
                LoadEmployees();
            }
            catch (Exception ex) 
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }   
        }

    }
}