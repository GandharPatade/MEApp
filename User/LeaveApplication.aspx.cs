using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace MEApp.User
{
    public partial class LeaveApplication : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //// No session or login validation
                //SqlConnection conn = new SqlConnection(connStr);
                //string query = "select * from LeaveRequests where EmployeeCode='" + Session["EmpCode"].ToString() + "'";
                //SqlCommand mdc = new SqlCommand(query, conn);
                //SqlDataAdapter da = new SqlDataAdapter(mdc);
                //DataSet ds = new DataSet();
                //da.Fill(ds);

                //GridView1.DataSource = ds;
                //GridView1.DataBind();

                LoadLeaveRequests();
            }
            
        }


        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    string employeeCode = txtEmpCode.Text.Trim();
        //    string leaveType = DropDownList1.SelectedValue;
        //    DateTime startDate = DateTime.Parse(TextBox1.Text);
        //    DateTime endDate = DateTime.Parse(TextBox2.Text);
        //    string reason = TextBox3.Text;

        //    if (string.IsNullOrEmpty(employeeCode))
        //    {
        //        lblMessage.Text = "Please enter Employee Code.";
        //        lblMessage.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }



        //    string query = @"INSERT INTO LeaveRequests 
        //                    (EmployeeCode, LeaveType, StartDate, EndDate, Reason) 
        //                    VALUES 
        //                    (@EmployeeCode, @LeaveType, @StartDate, @EndDate, @Reason)";

        //    using (SqlConnection conn = new SqlConnection(connStr))
        //    using (SqlCommand cmd = new SqlCommand(query, conn))
        //    {
        //        cmd.Parameters.AddWithValue("@EmployeeCode", employeeCode);
        //        cmd.Parameters.AddWithValue("@LeaveType", leaveType);
        //        cmd.Parameters.AddWithValue("@StartDate", startDate);
        //        cmd.Parameters.AddWithValue("@EndDate", endDate);
        //        cmd.Parameters.AddWithValue("@Reason", reason);

        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }

        //    lblMessage.Text = "Leave request submitted successfully.";
        //    lblMessage.ForeColor = System.Drawing.Color.Green;
        //    ClearForm();
        //}

        protected void Button1_Click(object sender, EventArgs e)
        {
            string employeeCode = txtEmpCode.Text.Trim();
            string leaveType = DropDownList1.SelectedValue;
            DateTime startDate = DateTime.Parse(TextBox1.Text);
            DateTime endDate = DateTime.Parse(TextBox2.Text);
            string reason = TextBox3.Text;

            if (string.IsNullOrEmpty(employeeCode))
            {
                lblMessage.Text = "Please enter Employee Code.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string query = @"INSERT INTO LeaveRequests 
                    (EmployeeCode, LeaveType, StartDate, EndDate, Reason) 
                    VALUES 
                    (@EmployeeCode, @LeaveType, @StartDate, @EndDate, @Reason)";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@EmployeeCode", employeeCode);
                cmd.Parameters.AddWithValue("@LeaveType", leaveType);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                cmd.Parameters.AddWithValue("@Reason", reason);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            lblMessage.Text = "Leave request submitted successfully.";
            lblMessage.ForeColor = System.Drawing.Color.Green;
            ClearForm();
            LoadLeaveRequests();  // <-- Load updated GridView data
        }


        private void LoadLeaveRequests()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM LeaveRequests WHERE EmployeeCode = @EmpCode";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmpCode", Session["EmpCode"].ToString());

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }



        private void ClearForm()
        {
            txtEmpCode.Text = "";
            DropDownList1.SelectedIndex = 0;
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
        }


    }
}