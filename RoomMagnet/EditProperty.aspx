<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditProperty.aspx.cs" Inherits="EditProperty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style>
        .sub-banner {
            height: 130px;
        }
         </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

       <div class="sub-banner overview-bgi">
        <div class="container">

            <div class="headingg">
                <h1>Edit Property</h1>
            </div>

        </div>
    </div>
   
    <div class="EditProperty">
         <div class="container" style="margin-top: 30px;margin-bottom: 30px;">
             <div class="row">
                            <div class="col-md-2">
                            </div>
                            <div class="col-md-8">
                                <div class="hostaddproperty">



                                    <div class="form-group">
                                        <label for="inputAddress">Address</label>

                                        <asp:TextBox ID="tbPropertyAddress1" CssClass="form-control" runat="server" placeholder="1234 Main St"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputAddress2">Address 2</label>

                                        <asp:TextBox ID="tbPropertyAddress2" CssClass="form-control" runat="server" placeholder="Apartment, studio, or floor"></asp:TextBox>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-md-6">
                                            <label for="inputCity">City</label>

                                            <asp:TextBox ID="tbPropertyCity" CssClass="form-control" runat="server" placeholder="City"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-md-3">
                                            <label for="inputState">State</label>


                                            <asp:DropDownList ID="ddState" runat="server" CssClass="form-control" Style="height: auto">

                                                <asp:ListItem Value="AL">AL</asp:ListItem>
                                                <asp:ListItem Value="AK">AK</asp:ListItem>
                                                <asp:ListItem Value="AZ">AZ</asp:ListItem>
                                                <asp:ListItem Value="AR">AR</asp:ListItem>
                                                <asp:ListItem Value="CA">CA</asp:ListItem>
                                                <asp:ListItem Value="CO">CO</asp:ListItem>
                                                <asp:ListItem Value="CT">CT</asp:ListItem>
                                                <asp:ListItem Value="DC">DC</asp:ListItem>
                                                <asp:ListItem Value="DE">DE</asp:ListItem>
                                                <asp:ListItem Value="FL">FL</asp:ListItem>
                                                <asp:ListItem Value="GA">GA</asp:ListItem>
                                                <asp:ListItem Value="HI">HI</asp:ListItem>
                                                <asp:ListItem Value="ID">ID</asp:ListItem>
                                                <asp:ListItem Value="IL">IL</asp:ListItem>
                                                <asp:ListItem Value="IN">IN</asp:ListItem>
                                                <asp:ListItem Value="IA">IA</asp:ListItem>
                                                <asp:ListItem Value="KS">KS</asp:ListItem>
                                                <asp:ListItem Value="KY">KY</asp:ListItem>
                                                <asp:ListItem Value="LA">LA</asp:ListItem>
                                                <asp:ListItem Value="ME">ME</asp:ListItem>
                                                <asp:ListItem Value="MD">MD</asp:ListItem>
                                                <asp:ListItem Value="MA">MA</asp:ListItem>
                                                <asp:ListItem Value="MI">MI</asp:ListItem>
                                                <asp:ListItem Value="MN">MN</asp:ListItem>
                                                <asp:ListItem Value="MS">MS</asp:ListItem>
                                                <asp:ListItem Value="MO">MO</asp:ListItem>
                                                <asp:ListItem Value="MT">MT</asp:ListItem>
                                                <asp:ListItem Value="NE">NE</asp:ListItem>
                                                <asp:ListItem Value="NV">NV</asp:ListItem>
                                                <asp:ListItem Value="NH">NH</asp:ListItem>
                                                <asp:ListItem Value="NJ">NJ</asp:ListItem>
                                                <asp:ListItem Value="NM">NM</asp:ListItem>
                                                <asp:ListItem Value="NY">NY</asp:ListItem>
                                                <asp:ListItem Value="NC">NC</asp:ListItem>
                                                <asp:ListItem Value="ND">ND</asp:ListItem>
                                                <asp:ListItem Value="OH">OH</asp:ListItem>
                                                <asp:ListItem Value="OK">OK</asp:ListItem>
                                                <asp:ListItem Value="OR">OR</asp:ListItem>
                                                <asp:ListItem Value="PA">PA</asp:ListItem>
                                                <asp:ListItem Value="RI">RI</asp:ListItem>
                                                <asp:ListItem Value="SC">SC</asp:ListItem>
                                                <asp:ListItem Value="SD">SD</asp:ListItem>
                                                <asp:ListItem Value="TN">TN</asp:ListItem>
                                                <asp:ListItem Value="TX">TX</asp:ListItem>
                                                <asp:ListItem Value="UT">UT</asp:ListItem>
                                                <asp:ListItem Value="VT">VT</asp:ListItem>
                                                <asp:ListItem Value="VA">VA</asp:ListItem>
                                                <asp:ListItem Value="WA">WA</asp:ListItem>
                                                <asp:ListItem Value="WV">WV</asp:ListItem>
                                                <asp:ListItem Value="WI">WI</asp:ListItem>
                                                <asp:ListItem Value="WY">WY</asp:ListItem>

                                            </asp:DropDownList>

                                        </div>
                                        <div class="form-group col-md-3">
                                            <label for="inputZip">Zip</label>
                                            <asp:TextBox ID="tbPropertyZip" CssClass="form-control" runat="server" placeholder="Zip"></asp:TextBox>

                                        </div>
                                    </div>

                                    <div class="form-row">
                                        <div class="col">
                                            <div class="form-group">
                                                <label for="ContentPlaceHolder1_tbCapacity">Capacity</label>
                                                <asp:TextBox ID="tbPropertyCapacity" runat="server" Class="form-control" placeholder="Capacity"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="form-group">
                                                <label for="ContentPlaceHolder1_tbAvailability">Availability</label>
                                                <asp:TextBox ID="tbPropertyAvailability" runat="server" Class="form-control" placeholder="Availablility"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="form-group">
                                                <label for="ContentPlaceHolder1_tbPrice">Price</label>

                                                <asp:TextBox ID="tbPropertyPrice" runat="server" Class="form-control" placeholder="Price"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="form-group">
                                                <label for="ContentPlaceHolder1_tbPrice">Room Type</label>

                                                <asp:TextBox ID="tbPropertyRoomType" runat="server" Class="form-control" placeholder="Room Type"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label for="ContentPlaceHolder1_tbDecription">Decription</label>

                                        <asp:TextBox ID="tbPropertyDescription" runat="server" Class="form-control" placeholder="Decription" Rows="3" TextMode="MultiLine"></asp:TextBox>

                                    </div>
                                    <div class="form-group">
                                        <label for="ContentPlaceHolder1_tbAmenities">Amenities</label>

                                        <label for="tbAmenities"><b>Amenities</b></label>
                                        <asp:CheckBoxList ID="cblAmenities" CssClass="list-group list-group-flush" runat="server">
                                            <asp:ListItem>Wifi</asp:ListItem>
                                            <asp:ListItem>Cable</asp:ListItem>
                                            <asp:ListItem>Air Condition</asp:ListItem>
                                            <asp:ListItem>Heat</asp:ListItem>
                                            <asp:ListItem>Washer</asp:ListItem>
                                            <asp:ListItem>Dryer</asp:ListItem>
                                        </asp:CheckBoxList>

                                    </div>
                                    <div class="form-group">
                                        <label for="ContentPlaceHolder1_tbDecription">Upload a image to replace Older one</label>
                                        <asp:FileUpload runat="server" CssClass="btn btn-default btn-file" Style="display: block" accept=".png,.jpg,.jpeg" ID="firstUploader"></asp:FileUpload>

                                    </div>

                                    <asp:Button ID="btnUpdateProperty" type="submit"  class="btn btn-success" runat="server" Text="Update"></asp:Button>

                                </div>
                            </div>
                        </div>
        </div>
             </div>

</asp:Content>

