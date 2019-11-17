using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
     
        if (Session["USERNAME"] != null)
        {
            btnSignup.Visible = false;
            btnSignin.Visible = false;
            btnSignOut.Visible = true;
           MyAccount.Visible = true;
            userName.InnerText="HI "+Session["USERNAME"].ToString();
            if (Session["USERTYPE"] != null)
            {
                if (Session["USERTYPE"].ToString() == "T")
                {
                    tenantDashboard.Visible = true;
                    houseOwnerDashboard.Visible = false;
                    adminDashboard.Visible = false;


                }
                else if (Session["USERTYPE"].ToString() == "H")
                {
                    houseOwnerDashboard.Visible = true;
                    tenantDashboard.Visible = false;
                    adminDashboard.Visible = false;

                    addProperties.Visible = true;


                }
                else if (Session["USERTYPE"].ToString() == "A")
                {
                    houseOwnerDashboard.Visible = false;
                    tenantDashboard.Visible = false;
                    adminDashboard.Visible = true;

                    addProperties.Visible = true;
                }


            }
        }
        else
        {
            btnSignup.Visible = true;
            btnSignin.Visible = true;
            btnSignOut.Visible = false;
            MyAccount.Visible = false;

        }


    }

    protected void btnSignOut_Click(object sender, EventArgs e)
    {
        Session["USERNAME"] = null;
        Response.Redirect("~/home.aspx");
    }
}
