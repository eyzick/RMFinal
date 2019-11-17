﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class SignIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["UNAME"] != null && Request.Cookies["PWD"] != null)
            {
                UserName.Text = Request.Cookies["UNAME"].Value;
             //  Password.Attributes["value"] = Request.Cookies["PWD"].Value;
                CheckBox1.Checked = true;
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Boolean success = false;
        int id = 0;
        String usertype = "";

        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = @"Data Source=aay09edjn65sf6.cpcbbo8ggvx6.us-east-1.rds.amazonaws.com;Initial Catalog=RoomMagnet;Persist Security Info=True;User ID=fahrenheit;Password=cis484fall";
        sc.Open();
        System.Data.SqlClient.SqlCommand match = new System.Data.SqlClient.SqlCommand();
        match.Connection = sc;

        match.CommandText = "select passwordhash from[db_owner].[AdminPassword] where Email = @Email " +
            "union select passwordhash from[dbo].[HostPassword] where Email = @Email " +
            "union select passwordhash from[dbo].[TenantPassword] where Email = @Email";

        match.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Email", UserName.Text));
        System.Data.SqlClient.SqlDataReader reader = match.ExecuteReader(); // create a reader

        if (reader.HasRows)
        {
            while (reader.Read()) // this will read the single record that matches the entered usename
            {
                string storedHash = reader["PasswordHash"].ToString(); // store the database password into this varable
                if (PasswordHash.ValidatePassword(Password.Text, storedHash)) // if the entered password matches what is stored, it will show success
                {

                    success = true;
                }

            }
        }
        else
        {// if the username does not exist, it will show failure.

           
        }
        sc.Close();
        if (success == true)
        {
            sc.Open();
            System.Data.SqlClient.SqlCommand matchID = new System.Data.SqlClient.SqlCommand();
            matchID.Connection = sc;
            //matchID.CommandText = "Select AdminID from [db_owner].[AdminPassword] where Email = @Email";
            matchID.CommandText = "select adminid from[db_owner].[AdminPassword] where Email = @Email " +
                "union select hostid from[dbo].[HostPassword] where Email = @Email " +
                "union select tenantid from[dbo].[TenantPassword] where Email = @Email";
            matchID.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Email", UserName.Text));
            id = (Int32)matchID.ExecuteScalar();
            Session["globalID"] = id;


            System.Data.SqlClient.SqlCommand type = new System.Data.SqlClient.SqlCommand();
            type.Connection = sc;

            type.CommandText = "select * from [dbo].[RMUser] where userid = " + id;

          

            SqlDataAdapter sda = new SqlDataAdapter(type);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                Session["USERID"] = dt.Rows[0]["UserID"].ToString();
                Session["USEREMAIL"] = dt.Rows[0]["Email"].ToString();

                if (CheckBox1.Checked)
                {
                    Response.Cookies["UNAME"].Value = UserName.Text;


                    Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(15);

                }
                else
                {
                    Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(-1);

                }
                string Utype;
                Utype = dt.Rows[0]["UserType"].ToString().Trim();

                Session["USERTYPE"] = Utype.ToString();

                if (Utype == "t")
                {
                    Session["USERNAME"] = UserName.Text;
                    Response.Redirect("~/TenantDashboard.aspx");


                }
                if (Utype == "a")
                {
                    Session["USERNAME"] = UserName.Text;
                    Response.Redirect("~/AdminDashBoard.aspx");
                }
                if (Utype == "h")
                {
                    Session["USERNAME"] = UserName.Text;
                    Response.Redirect("~/HostDashBoard.aspx");
                }


            }
            else
            {
                lblError.Text = "Invalid Username or Password !";
            }

        }

















        String CS = ConfigurationManager.ConnectionStrings["RoomMagnet"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[RMUser] where Email='" + UserName.Text + "' or LastName='" + Password.Text + "'", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                Session["USERID"] = dt.Rows[0]["UserID"].ToString();
                Session["USEREMAIL"] = dt.Rows[0]["Email"].ToString();

                if (CheckBox1.Checked)
                {
                    Response.Cookies["UNAME"].Value = UserName.Text;
               

                    Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(15);
                 
                }
                else
                {
                    Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(-1);
                   
                }
                string Utype;
                Utype = dt.Rows[0]["UserType"].ToString().Trim();

                Session["USERTYPE"] = Utype.ToString();

                if (Utype == "t")
                {
                    Session["USERNAME"] = UserName.Text;
                    Response.Redirect("~/TenantDashboard.aspx");
                    

                }
                if (Utype == "a")
                {
                    Session["USERNAME"] = UserName.Text;
                    Response.Redirect("~/AdminDashBoard.aspx");
                }
                if (Utype == "h")
                {
                    Session["USERNAME"] = UserName.Text;
                    Response.Redirect("~/HostDashBoard.aspx");
                }


            }
            else
            {
                lblError.Text = "Invalid Username or Password !";
            }
        }
    }
}