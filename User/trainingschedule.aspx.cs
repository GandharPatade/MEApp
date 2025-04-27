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
    public partial class trainingschedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Training", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                TrainingGridView.DataSource = dt;
                TrainingGridView.DataBind();
            }
        }


        protected void TrainingGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            TrainingGridView.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void TrainingGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            TrainingGridView.EditIndex = -1;
            BindGrid();
        }

        protected void TrainingGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int trainingId = Convert.ToInt32(TrainingGridView.DataKeys[e.RowIndex].Value);

            string title = ((TextBox)TrainingGridView.Rows[e.RowIndex].FindControl("EditTitleTextBox")).Text;
            string description = ((TextBox)TrainingGridView.Rows[e.RowIndex].FindControl("EditDescriptionTextBox")).Text;
            string status = ((DropDownList)TrainingGridView.Rows[e.RowIndex].FindControl("EditStatusDropDown")).SelectedValue;
            string url = ((TextBox)TrainingGridView.Rows[e.RowIndex].FindControl("EditURLTextBox")).Text;

            string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            {
                try
                {
                    SqlCommand cmd = new SqlCommand($"exec sp_updateTraining '{trainingId}', '{title}', '{description}', '{status}', '{url}'", conn);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('{ex.Message}')</script>");
                }
            }

            TrainingGridView.EditIndex = -1;
            BindGrid();
        }

        protected void TrainingGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int trainingId = Convert.ToInt32(TrainingGridView.DataKeys[e.RowIndex].Value);

            string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Training WHERE TrainingID = @TrainingID", conn);
                    cmd.Parameters.AddWithValue("@TrainingID", trainingId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('{ex.Message}')</script>");
                }
            }

            BindGrid();
        }

        protected void TrainingGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && TrainingGridView.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddl = (DropDownList)e.Row.FindControl("EditStatusDropDown");
                string status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();

                if (ddl != null)
                {
                    ddl.SelectedValue = status;
                }
            }
        }
    }
}