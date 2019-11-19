using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TenantDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USERTYPE"] != null)
        {
            if (Session["USERTYPE"].ToString() == "t")
            {


                loadProfile(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Home.aspx");
            }
        }
        else
        {
            Response.Redirect("~/Home.aspx");
        }

        //if (Session["USERNAME"] == null)
        //{
        //    Response.Redirect("Home.aspx");
        //}




    }

    private void loadProfile(string userID) {

        String CS = ConfigurationManager.ConnectionStrings["RoomMagnet"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("select * from RMUser where UserID="+userID, con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            tbName.Text = dt.Rows[0]["FirstName"].ToString();
            tbName1.Text = dt.Rows[0]["LastName"].ToString();
            // continue
        }

         





    }

}