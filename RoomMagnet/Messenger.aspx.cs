using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Massenger : System.Web.UI.Page
{

    int userID = 229;
    char usertype = 't';

    int firstID = 0;
    int secondID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["USERNAME"] == null)
        {
            Response.Redirect("index.aspx");
        }




        userID = Convert.ToInt32(Session["USERID"].ToString());
        string temp = Session["USERTYPE"].ToString();

        usertype = char.Parse(temp);



        if (!IsPostBack)
        {
            Session["contactselect"] = null;

        }
        if (usertype == 'h')
        {
            secondID = userID;
            if (Request.QueryString["id"] != null)
            {
                firstID = Convert.ToInt32(Request.QueryString["id"].ToString());
            }
            headimgsrc.Visible = false;
            headimgsrc1.Visible = true;
        }
        else
        {
            firstID = userID;
            if (Request.QueryString["id"] != null)
            {
                secondID = Convert.ToInt32(Request.QueryString["id"].ToString());
            }
            headimgsrc.Visible = true;
            headimgsrc1.Visible = false;
        }

        if (Request.QueryString["id"] != null)
        {
            showMessages(firstID, secondID);
            loadcontacts1(userID, usertype);

        }
        else
        {

            if (loadcontacts1(userID, usertype))
            {
                showMessages(firstID, secondID);
            }
        }


    }
    protected bool loadcontacts1(int userid, char usertype)
    {
        string selectcontacts = "";
        string requestcontacts = "";
        if (usertype == 't')
        {
            selectcontacts = "TenantID";
            requestcontacts = "HostID";
        }
        else if (usertype == 'h')
        {
            selectcontacts = "HostID";
            requestcontacts = "TenantID";
        }

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RoomMagnet"].ConnectionString))
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * FROM RMUser WHERE UserID IN (select " + requestcontacts + " from MessagesRoutes where " + selectcontacts + "=@myID)", con);

            cmd.Parameters.AddWithValue("@myID", userid);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                if (usertype == 'h')
                {
                    firstID = Convert.ToInt32(dt.Rows[0]["UserID"]);

                    if (Session["contactselect"] != null)
                    {

                        firstID = Convert.ToInt32(Session["contactselect"]);
                    }

                    showHeader(firstID);
                }
                else
                {
                    secondID = Convert.ToInt32(dt.Rows[0]["UserID"]);

                    if (Session["contactselect"] != null)
                    {

                        secondID = Convert.ToInt32(Session["contactselect"]);
                    }

                    showHeader(secondID);
                }


                rptContacts.DataSource = dt;
                rptContacts.DataBind();
                //   string SearchQuery = "SELECT * FROM RMUser WHERE UserID IN (SELECT AccomodationID FROM TenantFavorites WHERE TenantID = @TenantID)"
                return true;

            }
            else
            {
                return false;
            }




        }


    }

    protected void showHeader(int headerid)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RoomMagnet"].ConnectionString))
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select FirstName,LastName from RMUser where UserID=@headerid", con);
            cmd.Parameters.AddWithValue("@headerid", headerid);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {

                msg_header.InnerText = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
            }

        }

    }
    protected void showMessages(int tenantID, int hostID)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RoomMagnet"].ConnectionString))
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select MsgID from MessagesRoutes where TenantID=@TenantID and HostID=@HostID", con);
            cmd.Parameters.AddWithValue("@TenantID", tenantID);
            cmd.Parameters.AddWithValue("@HostID", hostID);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            sda.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                try
                {
                    SqlCommand cmd1 = new SqlCommand("insert into MessagesRoutes values(@TenantID,@HostID)", con);
                    cmd1.Parameters.AddWithValue("@TenantID", tenantID);
                    cmd1.Parameters.AddWithValue("@HostID", hostID);
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd3 = new SqlCommand("select MsgID from MessagesRoutes where TenantID=@TenantID and HostID=@HostID", con);
                    cmd3.Parameters.AddWithValue("@TenantID", tenantID);
                    cmd3.Parameters.AddWithValue("@HostID", hostID);

                    SqlDataAdapter sda3 = new SqlDataAdapter(cmd3);



                    sda3.Fill(dt);


                }
                catch (Exception ex)
                {


                }
            }

            int msgID = Convert.ToInt32(dt.Rows[0]["MsgID"]);
            try
            {
                SqlCommand cmd2 = new SqlCommand("select * from Messages where MsgID =@MsgID ORDER BY time", con);
                cmd2.Parameters.AddWithValue("@MsgID", msgID);

                DataTable dt2 = new DataTable();
                SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
                sda2.Fill(dt2);

                rptMsgBody.DataSource = dt2;
                rptMsgBody.DataBind();

            }
            catch (Exception ex)
            {


            }



        }

    }

    protected void loadcontacts(int userid, char usertype)
    {
        string selectcontacts = "";
        string requestcontacts = "";
        if (usertype == 't')
        {
            selectcontacts = "TenantID";
            requestcontacts = "HostID";
        }
        else if (usertype == 'h')
        {
            selectcontacts = "HostID";
            requestcontacts = "TenantID";
        }

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RoomMagnet"].ConnectionString))
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select " + requestcontacts + " from MessagesRoutes where " + selectcontacts + "=@myID", con);

            cmd.Parameters.AddWithValue("@myID", userid);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                showMessages(userid, Convert.ToInt32(dt.Rows[0]["HostID"]));
            }


            //    try
            //    {
            //        SqlCommand cmd1 = new SqlCommand("insert into MessagesRoutes values(@TenantID,@HostID)", con);
            //        cmd1.Parameters.AddWithValue("@TenantID", tenantID);
            //        cmd1.Parameters.AddWithValue("@HostID", hostID);
            //        cmd1.ExecuteNonQuery();

            //        SqlCommand cmd3 = new SqlCommand("select MsgID from MessagesRoutes where TenantID=@TenantID and HostID=@HostID", con);
            //        cmd3.Parameters.AddWithValue("@TenantID", tenantID);
            //        cmd3.Parameters.AddWithValue("@HostID", hostID);

            //        SqlDataAdapter sda3 = new SqlDataAdapter(cmd3);



            //        sda3.Fill(dt);


            //    }
            //    catch (Exception ex)
            //    {


            //    }
            //}

            //int msgID = Convert.ToInt32(dt.Rows[0]["MsgID"]);
            //try
            //{
            //    SqlCommand cmd2 = new SqlCommand("select * from Messages where MsgID =@MsgID;", con);
            //    cmd2.Parameters.AddWithValue("@MsgID", msgID);

            //    DataTable dt2 = new DataTable();
            //    SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
            //    sda2.Fill(dt2);

            //    rptMsgBody.DataSource = dt2;
            //    rptMsgBody.DataBind();

            //}
            //catch (Exception ex)
            //{


            //}



        }


    }



    protected void MsgSender(int tenantID, int hostID, char usertype, string msg)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RoomMagnet"].ConnectionString))
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select MsgID from MessagesRoutes where TenantID=@TenantID and HostID=@HostID", con);
            cmd.Parameters.AddWithValue("@TenantID", tenantID);
            cmd.Parameters.AddWithValue("@HostID", hostID);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            sda.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                try
                {
                    SqlCommand cmd1 = new SqlCommand("insert into MessagesRoutes values(@TenantID,@HostID)", con);
                    cmd1.Parameters.AddWithValue("@TenantID", tenantID);
                    cmd1.Parameters.AddWithValue("@HostID", hostID);
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd3 = new SqlCommand("select MsgID from MessagesRoutes where TenantID=@TenantID and HostID=@HostID", con);
                    cmd3.Parameters.AddWithValue("@TenantID", tenantID);
                    cmd3.Parameters.AddWithValue("@HostID", hostID);

                    SqlDataAdapter sda3 = new SqlDataAdapter(cmd3);



                    sda3.Fill(dt);


                }
                catch (Exception ex)
                {


                }
            }

            int msgID = Convert.ToInt32(dt.Rows[0]["MsgID"]);
            try
            {
                SqlCommand cmd2 = new SqlCommand("insert into Messages values(@MsgID,@MsgSender,@Message,@time)", con);
                cmd2.Parameters.AddWithValue("@MsgID", msgID);
                cmd2.Parameters.AddWithValue("@MsgSender", usertype);
                cmd2.Parameters.AddWithValue("@Message", msg);
                cmd2.Parameters.AddWithValue("@time", DateTime.Now);
                cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {


            }



        }
    }

    protected void btnSendMsgClick(object sender, EventArgs e)
    {
        if (IsPostBack && WriteMsgArea.InnerText != "" && firstID != 0 && secondID != 0)
        {
            MsgSender(firstID, secondID, usertype, WriteMsgArea.InnerText);
            WriteMsgArea.InnerText = "";
            showMessages(firstID, secondID);
        }

    }


    protected void contactsleft_ServerClick(object sender, EventArgs e)
    {
        HtmlAnchor bttn = (HtmlAnchor)sender;

        Session["contactselect"] = bttn.Name;

        if (usertype == 'h')
        {
            secondID = userID;
        }
        else
        {
            firstID = userID;
        }
        bttn.Attributes.Add("class", "active");
        loadcontacts1(userID, usertype);
        showMessages(firstID, secondID);

    }
}