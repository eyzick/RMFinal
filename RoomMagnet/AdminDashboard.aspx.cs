using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminDashboard : System.Web.UI.Page
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
            BindBrandsRptr();
            BindBrandsRptr2();
            backgroundStatus();
        }
    }

    private void BindBrandsRptr()
    {
        String CS = ConfigurationManager.ConnectionStrings["RoomMagnet"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("select dbo.Tenant.TenantID, dbo.RMUser.FirstName, dbo.RMUser.LastName, dbo.Tenant.BackgroundCheckStatus " +
                "from dbo.RMUser inner join dbo.Tenant on dbo.RMUser.UserID = dbo.Tenant.TenantID", con))
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

    private void BindBrandsRptr2()
    {
        String CS = ConfigurationManager.ConnectionStrings["RoomMagnet"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("select dbo.Host.HostID, dbo.RMUser.FirstName, dbo.RMUser.LastName, dbo.Host.BackgroundCheckStatus " +
                "from dbo.RMUser inner join dbo.Host on dbo.RMUser.UserID = dbo.Host.HostID", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dtBrands = new DataTable();
                    sda.Fill(dtBrands);
                    rptrHost.DataSource = dtBrands;
                    rptrHost.DataBind();
                }
            }
        }
    }

    protected void BtnStatusChange_Click(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlCommand update = new System.Data.SqlClient.SqlCommand();
        update.Connection = dbConnection;

        foreach (RepeaterItem item in rptrTenant.Items)
        {
            DropDownList dropDown = (DropDownList)item.FindControl("ddlStatus");
            int status = Int32.Parse(dropDown.SelectedValue);

            if (status == 1)
            {
                var test = ((Label)item.FindControl("lbltenantid")).Text;
                int number = int.Parse(test);

                update.CommandText = "update tenant set backgroundcheckstatus=1 where tenantid = " + number;
                update.ExecuteNonQuery();

                Label lblstat = (Label)item.FindControl("lblstatus");
                lblstat.Text = "Approved";
            }
            else if (status == 0)
            {
                var test = ((Label)item.FindControl("lbltenantid")).Text;
                int number = int.Parse(test);

                update.CommandText = "update tenant set backgroundcheckstatus=0 where tenantid = " + number;
                update.ExecuteNonQuery();

                Label lblstat = (Label)item.FindControl("lblstatus");
                lblstat.Text = "Pending";
            }
            else if (status == 2)
            {
                var test = ((Label)item.FindControl("lbltenantid")).Text;
                int number = int.Parse(test);
                update.CommandText = "update tenant set backgroundcheckstatus=2 where tenantid = " + number;
                update.ExecuteNonQuery();
                update.CommandText = "update tenantPassword set email = UserDisabled";
                update.ExecuteNonQuery();

                Label lblstat = (Label)item.FindControl("lblstatus");
                lblstat.Text = "Account Disabled";
            }
        }
    }

    protected void backgroundStatus()
    {
        foreach (RepeaterItem item in rptrTenant.Items)
        {
            System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
            insert.Connection = dbConnection;

            var test = ((Label)item.FindControl("lbltenantid")).Text;
            int number = int.Parse(test);

            insert.CommandText = "select usertype from rmuser where userid = " + number;
            string type = insert.ExecuteScalar().ToString();

            if (type == "t")
            {
                insert.CommandText = "select backgroundcheckstatus from tenant where tenantid = " + number;
                bool status = (bool)insert.ExecuteScalar();

                if (status)
                {
                    Label lblstat = (Label)item.FindControl("lblstatus");
                    lblstat.Text = "Approved";

                    DropDownList ddl = (DropDownList)item.FindControl("ddlStatus");
                    ddl.SelectedValue = "1";
                }
                else
                {
                    Label lblstat = (Label)item.FindControl("lblstatus");
                    lblstat.Text = "Pending";

                    DropDownList ddl = (DropDownList)item.FindControl("ddlStatus");
                    ddl.SelectedValue = "0";
                }
            }
        }

        foreach (RepeaterItem item in rptrHost.Items)
        {
            System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
            insert.Connection = dbConnection;

            var test = ((Label)item.FindControl("lblhostid")).Text;
            int number = int.Parse(test);

            insert.CommandText = "select usertype from rmuser where userid = " + number;
            string type = insert.ExecuteScalar().ToString();

            if (type == "h")
            {
                insert.CommandText = "select backgroundcheckstatus from host where hostid = " + number;
                bool status = (bool)insert.ExecuteScalar();

                if (status)
                {
                    Label lblstat = (Label)item.FindControl("lblstatus");
                    lblstat.Text = "Approved";

                    DropDownList ddl = (DropDownList)item.FindControl("ddlStatus");
                    ddl.SelectedValue = "1";
                }
                else
                {
                    Label lblstat = (Label)item.FindControl("lblstatus");
                    lblstat.Text = "Pending";

                    DropDownList ddl = (DropDownList)item.FindControl("ddlStatus");
                    ddl.SelectedValue = "0";
                }
            }
        }
    }

    protected void BtnStatusChange_Click1(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlCommand update = new System.Data.SqlClient.SqlCommand();
        update.Connection = dbConnection;

        foreach (RepeaterItem item in rptrHost.Items)
        {
            DropDownList dropDown = (DropDownList)item.FindControl("ddlStatus");
            int status = Int32.Parse(dropDown.SelectedValue);

            if (status == 1)
            {
                var test = ((Label)item.FindControl("lblhostid")).Text;
                int number = int.Parse(test);

                update.CommandText = "update host set backgroundcheckstatus=1 where hostid = " + number;
                update.ExecuteNonQuery();

                Label lblstat = (Label)item.FindControl("lblstatus");
                lblstat.Text = "Approved";
            }
            else if (status == 0)
            {
                var test = ((Label)item.FindControl("lblhostid")).Text;
                int number = int.Parse(test);

                update.CommandText = "update host set backgroundcheckstatus=0 where hostid = " + number;
                update.ExecuteNonQuery();

                Label lblstat = (Label)item.FindControl("lblstatus");
                lblstat.Text = "Pending";
            }
            else if (status == 2)
            {
                var test = ((Label)item.FindControl("lblhostid")).Text;
                int number = int.Parse(test);
                update.CommandText = "update host set backgroundcheckstatus=2 where hostid = " + number;
                update.ExecuteNonQuery();
                update.CommandText = "update hostPassword set email = 'UserDisabled' where hostid = " + number;
                update.ExecuteNonQuery();

                Label lblstat = (Label)item.FindControl("lblstatus");
                lblstat.Text = "Account Disabled";
            }
        }
    }
}