
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
	public partial class SalaryStructure : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                LoadStructures();
            }
        }

        void LoadStructures()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM SalaryStructure", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvStructure.DataSource = dt;
            gvStructure.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SP_InsertUpdateSalaryStructure", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StructureID", string.IsNullOrEmpty(hfStructureID.Value) ? (object)DBNull.Value : hfStructureID.Value);
                cmd.Parameters.AddWithValue("@Role", txtRole.Text);
                cmd.Parameters.AddWithValue("@BasicSalary", txtBasic.Text);
                cmd.Parameters.AddWithValue("@HRA", txtHRA.Text);
                cmd.Parameters.AddWithValue("@Allowances", txtAllowances.Text);
                cmd.Parameters.AddWithValue("@Deductions", txtDeductions.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                ClearFields();
                LoadStructures();
            }
            catch(Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }
        }

        protected void gvStructure_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "editRow" || e.CommandName == "deleteRow")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                if (rowIndex >= 0 && rowIndex < gvStructure.Rows.Count)
                {
                    int id = Convert.ToInt32(gvStructure.DataKeys[rowIndex].Value);

                    if (e.CommandName == "editRow")
                    {
                        GridViewRow row = gvStructure.Rows[rowIndex];
                        hfStructureID.Value = id.ToString();
                        txtRole.Text = row.Cells[1].Text;
                        txtBasic.Text = row.Cells[2].Text;
                        txtHRA.Text = row.Cells[3].Text;
                        txtAllowances.Text = row.Cells[4].Text;
                        txtDeductions.Text = row.Cells[5].Text;
                    }
                    else if (e.CommandName == "deleteRow")
                    {
                        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString);
                        SqlCommand cmd = new SqlCommand("DELETE FROM SalaryStructure WHERE StructureID=@id", con);
                        cmd.Parameters.AddWithValue("@id", id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        LoadStructures();
                    }
                }
            }
        }

        void ClearFields()
        {
            txtRole.Text = txtBasic.Text = txtHRA.Text = txtAllowances.Text = txtDeductions.Text = "";
            hfStructureID.Value = "";
        }
    }
}