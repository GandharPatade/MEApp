using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MEApp.User
{
	public partial class UserDashboard : System.Web.UI.Page
	{
        SqlConnection conn;
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                Label2.Text = Session["Email12"].ToString();
                
                string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
                SqlConnection conn = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand($"Select FullName, ContactNo from EmployeeProfiles where Email = '{Label2.Text}'", conn);

                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    Label1.Text = rdr["FullName"].ToString();
                    Label3.Text = rdr["ContactNo"].ToString();
                }
                
                rdr.Close();
            }
            

        }
	}
}