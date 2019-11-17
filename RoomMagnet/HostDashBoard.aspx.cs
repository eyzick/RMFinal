using System;
using System.Collections.Generic;
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

    }


    protected void btnAddProperty_Click(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
        insert.Connection = dbConnection;

        System.Data.SqlClient.SqlCommand submit = new System.Data.SqlClient.SqlCommand();
        submit.Connection = dbConnection;

        System.Data.SqlClient.SqlCommand accid = new System.Data.SqlClient.SqlCommand();
        accid.Connection = dbConnection;

        String housenumber = tbPropertyAddress1.Text;
        String street = tbPropertyAddress2.Text;
        String city = tbPropertyCity.Text;
        String zip = tbPropertyZip.Text;
        String state = ddlPropertyState.SelectedValue;
        String price = tbPropertyPrice.Text;
        String capacity = tbPropertyCapacity.Text;
        String availability = tbPropertyAvailability.Text;
        String roomtype = tbPropertyRoomType.Text;
        String description = tbPropertyDescription.Text;
        int hostid = 1;
        DateTime date = DateTime.Today;
        

        byte[] i = null;
        if (firstUploader.HasFile)
        {
            MemoryStream ms = new MemoryStream();
            Bitmap bitmap2 = new Bitmap(firstUploader.PostedFile.InputStream);
            bitmap2.Save(ms, bitmap2.RawFormat);
            i = ms.GetBuffer();
            ms.Close();
        }



        insert.CommandText = "insert into [dbo].[Accomodation] values (@HouseNumber, @Street, @City, @State, @Zip, @Price, @Capacity, @Availability" +
            ", @RoomType, @Description, @HostID, @ModifiedDate,@Image)";
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HouseNumber", housenumber));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Street", street));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@City", city));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@State", state));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Zip", zip));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Price", price));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Capacity", capacity));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Availability", availability));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RoomType", roomtype));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Description", description));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HostID", hostid));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ModifiedDate", date));
        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Image", i));

        insert.ExecuteNonQuery();

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
            if (cblAmenities.Items[j].Selected)
            {
                submit.CommandText = "insert into [dbo].[Amenity] values (@AmenityName, @AccomodationID, @ModifiedDate)";
                submit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AmenityName", cblAmenities.Items[j].Text));
                submit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccomodationID", accomodationid));
                submit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ModifiedDate", date));

                submit.ExecuteNonQuery();
            }

            submit.Parameters.Clear();
        }

        dbConnection.Close();

    }
}