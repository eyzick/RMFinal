//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
//using System.Web.Configuration;
//using System.Web.UI;
//using System.Web.UI.WebControls;


//public partial class _Default : System.Web.UI.Page
//{
//    protected void Page_Load(object sender, EventArgs e)
//    {
//        string ConnectionString = WebConfigurationManager.ConnectionStrings["RoomMagnet"].ConnectionString; // connection string
//        System.Data.SqlClient.SqlConnection dbConnection;

//        DataTable dt = new DataTable();
//        string SearchQuery = "";
//        SearchQuery = "SELECT dbo.RMUser.FirstName, dbo.Accomodation.AccomodationID FROM dbo.Accomodation INNER JOIN dbo.RMUser ON dbo.Accomodation.HostID = dbo.RMUser.UserID";



//        SqlCommand command = new SqlCommand(SearchQuery, dbConnection); // sqlcommand that takes query and connection
//        SqlDataAdapter data_adapter = new SqlDataAdapter(command); // data adapter 
//        command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FirstName", ));
//        command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@city", txt_search.Text));
//        command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@state", txt_search.Text));
//        command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zip", txt_search.Text));
//        data_adapter.Fill(dt); // getting rows to dt(datatable) variabble


//        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Could not fetch Property rows from Database" + "');", true);



//        //GridView1.DataSource = dt;
//        //GridView1.DataBind();
//        Repeater1.DataSource = dt;
//        Repeater1.DataBind();
//        dbConnection.Close(); // closing the db connection


//    }
//}