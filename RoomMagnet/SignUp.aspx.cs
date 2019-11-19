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


    protected void btnSingupTenant_Click(object sender, EventArgs e)
    {
        string userType = "t";
        
            if (tbPassWord.Text == tbPassWord.Text)
            {
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Data Source=aay09edjn65sf6.cpcbbo8ggvx6.us-east-1.rds.amazonaws.com;Initial Catalog=RoomMagnet;Persist Security Info=True;User ID=fahrenheit;Password=cis484fall";
            sc.Open();
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

                tempTenant.SetFirstName(HttpUtility.HtmlEncode(tbTenantFirstName.Text));
                tempTenant.SetLastName(HttpUtility.HtmlEncode(tbTenantLastName.Text));
                DateTime test2 = Convert.ToDateTime(tbTenantDOB.Text);
                tempTenant.SetDateOfBirth(test2);
                tempTenant.SetHouseNumber(HttpUtility.HtmlEncode(addressArray[0]));
                tempTenant.SetStreet(HttpUtility.HtmlEncode(addressArray[1]));
                tempTenant.SetCityCounty(HttpUtility.HtmlEncode(tbTenantCity.Text));
                tempTenant.SetHomeState(ddTenantStates.SelectedValue);
                tempTenant.SetZip(HttpUtility.HtmlEncode(tbTenantZip.Text));
                tempTenant.setPhoneNumber(HttpUtility.HtmlEncode(tbTenantPhoneNumber.Text));
                tempTenant.SetEmailAddress(HttpUtility.HtmlEncode(tbTenantEmailAddress.Text));

                // Insert into database 
                DateTime now = DateTime.Now;
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






                lblMsg.Text = "Registration Successfull";
                    lblMsg.ForeColor = Color.Green;
                    Response.Redirect("~/Signin.aspx");
            }
            
            else
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "Passwords do not match";
            }
      

    }

    protected void btnSingupHouseOwner_Click(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = @"Data Source=aay09edjn65sf6.cpcbbo8ggvx6.us-east-1.rds.amazonaws.com;Initial Catalog=RoomMagnet;Persist Security Info=True;User ID=fahrenheit;Password=cis484fall";
        sc.Open();

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
    }
}