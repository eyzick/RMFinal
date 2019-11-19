using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["tbEmail"] != null)
        {


        }
    }
    protected void btnOwner_Click(object sender, EventArgs e)
    {
        Response.Redirect("SignUp.aspx");
    }
    protected void btnRenter_Click(object sender, EventArgs e)
    {
        Response.Redirect("PropertySearch.aspx");
    }
}