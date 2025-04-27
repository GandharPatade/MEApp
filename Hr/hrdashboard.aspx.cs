using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MEApp.Hr
{
    public partial class hrdashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Text = Session["FullName"].ToString();
                Label2.Text = Session["Email12"].ToString();
            }
        }
    }
}