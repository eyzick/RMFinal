using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PropertySearch : System.Web.UI.Page
{
    string ConnectionString = WebConfigurationManager.ConnectionStrings["RoomMagnet"].ConnectionString; // connection string
    System.Data.SqlClient.SqlConnection dbConnection;
    protected void Page_Init(Object sender, EventArgs e)
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

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        string SearchQuery = "";

        if (txt_search.Text != "")
        {
            SearchQuery = "Select * from Accomodation where (Street = @street OR City = @city) OR(State = @state OR Zip = @zip)";
        }
        else
        {
            SearchQuery = "Select * from Accomodation";
        }

        try
        {

            SqlCommand command = new SqlCommand(SearchQuery, dbConnection); // sqlcommand that takes query and connection
            SqlDataAdapter data_adapter = new SqlDataAdapter(command); // data adapter 
            command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@street", txt_search.Text));
            command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@city", txt_search.Text));
            command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@state", txt_search.Text));
            command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zip", txt_search.Text));
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