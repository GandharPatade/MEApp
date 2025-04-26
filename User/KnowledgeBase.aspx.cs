using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MEApp.User
{
    public partial class KnowledgeBase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlContent.Visible = false;
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = ddlCategory.SelectedValue.Trim();

            if (string.IsNullOrEmpty(selected))
            {
                pnlContent.Visible = false;
                return;
            }

            pnlContent.Visible = true;

            // Clear old data first
            lblHeader.Text = "";
            lblQ1.Text = lblA1.Text = lblQ2.Text = lblA2.Text = lblQ3.Text = lblA3.Text = "";

            if (selected == "FAQs")
            {
                lblHeader.Text = "Frequently Asked Questions";

                lblQ1.Text = "Q: How do I reset my password?";
                lblA1.Text = "A: Use the 'Forgot Password' link on the login page.";

                lblQ2.Text = "Q: Where can I view my attendance?";
                lblA2.Text = "A: In the Employee Portal under 'My Attendance'.";

                lblQ3.Text = ""; // No 3rd FAQ for now
                lblA3.Text = "";
            }
            else if (selected == "HR Policies")
            {
                lblHeader.Text = "HR Policies";

                lblQ1.Text = "Leave Policy:";
                lblA1.Text = "20 paid leaves per year.";

                lblQ2.Text = "Work From Home Policy:";
                lblA2.Text = "Allowed up to 5 days/month.";

                lblQ3.Text = "Code of Conduct:";
                lblA3.Text = "Professional behavior is mandatory at all times.";
            }
        }
    }
}