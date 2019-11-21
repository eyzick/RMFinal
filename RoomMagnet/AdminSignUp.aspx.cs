using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminSignUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSingupAdmin_Click(object sender, EventArgs e)
    {
        int validated = validateInformation(tbFirstName.Text, tbLastName.Text, tbPhoneNumber.Text, tbDOB.Text, AdminCode.Text);

        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = @"Data Source=aam1nhqjz9qqwh.cpcbbo8ggvx6.us-east-1.rds.amazonaws.com,1433;Initial Catalog=RoomMagnet;Persist Security Info=True;User ID=fahrenheit;Password=cis484fall";
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
                    string usertype = "a";

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
                    insertPass.CommandText = "Insert into [db_owner].[AdminPassword] values(@MaxID, @Password, @ModifiedDate, @Email);";
                    insertPass.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MaxID", tempID));
                    insertPass.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Email", tbEmail.Text));
                    insertPass.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Password", PasswordHash.HashPassword(tbPassWord.Text)));
                    insertPass.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ModifiedDate", DateTime.Now));
                    insertPass.ExecuteNonQuery();

                    string adminCode = HttpUtility.HtmlEncode(AdminCode.Text);
                    Boolean adminTrue = false;
                    System.Data.SqlClient.SqlCommand match = new System.Data.SqlClient.SqlCommand();
                    match.Connection = sc;
                    match.CommandText = "select AccessCode from [db_owner].[AdminCode] where AccessCode = @AdminCode";
                    match.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AdminCode", adminCode));
                    System.Data.SqlClient.SqlDataReader reader = match.ExecuteReader(); // create a reader
                    if (reader.HasRows)
                    {
                        while (reader.Read()) // this will read the single recoed that matches the entered usename
                        {

                            string adminTest = reader["AccessCode"].ToString();
                            adminTrue = codeConfirm(adminTest, adminCode);

                        }
                    }
                    sc.Close();
                    if (adminTrue == false)
                    {
                        //lblDebug.Text = "Invalid Access Code";
                    }
                    else
                    {
                        Response.Redirect("~/Signin.aspx");
                    }
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
                else if (validated == 5)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('please enter a valid administration code');", true);
                }
            }
        }
    }

    public int validateInformation(string firstName, string lastName, string phoneNumber, string birthday, string code)
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

        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = @"Data Source=aay09edjn65sf6.cpcbbo8ggvx6.us-east-1.rds.amazonaws.com;Initial Catalog=RoomMagnet;Persist Security Info=True;User ID=fahrenheit;Password=cis484fall";
        sc.Open();
        System.Data.SqlClient.SqlCommand match = new System.Data.SqlClient.SqlCommand();
        match.Connection = sc;

        match.CommandText = "select * from [db_owner].[AdminCode]";
        string thing = match.ExecuteScalar().ToString();

        if (code != thing)
        {
            error = 5;
        }


        return error;
    }

    Boolean codeConfirm(string one, string two)
    {
        Boolean bo;

        int compareString = string.Compare(one, two);

        if (compareString != 0)
        {
            bo = false;
        }
        else
        {
            bo = true;
        }

        return bo;
    }
}