using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TenantDashboard : System.Web.UI.Page
{
    string ConnectionString = WebConfigurationManager.ConnectionStrings["RoomMagnet"].ConnectionString; // connection string
    System.Data.SqlClient.SqlConnection dbConnection;

    protected void Page_Init(Object sender, EventArgs e) // when first time the program load to memory before going to webbrowser
    {
        try
        {
            dbConnection = new System.Data.SqlClient.SqlConnection(); // creaeting connection to the database
            dbConnection.ConnectionString = ConnectionString; // giving connection string to dbconnection
            dbConnection.Open(); // opening the connection for intraction
        }
        catch (Exception)
        {
            // if connection is not establed due to some error
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Connection Not Established" + "');", true);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["USERNAME"] == null)
        {
            Response.Redirect("index.aspx");
        }

        if (Session["USERTYPE"] != null)
        {
            if (Session["USERTYPE"].ToString() == "t")
            {


                loadProfile(Session["USERID"].ToString());

               
                propetybind();
                if (Session["tabState"] != null)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "script", "document.querySelector('#" + Session["tabState"].ToString() + "').click()", true);
                }

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
    protected void propetybind()
    {
        if (Session["USERID"] != null)
        {
            int tenantID = Convert.ToInt32(Session["USERID"]);
            DataTable dt = new DataTable();

            string SearchQuery = "SELECT * FROM Accomodation WHERE AccomodationID IN (SELECT AccomodationID FROM TenantFavorites WHERE TenantID = @TenantID)";

            try
            {

                SqlCommand command = new SqlCommand(SearchQuery, dbConnection); // sqlcommand that takes query and connection
                SqlDataAdapter data_adapter = new SqlDataAdapter(command); // data adapter 
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TenantID", tenantID));

                data_adapter.Fill(dt); // getting rows to dt(datatable) variabble

               





            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Could not fetch Property rows from Database" + "');", true);

            }
            finally
            {

                //GridView1.DataSource = dt;
                //GridView1.DataBind();
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
                dbConnection.Close(); // closing the db connection
            }

        }

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
    protected void btnPropertyDelete_Click(object sender, EventArgs e)
    {

      

            try { dbConnection.Open(); }
            catch { }
            Session["tabState"] = "nav-profile-tab";
            var b = (LinkButton)sender;

            int propertyId = Convert.ToInt32(b.CommandName.ToString());


            try
            {
                String queryDeleteFav = "delete from TenantFavorites where TenantID=@tenantID and AccomodationID =@accomudationID;";

                SqlCommand command = new SqlCommand(queryDeleteFav, dbConnection); // sqlcommand that takes query and connection
                SqlDataAdapter data_adapter = new SqlDataAdapter(command); // data adapter 
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tenantID ", Session["USERID"].ToString()));
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@accomudationID", propertyId));
                command.ExecuteNonQuery(); // getting rows to dt(datatable) variabble







                propetybind();




            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Could not fetch Property rows from Database" + "');", true);

            }
            finally
            {


            }
        }
    

}