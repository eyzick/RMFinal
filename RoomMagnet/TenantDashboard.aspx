<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TenantDashboard.aspx.cs" Inherits="TenantDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style>
        .sub-banner {
            height: 130px;
        }

        .project-tab {
            padding: 10%;
            margin-top: -8%;
        }

            .project-tab #tabs {
                background: #007b5e;
                color: #eee;
            }

                .project-tab #tabs h6.section-title {
                    color: #eee;
                }

                .project-tab #tabs .nav-tabs .nav-item.show .nav-link, .nav-tabs .nav-link.active {
                    color: #0062cc;
                    background-color: transparent;
                    border-color: transparent transparent #f3f3f3;
                    border-bottom: 3px solid !important;
                    font-size: 16px;
                    font-weight: bold;
                }

            .project-tab .nav-link {
                border: 1px solid transparent;
                border-top-left-radius: .25rem;
                border-top-right-radius: .25rem;
                color: #d8dce0;
                font-size: 16px;
                font-weight: 600;
            }

                .project-tab .nav-link:hover {
                    border: none;
                }

            .project-tab thead {
                background: #f3f3f3;
                color: #333;
            }

            .project-tab a {
                text-decoration: none;
                color: #333;
                font-weight: 600;
            }

        .tabbing-box .nav-tabs .nav-item.show .nav-link, .nav-tabs .nav-link:hover {
            background-color: #17a2b8;
        }
           .propertybox {
        width: 80%;
        padding-top: 0px;
        padding-left: 0px;
        padding-right: 0px;
        box-shadow: 2px 2px 2px 2px grey;
        margin: 12px;
        margin-bottom: 12px;
        text-align: justify;
        border-radius: 5px;
    }

        .propertybox .btn {
            width: 110px;
            font-size: 12px;
            text-align: center;
            background-color: palevioletred;
            border-radius: 7px;
            
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="sub-banner overview-bgi">
        <div class="container">

            <div class="headingg">
                <h1>Tenant Panel</h1>
            </div>

        </div>
    </div>


    <section id="tabs" class="project-tab">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <nav>
                        <div class="nav nav-tabs nav-fill" id="nav-tab" role="tablist">

                            <a class="nav-item nav-link active" id="nav-home-tab" data-toggle="tab" href="#nav-home" role="tab" aria-controls="nav-home" aria-selected="true">
                                Profile</a>
                            <a class="nav-item nav-link " id="nav-profile-tab" data-toggle="tab" href="#nav-profile" role="tab" aria-controls="nav-profile" aria-selected="false">
                                My Favorities</a>
                            <a class="nav-item nav-link " id="nav-changepassword-tab" data-toggle="tab" href="#nav-changepassword" role="tab" aria-controls="nav-changepassword" aria-selected="false">
                                Change Password</a>
                        
                        </div>
                    </nav>
                    <br>
                    <div class="tab-content" id="nav-tabContent">

                        <div class="tab-pane fade show active" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab">

                           <div class="col-md-2">
                            </div>
                            <div class="col-md-8">
                              
           <label>
           <input type="checkbox" id="myCheck" onclick="myFunction()">Update
          </label>

                
  
                           <div class="hostProfile">
                             <div class="form-row">
                            <div class="col">
                                <div class="form-group">
                                    <label for="ContentPlaceHolder1_tbFirstName">First Name</label>
                                    <asp:TextBox ID="tbName" runat="server" Class="form-control" placeholder="Name" ReadOnly="True"></asp:TextBox>
                                </div>
                                </div>
                                 <div class="col">
                                  <div class="form-group">
                                    <label for="ContentPlaceHolder1_tbLastName">Last Name</label>
                                    <asp:TextBox ID="tbName1" runat="server" Class="form-control" placeholder="Last Name" ReadOnly="True"></asp:TextBox>
                                </div>
                                     </div>
                              </div>
                                <div class="form-group">
                                    <label for="ContentPlaceHolder1_tbUname">Email</label>

                                    <asp:TextBox ID="tbUname" runat="server" Class="form-control" placeholder="Email" ReadOnly="True"></asp:TextBox>

                                </div>
                        
                         <div class="form-row">                    

                               <div class="col">
                                <div class="form-group">
                                    <label for="ContentPlaceHolder1_tbPhone">Phone Number</label>
                                    <asp:TextBox ID="tbPhone" runat="server" Class="form-control" aria-describedby="phoneHelp" placeholder="Phone Number" TextMode="SingleLine" MaxLength="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="tbPhone" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="tenantUpdate">Please enter your phone number</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="tbPhone" ForeColor="Red" ValidationGroup="tenantUpdate" ValidationExpression="^([0-9]){10,}$" Text="Please enter valid phone number" Display="Dynamic"></asp:RegularExpressionValidator>

            
                                </div>
                                </div>

                            </div>

                               <div class="form-group">
                                   <label for="inputAddress">House Number</label>
                                   <asp:TextBox ID="tbHouseNumber" runat="server" Class="form-control" aria-describedby="phoneHelp" placeholder="House Number" MaxLength="10"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ControlToValidate="tbHouseNumber" ValidationGroup="tenantUpdate" Text="Please enter your house number" Display="Dynamic"></asp:RequiredFieldValidator>
                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="^[0-9]*$" ControlToValidate="tbHouseNumber" ValidationGroup="tenantUpdate" Text="Invalid house number" Display="Dynamic"></asp:RegularExpressionValidator>
                               </div>
                               <div class="form-group">
                                   <label for="inputAddress2">Street</label>
                                   <asp:TextBox ID="tbAddress" runat="server" Class="form-control" aria-describedby="phoneHelp" placeholder="Street"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ControlToValidate="tbAddress" ValidationGroup="tenantUpdate" Text="Please enter your street address" Display="Dynamic"></asp:RequiredFieldValidator>

                               </div>
                          <div class="form-row">
                              <div class="form-group col-md-6">
                                  <label for="inputCity">City</label>
                                  <asp:TextBox ID="tbCity" runat="server" Class="form-control" aria-describedby="phoneHelp" placeholder="City"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbCity" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="tenantUpdate">Please enter your city name</asp:RequiredFieldValidator>
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="tbCity" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$" ValidationGroup="tenantUpdate">Invalid city name</asp:RegularExpressionValidator>
                              </div>
                              <div class="form-group col-md-3">
                                  <label for="inputState">State</label>


                                  <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" Style="height: auto">

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
                                  <asp:TextBox ID="tbZip" runat="server" Class="form-control" aria-describedby="phoneHelp" placeholder="Zip" MaxLength="5"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tbZip" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="tenantUpdate">Please enter your Zip code</asp:RequiredFieldValidator>
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="tbZip" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="\d{5}(-\d{4})?" ValidationGroup="tenantUpdate">Invalid ZIP</asp:RegularExpressionValidator>
                              </div>
  </div>
                        
                         
                               <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass ="btn btn-primary" OnClick="btnUpdate_Click" ValidationGroup="tenantUpdate" />
                               <asp:Button ID="btnPopulate" runat="server" Text="Populate" CssClass ="btn btn-primary" OnClick="btnPopulate_Click" />

                               </div>
                                </div>
                        </div>

                        <div class="tab-pane fade" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">
                           <h2>Properties</h2>

                            <asp:Repeater ID="Repeater1" runat="server">

                                <ItemTemplate>
                                    <div class="container propertybox">

                                        <div class="thumbnail">

                                               
                                            <div class="row">
                                                <div class="col-5">
                                                       <img src='<%#    "data:Image.jpg;base64," + Convert.ToBase64String( (byte[])Eval("image")  ) %>' alt="" style="width:90%" />
                                                </div>

                                         <div class="col-4">
                                              <div class="caption" style="padding: 15px;">
                                                  
                                                        <h5><%# String.Concat(Eval("HouseNumber"), " ", Eval("Street"))%></h5>
                                                        <h5><%# String.Concat(Eval("City"), ", ", Eval("State"), " ", Eval("Zip")) %></h5>
                                                        <h5><strong><%#Eval("Price", "{0:C}").ToString() %> per month</strong></h5>
                                             
                                                   </div>
                                             </div>
                                                 

                                                    <div class="col-md-3 btnsetting" style="padding-top: 10px">
                                                      
                                                        <p>
                                                            <a href="propertydescription.aspx?id=<%# Eval("AccomodationID")%>" class="glyphicon glyphicon-list-alt">View </a></p>
                                                        <p>
                                                       
                                                          <p>
                                                              <asp:LinkButton ID="LinkButton1" CommandName='<%# Eval("AccomodationID")%>' CssClass="glyphicon glyphicon-remove" OnClick="btnPropertyDelete_Click" runat="server">Delete</asp:LinkButton>
                                                             
                                                            
                                                        <p>
                                                          
                                                        </p>
                                                    </div>
                                             
                                               
                                           
                                            
                                             
                                           
                                                </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>

                        </div>
                         <div class="tab-pane fade" id="nav-changepassword" role="tabpanel" aria-labelledby="nav-fav-tab">
                             Use the form below to change the password for your RoomMagnet account
                              <div class="col-md-2">
                            </div>
                            <div class="col-md-8">
                                <div class="tenantchangepassword">



                                    <div class="form-group">
                                        <label for="inputCurrentPassword">Current Password</label>

                                        <asp:TextBox ID="tenantCurrentPassword" CssClass="form-control" runat="server" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="tenantCurrentPassword" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ValidationGroup="changePassword" ForeColor="Red">Please enter your current password</asp:RequiredFieldValidator>
                                        <br/>
                                     <label for="inputNewPassword">New Password</label>
                                     <asp:TextBox ID="tenantNewpassword" CssClass="form-control" runat="server" ></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="tenantNewpassword" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ValidationGroup="changePassword" ForeColor="Red">Please enter your new password</asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="tenantNewpassword" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="^(?=(.*[a-z]){1,})(?=(.*[\d]){1,})(?=(.*[\W]){1,})(?!.*\s).{8,30}$" ValidationGroup="changePassword">Passwords must be at least 8 characters, and least contains 1 lower case, 1 upper case, 1 numeric, 1 non-word and no whitespace</asp:RegularExpressionValidator>

                                        <br/>
                                        <label for="inputReenterPassword">Reenter new password</label>
                                     <asp:TextBox ID="tenantReenterPassword" CssClass="form-control" runat="server" ></asp:TextBox>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tenantNewpassword" ControlToValidate="tenantReenterPassword" Display="Dynamic" ErrorMessage="CompareValidator" ForeColor="Red" ValidationGroup="changePassword">Passwords must match</asp:CompareValidator>
                                        <br/>
                                     <asp:Button ID="changepassword" OnClick="btnChangePassword_Click" class="btn btn-primary" runat="server" ValidationGroup="changePassword" Text="Save Changes"></asp:Button>


                             </div>


                    </div>
                                </div>

                </div>

                        

                    </div>

                </div>
            </div>
        </div>
    </section>
   <script>

    

       function myFunction() {
  // Get the checkbox
  var checkBox = document.getElementById("myCheck");
  // Get the output text
  var text = document.getElementById("text");

  // If the checkbox is checked, display the output text
           if (checkBox.checked == true)
           {
               $(".hostProfile :input").attr("disabled", false);
           }
           else
           {
                $(".hostProfile :input").attr("disabled", true);
           }
       }

         document.getElementById("myCheck").checked = true;

</script>

</asp:Content>
