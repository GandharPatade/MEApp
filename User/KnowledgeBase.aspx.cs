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

        }
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = ddlCategory.SelectedValue;
            pnlContent.Visible = true;

            if (selected == "FAQ")
            {
                ltlContent.Text = @"
                    <h3>Frequently Asked Questions</h3>
                    <ul>
                        <li><strong>Q:</strong> How do I reset my password?<br/><strong>A:</strong> Use the 'Forgot Password' link on login.</li>
                        <li><strong>Q:</strong> Where can I view my attendance?<br/><strong>A:</strong> In the Employee Portal under 'My Attendance'.</li>
                    </ul>
                ";
            }
            else if (selected == "HR")
            {
                ltlContent.Text = @"
                    <h3>HR Policies</h3>
                    <ul>
                        <li>Leave Policy: 20 paid leaves per year.</li>
                        <li>Work From Home Policy: Allowed up to 5 days/month.</li>
                        <li>Code of Conduct: Professional behavior is mandatory at all times.</li>
                    </ul>
                ";
            }
            else
            {
                pnlContent.Visible = false;
            }
        }
    }
}
