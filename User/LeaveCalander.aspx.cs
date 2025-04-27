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
    public partial class LeaveCalander : System.Web.UI.Page
    {

        private Dictionary<DateTime, string> events = new Dictionary<DateTime, string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEvents();
            }
        }


        private void LoadEvents()
        {
            string cs = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "EXEC fetchEvnt";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DateTime date = Convert.ToDateTime(reader["Date"]);
                    string title = reader["Title"].ToString();
                    string status = reader["Status"].ToString();

                    if (status == "Active")
                    {
                        events[date] = title;
                    }
                }
            }
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (events.ContainsKey(e.Day.Date))
            {
                e.Cell.BackColor = System.Drawing.Color.LightGreen;
                e.Cell.Controls.Add(new Literal { Text = "<br/>" + events[e.Day.Date] });
            }
        }
    }
}