using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

public partial class SignUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnSingupTenant_Click(object sender, EventArgs e)
    {
        
            if (tbPassWord.Text == tbPassWord.Text)
            {
                String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString1"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                  //// insert query 






                    lblMsg.Text = "Registration Successfull";
                    lblMsg.ForeColor = Color.Green;
                    Response.Redirect("~/Signin.aspx");
                }
            }
            else
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "Passwords do not match";
            }
      

    }

    protected void btnSingupHouseOwner_Click(object sender, EventArgs e)
    {

    }
}