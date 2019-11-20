using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HostDashBoard : System.Web.UI.Page
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
            Response.Redirect("Home.aspx");
        }

        //Session["USERID"] = "226";

        if (Session["USERID"] != null)
        {
            int hostID = Convert.ToInt32(Session["USERID"]);
            DataTable dt = new DataTable();

            string SearchQuery = "Select * from Accomodation where HostID=@hostID";

            try
            {

                SqlCommand command = new SqlCommand(SearchQuery, dbConnection); // sqlcommand that takes query and connection
                SqlDataAdapter data_adapter = new SqlDataAdapter(command); // data adapter 
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@hostID", hostID));

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


    protected void btnAddProperty_Click(object sender, EventArgs e)
    {
        Property tempProperty = new Property();

       // splitting up address
        string address = HttpUtility.HtmlEncode(tbPropertyAddress.Text);
        string[] addressArray = new string[2];
        int count = 2;
        string[] seperator = { " " };
        string[] strList = address.Split(seperator, count, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < 2; i++)
        {
            addressArray[i] = strList[i];

        }

        tempProperty.setHouseNumber(addressArray[0]);
        tempProperty.setStreet(addressArray[1]);
        tempProperty.setCityCounty(HttpUtility.HtmlEncode(tbPropertyCity.Text));
        tempProperty.setHomeState(ddState.SelectedValue);
        tempProperty.setZip(HttpUtility.HtmlEncode(tbPropertyZip.Text));
        tempProperty.setMonthlyPrice(Double.Parse(tbPropertyPrice.Text));
        tempProperty.setRoomType(tbPropertyRoomType.Text);
        tempProperty.setDescription(tbPropertyDescription.Text);
        tempProperty.setCapacity(int.Parse(tbPropertyCapacity.Text));

        // need to change property class to better fit what we need here - description, availability

        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = ConfigurationManager.ConnectionStrings["RoomMagnet"].ConnectionString;
        sc.Open();

        byte[] picture = null;
        if (firstUploader.HasFile)
        {
            MemoryStream ms = new MemoryStream();
            Bitmap bitmap2 = new Bitmap(firstUploader.PostedFile.InputStream);
            bitmap2.Save(ms, bitmap2.RawFormat);
            picture = ms.GetBuffer();
            ms.Close();
        }

        System.Data.SqlClient.SqlCommand insertProperty = new System.Data.SqlClient.SqlCommand();
        insertProperty.Connection = sc;
        insertProperty.CommandText = "Insert into [dbo].[Accomodation] values (@HouseNumber, @Street, @City, @State, @Zip, @Price, @Capacity,  @RoomType, @Description, @HostID, @ModifiedDate, @Image);";
        insertProperty.Parameters.Add(new SqlParameter("@HouseNumber", tempProperty.getHouseNumber()));
        insertProperty.Parameters.Add(new SqlParameter("@Street", tempProperty.getStreet()));
        insertProperty.Parameters.Add(new SqlParameter("@City", tempProperty.getCityCounty()));
        insertProperty.Parameters.Add(new SqlParameter("@State", tempProperty.getHomeState()));
        insertProperty.Parameters.Add(new SqlParameter("@Zip", tempProperty.getZip()));
        insertProperty.Parameters.Add(new SqlParameter("@Price", tempProperty.getMonthlyPrice()));
        insertProperty.Parameters.Add(new SqlParameter("@Capacity", tempProperty.getCapacity()));
        insertProperty.Parameters.Add(new SqlParameter("@RoomType", tempProperty.getRoomType()));
        insertProperty.Parameters.Add(new SqlParameter("@Description", tempProperty.getDescription()));
        insertProperty.Parameters.Add(new SqlParameter("@HostID", Session["globalID"]));
        insertProperty.Parameters.Add(new SqlParameter("@ModifiedDate", DateTime.Now));
        insertProperty.Parameters.Add(new SqlParameter("@Image", picture));
        insertProperty.ExecuteNonQuery();

        int id = 0;
        DataTable dt = new DataTable();
        try
        {
           SqlCommand command = new SqlCommand("SELECT TOP 1AccomodationID FROM Accomodation ORDER BY AccomodationID DESC", dbConnection); // sqlcommand that takes query and connection
          SqlDataAdapter data_adapter = new SqlDataAdapter(command); // data adapter 
        data_adapter.Fill(dt); 

        foreach (DataRow row in dt.Rows)// iterating the whole datatable
        {
            id = Convert.ToInt32(row[0].ToString()); // adding items to dropdownlist from datatable dt
        }
        dt.Dispose();
       
          
        }
        catch
        {

        }
      
        int accomodationid = id;

        

        for (int j = 0; j < cblAmenities.Items.Count; j++)
        {
            System.Data.SqlClient.SqlCommand submit = new System.Data.SqlClient.SqlCommand();
            submit.Connection = sc;

            if (cblAmenities.Items[j].Selected)
            {
                submit.CommandText = "insert into [dbo].[Amenity] values (@AmenityName, @AccomodationID, @ModifiedDate)";
                submit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AmenityName", cblAmenities.Items[j].Text));
                submit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccomodationID", accomodationid));
                submit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ModifiedDate", DateTime.Today));

                submit.ExecuteNonQuery();
            }

                submit.Parameters.Clear();
        }

            dbConnection.Close();

    }
    protected void HostPropertyDisplay(object sender, EventArgs e)
    {





    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
       

    }



    protected void btnPropertyDelete_Click(object sender, EventArgs e)
    {
       var  b = (LinkButton)sender;

        int propertyId = Convert.ToInt32(b.CommandName.ToString());
        string SearchQuery = "Delete from Accomodation where AccomodationID=@propertyID";
        DataTable dt = new DataTable();
        try
        {

            SqlCommand command = new SqlCommand(SearchQuery, dbConnection); // sqlcommand that takes query and connection
            SqlDataAdapter data_adapter = new SqlDataAdapter(command); // data adapter 
            command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@propertyID", propertyId));

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