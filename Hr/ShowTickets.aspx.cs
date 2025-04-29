using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MEApp.Hr
{
    public partial class ShowTickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //gvAllTickets.RowCommand += gvAllTickets_RowCommand;

                LoadAllTickets();
            }
        }

        private void LoadAllTickets()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllTickets", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvAllTickets.DataSource = dt;
                gvAllTickets.DataBind();
            }
        }



        protected void gvAllTickets_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteTicket")
            {
                int ticketId = Convert.ToInt32(e.CommandArgument);
                DeleteTicket(ticketId);
                LoadAllTickets(); // Refresh grid after deletion
            }
        }

        private void DeleteTicket(int ticketId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MEApp"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Tickets WHERE TicketID = @TicketID", con);
                cmd.Parameters.AddWithValue("@TicketID", ticketId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }



    }
}