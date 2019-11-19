using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
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

            string ConnectionString = WebConfigurationManager.ConnectionStrings["RoomMagnet"].ConnectionString; // connection string
            System.Data.SqlClient.SqlConnection dbConnection;
            dbConnection = new System.Data.SqlClient.SqlConnection(); // creaeting connection to the database
            dbConnection.ConnectionString = ConnectionString; // giving connection string to dbconnection
            dbConnection.Open(); // opening the connection for intraction
            System.Data.SqlClient.SqlCommand update = new System.Data.SqlClient.SqlCommand();
            update.Connection = dbConnection;

            update.CommandText = "select firstname from rmuser where email = '" + Session["USERNAME"].ToString() + "'";
            String email = update.ExecuteScalar().ToString();

            tbEmail.InnerText = "HI " + email;

            dbConnection.Close();

            if (Session["USERTYPE"] != null)
            {
                if (Session["USERTYPE"].ToString() == "t")
                {
                    tenantDashboard.Visible = true;
                    houseOwnerDashboard.Visible = false;
                    adminDashboard.Visible = false;

                    addProperties.Visible = false;
                    myFavorites.Visible = true;
                    myProperties.Visible = false;
                    myProfile.Visible = true;

                }
                else if (Session["USERTYPE"].ToString() == "h")
                {
                    houseOwnerDashboard.Visible = true;
                    tenantDashboard.Visible = false;
                    adminDashboard.Visible = false;

                    addProperties.Visible = true;
                    myFavorites.Visible = true;
                    myProfile.Visible = true;
                    myProperties.Visible = true;

                }
                else if (Session["USERTYPE"].ToString() == "a")
                {
                    houseOwnerDashboard.Visible = false;
                    tenantDashboard.Visible = false;
                    adminDashboard.Visible = true;

                    addProperties.Visible = false;
                    myProperties.Visible = false;
                    myFavorites.Visible = false;
                    myProfile.Visible = false;
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