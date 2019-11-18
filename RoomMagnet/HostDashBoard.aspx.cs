﻿using System;
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
        Property tempProperty = new Property();

        //splitting up address
        //string address = HttpUtility.HtmlEncode(tbAddress.Text);
        //string[] addressArray = new string[2];
        //int count = 2;
        //string[] seperator = { " " };
        //string[] strList = address.Split(seperator, count, StringSplitOptions.RemoveEmptyEntries);
        //for (int i = 0; i < 2; i++)
        //{
        //    addressArray[i] = strList[i];

        //}

        //tempProperty.setHouseNumber(addressArray[0]);
        //tempProperty.setStreet(addressArray[1]);
        //tempProperty.setCityCounty(HttpUtility.HtmlEncode(tbCity.Text));
        //tempProperty.setHomeState(ddState.SelectedValue);
        //tempProperty.setZip(HttpUtility.HtmlEncode(tbZip.Text));
        //tempProperty.setMonthlyPrice(Double.Parse(tbPrice.Text));
        //tempProperty.setRoomType(tbPropertyRoomType.Text);
        //tempProperty.setDescription("CHANGE ME LATER");

        // need to change property class to better fit what we need here - description, availability

        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = @"Data Source=aay09edjn65sf6.cpcbbo8ggvx6.us-east-1.rds.amazonaws.com;Initial Catalog=RoomMagnet;Persist Security Info=True;User ID=fahrenheit;Password=cis484fall";
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
        insertProperty.CommandText = "Insert into [dbo].[Accomodation] values (@HouseNumber, @Street, @City, @State, @Zip, @Price, 1, 1, @RoomType, @Description, @HostID, @ModifiedDate, @Image);";
        insertProperty.Parameters.Add(new SqlParameter("@HouseNumber", tempProperty.getHouseNumber()));
        insertProperty.Parameters.Add(new SqlParameter("@Street", tempProperty.getStreet()));
        insertProperty.Parameters.Add(new SqlParameter("@City", tempProperty.getCityCounty()));
        insertProperty.Parameters.Add(new SqlParameter("@State", tempProperty.getHomeState()));
        insertProperty.Parameters.Add(new SqlParameter("@Zip", tempProperty.getZip()));
        insertProperty.Parameters.Add(new SqlParameter("@Price", tempProperty.getMonthlyPrice()));
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
            if (cblAmenities.Items[j].Selected)
            {
                //        submit.CommandText = "insert into [dbo].[Amenity] values (@AmenityName, @AccomodationID, @ModifiedDate)";
                //        submit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AmenityName", cblAmenities.Items[j].Text));
                //        submit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccomodationID", accomodationid));
                //        submit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ModifiedDate", date));

                //        submit.ExecuteNonQuery();
            }

            //    submit.Parameters.Clear();
        }

            dbConnection.Close();

            }
        }