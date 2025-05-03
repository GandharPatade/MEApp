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
            LoadEmployees("Active");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedStatus = DropDownList1.SelectedValue;
            LoadEmployees(selectedStatus);
        }

        private void LoadEmployees(string status)
        {
            SqlDataAdapter da = new SqlDataAdapter($"EXEC sp_GetAllEmployees '{status}'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridViewEmployees.DataSource = dt;
            GridViewEmployees.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string selectedStatus = DropDownList1.SelectedValue;
            LoadEmployees(selectedStatus);
        }


        protected void GridViewEmployees_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewEmployees.EditIndex = e.NewEditIndex;
            string selectedStatus = DropDownList1.SelectedValue;

            LoadEmployees(selectedStatus);

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
            string selectedStatus = DropDownList1.SelectedValue;

            LoadEmployees(selectedStatus);
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

            int departmentID;
            int designationID;

            if (ddlDes != null && int.TryParse(ddlDes.SelectedValue, out designationID) && designationID > 0)
            {
                // valid
            }
            else
            {
                lblMessage.Text = "Please select a valid designation.";
                return;
            }

            if (ddlDept != null && int.TryParse(ddlDept.SelectedValue, out departmentID) && departmentID > 0)
            {
                // valid
            }
            else
            {
                lblMessage.Text = "Please select a valid department.";
                return;
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
            string selectedStatus = DropDownList1.SelectedValue;

            LoadEmployees(selectedStatus);
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
                string selectedStatus = DropDownList1.SelectedValue;

                LoadEmployees(selectedStatus);
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

            if (!string.IsNullOrEmpty(selectedValue) && ddlDepartment.Items.FindByValue(selectedValue) != null)
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

            if (!string.IsNullOrEmpty(selectedValue) && ddlDesignation.Items.FindByValue(selectedValue) != null)
            {
                ddlDesignation.SelectedValue = selectedValue;
            }

        }

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
                ddlDept.DataSource = GetActiveDepartments(); // your method to get active depts
                ddlDept.DataTextField = "DepartmentName";
                ddlDept.DataValueField = "DepartmentID";
                ddlDept.DataBind();

                // Add current (possibly inactive) item if missing
                if (ddlDept.Items.FindByValue(currentDeptID.ToString()) == null)
                {
                    ddlDept.Items.Add(new ListItem("Inactive - ID: " + currentDeptID, currentDeptID.ToString()));
                }

                ddlDept.SelectedValue = currentDeptID.ToString();

                // Bind Designation dropdown
                ddlDes.DataSource = GetActiveDesignations(); // your method to get active designations
                ddlDes.DataTextField = "DesignationName";
                ddlDes.DataValueField = "DesignationID";
                ddlDes.DataBind();

                // Add current (possibly inactive) item if missing
                if (ddlDes.Items.FindByValue(currentDesID.ToString()) == null)
                {
                    ddlDes.Items.Add(new ListItem("Inactive - ID: " + currentDesID, currentDesID.ToString()));
                }

                ddlDes.SelectedValue = currentDesID.ToString();
            }
        }

        private DataTable GetActiveDepartments()
        {
            string query = "SELECT DepartmentID, DepartmentName FROM Department WHERE Status = 'Active'";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        private DataTable GetActiveDesignations()
        {
            string query = "SELECT DesignationID, DesignationName FROM Designation WHERE Status = 'Active'";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


    }
}
