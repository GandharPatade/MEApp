using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MEApp.Admin
{
	public partial class AdminDashboard : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["FullName"] != null)
            {
                Label1.Text = Session["FullName"].ToString();
               
            }
            else
            {
               
                Response.Redirect("../Account/LogIn.aspx");
              
            }

        }
	}
}