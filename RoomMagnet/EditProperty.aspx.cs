using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditProperty : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            int propertyID = Convert.ToInt32(Request.QueryString["id"].ToString());
          
            String CS = ConfigurationManager.ConnectionStrings["RoomMagnet"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Accomodation where AccomodationID=" + propertyID, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {

                        DataTable properydata = new DataTable();
                        sda.Fill(properydata);

                        if (properydata.Rows.Count == 0)
                        {
                            return;
                        }

                        tbPropertyAddress1.Text = properydata.Rows[0]["HouseNumber"].ToString();
                        tbPropertyAddress2.Text = properydata.Rows[0]["Street"].ToString();
                        tbPropertyCity.Text = properydata.Rows[0]["City"].ToString();
                        tbPropertyZip.Text = properydata.Rows[0]["Zip"].ToString();
                        tbPropertyPrice.Text = properydata.Rows[0]["Price"].ToString();

                        tbPropertyCapacity.Text = properydata.Rows[0]["Capacity"].ToString();
                        tbPropertyDescription.Text = properydata.Rows[0]["Description"].ToString();
                    //    tbPropertyAvailability.Text = properydata.Rows[0]["Availability"].ToString();
                        tbPropertyRoomType.Text = properydata.Rows[0]["RoomType"].ToString();
                        ddState.Text = properydata.Rows[0]["State"].ToString();




                        //     int amenityID =Convert.ToInt32(properydata.Rows[0]["City"]);

                        using (SqlConnection con1 = new SqlConnection(CS))
                        {
                            using (SqlCommand cmd1 = new SqlCommand("select * from Amenity where AccomodationID=" + propertyID, con1))
                            {
                                using (SqlDataAdapter sda1 = new SqlDataAdapter(cmd1))
                                {
                                    DataTable properydata1 = new DataTable();
                                    sda1.Fill(properydata1);

                                    if (properydata1.Rows.Count != 0)
                                    {
                                     
                                        foreach (DataRow row in properydata1.Rows)
                                        {
                                            foreach (ListItem item in this.cblAmenities.Items)
                                            {
                                                if (row["AmenityName"].ToString() == item.Value.ToString())
                                                {
                                                    item.Selected = true;
                                                }
                                              
                                            }
                                          
                                        }


                                      

                                    }

                                }
                            }
                        }

                      



                    }

                }
            }





        }
    }

    protected void btnUpdateProperty_Click(object sender, EventArgs e)
    {

    }
}