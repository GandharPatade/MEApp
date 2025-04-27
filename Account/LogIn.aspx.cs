using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MEApp.Account
{
	public partial class LogIn : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            //Session.Clear();
            //Session.Abandon();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString);
            conn.Open();

            string email = txtEmail.Text;
            string password = txtPassword.Text;

            SqlCommand cmd = new SqlCommand("exec sp_Login @Email, @Password", conn);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Password", password);


            SqlCommand dmc = new SqlCommand("SELECT * FROM Users WHERE Email = @Email AND Password = @Password", conn);
            dmc.Parameters.AddWithValue("@Email", email);
            dmc.Parameters.AddWithValue("@Password", password);

            SqlDataAdapter da = new SqlDataAdapter(dmc);
            DataSet ds = new DataSet();
            da.Fill(ds);

            SqlCommand dd = new SqlCommand("select * from EmployeeProfiles where Email='"+txtEmail.Text.Trim()+"'", conn);
            SqlDataAdapter dda = new SqlDataAdapter(dd);
            DataSet dds = new DataSet();
            dda.Fill(dds);



            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Session["UserID"] = dr["UserID"].ToString();
                Session["FullName"] = dr["FullName"].ToString();
                Session["Role"] = dr["Role"].ToString();
                Session["Email12"] = ds.Tables[0].Rows[0][2].ToString(); 

                string role = dr["Role"].ToString().ToLower();
                conn.Close();

                if (role == "admin")
                {
                    Response.Redirect("~/Admin/AdminDashboard.aspx");
                }
                else if (role == "user")
                {
                    Session["EmpCode"] = dds.Tables[0].Rows[0][1].ToString();
                    Session["phonenumber"] = dds.Tables[0].Rows[0][3].ToString();
                    Response.Redirect("~/User/UserDashboard.aspx");
                }
                else if (role == "hr")
                {
                    Response.Redirect("~/Hr/hrdashboard.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Unknown Role');</script>");
                }
            }
            else
            {
                conn.Close();
                Response.Write("<script>alert('Invalid credentials');</script>");
            }
        }
    }
}