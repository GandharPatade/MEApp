using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MEApp.Admin
{
    public partial class ViewEmp : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Initially load all employees
                LoadEmployees("All");
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string selectedStatus = ddlStatusFilter.SelectedValue;
            LoadEmployees(selectedStatus);
        }

        private void LoadEmployees(string status)
        {
            string query = @"
            SELECT e.EmployeeCode, e.FullName, e.Email, e.ContactNo, 
                   e.DepartmentID, d.DepartmentName, e.DesignationID, des.DesignationName
            FROM EmployeeProfiles e
            LEFT JOIN Department d ON e.DepartmentID = d.DepartmentID
            LEFT JOIN Designation des ON e.DesignationID = des.DesignationID";

            // Apply filter if needed
            if (status != "All")
            {
                query += " WHERE d.Status = @Status";
            }

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            if (status != "All")
            {
                da.SelectCommand.Parameters.AddWithValue("@Status", status);
            }

            DataTable dt = new DataTable();
            da.Fill(dt);
            GridViewEmployees.DataSource = dt;
            GridViewEmployees.DataBind();
        }




        // Row Editing: Switching to edit mode
        protected void GridViewEmployees_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewEmployees.EditIndex = e.NewEditIndex;
            LoadEmployees(ddlStatusFilter.SelectedValue);
        }

        // Row Updating: Updating the record in the database
        protected void GridViewEmployees_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewEmployees.Rows[e.RowIndex];

            string employeeCode = GridViewEmployees.DataKeys[e.RowIndex]["EmployeeCode"].ToString();
            string fullName = ((TextBox)row.FindControl("txtFullName")).Text;
            string email = ((TextBox)row.FindControl("txtEmail")).Text;
            string contactNo = ((TextBox)row.FindControl("txtContactNo")).Text;

            DropDownList ddlDept = (DropDownList)row.FindControl("ddlDepartment");
            DropDownList ddlDes = (DropDownList)row.FindControl("ddlDesignation");

            int departmentID = int.Parse(ddlDept.SelectedValue);
            int designationID = int.Parse(ddlDes.SelectedValue);

            string updateQuery = @"
                UPDATE EmployeeProfiles 
                SET FullName = @FullName, Email = @Email, ContactNo = @ContactNo, 
                    DepartmentID = @DepartmentID, DesignationID = @DesignationID
                WHERE EmployeeCode = @EmployeeCode";

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
            LoadEmployees(ddlStatusFilter.SelectedValue);
        }

        // Row Canceling Edit: Canceling edit mode
        protected void GridViewEmployees_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewEmployees.EditIndex = -1;
            LoadEmployees(ddlStatusFilter.SelectedValue);
        }

        // Row Deleting: Deleting the employee record
        protected void GridViewEmployees_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string employeeCode = GridViewEmployees.DataKeys[e.RowIndex]["EmployeeCode"].ToString();

            string deleteQuery = "DELETE FROM EmployeeProfiles WHERE EmployeeCode = @EmployeeCode";

            SqlCommand cmd = new SqlCommand(deleteQuery, con);
            cmd.Parameters.AddWithValue("@EmployeeCode", employeeCode);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            LoadEmployees(ddlStatusFilter.SelectedValue);
        }

        // Row DataBound: Binding Department and Designation dropdowns
        protected void GridViewEmployees_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                DropDownList ddlDept = (DropDownList)e.Row.FindControl("ddlDepartment");
                DropDownList ddlDes = (DropDownList)e.Row.FindControl("ddlDesignation");

                HiddenField hfDeptID = (HiddenField)e.Row.FindControl("hfDepartmentID");
                HiddenField hfDesID = (HiddenField)e.Row.FindControl("hfDesignationID");

                int currentDeptID = int.Parse(hfDeptID.Value);
                int currentDesID = int.Parse(hfDesID.Value);

                // Bind Department dropdown
                ddlDept.DataSource = GetActiveDepartments(); // Get active departments
                ddlDept.DataTextField = "DepartmentName";
                ddlDept.DataValueField = "DepartmentID";
                ddlDept.DataBind();

                ddlDept.SelectedValue = currentDeptID.ToString();

                // Bind Designation dropdown
                ddlDes.DataSource = GetActiveDesignations(); // Get active designations
                ddlDes.DataTextField = "DesignationName";
                ddlDes.DataValueField = "DesignationID";
                ddlDes.DataBind();

                ddlDes.SelectedValue = currentDesID.ToString();
            }
        }

        // Helper method to get active departments
        private DataTable GetActiveDepartments()
        {
            string query = "SELECT DepartmentID, DepartmentName FROM Department WHERE Status = 'Active'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Helper method to get active designations
        private DataTable GetActiveDesignations()
        {
            string query = "SELECT DesignationID, DesignationName FROM Designation WHERE Status = 'Active'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
