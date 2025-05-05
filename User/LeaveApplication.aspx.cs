//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Data;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Configuration;
//using System.Reflection.Emit;

//namespace MEApp.User
//{
//    public partial class LeaveApplication : System.Web.UI.Page
//    {
//        string connStr = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                //// No session or login validation
//                //SqlConnection conn = new SqlConnection(connStr);
//                //string query = "select * from LeaveRequests where EmployeeCode='" + Session["EmpCode"].ToString() + "'";
//                //SqlCommand mdc = new SqlCommand(query, conn);
//                //SqlDataAdapter da = new SqlDataAdapter(mdc);
//                //DataSet ds = new DataSet();
//                //da.Fill(ds);

//                //GridView1.DataSource = ds;
//                //GridView1.DataBind();
//                string email = Session["Email12"].ToString();

//                SqlConnection conn = new SqlConnection(connStr);
//                SqlCommand cmd = new SqlCommand($"Select EmployeeCode from EmployeeProfiles where Email = '{email}'", conn);

//                conn.Open();
//                SqlDataReader rdr = cmd.ExecuteReader();

//                if (rdr.Read()) 
//                {
//                    txtEmpCode.Text = rdr["EmployeeCode"].ToString();
//                }
//                rdr.Close();


//                LoadLeaveRequests();
//            }

//        }


//        //protected void Button1_Click(object sender, EventArgs e)
//        //{
//        //    string employeeCode = txtEmpCode.Text.Trim();
//        //    string leaveType = DropDownList1.SelectedValue;
//        //    DateTime startDate = DateTime.Parse(TextBox1.Text);
//        //    DateTime endDate = DateTime.Parse(TextBox2.Text);
//        //    string reason = TextBox3.Text;

//        //    if (string.IsNullOrEmpty(employeeCode))
//        //    {
//        //        lblMessage.Text = "Please enter Employee Code.";
//        //        lblMessage.ForeColor = System.Drawing.Color.Red;
//        //        return;
//        //    }



//        //    string query = @"INSERT INTO LeaveRequests 
//        //                    (EmployeeCode, LeaveType, StartDate, EndDate, Reason) 
//        //                    VALUES 
//        //                    (@EmployeeCode, @LeaveType, @StartDate, @EndDate, @Reason)";

//        //    using (SqlConnection conn = new SqlConnection(connStr))
//        //    using (SqlCommand cmd = new SqlCommand(query, conn))
//        //    {
//        //        cmd.Parameters.AddWithValue("@EmployeeCode", employeeCode);
//        //        cmd.Parameters.AddWithValue("@LeaveType", leaveType);
//        //        cmd.Parameters.AddWithValue("@StartDate", startDate);
//        //        cmd.Parameters.AddWithValue("@EndDate", endDate);
//        //        cmd.Parameters.AddWithValue("@Reason", reason);

//        //        conn.Open();
//        //        cmd.ExecuteNonQuery();
//        //    }

//        //    lblMessage.Text = "Leave request submitted successfully.";
//        //    lblMessage.ForeColor = System.Drawing.Color.Green;
//        //    ClearForm();
//        //}

//        protected void Button1_Click(object sender, EventArgs e)
//        {
//            string employeeCode = txtEmpCode.Text.Trim();
//            string leaveType = DropDownList1.SelectedValue;
//            DateTime startDate = DateTime.Parse(TextBox1.Text);
//            DateTime endDate = DateTime.Parse(TextBox2.Text);
//            string reason = TextBox3.Text;

//            if (string.IsNullOrEmpty(employeeCode))
//            {
//                lblMessage.Text = "Please enter Employee Code.";
//                lblMessage.ForeColor = System.Drawing.Color.Red;
//                return;
//            }

//            string query = @"INSERT INTO LeaveRequests 
//                    (EmployeeCode, LeaveType, StartDate, EndDate, Reason) 
//                    VALUES 
//                    (@EmployeeCode, @LeaveType, @StartDate, @EndDate, @Reason)";

//            using (SqlConnection conn = new SqlConnection(connStr))
//            using (SqlCommand cmd = new SqlCommand(query, conn))
//            {
//                cmd.Parameters.AddWithValue("@EmployeeCode", employeeCode);
//                cmd.Parameters.AddWithValue("@LeaveType", leaveType);
//                cmd.Parameters.AddWithValue("@StartDate", startDate);
//                cmd.Parameters.AddWithValue("@EndDate", endDate);
//                cmd.Parameters.AddWithValue("@Reason", reason);

//                conn.Open();
//                cmd.ExecuteNonQuery();
//            }

//            lblMessage.Text = "Leave request submitted successfully.";
//            lblMessage.ForeColor = System.Drawing.Color.Green;
//            ClearForm();
//            LoadLeaveRequests();  // <-- Load updated GridView data
//        }


//        private void LoadLeaveRequests()
//        {
//            using (SqlConnection conn = new SqlConnection(connStr))
//            {
//                string query = "SELECT * FROM LeaveRequests WHERE EmployeeCode = @EmpCode";
//                SqlCommand cmd = new SqlCommand(query, conn);
//                cmd.Parameters.AddWithValue("@EmpCode", Session["EmpCode"].ToString());

//                SqlDataAdapter da = new SqlDataAdapter(cmd);
//                DataSet ds = new DataSet();
//                da.Fill(ds);

//                GridView1.DataSource = ds;
//                GridView1.DataBind();
//            }
//        }



//        private void ClearForm()
//        {
//            txtEmpCode.Text = "";
//            DropDownList1.SelectedIndex = 0;
//            TextBox1.Text = "";
//            TextBox2.Text = "";
//            TextBox3.Text = "";
//        }


//    }
//}








using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Reflection.Emit;

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
                string email = Session["Email12"].ToString();

                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand($"Select EmployeeCode from EmployeeProfiles where Email = '{email}'", conn);

                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    txtEmpCode.Text = rdr["EmployeeCode"].ToString();
                }
                rdr.Close();


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

            int requestedDays = (endDate - startDate).Days + 1;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Get total leave days already taken this year
                string totalLeavesQuery = @"
            SELECT ISNULL(SUM(DATEDIFF(DAY, StartDate, EndDate) + 1), 0)
            FROM LeaveRequests
            WHERE EmployeeCode = @EmployeeCode
              AND YEAR(StartDate) = YEAR(GETDATE())
        ";

                SqlCommand leaveCountCmd = new SqlCommand(totalLeavesQuery, conn);
                leaveCountCmd.Parameters.AddWithValue("@EmployeeCode", employeeCode);

                int leaveTaken = Convert.ToInt32(leaveCountCmd.ExecuteScalar());

                if (leaveTaken + requestedDays > 14)
                {
                    lblMessage.Text = $"Leave limit exceeded! You have already taken {leaveTaken} days. Requested {requestedDays} more.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                // Insert the leave request
                string insertQuery = @"INSERT INTO LeaveRequests 
                    (EmployeeCode, LeaveType, StartDate, EndDate, Reason) 
                    VALUES 
                    (@EmployeeCode, @LeaveType, @StartDate, @EndDate, @Reason)";

                SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@EmployeeCode", employeeCode);
                insertCmd.Parameters.AddWithValue("@LeaveType", leaveType);
                insertCmd.Parameters.AddWithValue("@StartDate", startDate);
                insertCmd.Parameters.AddWithValue("@EndDate", endDate);
                insertCmd.Parameters.AddWithValue("@Reason", reason);

                insertCmd.ExecuteNonQuery();
            }

            lblMessage.Text = "Leave request submitted successfully.";
            lblMessage.ForeColor = System.Drawing.Color.Green;
            ClearForm();
            LoadLeaveRequests();
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