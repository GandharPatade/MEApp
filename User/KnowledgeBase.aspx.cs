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
                // FAQs
                lblFAQ1Question.Text = "Q1: How can I reset my company password?";
                lblFAQ1Answer.Text = "A1: You can reset your password using the self-service portal or contact IT support.";

                lblFAQ2Question.Text = "Q2: Where can I find the holiday list?";
                lblFAQ2Answer.Text = "A2: The holiday list is available on the company intranet under HR section.";

                // HR Policies
                lblPolicy1Title.Text = "Policy 1: Work From Home Policy";
                lblPolicy1Content.Text = "Employees are allowed to work from home up to 2 days a week with manager approval.";

                lblPolicy2Title.Text = "Policy 2: Leave Policy";
                lblPolicy2Content.Text = "Employees are entitled to 20 days of paid leave per year, excluding public holidays.";
            }
        }

       
    }
}