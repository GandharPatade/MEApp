using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MEApp.Hr
{
    public partial class AddEvents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string date = txtDate.Text.Trim();
            string status = ddlStatus.SelectedValue;

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(date))
            {
                lblMessage.Text = "Please fill in all fields.";
                return;
            }

            string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "EXEC insertEvnt @title, @date, @status";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@status", status);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            lblMessage.Text = "Event added successfully!";
            txtTitle.Text = "";
            txtDate.Text = "";
            ddlStatus.SelectedIndex = 0;
        }
    }
}