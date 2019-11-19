using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

public partial class SignUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSingupHouseOwner_Click(object sender, EventArgs e)
    {
        int validated = validateInformation(tbFirstName.Text, tbLastName.Text, tbPhoneNumber.Text, tbDOB.Text);

            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Data Source=aay09edjn65sf6.cpcbbo8ggvx6.us-east-1.rds.amazonaws.com;Initial Catalog=RoomMagnet;Persist Security Info=True;User ID=fahrenheit;Password=cis484fall";
            sc.Open();


        using (SqlConnection con = new SqlConnection("Data Source=aay09edjn65sf6.cpcbbo8ggvx6.us-east-1.rds.amazonaws.com;Initial Catalog=RoomMagnet;Persist Security Info=True;User ID=fahrenheit;Password=cis484fall"))
        {
            con.Open();

            bool exists = false;

            // create a command to check if the username exists
            using (SqlCommand cmd = new SqlCommand("select count(*) from [dbo].[RMUser] where Email = @Email", con))
            {
                cmd.Parameters.AddWithValue("Email", tbEmail.Text);
                exists = (int)cmd.ExecuteScalar() > 0;
            }
            if (exists)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('This email is already exist!');", true);

            }
            else
            {
                if (validated == 0)
                {
                    string usertype = "h";

                    Host tempHost = new Host();

                    //splitting up address
                    string address = HttpUtility.HtmlEncode(tbAddress.Text);
                    string[] addressArray = new string[2];
                    int count = 2;
                    string[] seperator = { " " };
                    string[] strList = address.Split(seperator, count, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < 2; i++)
                    {
                        addressArray[i] = strList[i];

                    }
                    DateTime now = DateTime.Now;

                    string tempDate = HttpUtility.HtmlEncode(tbDOB.Text);
                    DateTime DOB = Convert.ToDateTime(tempDate);

                    tempHost.SetFirstName(HttpUtility.HtmlEncode(tbFirstName.Text));
                    tempHost.SetLastName(HttpUtility.HtmlEncode(tbLastName.Text));
                    tempHost.SetDateOfBirth(DOB);
                    tempHost.SetHouseNumber(HttpUtility.HtmlEncode(addressArray[0]));
                    tempHost.SetStreet(HttpUtility.HtmlEncode(addressArray[1]));
                    tempHost.SetHomeState(ddState.SelectedValue);
                    tempHost.SetZip(HttpUtility.HtmlEncode(tbZip.Text));
                    tempHost.setPhoneNumber(HttpUtility.HtmlEncode(tbPhoneNumber.Text));
                    tempHost.SetCityCounty(HttpUtility.HtmlEncode(tbCity.Text));
                    tempHost.SetEmailAddress(HttpUtility.HtmlEncode(tbEmail.Text));



                    System.Data.SqlClient.SqlCommand insertTest = new System.Data.SqlClient.SqlCommand();
                    insertTest.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FirstName", tempHost.GetFirstName()));
                    insertTest.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LastName", tempHost.GetLastName()));
                    insertTest.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Email", tempHost.GetEmailAddress()));
                    insertTest.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PhoneNumber", tempHost.getPhoneNumber()));
                    insertTest.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DOB", tempHost.GetDateOfBirth()));
                    insertTest.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HouseNum", tempHost.GetHouseNumber()));
                    insertTest.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Street", tempHost.GetStreet()));
                    insertTest.Parameters.Add(new System.Data.SqlClient.SqlParameter("@City", tempHost.GetCityCounty()));
                    insertTest.Parameters.Add(new System.Data.SqlClient.SqlParameter("@State", tempHost.GetHomeState()));
                    insertTest.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Zip", tempHost.GetZip()));
                    insertTest.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ModfiedDate", now));
                    insertTest.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserType", usertype));
                    insertTest.Connection = sc;

                    insertTest.CommandText = "Insert into [dbo].[RMUser] VALUES (@FirstName," +
                           "@LastName," +
                           "@Email," +
                           "@PhoneNumber," +
                           "@DOB," +
                           "@HouseNum," +
                           "@Street," +
                           "@City," +
                           "@State," +
                           "@Zip," +
                           "@ModfiedDate," +
                           "@UserType);";
                    insertTest.ExecuteNonQuery();

                    System.Data.SqlClient.SqlCommand maxID = new System.Data.SqlClient.SqlCommand();
                    maxID.Connection = sc;

                    maxID.CommandText = "Select MAX(UserID) from [dbo].[RMUser];";

                    int tempID = (Int32)maxID.ExecuteScalar();

                    System.Data.SqlClient.SqlCommand insertPass = new System.Data.SqlClient.SqlCommand();
                    insertPass.Connection = sc;
                    insertPass.CommandText = "Insert into [dbo].[HostPassword] values(@MaxID, @Password, @ModifiedDate, @Email);";
                    insertPass.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MaxID", tempID));
                    insertPass.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Email", tbEmail.Text));
                    insertPass.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Password", PasswordHash.HashPassword(tbPassWord.Text)));
                    insertPass.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ModifiedDate", DateTime.Now));
                    insertPass.ExecuteNonQuery();

                    Response.Redirect("~/Signin.aspx");


                }

                else if (validated == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('please enter a valid first name');", true);

                }
                else if (validated == 2)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('please enter a valid last name');", true);


                }
                else if (validated == 3)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('please enter a valid phone number');", true);


                }
                else if (validated == 4)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Sorry, your age does not meet the requirements');", true);

                }
            }
        }



        

        
    }
    protected void btnSingupTenant_Click(object sender, EventArgs e)
    {


        //Validation
        int validated = validateInformation(tbTenantFirstName.Text, tbTenantLastName.Text, tbTenantPhoneNumber.Text, tbTenantDOB.Text);



        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = @"Data Source=aay09edjn65sf6.cpcbbo8ggvx6.us-east-1.rds.amazonaws.com;Initial Catalog=RoomMagnet;Persist Security Info=True;User ID=fahrenheit;Password=cis484fall";
        sc.Open();

        using (SqlConnection con = new SqlConnection("Data Source=aay09edjn65sf6.cpcbbo8ggvx6.us-east-1.rds.amazonaws.com;Initial Catalog=RoomMagnet;Persist Security Info=True;User ID=fahrenheit;Password=cis484fall"))
        {
            con.Open();

            bool exists = false;

            // create a command to check if the username exists
            using (SqlCommand cmd = new SqlCommand("select count(*) from [dbo].[RMUser] where Email = @Email", con))
            {
                cmd.Parameters.AddWithValue("Email", tbTenantEmailAddress.Text);
                exists = (int)cmd.ExecuteScalar() > 0;
            }
            if (exists)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('This email is already exist!');", true);

            }

            else
            {
                if (validated == 0)
                {
                    string userType = "t";

                    Tenant tempTenant = new Tenant();

                    //splitting up address
                    string address = HttpUtility.HtmlEncode(tbTenantAddress.Text);
                    string[] addressArray = new string[2];
                    int count = 2;
                    string[] seperator = { " " };
                    string[] strList = address.Split(seperator, count, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < 2; i++)
                    {
                        addressArray[i] = strList[i];

                    }
                    DateTime now = DateTime.Now;

                    string tempDate = HttpUtility.HtmlEncode(tbTenantDOB.Text);
                    DateTime DOB = Convert.ToDateTime(tempDate);
                    tempTenant.SetFirstName(HttpUtility.HtmlEncode(tbTenantFirstName.Text));
                    tempTenant.SetLastName(HttpUtility.HtmlEncode(tbTenantLastName.Text));
                    tempTenant.SetDateOfBirth(DOB);
                    tempTenant.SetHouseNumber(HttpUtility.HtmlEncode(addressArray[0]));
                    tempTenant.SetStreet(HttpUtility.HtmlEncode(addressArray[1]));
                    tempTenant.SetCityCounty(HttpUtility.HtmlEncode(tbTenantCity.Text));
                    tempTenant.SetHomeState(ddTenantStates.SelectedValue);
                    tempTenant.SetZip(HttpUtility.HtmlEncode(tbTenantZip.Text));
                    tempTenant.setPhoneNumber(HttpUtility.HtmlEncode(tbTenantPhoneNumber.Text));
                    tempTenant.SetEmailAddress(HttpUtility.HtmlEncode(tbTenantEmailAddress.Text));

                    // Insert into database 
                    System.Data.SqlClient.SqlCommand insertTest = new System.Data.SqlClient.SqlCommand();
                    insertTest.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FirstName", tempTenant.GetFirstName()));
                    insertTest.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LastName", tempTenant.GetLastName()));
                    insertTest.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Email", tempTenant.GetEmailAddress()));
                    insertTest.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PhoneNumber", tempTenant.getPhoneNumber()));
                    insertTest.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DOB", tempTenant.GetDateOfBirth()));
                    insertTest.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HouseNum", tempTenant.GetHouseNumber()));
                    insertTest.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Street", tempTenant.GetStreet()));
                    insertTest.Parameters.Add(new System.Data.SqlClient.SqlParameter("@City", tempTenant.GetCityCounty()));
                    insertTest.Parameters.Add(new System.Data.SqlClient.SqlParameter("@State", tempTenant.GetHomeState()));
                    insertTest.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Zip", tempTenant.GetZip()));
                    insertTest.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ModfiedDate", now));
                    insertTest.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserType", userType));
                    insertTest.Connection = sc;

                    insertTest.CommandText = "Insert into [dbo].[RMUser] VALUES (@FirstName," +
                            "@LastName," +
                            "@Email," +
                            "@PhoneNumber," +
                            "@DOB," +
                            "@HouseNum," +
                            "@Street," +
                            "@City," +
                            "@State," +
                            "@Zip," +
                            "@ModfiedDate," +
                            "@UserType);";
                    insertTest.ExecuteNonQuery();
                    System.Data.SqlClient.SqlCommand maxID = new System.Data.SqlClient.SqlCommand();
                    maxID.Connection = sc;

                    maxID.CommandText = "Select MAX(UserID) from [dbo].[RMUser];";

                    int tempID = (Int32)maxID.ExecuteScalar();


                    System.Data.SqlClient.SqlCommand insertPass = new System.Data.SqlClient.SqlCommand();
                    insertPass.Connection = sc;
                    insertPass.CommandText = "Insert into [dbo].[TenantPassword] values(@MaxID, @Password, @ModifiedDate, @Email);";
                    insertPass.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MaxID", tempID));
                    insertPass.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Email", tbTenantEmailAddress.Text));
                    insertPass.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Password", PasswordHash.HashPassword(tbTenantPassword.Text)));
                    insertPass.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ModifiedDate", DateTime.Now));
                    insertPass.ExecuteNonQuery();

                    Response.Redirect("~/Signin.aspx");
                }

                else if (validated == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('please enter a valid first name');", true);

                }
                else if (validated == 2)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('please enter a valid last name');", true);


                }
                else if (validated == 3)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('please enter a valid phone number');", true);


                }
                else if (validated == 4)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Sorry, your age does not meet the requirements');", true);

                }
            }

            

        }
    }

    
    public int validateInformation(string firstName, string lastName, string phoneNumber, string birthday)
    {
        int error = 0;
        if (firstName.Any(char.IsWhiteSpace))
        {
            
            error = 1;

        }
        if (lastName.Any(char.IsWhiteSpace))
        {
            error = 2;

        }
        if (phoneNumber.Length != 10)
        {
            error = 3;

        }
        var today = DateTime.Today;
        DateTime bir = DateTime.ParseExact(birthday, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

        var age = today.Year - bir.Year;

        if (bir.Month > today.Month)
        {
            age--;
        }

        else if (bir.Day > today.Day)
        {
            age--;
        }
        if (age >= 130 || age < 18)
        {
            error = 4;

        }


        return error;
    }
    }