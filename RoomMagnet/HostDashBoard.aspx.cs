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
            Response.Redirect("index.aspx");
        }

        if (!IsPostBack)
        {
            propetybind();

            BindBrandsRptr();

            appStatus();


        }
        if (Session["tabState"] != null)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "script", "document.querySelector('#" + Session["tabState"].ToString()+"').click()", true);
        }

      
        
           
           
        
        
        


    }

    protected void propetybind()
    {
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
        
        
        Session["tabState"] = "nav-addproperty-tab";
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
        if (Session["tabState"] != null)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "script", "document.querySelector('#" + Session["tabState"].ToString() + "').click()", true);
        }
        propetybind();

    }
    protected void HostPropertyDisplay(object sender, EventArgs e)
    {





    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
       

    }



    protected void btnPropertyDelete_Click(object sender, EventArgs e)
    {
        Session["tabState"] = "nav-profile-tab";
        var b = (LinkButton)sender;

        int propertyId = Convert.ToInt32(b.CommandName.ToString());


        try
        {
            String queryDeleteFav = "Delete from TenantFavorites where AccomodationID=@propertyID";

            SqlCommand command = new SqlCommand(queryDeleteFav, dbConnection); // sqlcommand that takes query and connection
            SqlDataAdapter data_adapter = new SqlDataAdapter(command); // data adapter 
            command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@propertyID", propertyId));

            command.ExecuteNonQuery(); // getting rows to dt(datatable) variabble


            string SearchQuery = "Delete from Accomodation where AccomodationID=@propertyID; " + queryDeleteFav;
            SqlCommand command1 = new SqlCommand(SearchQuery, dbConnection); // sqlcommand that takes query and connection
            SqlDataAdapter data_adapter1 = new SqlDataAdapter(command1); // data adapter 
            command1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@propertyID", propertyId));

            command1.ExecuteNonQuery(); // getting rows to dt(datatable) variabble






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
    private void BindBrandsRptr()
    {
        String CS = ConfigurationManager.ConnectionStrings["RoomMagnet"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        { 
            using (SqlCommand cmd = new SqlCommand("SELECT dbo.RMUser.UserID, dbo.Accomodation.HouseNumber, dbo.Accomodation.Street, dbo.RMUser.FirstName, dbo.RMUser.LastName FROM dbo.Application INNER JOIN " +
                "dbo.Accomodation ON dbo.Application.AccomodationID = dbo.Accomodation.AccomodationID INNER JOIN dbo.RMUser ON dbo.Application.TenantID = dbo.RMUser.UserID where dbo.Accomodation.HostID = " + Session["USERID"] , con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dtBrands = new DataTable();
                    sda.Fill(dtBrands);
                    rptrTenant.DataSource = dtBrands;
                    rptrTenant.DataBind();
                }
            }
        }
    }
    protected void BtnStatusChange_Click(object sender, EventArgs e)
        {
        Session["tabState"] = "nav-fav-tab";
        System.Data.SqlClient.SqlCommand update = new System.Data.SqlClient.SqlCommand();
        update.Connection = dbConnection;

        System.Data.SqlClient.SqlCommand getaddress = new System.Data.SqlClient.SqlCommand();
        getaddress.Connection = dbConnection;

        try { dbConnection.Open(); }
        catch { }
                  
        try
        {
            foreach (RepeaterItem item in rptrTenant.Items)
            {
               

                DropDownList dropDown = (DropDownList)item.FindControl("ddlStatus");
                int status = Int32.Parse(dropDown.SelectedValue);

                if (status == 1)
                {
                    var tenid = ((Label)item.FindControl("userid")).Text;
                    int number = int.Parse(tenid);

                    getaddress.CommandText = "select accomodationid from application where tenantid = " + tenid;
                    int address = Int32.Parse(getaddress.ExecuteScalar().ToString());

                    update.CommandText = "insert into [dbo].[Confirmation] values (@ConfirmDate, @TenantID, @HostID, @AccomID, @ModifiedDate)";
                    update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ConfirmDate", DateTime.Today));
                    update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TenantID", tenid));
                    update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HostID", Session["USERID"]));
                    update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccomID", address));
                    update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ModifiedDate", DateTime.Today));
                    update.ExecuteNonQuery();

                    update.CommandText = "update Application set status = 1 where tenantid = " + tenid + " and accomodationid = " + address;
                    update.ExecuteNonQuery();

                    Label lblstat = (Label)item.FindControl("lblstatus");
                    lblstat.Text = "Accepted";

                    update.Parameters.Clear();
                }
                else if (status == 0)
                {
                    var tenid = ((Label)item.FindControl("userid")).Text;
                    int number = int.Parse(tenid);

                    getaddress.CommandText = "select accomodationid from application where tenantid = " + number;
                    int address = Int32.Parse(getaddress.ExecuteScalar().ToString());

                    update.CommandText = "update Application set status = 0 where tenantid = " + number + " and accomodationid = " + address;
                    update.ExecuteNonQuery();

                    Label lblstat = (Label)item.FindControl("lblstatus");
                    lblstat.Text = "Rejected";
                }
            }
        }
        //catch { }
        finally
        {

            dbConnection.Close();
        }
    }

    protected void appStatus()
    {
        System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
        insert.Connection = dbConnection;

        System.Data.SqlClient.SqlCommand getstatus = new System.Data.SqlClient.SqlCommand();
        getstatus.Connection = dbConnection;

        System.Data.SqlClient.SqlCommand getaddress = new System.Data.SqlClient.SqlCommand();
        getaddress.Connection = dbConnection;

        try { dbConnection.Open(); }
        catch { }
        try
        {
            foreach (RepeaterItem item in rptrTenant.Items)
            {
                var tenid = ((Label)item.FindControl("userid")).Text;
                int number = int.Parse(tenid);

                getaddress.CommandText = "select accomodationid from application where tenantid = " + number;
                int address = Int32.Parse(getaddress.ExecuteScalar().ToString());

                getstatus.CommandText = "select status from application where tenantid = " + number + " and accomodationid = " + address; 
                int id = Int32.Parse(getaddress.ExecuteScalar().ToString());

                bool status = (bool)getstatus.ExecuteScalar();
                    
                    
                    if (status)
                    {
                        Label lblstat = (Label)item.FindControl("lblstatus");
                        lblstat.Text = "Accepted";

                        DropDownList ddl = (DropDownList)item.FindControl("ddlStatus");
                        ddl.SelectedValue = "1";
                    }
                    else
                    {
                        Label lblstat = (Label)item.FindControl("lblstatus");
                        lblstat.Text = "Rejected";

                        DropDownList ddl = (DropDownList)item.FindControl("ddlStatus");
                        ddl.SelectedValue = "0";
                    }
                
            }
        }
        catch { }
        finally
        {

            dbConnection.Close();
        }

    }



    protected void Unnamed_Click(object sender, EventArgs e)
    {

    }

    protected void UpdateProfile_Click(object sender, EventArgs e)
    {
        try
        {
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = ConfigurationManager.ConnectionStrings["RoomMagnet"].ConnectionString;

            sc.Open();

            SqlCommand update = new SqlCommand();
            update.Connection = sc;
            update.CommandText = "update RMUser set FirstName = @FirstName, " +
                "LastName = @LastName, " +
                "Email = @Email, " +
                "PhoneNumber = @PhoneNumber," +
                "HouseNumber = @HouseNumber," +
                "Street = @Street," +
                "City = @City," +
                "Zip = @Zip where UserID = " + Session["USERID"];
            update.Parameters.Add(new SqlParameter("@FirstName", HttpUtility.HtmlEncode(tbName.Text)));
            update.Parameters.Add(new SqlParameter("@LastName", HttpUtility.HtmlEncode(tbName1.Text)));
            update.Parameters.Add(new SqlParameter("@PhoneNumber", HttpUtility.HtmlEncode(tbPhone.Text)));
            update.Parameters.Add(new SqlParameter("@Email", HttpUtility.HtmlEncode(tbUname.Text)));
            update.Parameters.Add(new SqlParameter("@HouseNumber", HttpUtility.HtmlEncode(tbHouseNumber.Text)));
            update.Parameters.Add(new SqlParameter("@Street", HttpUtility.HtmlEncode(tbAddress.Text)));
            update.Parameters.Add(new SqlParameter("@City", HttpUtility.HtmlEncode(tbCity.Text)));
            update.Parameters.Add(new SqlParameter("@Zip", HttpUtility.HtmlEncode(tbZip.Text)));

            update.ExecuteNonQuery();
        }
        catch
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Failed to update');", true);
        }

    }

    protected void btnPopulate_Click(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = ConfigurationManager.ConnectionStrings["RoomMagnet"].ConnectionString;
        sc.Open();

        SqlCommand populate = new SqlCommand();
        populate.Connection = sc;

        populate.CommandText = "select FirstName from RMUser where userID = " + Session["USERID"];
        tbName.Text = Convert.ToString(populate.ExecuteScalar());
        populate.CommandText = "select LastName from RMUser where userID = " + Session["USERID"];
        tbName1.Text = Convert.ToString(populate.ExecuteScalar());
        populate.CommandText = "select PhoneNumber from RMUser where userID = " + Session["USERID"];
        tbPhone.Text = Convert.ToString(populate.ExecuteScalar());
        populate.CommandText = "select Email from RMUser where userID = " + Session["USERID"];
        tbUname.Text = Convert.ToString(populate.ExecuteScalar());
        populate.CommandText = "select HouseNumber from RMUser where userID = " + Session["USERID"];
        tbHouseNumber.Text = Convert.ToString(populate.ExecuteScalar());
        populate.CommandText = "select street from RMUser where userID = " + Session["USERID"];
        tbAddress.Text = Convert.ToString(populate.ExecuteScalar());
        populate.CommandText = "select city from RMUser where userID = " + Session["USERID"];
        tbCity.Text = Convert.ToString(populate.ExecuteScalar());
        populate.CommandText = "select zip from RMUser where userID = " + Session["USERID"];
        tbZip.Text = Convert.ToString(populate.ExecuteScalar());

        
    }
}