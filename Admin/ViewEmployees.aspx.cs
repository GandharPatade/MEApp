using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

            // Get department and designation IDs from the data key
            object deptIdObj = GridViewEmployees.DataKeys[e.NewEditIndex]["DepartmentID"];
            object desIdObj = GridViewEmployees.DataKeys[e.NewEditIndex]["DesignationID"];

            string deptId = deptIdObj != DBNull.Value ? deptIdObj.ToString() : "";
            string desId = desIdObj != DBNull.Value ? desIdObj.ToString() : "";

            // Find dropdowns in the GridView row being edited
            DropDownList ddlDept = (DropDownList)GridViewEmployees.Rows[e.NewEditIndex].FindControl("ddlDepartment");
            DropDownList ddlDes = (DropDownList)GridViewEmployees.Rows[e.NewEditIndex].FindControl("ddlDesignation");

            // Load data into the dropdowns
            LoadDepartments(ddlDept, deptId);
            LoadDesignations(ddlDes, desId);
        }

        protected void GridViewEmployees_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewEmployees.EditIndex = -1;
            LoadEmployees();
        }

        protected void GridViewEmployees_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewEmployees.Rows[e.RowIndex];

            string employeeCode = GridViewEmployees.DataKeys[e.RowIndex]["EmployeeCode"].ToString();

            string fullName = ((TextBox)row.Cells[1].Controls[0]).Text;
            string email = ((TextBox)row.Cells[2].Controls[0]).Text;
            string contactNo = ((TextBox)row.Cells[3].Controls[0]).Text;

            DropDownList ddlDept = (DropDownList)row.FindControl("ddlDepartment");
            DropDownList ddlDes = (DropDownList)row.FindControl("ddlDesignation");

            int departmentID = 0;
            int designationID = 0;

            if (ddlDept != null && !string.IsNullOrEmpty(ddlDept.SelectedValue))
            {
                int.TryParse(ddlDept.SelectedValue, out departmentID);
            }

            if (ddlDes != null && !string.IsNullOrEmpty(ddlDes.SelectedValue))
            {
                int.TryParse(ddlDes.SelectedValue, out designationID);
            }

            string updateQuery = "UPDATE EmployeeProfiles SET FullName = @FullName, Email = @Email, ContactNo = @ContactNo, DepartmentID = @DepartmentID, DesignationID = @DesignationID WHERE EmployeeCode = @EmployeeCode";

            SqlCommand cmd = new SqlCommand(updateQuery, con);
            cmd.Parameters.AddWithValue("@FullName", fullName);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@ContactNo", contactNo);
            cmd.Parameters.AddWithValue("@DepartmentID", departmentID);
            cmd.Parameters.AddWithValue("@DesignationID", designationID);
            cmd.Parameters.AddWithValue("@EmployeeCode", employeeCode);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            GridViewEmployees.EditIndex = -1;
            LoadEmployees();
        }

        protected void GridViewEmployees_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string empCode = GridViewEmployees.DataKeys[e.RowIndex]["EmployeeCode"].ToString();
                SqlCommand cmd = new SqlCommand("EXEC sp_DeleteEmployee @EmployeeCode", con);
                cmd.Parameters.AddWithValue("@EmployeeCode", empCode);

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

        protected void LoadDepartments(DropDownList ddlDepartment, string selectedValue)
        {
            SqlCommand cmd = new SqlCommand("SELECT DepartmentID, DepartmentName FROM Department WHERE Status = 'Active'", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            con.Close();

            ddlDepartment.DataSource = dt;
            ddlDepartment.DataTextField = "DepartmentName";
            ddlDepartment.DataValueField = "DepartmentID";
            ddlDepartment.DataBind();

            ddlDepartment.Items.Insert(0, new ListItem("--Select Department--", ""));

            if (!string.IsNullOrEmpty(selectedValue))
            {
                ddlDepartment.SelectedValue = selectedValue;
            }
        }

        protected void LoadDesignations(DropDownList ddlDesignation, string selectedValue)
        {
            SqlCommand cmd = new SqlCommand("SELECT DesignationID, DesignationName FROM Designation WHERE Status = 'Active'", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            con.Close();

            ddlDesignation.DataSource = dt;
            ddlDesignation.DataTextField = "DesignationName";
            ddlDesignation.DataValueField = "DesignationID";
            ddlDesignation.DataBind();

            ddlDesignation.Items.Insert(0, new ListItem("-- Select Designation --", ""));
            if (!string.IsNullOrEmpty(selectedValue))
            {
                ddlDesignation.SelectedValue = selectedValue;
            }
        }
    }
}
