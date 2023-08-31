using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InfobridgeAssessment
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text=="admin" && txtPassword.Text=="1234")
            {
                Response.Redirect("~/Employee.aspx");
            }
            else
            {
                lblError.Text = "Incorrect UserName or Password";
            }
        }
    }
}